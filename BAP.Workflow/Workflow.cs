// ***********************************************************************
// Assembly         : BAP.Workflow
// Author           : Victor Mamray
// Created          : 07-15-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-24-2020
// ***********************************************************************
// <copyright file="Workflow.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

using BAP.Common;
using BAP.DAL.Entities;
using Newtonsoft.Json;

namespace BAP.Workflow
{
    /// <summary>
    /// Class ActionAttributeView.
    /// </summary>
    public class ActionAttributeView
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
        public string AttributeType { get; set; }
        /// <summary>
        /// Gets or sets the attribute direction.
        /// </summary>
        /// <value>The attribute direction.</value>
        public string AttributeDirection { get; set; }
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
    /// Class ActionView.
    /// </summary>
    public class ActionView
    {
        /// <summary>
        /// Gets or sets the meta identifier.
        /// </summary>
        /// <value>The meta identifier.</value>
        public int MetaId { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        public string UniqueId { get; set; }
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
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public ActionState State { get; set; }
        /// <summary>
        /// Gets or sets the last completed at.
        /// </summary>
        /// <value>The last completed at.</value>
        public DateTime LastCompletedAt { get; set; }
        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>The attributes.</value>
        public List<ActionAttributeView> Attributes { get; set; }

        /// <summary>
        /// Gets the attributes json.
        /// </summary>
        /// <value>The attributes json.</value>
        public string AttributesJson
        {
            get
            {
                if (Attributes != null)
                    return JsonConvert.SerializeObject(Attributes);

                return "";
            }
        }
    }

    /// <summary>
    /// Class WorkflowStageView.
    /// </summary>
    public class WorkflowStageView
    {
        /// <summary>
        /// Gets the completed at.
        /// </summary>
        /// <value>The completed at.</value>
        public DateTime CompletedAt { get; internal set; }
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; internal set; }
        /// <summary>
        /// Gets the meta identifier.
        /// </summary>
        /// <value>The meta identifier.</value>
        public int MetaId { get; internal set; }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; internal set; }
        /// <summary>
        /// Gets the opened at.
        /// </summary>
        /// <value>The opened at.</value>
        public DateTime OpenedAt { get; internal set; }
        /// <summary>
        /// Gets the short description.
        /// </summary>
        /// <value>The short description.</value>
        public string ShortDescription { get; internal set; }
        /// <summary>
        /// Gets the type of the stage.
        /// </summary>
        /// <value>The type of the stage.</value>
        public StageType StageType { get; internal set; }
        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        public string UniqueId { get; internal set; }
        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
        public StageState State { get; internal set; }

        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        /// <value>The actions.</value>
        public List<ActionView> Actions { get; set; }
    }

    /// <summary>
    /// Class StageTransitionView.
    /// </summary>
    public class StageTransitionView
    {
        /// <summary>
        /// Gets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public string Comments { get; internal set; }
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; internal set; }
        /// <summary>
        /// Gets the name of from stage.
        /// </summary>
        /// <value>The name of from stage.</value>
        public string FromStageName { get; internal set; }
        /// <summary>
        /// Gets from stage opened at.
        /// </summary>
        /// <value>From stage opened at.</value>
        public DateTime FromStageOpenedAt { get; internal set; }
        /// <summary>
        /// Gets from stage completed at.
        /// </summary>
        /// <value>From stage completed at.</value>
        public DateTime FromStageCompletedAt { get; internal set; }
        /// <summary>
        /// Gets the meta identifier.
        /// </summary>
        /// <value>The meta identifier.</value>
        public int MetaId { get; internal set; }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; internal set; }
        /// <summary>
        /// Gets the short description.
        /// </summary>
        /// <value>The short description.</value>
        public string ShortDescription { get; internal set; }
        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
        public TransitionState State { get; internal set; }
        /// <summary>
        /// Converts to stagename.
        /// </summary>
        /// <value>The name of to stage.</value>
        public string ToStageName { get; internal set; }
        /// <summary>
        /// Converts to stageopenedat.
        /// </summary>
        /// <value>To stage opened at.</value>
        public DateTime ToStageOpenedAt { get; internal set; }
        /// <summary>
        /// Converts to stagecompletedat.
        /// </summary>
        /// <value>To stage completed at.</value>
        public DateTime ToStageCompletedAt { get; internal set; }
        /// <summary>
        /// Gets the transitioned at.
        /// </summary>
        /// <value>The transitioned at.</value>
        public DateTime TransitionedAt { get; internal set; }
        /// <summary>
        /// Gets the name of the transitioned by user.
        /// </summary>
        /// <value>The name of the transitioned by user.</value>
        public string TransitionedByUserName { get; internal set; }
        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        public string UniqueId { get; internal set; }
        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>The attachments.</value>
        public List<TransitionAttachment> Attachments { get; set; }
        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        /// <value>The actions.</value>
        public List<ActionView> Actions { get; set; }
    }

    /// <summary>
    /// Interface IWorkflowView
    /// </summary>
    public interface IWorkflowView
    {
        /// <summary>
        /// Gets the name of the entity class.
        /// </summary>
        /// <value>The name of the entity class.</value>
        string EntityClassName { get; }
        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        /// <value>The entity identifier.</value>
        int EntityId { get; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        string ShortDescription { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }
        /// <summary>
        /// Gets the current stage.
        /// </summary>
        /// <value>The current stage.</value>
        WorkflowStageView CurrentStage { get; }
        /// <summary>
        /// Gets the current transition views.
        /// </summary>
        /// <value>The current transition views.</value>
        List<string> CurrentTransitionViews { get; }
        /// <summary>
        /// Gets the stage views.
        /// </summary>
        /// <value>The stage views.</value>
        List<WorkflowStageView> StageViews { get; }
        /// <summary>
        /// Gets the transition views.
        /// </summary>
        /// <value>The transition views.</value>
        List<StageTransitionView> TransitionViews { get; }
    }

    /// <summary>
    /// Enum WorkflowState
    /// </summary>
    public enum WorkflowState
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0, // workflow not yet available to the user
        /// <summary>
        /// The open
        /// </summary>
        Open,     // workflow is in progress
        /// <summary>
        /// The passed
        /// </summary>
        Passed    // workflow has been completed
    }

    /// <summary>
    /// Class Workflow.
    /// Implements the <see cref="BAP.Workflow.IWorkflowView" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BAP.Workflow.IWorkflowView" />
    public class Workflow<T> : IWorkflowView where T : class, IBapEntity
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
        /// Entity instance
        /// </summary>
        /// <value>The entity.</value>
        public T Entity { get; set; }

        /// <summary>
        /// Gets the name of the entity class.
        /// </summary>
        /// <value>The name of the entity class.</value>
        public string EntityClassName
        {
            get
            {
                var result = "";
                if (Entity != null)
                    return Entity.GetType().Name;
                return result;
            }
        }

        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        /// <value>The entity identifier.</value>
        public int EntityId
        {
            get
            {
                var result = 0;
                if (Entity != null)
                    result = Entity.Id;

                return result;
            }
        }

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
        /// List of all the actions in the workflow
        /// </summary>
        /// <value>The actions.</value>
        public List<WorkflowAction<T>> Actions { get; set; }

        /// <summary>
        /// Gets or sets the stages.
        /// </summary>
        /// <value>The stages.</value>
        public List<WorkflowStage<T>> Stages { get; set; }

        /// <summary>
        /// List of application user roles workflow is allowed to
        /// </summary>
        /// <value>The roles allowed.</value>
        public List<string> RolesAllowed { get; set; }

        /// <summary>
        /// List of allowed transitions between given stages
        /// </summary>
        /// <value>The transitions.</value>
        public List<StageTransition<T>> Transitions { get; set; }

        /// <summary>
        /// Gets or sets the current transitions.
        /// </summary>
        /// <value>The current transitions.</value>
        public List<StageTransition<T>> CurrentTransitions { get; set; }

        /// <summary>
        /// Gets the current stage.
        /// </summary>
        /// <value>The current stage.</value>
        public WorkflowStageView CurrentStage
        {
            get
            {
                var stage = GetCurrentStage();
                return new WorkflowStageView
                {
                    State = stage.State,
                    CompletedAt = stage.CompletedAt,
                    Description = stage.Description,
                    MetaId = stage.MetaId,
                    Name = stage.Name,
                    OpenedAt = stage.OpenedAt,
                    ShortDescription = stage.ShortDescription,
                    StageType = stage.StageType,
                    UniqueId = stage.UniqueId,
                    Actions = stage.RequiredActions?.Select(a => new ActionView
                    {
                        LastCompletedAt = a.CompletedAt,
                        MetaId = a.MetaId,
                        Name = a.Name,
                        ShortDescription = a.ShortDescription,
                        State = a.State,
                        UniqueId = a.UniqueId,
                        Attributes = a.Attributes?.Select(b => new ActionAttributeView { 
                            AttributeDirection = b.AttributeDirection.ToString(),
                            AttributeType = b.AttributeType.ToString(),
                            IsPublic = b.IsPublic,
                            IsReadOnly = b.IsReadOnly,
                            IsVisible = b.IsVisible,
                            MetaId = b.MetaId,
                            Name = b.Name,
                            ShortDescription = b.ShortDescription,
                            UniqueId = b.UniqueId,
                            Value = b.Value
                        }).ToList()
                    }).ToList()
                };
            }
        }

        /// <summary>
        /// Gets the current transition views.
        /// </summary>
        /// <value>The current transition views.</value>
        public List<string> CurrentTransitionViews
        {
            get
            {
                List<string> result = null;
                if (CurrentTransitions != null && CurrentTransitions.Count > 0)
                {
                    result = CurrentTransitions.Select(trans => trans.UniqueId).ToList();
                }
                return result;
            }
        }

        /// <summary>
        /// Gets the transition views.
        /// </summary>
        /// <value>The transition views.</value>
        public List<StageTransitionView> TransitionViews
        {
            get
            {
                var result = new List<StageTransitionView>();
                if (this.Transitions != null && this.Transitions.Any())
                    result = Transitions.Select(trans =>
                              new StageTransitionView
                              {
                                  Comments = trans.Comments,
                                  Description = trans.Description,
                                  FromStageName = trans.FromStage.Name,
                                  FromStageOpenedAt = trans.FromStage.OpenedAt,
                                  FromStageCompletedAt = trans.FromStage.CompletedAt,
                                  MetaId = trans.MetaId,
                                  Name = trans.Name,
                                  ShortDescription = trans.ShortDescription,
                                  State = trans.State,
                                  ToStageName = trans.ToStage.Name,
                                  ToStageCompletedAt = trans.ToStage.CompletedAt,
                                  ToStageOpenedAt = trans.ToStage.OpenedAt,
                                  TransitionedAt = trans.TransitionedAt,
                                  TransitionedByUserName = trans.TransitionedByUserName,
                                  UniqueId = trans.UniqueId,
                                  Attachments = trans.Attachments,
                                  Actions = trans.ToStageActions?.Select(act => new ActionView
                                  {
                                      LastCompletedAt = act.CompletedAt,
                                      MetaId = act.MetaId,
                                      Name = act.Name,
                                      ShortDescription = act.ShortDescription,
                                      State = act.State,
                                      UniqueId = act.UniqueId,
                                      Attributes = act.Attributes?.Select(b => new ActionAttributeView
                                      {
                                          AttributeDirection = b.AttributeDirection.ToString(),
                                          AttributeType = b.AttributeType.ToString(),
                                          IsPublic = b.IsPublic,
                                          IsReadOnly = b.IsReadOnly,
                                          IsVisible = b.IsVisible,
                                          MetaId = b.MetaId,
                                          Name = b.Name,
                                          ShortDescription = b.ShortDescription,
                                          UniqueId = b.UniqueId,
                                          Value = b.Value
                                      }).ToList()
                                  }).ToList()
                              }
                        ).ToList();
                return result;
            }
        }

        /// <summary>
        /// Gets the stage views.
        /// </summary>
        /// <value>The stage views.</value>
        public List<WorkflowStageView> StageViews
        {
            get
            {
                var result = new List<WorkflowStageView>();
                if (this.Stages != null && this.Stages.Any())
                    result = Stages.Select(stage =>
                              new WorkflowStageView
                              {
                                  CompletedAt = stage.CompletedAt,
                                  Description = stage.Description,
                                  MetaId = stage.MetaId,
                                  Name = stage.Name,
                                  OpenedAt = stage.OpenedAt,
                                  ShortDescription = stage.ShortDescription,
                                  StageType = stage.StageType,
                                  State = stage.State,
                                  UniqueId = stage.UniqueId,
                                  Actions = stage.RequiredActions?.Select(a => new ActionView
                                  {
                                      LastCompletedAt = a.CompletedAt,
                                      MetaId = a.MetaId,
                                      Name = a.Name,
                                      ShortDescription = a.ShortDescription,
                                      State = a.State,
                                      UniqueId = a.UniqueId
                                  }).ToList()
                              }
                              ).ToList();
                return result;
            }
        }

        /// <summary>
        /// Gets the current stage.
        /// </summary>
        /// <returns>WorkflowStage&lt;T&gt;.</returns>
        private WorkflowStage<T> GetCurrentStage()
        {
            WorkflowStage<T> result = null;
            if (Stages.Any(a => a.State == StageState.Open))
            {
                result = Stages.Where(a => a.State == StageState.Open).OrderBy(a => a.OpenedAt).FirstOrDefault();
            }
            else
            {
                if (Stages.Any(a => a.State == StageState.Passed))
                    result = Stages.Where(a => a.State == StageState.Passed).OrderByDescending(a => a.CompletedAt).FirstOrDefault();
                else
                    result = Stages.SingleOrDefault(a => a.StageType == StageType.Initial);
            }
            return result;
        }
    }
}
