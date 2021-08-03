// ***********************************************************************
// Assembly         : BAP.Workflow
// Author           : Victor Mamray
// Created          : 07-15-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-15-2020
// ***********************************************************************
// <copyright file="WorkflowEngine.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using BAP.Common;
using BAP.DAL;
using BAP.BL;
using BAP.Common.Exceptions;
using BAP.DAL.Entities;
using BAP.Log;
using BAP.Lookups;
using BAP.FileSystem;


namespace BAP.Workflow
{
    /// <summary>
    /// Generic workflow engine implementation based on the particular BAP entity type (e.g. Attachment, Blog, etc.)
    /// </summary>
    /// <typeparam name="T">BAP Entity type</typeparam>
    public class WorkflowEngine<T> where T : class, IBapEntity
    {
        #region members
        /// <summary>
        /// The bl
        /// </summary>
        private readonly IWorkflowClassBL _bl;
        /// <summary>
        /// The context
        /// </summary>
        private readonly IAuthorizationContext _context;
        /// <summary>
        /// The configuration helper
        /// </summary>
        private readonly IConfigHelper _configHelper;
        /// <summary>
        /// The lookup engine
        /// </summary>
        private readonly ILookupEngine _lookupEngine;
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// The file processor
        /// </summary>
        private readonly IFileProcessor _fileProcessor;
        #endregion

        //Hiding default constructor
        /// <summary>
        /// Prevents a default instance of the <see cref="WorkflowEngine{T}"/> class from being created.
        /// </summary>
        private WorkflowEngine()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowEngine{T}"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="fileProc">The file proc.</param>
        /// <param name="bl">The bl.</param>
        public WorkflowEngine(IConfigHelper configHelper, IAuthorizationContext context, ILogger logger, ILookupEngine lookupEngine, IFileProcessor fileProc, IWorkflowClassBL bl)
        {
            _configHelper = configHelper;
            _context = context;
            _logger = logger;
            _lookupEngine = lookupEngine;
            _fileProcessor = fileProc;
            _bl = bl;
        }

        #region public methods

        /// <summary>
        /// Gets the available workflow classes.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>List&lt;WorkflowClass&gt;.</returns>
        public List<WorkflowClass> GetAvailableWorkflowClasses(T entity)
        {
            if (entity == null)
                return null;
            var entityType = entity.GetType();
            var selectedWorkflows = new List<WorkflowClass>();
            var workflowClasses = _bl.GetWorkflowClassesByEntity(entityType.Assembly.FullName, entityType.FullName);
            foreach (var wf in workflowClasses)
            {
                if (!string.IsNullOrEmpty(wf.AllowedRoles))
                {
                    var roles = wf.AllowedRoles.Split(",".ToCharArray());
                    var isInRole = false;
                    foreach (var role in roles)
                    {
                        if (_context.IsCurrentUserInRole(role))
                        {
                            isInRole = true;
                            break;
                        }
                    }
                    if (isInRole)
                    {
                        selectedWorkflows.Add(wf);
                    }
                }
                else
                {
                    selectedWorkflows.Add(wf);
                }
            }

            return selectedWorkflows;
        }

        /// <summary>
        /// Gets the workflow.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="metaId">The meta identifier.</param>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <returns>Workflow&lt;T&gt;.</returns>
        public Workflow<T> GetWorkflow(T entity, int? metaId = null, int? attachmentId = null)
        {
            Workflow<T> result = null;
            // Read workflow from DB
            var entityType = entity.GetType();
            var workflowObject = ((IWorkflowObjectBL)_bl).GetWorkflowObjectByEntity(entityType.Assembly.FullName, entityType.FullName, entity.Id);

            // If no such workflow yet created it and run Initial action if any
            if (workflowObject == null)
            {
                var selectedWorkflows = GetAvailableWorkflowClasses(entity);
                if (selectedWorkflows.Count == 1)
                {                    
                    // return from method
                    result = InitWorkflow(selectedWorkflows[0], entity);
                }
            }
            else
            {
                result = DeserializeWorkflow(workflowObject.WorkflowData, entity);

                //Incoming call to add extra attachment to the transition
                if(metaId.HasValue && attachmentId.HasValue)
                {
                    AddAttachmentToTransition(result, metaId.Value, attachmentId.Value);
                }                                               
            }

            // Finally return Workflow to the user
            return result;
        }



        /// <summary>
        /// Initializes the workflow.
        /// </summary>
        /// <param name="wfClass">The wf class.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>Workflow&lt;T&gt;.</returns>
        public Workflow<T> InitWorkflow(WorkflowClass wfClass, T entity)
        {
            // Create workflow instance based on meta data
            var wf = InitWorkflowFromMetaData(wfClass, entity);

            // Process initialization
            WorkflowInit(wf, entity);

            // Serialize Workflow object to DB
            SaveWorkflow(wf);

            // return from method
            return wf;
        }

        /// <summary>
        /// Does the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool DoAction(WorkflowAction<T> action)
        {
            if (action == null)
                return true;

            var result = true;

            // if external executor specified - run it
            if (!string.IsNullOrEmpty(action.ActionAssembly) && !string.IsNullOrEmpty(action.ActionClass) && action.Workflow != null && action.Workflow.Entity != null)
            {
                try
                {
                    var assembly = Assembly.Load(action.ActionAssembly);
                    if (assembly != null)
                    {
                        var type = assembly.GetType(action.ActionClass);
                        if (type != null && typeof(IEntityWorkflowAction<T>).IsAssignableFrom(type))
                        {
                            var constArgs = new object[5];
                            constArgs[0] = _lookupEngine;
                            constArgs[1] = _fileProcessor;
                            constArgs[2] = _configHelper;
                            constArgs[3] = _context;
                            constArgs[4] = _logger;
                            IEntityWorkflowAction<T> classInstance = (IEntityWorkflowAction<T>)Activator.CreateInstance(type, constArgs);
                            var thisResult = classInstance.Execute(action.Workflow.Entity, action.Attributes);
                            result = thisResult.Success;
                        }
                    }
                }
                catch (Exception ex)
                {
                    action.LastCompleteError = ex.Message;
                    result = false;
                }
            }

            // set action state
            action.State = result ? ActionState.Completed : ActionState.Failed;
            action.CompletedAt = DateTime.Now;

            // return action
            return result;
        }

        /// <summary>
        /// Method chooses transition of the workflow. It closes From Stage and opens To Stage.
        /// Opening stage may also mean some actions are required to be done before it closes.
        /// </summary>
        /// <param name="workflow">Workflow instance</param>
        /// <param name="transition">Transition instance</param>
        /// <param name="comment">Coments added as part of transition performed itself</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ChooseTransition(Workflow<T> workflow, StageTransition<T> transition, string comment)
        {
            if (transition == null || transition.FromStage == null || transition.ToStage == null || transition.FromStage.State != StageState.Passed)
                return false;

            bool allActionsDone = transition.ToStage.RequiredActions == null
                || transition.ToStage.RequiredActions.Count == 0
                || !transition.ToStage.RequiredActions.Any(a => a.State == ActionState.Failed || a.State == ActionState.Open);

            if (!allActionsDone)
                return false;

            // transition attributes
            transition.TransitionedAt = DateTime.Now;
            transition.Comments = comment;
            transition.TransitionedByUserName = _context.GetCurrentUserFullName();
            transition.State = TransitionState.Done;

            // to stage process
            if (transition.ToStage.RequiredActions != null && transition.ToStage.RequiredActions.Count > 0)
                transition.ToStage.CompletedAt = transition.ToStage.RequiredActions.Max(a => a.CompletedAt);
            else
                transition.ToStage.CompletedAt = DateTime.Now;
            transition.ToStage.State = StageState.Passed;

            // set available transitions to the workflow, those are available to go from the current opened stage            
            SetCurrentTransitions(workflow, transition.ToStage);

            // if finish stage - complete workflow
            if (transition.ToStage.StageType == StageType.Finish)
            {
                WorkflowComplete(workflow, transition.ToStage);
            }

            return true;
        }

        /// <summary>
        /// Adds the attachment to transition.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="transitionMetaId">The transition meta identifier.</param>
        /// <param name="attachmentId">The attachment identifier.</param>
        public void AddAttachmentToTransition(Workflow<T> workflow, int transitionMetaId, int attachmentId)
        {
            if (workflow == null)
                return;
            var attachments = ((IAttachmentBL)_bl).GetAttachmentsByEntityId(workflow.Entity.GetType().Name, workflow.EntityId).ToList();
            if (attachments == null || !attachments.Any())
                return;

            var att = attachments.FirstOrDefault(a => a.Id == attachmentId);
            var trans = workflow.Transitions.FirstOrDefault(ct => ct.MetaId == transitionMetaId);
            if (trans != null && att != null)
            {
                if (trans.Attachments == null)
                    trans.Attachments = new List<TransitionAttachment>();
                if(!trans.Attachments.Any(a => a.AttachmentId == attachmentId))
                {
                    trans.Attachments.Add(new TransitionAttachment(attachments.FirstOrDefault(a => a.Id == attachmentId)));
                    SaveWorkflow(workflow);
                }                
            }
        }

        /// <summary>
        /// Saves the workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        public void SaveWorkflow(Workflow<T> workflow)
        {
            if (workflow == null)
                return;

            workflow = ProcessWorkflowBeforeSave(workflow);

            var entity = workflow.Entity;
            var entityType = entity.GetType();
            var workflowObject = ((IWorkflowObjectBL)_bl).GetWorkflowObjectByEntity(entityType.Assembly.FullName, entityType.FullName, entity.Id);
            var json = SerializeWorkflow(workflow);

            if (workflowObject == null)
            {
                var wfClass = _bl.GetWorkflowClassById(workflow.MetaId);
                var wfObject = new WorkflowObject()
                {
                    Description = wfClass.Description,
                    Name = wfClass.Name + Guid.NewGuid().ToString(),
                    ShortDescription = wfClass.ShortDescription,
                    Workflow = wfClass,
                    WorkflowData = json,
                    WorkflowId = wfClass.Id,
                    BapEntityAssembly = entityType.Assembly.FullName,
                    BapEntityClass = entityType.FullName,
                    BapEntityId = entity.Id
                };
                ((IWorkflowObjectBL)_bl).AddWorkflowObject(wfObject);
            }
            else
            {
                workflowObject.WorkflowData = json;
                ((IWorkflowObjectBL)_bl).UpdateWorkflowObject(workflowObject);
            }
        }

        /// <summary>
        /// Processes the workflow before save.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <returns>Workflow&lt;T&gt;.</returns>
        private Workflow<T> ProcessWorkflowBeforeSave(Workflow<T> workflow)
        {
            if (workflow == null)
                return workflow;

            //Adjust transitions statuses - if all actions done, transition is ready for a move
            if (workflow.Transitions != null && workflow.Transitions.Any(a => a.State == TransitionState.Available && a.ToStageActions != null))
            {
                foreach (var trans in workflow.Transitions.Where(a => a.State == TransitionState.Available && a.ToStageActions != null))
                {
                    if (!trans.ToStageActions.Any(a => a.State == ActionState.Failed || a.State == ActionState.Open))
                        trans.State = TransitionState.Ready;
                }
            }

            return workflow;
        }

        /// <summary>
        /// Removes the workflow.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="saveDb">if set to <c>true</c> [save database].</param>
        public void RemoveWorkflow(T entity, bool saveDb = true)
        {
            if (entity == null)
                return;

            var entityType = entity.GetType();
            var workflowObject = ((IWorkflowObjectBL)_bl).GetWorkflowObjectByEntity(entityType.Assembly.FullName, entityType.FullName, entity.Id);
            if (workflowObject != null)
            {
                ((IWorkflowObjectBL)_bl).RemoveWorkflowObject(saveDb, workflowObject);
            }
        }

        #endregion

        #region private methods
        /// <summary>
        /// Initializes the action attributes.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="action">The action.</param>
        private void InitActionAttributes(Workflow<T> workflow, WorkflowAction<T> action)
        {
            if (action == null || action.Attributes == null || action.Attributes.Count == 0)
                return;

            foreach (var attr in action.Attributes)
            {
                if (!string.IsNullOrEmpty(attr.DataSource))
                {
                    var parts = attr.DataSource.Split(".".ToCharArray());
                    // reference of another action in the workflow
                    if (parts[0].ToLower() == "action" && parts.Length == 3)
                    {
                        var sourceAction = workflow.Actions.SingleOrDefault(a => a.Name == parts[1]);
                        if (sourceAction != null)
                        {
                            var sourceAttr = sourceAction.Attributes.SingleOrDefault(a => a.Name == parts[2]);
                            if (sourceAttr != null && sourceAttr.AttributeType == attr.AttributeType)
                            {
                                attr.Value = sourceAttr.Value;
                            }
                        }
                    }// this entity property name
                    else if (parts[0].ToLower() == "entity" && parts.Length == 2)
                    {
                        var property = workflow.Entity.GetType().GetProperty(parts[1]);
                        if (property != null)
                        {
                            object val = property.GetValue(workflow.Entity, null);
                            if (val != null)
                                attr.Value = val.ToString();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes the workflow from meta data.
        /// </summary>
        /// <param name="meta">The meta.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>Workflow&lt;T&gt;.</returns>
        private Workflow<T> InitWorkflowFromMetaData(WorkflowClass meta, T entity)
        {
            List<string> roles = null;
            if (!string.IsNullOrEmpty(meta.AllowedRoles))
                roles = meta.AllowedRoles.Split(",".ToCharArray()).ToList();

            // init main object
            var result = new Workflow<T>
            {
                UniqueId = Guid.NewGuid().ToString(),
                MetaId = meta.Id,
                Name = meta.Name,
                ShortDescription = meta.ShortDescription,
                Description = meta.Description,
                RolesAllowed = roles,
                Entity = entity
            };

            // add actions
            result.Actions = new List<WorkflowAction<T>>();
            foreach (var action in meta.Actions)
            {
                var wfAction = new WorkflowAction<T>()
                {
                    UniqueId = Guid.NewGuid().ToString(),
                    MetaId = action.Id,
                    ActionAssembly = action.ActionAssembly,
                    ActionClass = action.ActionClass,
                    ActionType = (ActionType)action.ActionType,
                    Description = action.Description,
                    Name = action.Name,
                    ShortDescription = action.ShortDescription,
                    Workflow = result,
                    State = ActionState.None
                };

                wfAction.Attributes = new List<ActionAttribute<T>>();
                foreach (var attr in action.Attributes)
                {
                    wfAction.Attributes.Add(new ActionAttribute<T>()
                    {
                        UniqueId = Guid.NewGuid().ToString(),
                        MetaId = attr.Id,
                        Action = wfAction,
                        AttributeType = (AttributeType)attr.AtributeType,
                        AttributeDirection = (AttributeDirection)attr.AtributeDirection,
                        DataSource = attr.DataSource,
                        Description = attr.Description,
                        IsPublic = attr.IsPublic,
                        IsReadOnly = attr.IsReadonly,
                        IsVisible = attr.IsVisible,
                        Name = attr.Name,
                        ShortDescription = attr.ShortDescription,
                        Value = attr.DefaultValue
                    });
                }
                result.Actions.Add(wfAction);
            }

            // add stages
            result.Stages = new List<WorkflowStage<T>>();
            foreach (var stage in meta.Stages)
            {
                var wfStage = new WorkflowStage<T>()
                {
                    UniqueId = Guid.NewGuid().ToString(),
                    MetaId = stage.Id,
                    Description = stage.Description,
                    Name = stage.Name,
                    ShortDescription = stage.ShortDescription,
                    StageType = (StageType)stage.StageType,
                    Workflow = result,
                    State = StageState.None
                    // RequiredActions - initialized when we move to this stage - transition driven
                };

                result.Stages.Add(wfStage);
            }

            // add transitions
            result.Transitions = new List<StageTransition<T>>();
            foreach (var trans in meta.Transitions)
            {
                var wfTranstion = new StageTransition<T>()
                {
                    UniqueId = Guid.NewGuid().ToString(),
                    Description = trans.Description,
                    MetaId = trans.Id,
                    FromStage = result.Stages.SingleOrDefault(a => a.MetaId == trans.FromStageId),
                    Name = trans.Name,
                    ShortDescription = trans.ShortDescription,
                    State = TransitionState.None,
                    ToStage = result.Stages.SingleOrDefault(a => a.MetaId == trans.ToStageId),
                    Workflow = result
                };

                wfTranstion.ToStageActions = new List<WorkflowAction<T>>();
                foreach (var act in trans.Actions)
                {
                    wfTranstion.ToStageActions.Add(result.Actions.SingleOrDefault(a => a.MetaId == act.Id));
                }

                result.Transitions.Add(wfTranstion);
            }

            return result;
        }

        /// <summary>
        /// Workflows the initialize.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="entity">The entity.</param>
        /// <exception cref="BAP.Common.Exceptions.BAPWorkflowException"></exception>
        /// <exception cref="BAP.Common.Exceptions.BAPWorkflowException"></exception>
        /// <exception cref="BAP.Common.Exceptions.BAPWorkflowException"></exception>
        /// <exception cref="BAP.Common.Exceptions.BAPWorkflowException"></exception>
        /// <exception cref="BAP.Common.Exceptions.BAPWorkflowException"></exception>
        /// <exception cref="BAP.Common.Exceptions.BAPWorkflowException"></exception>
        private void WorkflowInit(Workflow<T> workflow, T entity)
        {
            if (workflow == null || entity == null)
                return;

            // Data validation
            if (workflow.Stages == null || workflow.Stages.Count == 0)
                throw new BAPWorkflowException(string.Format("Invalid workflow '{0}'. It does not have stages specified", workflow.Name));

            if (!workflow.Stages.Any(a => a.StageType == StageType.Initial))
                throw new BAPWorkflowException(string.Format("Invalid workflow '{0}'. It does not have initial stage specified", workflow.Name));

            if (workflow.Stages.Where(a => a.StageType == StageType.Initial).Count() > 1)
                throw new BAPWorkflowException(string.Format("Invalid workflow '{0}'. It has more than one initial stage specified", workflow.Name));

            if (!workflow.Stages.Any(a => a.StageType == StageType.Finish))
                throw new BAPWorkflowException(string.Format("Invalid workflow '{0}'. It does not have finish stage specified", workflow.Name));

            if (workflow.Stages.Where(a => a.StageType == StageType.Finish).Count() > 1)
                throw new BAPWorkflowException(string.Format("Invalid workflow '{0}'. It has more than one finish stage specified", workflow.Name));

            // Do intial actions
            var initActions = workflow.Actions.Where(a => a.ActionType == ActionType.Initialize);
            foreach (var action in initActions)
            {
                var result = DoAction(action);
                if (!result)
                {
                    throw new BAPWorkflowException(string.Format("Cannot initialize workflow '{0}'. Init action {1} failed with error {2}", workflow.Name, action.Name, action.LastCompleteError));
                }
            }

            // Set statuses
            var initialStage = workflow.Stages.SingleOrDefault(a => a.StageType == StageType.Initial);
            initialStage.OpenedAt = entity.CreateDate.HasValue ? entity.CreateDate.Value : DateTime.Now;
            initialStage.State = StageState.Passed;
            initialStage.CompletedAt = DateTime.Now;
            SetCurrentTransitions(workflow, initialStage);
        }

        /// <summary>
        /// Sets the current transitions.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="stage">The stage.</param>
        private void SetCurrentTransitions(Workflow<T> workflow, WorkflowStage<T> stage)
        {
            if (workflow == null || stage == null)
                return;

            workflow.CurrentTransitions = workflow.Transitions.Where(a => a.FromStage.MetaId == stage.MetaId).ToList();
            workflow.CurrentTransitions.ForEach(trns =>
            {
                trns.ToStage.OpenedAt = DateTime.Now;
                trns.ToStage.State = StageState.Open;
                trns.ToStage.RequiredActions = new List<WorkflowAction<T>>();
                trns.ToStage.RequiredActions.AddRange(trns.ToStageActions);
                foreach (var action in trns.ToStage.RequiredActions)
                {
                    action.OpenedAt = DateTime.Now;
                    action.State = ActionState.Open;
                    InitActionAttributes(trns.Workflow, action);
                }
                trns.State = trns.ToStageActions != null && trns.ToStageActions.Any() ? TransitionState.Available : TransitionState.Ready;
            });
        }

        /// <summary>
        /// Workflows the complete.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <param name="stage">The stage.</param>
        /// <exception cref="BAP.Common.Exceptions.BAPWorkflowException"></exception>
        private void WorkflowComplete(Workflow<T> workflow, WorkflowStage<T> stage)
        {
            if (stage.RequiredActions != null && stage.RequiredActions.Count > 0)
            {
                foreach (var action in stage.RequiredActions)
                {
                    var result = DoAction(action);
                    if (!result)
                    {
                        throw new BAPWorkflowException(string.Format("Cannot complete workflow '{0}'. Finish action {1} failed with error {2}", workflow.Name, action.Name, action.LastCompleteError));
                    }
                }
            }

            stage.CompletedAt = DateTime.Now;
            stage.State = StageState.Passed;
            workflow.State = WorkflowState.Passed;
            workflow.CompletedAt = DateTime.Now;
        }

        /// <summary>
        /// Class WorkflowDC.
        /// </summary>
        private class WorkflowDC
        {
            /// <summary>
            /// Gets or sets the unique identifier.
            /// </summary>
            /// <value>The unique identifier.</value>
            public string UniqueId { get; set; }
            /// <summary>
            /// Gets or sets the meta identifier.
            /// </summary>
            /// <value>The meta identifier.</value>
            public int MetaId { get; set; }
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets the short description.
            /// </summary>
            /// <value>The short description.</value>
            public string ShortDescription { get; set; }
            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            public string Description { get; set; }
            /// <summary>
            /// Gets or sets the entity identifier.
            /// </summary>
            /// <value>The entity identifier.</value>
            public int EntityId { get; set; }

            /// <summary>
            /// Gets or sets the state.
            /// </summary>
            /// <value>The state.</value>
            public WorkflowState State { get; set; }
            /// <summary>
            /// Gets or sets the opened at.
            /// </summary>
            /// <value>The opened at.</value>
            public DateTime OpenedAt { get; set; }
            /// <summary>
            /// Gets or sets the completed at.
            /// </summary>
            /// <value>The completed at.</value>
            public DateTime CompletedAt { get; set; }

            /// <summary>
            /// Gets or sets the actions.
            /// </summary>
            /// <value>The actions.</value>
            public List<ActionDC> Actions { get; set; }
            /// <summary>
            /// Gets or sets the stages.
            /// </summary>
            /// <value>The stages.</value>
            public List<StageDC> Stages { get; set; }
            /// <summary>
            /// Gets or sets the transitions.
            /// </summary>
            /// <value>The transitions.</value>
            public List<TransitionDC> Transitions { get; set; }
            /// <summary>
            /// Gets or sets the current transitions.
            /// </summary>
            /// <value>The current transitions.</value>
            public List<int> CurrentTransitions { get; set; }
            /// <summary>
            /// Gets or sets the roles allowed.
            /// </summary>
            /// <value>The roles allowed.</value>
            public List<string> RolesAllowed { get; set; }
        }

        /// <summary>
        /// Class ActionDC.
        /// </summary>
        private class ActionDC
        {
            /// <summary>
            /// Gets or sets the unique identifier.
            /// </summary>
            /// <value>The unique identifier.</value>
            public string UniqueId { get; set; }
            /// <summary>
            /// Gets or sets the meta identifier.
            /// </summary>
            /// <value>The meta identifier.</value>
            public int MetaId { get; set; }
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets the short description.
            /// </summary>
            /// <value>The short description.</value>
            public string ShortDescription { get; set; }
            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            public string Description { get; set; }

            /// <summary>
            /// Gets or sets the action assembly.
            /// </summary>
            /// <value>The action assembly.</value>
            public string ActionAssembly { get; set; }
            /// <summary>
            /// Gets or sets the action class.
            /// </summary>
            /// <value>The action class.</value>
            public string ActionClass { get; set; }

            /// <summary>
            /// Gets or sets the type of the action.
            /// </summary>
            /// <value>The type of the action.</value>
            public ActionType ActionType { get; set; }
            /// <summary>
            /// Gets or sets the attributes.
            /// </summary>
            /// <value>The attributes.</value>
            public List<AttributeDC> Attributes { get; set; }
            /// <summary>
            /// Gets or sets the state.
            /// </summary>
            /// <value>The state.</value>
            public ActionState State { get; set; }
            /// <summary>
            /// Gets or sets the opened at.
            /// </summary>
            /// <value>The opened at.</value>
            public DateTime OpenedAt { get; set; }
            /// <summary>
            /// Gets or sets the completed at.
            /// </summary>
            /// <value>The completed at.</value>
            public DateTime CompletedAt { get; set; }
            /// <summary>
            /// Gets or sets the last complete error.
            /// </summary>
            /// <value>The last complete error.</value>
            public string LastCompleteError { get; set; }
        }

        /// <summary>
        /// Class AttributeDC.
        /// </summary>
        private class AttributeDC
        {
            /// <summary>
            /// Gets or sets the unique identifier.
            /// </summary>
            /// <value>The unique identifier.</value>
            public string UniqueId { get; set; }
            /// <summary>
            /// Gets or sets the meta identifier.
            /// </summary>
            /// <value>The meta identifier.</value>
            public int MetaId { get; set; }
            /// <summary>
            /// Gets or sets the type of the attribute.
            /// </summary>
            /// <value>The type of the attribute.</value>
            public AttributeType AttributeType { get; set; }
            /// <summary>
            /// Gets or sets the attribute direction.
            /// </summary>
            /// <value>The attribute direction.</value>
            public AttributeDirection AttributeDirection { get; set; }
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets the short description.
            /// </summary>
            /// <value>The short description.</value>
            public string ShortDescription { get; set; }
            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            public string Description { get; set; }
            /// <summary>
            /// Gets or sets the data source.
            /// </summary>
            /// <value>The data source.</value>
            public string DataSource { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is public.
            /// </summary>
            /// <value><c>true</c> if this instance is public; otherwise, <c>false</c>.</value>
            public bool IsPublic { get; set; }
            /// <summary>
            /// Gets or sets a value indicating whether this instance is visible.
            /// </summary>
            /// <value><c>true</c> if this instance is visible; otherwise, <c>false</c>.</value>
            public bool IsVisible { get; set; }
            /// <summary>
            /// Gets or sets a value indicating whether this instance is read only.
            /// </summary>
            /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
            public bool IsReadOnly { get; set; }

            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>The value.</value>
            public string Value { get; set; }
        }

        /// <summary>
        /// Class StageDC.
        /// </summary>
        private class StageDC
        {
            /// <summary>
            /// Gets or sets the unique identifier.
            /// </summary>
            /// <value>The unique identifier.</value>
            public string UniqueId { get; set; }
            /// <summary>
            /// Gets or sets the meta identifier.
            /// </summary>
            /// <value>The meta identifier.</value>
            public int MetaId { get; set; }
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets the short description.
            /// </summary>
            /// <value>The short description.</value>
            public string ShortDescription { get; set; }
            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            public string Description { get; set; }

            /// <summary>
            /// Gets or sets the type of the stage.
            /// </summary>
            /// <value>The type of the stage.</value>
            public StageType StageType { get; set; }

            // list of action MetaIDs
            /// <summary>
            /// Gets or sets the required actions.
            /// </summary>
            /// <value>The required actions.</value>
            public List<int> RequiredActions { get; set; }

            /// <summary>
            /// Gets or sets the state.
            /// </summary>
            /// <value>The state.</value>
            public StageState State { get; set; }
            /// <summary>
            /// Gets or sets the opened at.
            /// </summary>
            /// <value>The opened at.</value>
            public DateTime OpenedAt { get; set; }
            /// <summary>
            /// Gets or sets the completed at.
            /// </summary>
            /// <value>The completed at.</value>
            public DateTime CompletedAt { get; set; }
        }

        /// <summary>
        /// Class TransitionDC.
        /// </summary>
        private class TransitionDC
        {
            /// <summary>
            /// Gets or sets the unique identifier.
            /// </summary>
            /// <value>The unique identifier.</value>
            public string UniqueId { get; set; }
            /// <summary>
            /// Gets or sets the meta identifier.
            /// </summary>
            /// <value>The meta identifier.</value>
            public int MetaId { get; set; }
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets the short description.
            /// </summary>
            /// <value>The short description.</value>
            public string ShortDescription { get; set; }
            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            public string Description { get; set; }

            /// <summary>
            /// Gets or sets from stage identifier.
            /// </summary>
            /// <value>From stage identifier.</value>
            public int FromStageId { get; set; }
            /// <summary>
            /// Converts to stageid.
            /// </summary>
            /// <value>To stage identifier.</value>
            public int ToStageId { get; set; }

            // list of action MetaIDs
            /// <summary>
            /// Converts to stageactions.
            /// </summary>
            /// <value>To stage actions.</value>
            public List<int> ToStageActions { get; set; }

            /// <summary>
            /// Gets or sets the state.
            /// </summary>
            /// <value>The state.</value>
            public TransitionState State { get; set; }
            /// <summary>
            /// Gets or sets the comments.
            /// </summary>
            /// <value>The comments.</value>
            public string Comments { get; set; }
            /// <summary>
            /// Gets or sets the transitioned at.
            /// </summary>
            /// <value>The transitioned at.</value>
            public DateTime TransitionedAt { get; set; }
            /// <summary>
            /// Gets or sets the name of the transitioned by user.
            /// </summary>
            /// <value>The name of the transitioned by user.</value>
            public string TransitionedByUserName { get; set; }
            /// <summary>
            /// Gets or sets the attachment ids.
            /// </summary>
            /// <value>The attachment ids.</value>
            public List<int> AttachmentIds { get; set; }
        }

        /// <summary>
        /// Class AttachmentDC.
        /// </summary>
        private class AttachmentDC
        {
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>The identifier.</value>
            public int Id { get; set; }
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            public string Description { get; set; }
            /// <summary>
            /// Gets or sets the create date.
            /// </summary>
            /// <value>The create date.</value>
            public DateTime? CreateDate { get; set; }
            /// <summary>
            /// Gets or sets the type of the attachment.
            /// </summary>
            /// <value>The type of the attachment.</value>
            public string AttachmentType { get; set; }
            /// <summary>
            /// Gets or sets the object.
            /// </summary>
            /// <value>The object.</value>
            public string Object { get; set; }
            /// <summary>
            /// Gets or sets the object identifier.
            /// </summary>
            /// <value>The object identifier.</value>
            public int ObjectId { get; set; }
            /// <summary>
            /// Gets or sets the path URL.
            /// </summary>
            /// <value>The path URL.</value>
            public string PathUrl { get; set; }
            /// <summary>
            /// Gets or sets the status.
            /// </summary>
            /// <value>The status.</value>
            public string Status { get; set; }
            /// <summary>
            /// Gets or sets the status date.
            /// </summary>
            /// <value>The status date.</value>
            public DateTime StatusDate { get; set; }
            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="AttachmentDC"/> is published.
            /// </summary>
            /// <value><c>null</c> if [published] contains no value, <c>true</c> if [published]; otherwise, <c>false</c>.</value>
            public bool? Published { get; set; }
            /// <summary>
            /// Gets or sets the publish from.
            /// </summary>
            /// <value>The publish from.</value>
            public DateTime? PublishFrom { get; set; }
            /// <summary>
            /// Gets or sets the publish to.
            /// </summary>
            /// <value>The publish to.</value>
            public DateTime? PublishTo { get; set; }
            /// <summary>
            /// Gets or sets the type of the MIME.
            /// </summary>
            /// <value>The type of the MIME.</value>
            public string MimeType { get; set; }
        }

        /// <summary>
        /// Serializes the workflow.
        /// </summary>
        /// <param name="workflow">The workflow.</param>
        /// <returns>System.String.</returns>
        private string SerializeWorkflow(Workflow<T> workflow)
        {
            if (workflow == null)
                return "";

            var wfDC = new WorkflowDC()
            {
                Description = workflow.Description,
                EntityId = workflow.EntityId,
                MetaId = workflow.MetaId,
                Name = workflow.Name,
                ShortDescription = workflow.ShortDescription,
                UniqueId = workflow.UniqueId,
                CompletedAt = workflow.CompletedAt,
                OpenedAt = workflow.OpenedAt,
                CurrentTransitions = (workflow.CurrentTransitions != null ? workflow.CurrentTransitions.Select(a => a.MetaId).ToList() : null),
                RolesAllowed = workflow.RolesAllowed
            };

            if (workflow.Actions != null)
            {
                wfDC.Actions = new List<ActionDC>();
                foreach (var action in workflow.Actions)
                {
                    var actionDC = new ActionDC
                    {
                        ActionAssembly = action.ActionAssembly,
                        ActionClass = action.ActionClass,
                        ActionType = action.ActionType,
                        CompletedAt = action.CompletedAt,
                        Description = action.Description,
                        LastCompleteError = action.LastCompleteError,
                        MetaId = action.MetaId,
                        Name = action.Name,
                        OpenedAt = action.OpenedAt,
                        ShortDescription = action.ShortDescription,
                        State = action.State,
                        UniqueId = action.UniqueId
                    };

                    if (action.Attributes != null)
                    {
                        actionDC.Attributes = new List<AttributeDC>();
                        foreach (var attr in action.Attributes)
                        {
                            var attrDC = new AttributeDC
                            {
                                AttributeType = attr.AttributeType,
                                AttributeDirection = attr.AttributeDirection,
                                DataSource = attr.DataSource,
                                Description = attr.Description,
                                IsPublic = attr.IsPublic,
                                IsReadOnly = attr.IsReadOnly,
                                IsVisible = attr.IsVisible,
                                MetaId = attr.MetaId,
                                Name = attr.Name,
                                ShortDescription = attr.ShortDescription,
                                UniqueId = attr.UniqueId,
                                Value = attr.Value
                            };
                            actionDC.Attributes.Add(attrDC);
                        }
                    }

                    wfDC.Actions.Add(actionDC);
                }
            }

            if (workflow.Stages != null)
            {
                wfDC.Stages = new List<StageDC>();
                foreach (var stage in workflow.Stages)
                {
                    var stageDC = new StageDC
                    {
                        CompletedAt = stage.CompletedAt,
                        Description = stage.Description,
                        MetaId = stage.MetaId,
                        Name = stage.Name,
                        OpenedAt = stage.OpenedAt,
                        RequiredActions = (stage.RequiredActions != null ? stage.RequiredActions.Select(a => a.MetaId).ToList() : null),
                        ShortDescription = stage.ShortDescription,
                        StageType = stage.StageType,
                        State = stage.State,
                        UniqueId = stage.UniqueId
                    };
                    wfDC.Stages.Add(stageDC);
                }
            }

            if (workflow.Transitions != null)
            {
                wfDC.Transitions = new List<TransitionDC>();
                foreach (var trans in workflow.Transitions)
                {
                    var transDC = new TransitionDC
                    {
                        Description = trans.Description,
                        FromStageId = trans.FromStage.MetaId,
                        MetaId = trans.MetaId,
                        Name = trans.Name,
                        ShortDescription = trans.ShortDescription,
                        State = trans.State,
                        ToStageActions = trans.ToStageActions != null ? trans.ToStageActions.Select(a => a.MetaId).ToList() : null,
                        ToStageId = trans.ToStage.MetaId,
                        UniqueId = trans.UniqueId,
                        Comments = trans.Comments,
                        TransitionedAt = trans.TransitionedAt,
                        TransitionedByUserName = trans.TransitionedByUserName
                    };

                    if (trans.Attachments != null)
                    {
                        transDC.AttachmentIds = trans.Attachments.Select(a => a.AttachmentId).ToList();                                                        
                    }

                    wfDC.Transitions.Add(transDC);
                }
            }

            //JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //var json = JsonConvert.SerializeObject(workflow, settings);
            var json = JsonConvert.SerializeObject(wfDC);

            return json;
        }

        /// <summary>
        /// Deserializes the workflow.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>Workflow&lt;T&gt;.</returns>
        private Workflow<T> DeserializeWorkflow(string json, T entity)
        {
            Workflow<T> result = null;
            var resultDC = JsonConvert.DeserializeObject<WorkflowDC>(json);
            if (resultDC != null)
            {
                result = new Workflow<T>
                {
                    MetaId = resultDC.MetaId,
                    CompletedAt = resultDC.CompletedAt,
                    Description = resultDC.Description,
                    Entity = entity,
                    Name = resultDC.Name,
                    OpenedAt = resultDC.OpenedAt,
                    RolesAllowed = resultDC.RolesAllowed,
                    ShortDescription = resultDC.ShortDescription,
                    State = resultDC.State,
                    UniqueId = resultDC.UniqueId
                };

                if (resultDC.Actions != null)
                {
                    result.Actions = new List<WorkflowAction<T>>();
                    foreach (var actionDC in resultDC.Actions)
                    {
                        var action = new WorkflowAction<T>
                        {
                            ActionAssembly = actionDC.ActionAssembly,
                            ActionClass = actionDC.ActionClass,
                            ActionType = actionDC.ActionType,
                            CompletedAt = actionDC.CompletedAt,
                            Description = actionDC.Description,
                            LastCompleteError = actionDC.LastCompleteError,
                            MetaId = actionDC.MetaId,
                            Name = actionDC.Name,
                            OpenedAt = actionDC.OpenedAt,
                            ShortDescription = actionDC.ShortDescription,
                            State = actionDC.State,
                            UniqueId = actionDC.UniqueId,
                            Workflow = result
                            //Attributes                             
                        };

                        if (actionDC.Attributes != null)
                        {
                            action.Attributes = new List<ActionAttribute<T>>();
                            foreach (var attrDC in actionDC.Attributes)
                            {
                                var attr = new ActionAttribute<T>
                                {
                                    Action = action,
                                    AttributeType = attrDC.AttributeType,
                                    AttributeDirection = attrDC.AttributeDirection,
                                    DataSource = attrDC.DataSource,
                                    Description = attrDC.Description,
                                    IsPublic = attrDC.IsPublic,
                                    IsReadOnly = attrDC.IsReadOnly,
                                    IsVisible = attrDC.IsVisible,
                                    MetaId = attrDC.MetaId,
                                    Name = attrDC.Name,
                                    ShortDescription = attrDC.ShortDescription,
                                    UniqueId = attrDC.UniqueId,
                                    Value = attrDC.Value
                                };
                                action.Attributes.Add(attr);
                            }
                        }

                        result.Actions.Add(action);
                    }
                }

                if (resultDC.Stages != null)
                {
                    result.Stages = new List<WorkflowStage<T>>();
                    foreach (var stageDC in resultDC.Stages)
                    {
                        var stage = new WorkflowStage<T>
                        {
                            CompletedAt = stageDC.CompletedAt,
                            Description = stageDC.Description,
                            MetaId = stageDC.MetaId,
                            Name = stageDC.Name,
                            OpenedAt = stageDC.OpenedAt,
                            //RequiredActions
                            ShortDescription = stageDC.ShortDescription,
                            StageType = stageDC.StageType,
                            State = stageDC.State,
                            UniqueId = stageDC.UniqueId,
                            Workflow = result
                        };

                        if (stageDC.RequiredActions != null)
                        {
                            stage.RequiredActions = new List<WorkflowAction<T>>();
                            foreach (var id in stageDC.RequiredActions)
                            {
                                stage.RequiredActions.Add(result.Actions.SingleOrDefault(a => a.MetaId == id));
                            }
                        }

                        result.Stages.Add(stage);
                    }
                }

                if (resultDC.Transitions != null)
                {
                    result.Transitions = new List<StageTransition<T>>();
                    foreach (var transDC in resultDC.Transitions)
                    {
                        var trans = new StageTransition<T>
                        {
                            Description = transDC.Description,
                            FromStage = result.Stages.SingleOrDefault(a => a.MetaId == transDC.FromStageId),
                            MetaId = transDC.MetaId,
                            Name = transDC.Name,
                            ShortDescription = transDC.ShortDescription,
                            State = transDC.State,
                            ToStage = result.Stages.SingleOrDefault(a => a.MetaId == transDC.ToStageId),
                            //ToStageActions
                            UniqueId = transDC.UniqueId,
                            Workflow = result,
                            Comments = transDC.Comments,
                            TransitionedAt = transDC.TransitionedAt,
                            TransitionedByUserName = transDC.TransitionedByUserName
                        };

                        if (transDC.ToStageActions != null)
                        {
                            trans.ToStageActions = new List<WorkflowAction<T>>();
                            foreach (var id in transDC.ToStageActions)
                            {
                                trans.ToStageActions.Add(result.Actions.SingleOrDefault(a => a.MetaId == id));
                            }
                        }

                        if (transDC.AttachmentIds != null)
                        {
                            trans.Attachments = new List<TransitionAttachment>();
                            var attachments = ((IAttachmentBL)_bl).GetAttachmentsByEntityId(entity.GetType().Name, entity.Id);
                            foreach(var id in transDC.AttachmentIds.Distinct())
                            {
                                if(attachments.Any(a => a.Id == id))
                                {
                                    trans.Attachments.Add(new TransitionAttachment(attachments.FirstOrDefault(a => a.Id == id)));
                                }
                            }                            
                        }

                        result.Transitions.Add(trans);
                    }
                }

                if (resultDC.CurrentTransitions != null)
                {
                    result.CurrentTransitions = new List<StageTransition<T>>();
                    foreach (var id in resultDC.CurrentTransitions)
                    {
                        var item = result.Transitions.SingleOrDefault(a => a.MetaId == id && a.ToStage.State != StageState.Passed);
                        if (item != null)
                            result.CurrentTransitions.Add(item);
                    }
                }
            }

            return result;
        }

        #endregion
    }
}
