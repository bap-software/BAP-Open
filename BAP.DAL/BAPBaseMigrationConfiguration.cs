// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="BAPBaseMigrationConfiguration.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using BAP.DAL.Entities;
using System.Collections.Generic;

namespace BAP.DAL
{
    /// <summary>
    /// Class BAPBaseMigrationConfiguration.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigrationsConfiguration{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigrationsConfiguration{T}" />
    public abstract class BAPBaseMigrationConfiguration<T> : DbMigrationsConfiguration<T> where T : DbContext
    {
        /// <summary>
        /// Upserts the content node.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="name">The name.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="aliasPath">The alias path.</param>
        /// <param name="area">The area.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="namespaces">The namespaces.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="menuIndex">Index of the menu.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="adminUserId">The admin user identifier.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <param name="clicable">if set to <c>true</c> [clicable].</param>
        /// <param name="allowChldren">if set to <c>true</c> [allow chldren].</param>
        /// <param name="showInMenu">if set to <c>true</c> [show in menu].</param>
        /// <param name="showInSitemap">if set to <c>true</c> [show in sitemap].</param>
        /// <param name="routeUrl">The route URL.</param>
        /// <param name="owners">The owners.</param>
        /// <param name="ownerPermissions">The owner permissions.</param>
        /// <returns>ContentNode.</returns>
        protected ContentNode UpsertContentNode(T db, string name, string caption, string aliasPath, string area, string controller, string action, string icon, string namespaces, string roles, int menuIndex, int orgId, string adminUserId, ContentNode parent = null, bool enabled = true, bool clicable = true, bool allowChldren = false, bool showInMenu = true, bool showInSitemap = true, string routeUrl = null, int owners = 127, int ownerPermissions = 8143)
        {
            DateTime createDateTime = DateTime.Now;
            ContentNode node = null;            
            var contentNodes = db.Set<ContentNode>();
            if (!contentNodes.Any(a => a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            {
                node = new ContentNode
                {
                    Name = name,
                    Alias = name,
                    AliasPath = aliasPath,
                    Area = area,
                    Controller = controller,
                    Action = action,
                    MenuCaption = caption,
                    View = action,
                    RouteUrl = routeUrl,
                    NameSpaces = namespaces,
                    MenuSortOrder = menuIndex,
                    MenuIcon = icon,
                    Roles = roles,

                    ParentNode = parent,
                    MenuClicable = clicable,
                    AllowChildren = allowChldren,
                    ShowInMenu = showInMenu,
                    ShowInSitemap = showInSitemap,
                    Enabled = enabled,

                    NavigationType = NavigationType.MvcRoute,
                    Rating = 1,
                    SitemapPriority = SitemapPriority.Normal,
                    SitemapChangeFrequency = SitemapChangeFrequency.Monthly,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = owners,
                    OwnerPermissions = ownerPermissions
                };
                contentNodes.Add(node);
            }
            else
            {
                node = contentNodes.SingleOrDefault(a => a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

                node.AliasPath = aliasPath;
                node.Area = area;
                node.Controller = controller;
                node.Action = action;
                node.MenuCaption = caption;
                node.View = action;
                node.RouteUrl = routeUrl;
                node.NameSpaces = namespaces;
                node.MenuSortOrder = menuIndex;
                node.MenuIcon = icon;
                node.Roles = roles;

                node.MenuClicable = clicable;
                node.AllowChildren = allowChldren;
                node.ShowInMenu = showInMenu;
                node.ShowInSitemap = showInSitemap;
                node.Enabled = enabled;

                node.LastModifiedDate = createDateTime;
                node.LastModifiedBy = adminUserId;
            }
            return node;
        }

        /// <summary>
        /// Upserts the document template.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="shortDescr">The short description.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="fileUrl">The file URL.</param>
        /// <param name="upsertUserId">The upsert user identifier.</param>
        protected void UpsertDocumentTemplate(T context, int orgId, string name, string shortDescr, string typeName, string fileUrl, string upsertUserId)
        {
            var documentTemplates = context.Set<DocumentTemplate>();
            var docTemplate = documentTemplates.SingleOrDefault(a => a.Name == name);
            var currDateTime = DateTime.Now;
            if (docTemplate == null)
            {
                docTemplate = new DocumentTemplate
                {
                    Name = name,
                    ShortDescription = shortDescr,
                    TemplateType = typeName,
                    TemplateBodyUrl = fileUrl,
                    OwnerGroup = 123,
                    OwnerPermissions = 2072079,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = upsertUserId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = upsertUserId
                };
                documentTemplates.Add(docTemplate);
            }
            else
            {
                docTemplate.ShortDescription = shortDescr;
                docTemplate.TemplateType = typeName;
                docTemplate.TemplateBodyUrl = fileUrl;
                docTemplate.LastModifiedDate = currDateTime;
                docTemplate.LastModifiedBy = upsertUserId;
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Adds the module.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name.</param>
        /// <param name="organization">The organization.</param>
        /// <param name="adminUserId">The admin user identifier.</param>
        /// <param name="createDateTime">The create date time.</param>
        protected void AddModule(T context, string name, Organization organization, string adminUserId, DateTime createDateTime)
        {
            var modules = context.Set<Module>();
            if (!modules.Any(m => m.Name == name))
            {
                var module = new Module
                {
                    Name = name,
                    ShortDescription = name,
                    Description = name,
                    Enabled = true,
                    GlobalId = Guid.NewGuid(),
                    Roles = "Administrator,ContentManager",
                    BitMask = 299599,
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 299599
                };
                modules.Add(module);

                var organizationModule = new OrganizationModule
                {
                    Name = $"{organization.Name} {module.Name}",
                    OrganizationId = organization.Id,
                    ModuleId = module.Id,
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 299599
                };
                var orgModules = context.Set<OrganizationModule>();
                orgModules.Add(organizationModule);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds the role.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name.</param>
        protected void AddRole(T context, string name)
        {
            var roles = context.Set<IdentityRole>();
            if (!roles.Any(r => r.Name == name))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = name };

                manager.Create(role);
            }
        }

        /// <summary>
        /// Adds the org user.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="organization">The organization.</param>
        /// <param name="adminUserId">The admin user identifier.</param>
        /// <param name="aspNetUserId">The ASP net user identifier.</param>
        /// <param name="email">The email.</param>
        /// <param name="fname">The fname.</param>
        /// <param name="lname">The lname.</param>
        /// <param name="addr1">The addr1.</param>
        /// <param name="addr2">The addr2.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="country">The country.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="workphone">The workphone.</param>
        /// <param name="cellphone">The cellphone.</param>
        /// <param name="isBuiltIn">if set to <c>true</c> [is built in].</param>
        /// <returns>OrganizationUser.</returns>
        protected OrganizationUser AddOrgUser(T context, Organization organization, string adminUserId, string aspNetUserId, string email, string fname, string lname, string addr1 = null, string addr2 = null, string city = null, string state = null, string country = null, string zip = null, string workphone = null, string cellphone = null, bool isBuiltIn = false)
        {
            var organizationUsers = context.Set<OrganizationUser>();
            var orgUser = organizationUsers.FirstOrDefault(a =>
                a.AspNetUserId == aspNetUserId && a.TenantUnit == "Organization" && a.TenantUnitId == organization.Id);
            if (orgUser == null)
            {
                var createDateTime = DateTime.Now;
                orgUser = new OrganizationUser
                {
                    AspNetUserId = aspNetUserId,
                    FirstName = fname,
                    LastName = lname,
                    AddressLine1 = addr1,
                    AddressLine2 = addr2,
                    City = city,
                    State = state,
                    Country = country,
                    Zip = zip,
                    PhoneNumber = workphone,
                    CellNumber = cellphone,
                    TenantUnit = "Organization",
                    TenantUnitId = organization.Id,
                    OwnerGroup = 127,
                    OwnerPermissions = 310991,
                    Organization = organization,
                    CreateDate = createDateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = createDateTime,
                    LastModifiedBy = adminUserId,
                    Email = email,
                    EmailConfirmed = true,
                    IsBuiltIn = isBuiltIn
                };
                organizationUsers.Add(orgUser);
                context.SaveChanges();
            }

            return orgUser;
        }

        /// <summary>
        /// Upserts the lookup value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="lookup">The lookup.</param>
        /// <param name="key">The key.</param>
        /// <param name="text">The text.</param>
        /// <param name="description">The description.</param>
        /// <param name="order">The order.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>LookupValue.</returns>
        protected LookupValue UpsertLookupValue(T context, int orgId, Lookup lookup, string key, string text, string description, int order, string userId)
        {
            if (context == null || orgId == 0 || lookup == null)
                return null;

            IQueryable<Lookup> query = context.Set<Lookup>();
            query = query.Where(a => a.Id == lookup.Id);
            query = query.Include(a => a.Values);
            var thisLoookup = query.SingleOrDefault();

            var currDateTime = DateTime.Now;
            LookupValue lValue = null;
            if (thisLoookup != null && thisLoookup.Values != null && thisLoookup.Values.Any(a => a.Key == key ))
            {
                lValue = thisLoookup.Values.First(a => a.Key == key );
                if (lValue != null)
                {
                    lValue.Text = text;
                    lValue.Description = description;
                    lValue.LastModifiedBy = userId;
                    lValue.LastModifiedDate = currDateTime;
                    context.SaveChanges();
                }
            }
            else
            {
                lValue = new LookupValue
                {
                    Key = key,
                    Text = text,
                    Description = description,                    
                    Order = order,
                    Parent = lookup,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId,
                    OwnerGroup = 127,
                    OwnerPermissions = 302799
                };
                context.Set<LookupValue>().Add(lValue);
            }

            return lValue;
        }

        /// <summary>
        /// Adds the currency.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="threeLetterCode">The three letter code.</param>
        /// <param name="name">The name.</param>
        /// <param name="symbol">The symbol.</param>
        /// <param name="description">The description.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="adminUserId">The admin user identifier.</param>
        /// <param name="isMain">if set to <c>true</c> [is main].</param>
        /// <param name="xchRate">The XCH rate.</param>
        protected void AddCurrency(T context, string threeLetterCode, string name, string symbol, string description,
           int orgId, string adminUserId, bool isMain = false, decimal xchRate = 1)
        {
            var currency = context.Set<Currency>().FirstOrDefault(a =>
                a.ThreeLetterCode == threeLetterCode && a.TenantUnit == "Organization" && a.TenantUnitId == orgId);
            if (currency == null)
            {
                var dateTime = DateTime.Now;
                currency = new Currency
                {
                    ThreeLetterCode = threeLetterCode,
                    Name = name,
                    Description = description,
                    ExchangeRate = xchRate,
                    Symbol = symbol,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = dateTime,
                    CreatedBy = adminUserId,
                    LastModifiedDate = dateTime,
                    LastModifiedBy = adminUserId,
                    OwnerGroup = 127,
                    OwnerPermissions = 1875535,
                    IsMain = isMain,
                    IsEnabled = true,
                    RoundTo = 2,
                    FormatString = "${0:n2}"
                };
                context.Set<Currency>().Add(currency);
            }
            else
            {
                currency.OwnerGroup = 127;
                currency.OwnerPermissions = 1875535;
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Adds the localization.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="resourceSet">The resource set.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="userId">The user identifier.</param>
        protected void AddLocalization(T context, string name, string value, string locale, string resourceSet, int orgId, string userId)
        {
            DateTime currDateTime = DateTime.Now;
            var localization = new Localization
            {
                Name = name,
                Value = value,
                CultureCode = locale,
                ResourceSet = resourceSet,
                OwnerGroup = 127,
                OwnerPermissions = 302799,
                TenantUnit = "Organization",
                TenantUnitId = orgId,
                CreateDate = currDateTime,
                CreatedBy = userId,
                LastModifiedDate = currDateTime,
                LastModifiedBy = userId
            };
            context.Set<Localization>().Add(localization);
        }

        /// <summary>
        /// Upserts the workflow.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name.</param>
        /// <param name="shortDescription">The short description.</param>
        /// <param name="allowedRoles">The allowed roles.</param>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>WorkflowClass.</returns>
        protected WorkflowClass UpsertWorkflow(T context, string name, string shortDescription, string allowedRoles, Type entityType, int orgId, string userId)
        {
            WorkflowClass result = null;
            DateTime currDateTime = DateTime.Now;
            if (!context.Set<WorkflowClass>().Any(a => a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            {
                result = new WorkflowClass
                {
                    Name = name,
                    ShortDescription = shortDescription,
                    AllowedRoles = allowedRoles,
                    BapEntityAssembly = entityType.Assembly.FullName,
                    BapEntityClass = entityType.FullName,
                    OwnerGroup = 27,
                    OwnerPermissions = 2072079,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                };
                context.Set<WorkflowClass>().Add(result);
            }
            else
            {
                result = context.Set<WorkflowClass>().SingleOrDefault(a => a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
                result.ShortDescription = shortDescription;
                result.AllowedRoles = allowedRoles;
                result.BapEntityAssembly = entityType.Assembly.FullName;
                result.BapEntityClass = entityType.FullName;
                result.LastModifiedBy = userId;
                result.LastModifiedDate = currDateTime;
            }
            return result;
        }

        /// <summary>
        /// Upserts the workflow action.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name.</param>
        /// <param name="shortDescription">The short description.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="actionAttributes">The action attributes.</param>
        /// <param name="wf">The wf.</param>
        /// <param name="actionClassType">Type of the action class.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>WorkflowAction.</returns>
        protected WorkflowAction UpsertWorkflowAction(T context, string name, string shortDescription, int actionType, List<WorkflowActionAttribute> actionAttributes, WorkflowClass wf, Type actionClassType, int orgId, string userId)
        {
            WorkflowAction result = null;
            DateTime currDateTime = DateTime.Now;
            if (!context.Set<WorkflowAction>().Any(a => a.Workflow.Name.Equals(wf.Name, StringComparison.InvariantCultureIgnoreCase) && a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            {
                result = new WorkflowAction
                {
                    Name = name,
                    ShortDescription = shortDescription,
                    Workflow = wf,
                    ActionAssembly = actionClassType.Assembly.FullName,
                    ActionClass = actionClassType.FullName,
                    ActionType = actionType,
                    Attributes = actionAttributes,
                    OwnerGroup = 27,
                    OwnerPermissions = 2072079,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                };
                if (actionAttributes != null)
                    actionAttributes.ForEach(a => { a.WorkflowAction = result; });

                context.Set<WorkflowAction>().Add(result);
            }
            else
            {
                result = context.Set<WorkflowAction>().SingleOrDefault(a => a.Workflow.Name.Equals(wf.Name, StringComparison.InvariantCultureIgnoreCase) && a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
                var attributesNow = context.Set<WorkflowActionAttribute>().Where(a => a.WorkflowActionId == result.Id).ToList();
                if (attributesNow != null && attributesNow.Any())
                    context.Set<WorkflowActionAttribute>().RemoveRange(attributesNow);
                if (actionAttributes != null)
                    actionAttributes.ForEach(a => { a.WorkflowAction = result; });
                result.ShortDescription = shortDescription;
                result.ActionType = actionType;
                result.Attributes = actionAttributes;
                result.ActionAssembly = actionClassType.Assembly.FullName;
                result.ActionClass = actionClassType.FullName;
                result.LastModifiedDate = currDateTime;
                result.LastModifiedBy = userId;
            }
            return result;
        }

        /// <summary>
        /// Upserts the workflow stage.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name.</param>
        /// <param name="shortDescription">The short description.</param>
        /// <param name="stageType">Type of the stage.</param>
        /// <param name="wf">The wf.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>WorkflowStage.</returns>
        protected WorkflowStage UpsertWorkflowStage(T context, string name, string shortDescription, StageType stageType, WorkflowClass wf, int orgId, string userId)
        {
            WorkflowStage result = null;
            DateTime currDateTime = DateTime.Now;
            if (!context.Set<WorkflowStage>().Any(a => a.Workflow.Name.Equals(wf.Name, StringComparison.InvariantCultureIgnoreCase) && a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            {
                result = new WorkflowStage
                {
                    Name = name,
                    ShortDescription = shortDescription,
                    StageType = (int)stageType,
                    Workflow = wf,
                    OwnerGroup = 27,
                    OwnerPermissions = 2072079,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                
                };
                context.Set<WorkflowStage>().Add(result);
            }
            else
            {
                result = context.Set<WorkflowStage>().SingleOrDefault(a => a.Workflow.Name.Equals(wf.Name, StringComparison.InvariantCultureIgnoreCase) && a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
                result.ShortDescription = shortDescription;
                result.StageType = (int)stageType;
                result.LastModifiedBy = userId;
                result.LastModifiedDate = currDateTime;
            }
            return result;
        }

        /// <summary>
        /// Upserts the workflow stage transition.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="wf">The wf.</param>
        /// <param name="fromStage">From stage.</param>
        /// <param name="toStage">To stage.</param>
        /// <param name="stageActions">The stage actions.</param>
        /// <param name="orgId">The org identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>WorkflowStageTransition.</returns>
        protected WorkflowStageTransition UpsertWorkflowStageTransition(T context, WorkflowClass wf, WorkflowStage fromStage, WorkflowStage toStage, List<WorkflowAction> stageActions, int orgId, string userId)
        {
            WorkflowStageTransition result = null;
            DateTime currDateTime = DateTime.Now;
            string name = fromStage.Name + "To" + toStage.Name;
            if (!context.Set<WorkflowStageTransition>().Any(a => a.Workflow.Name.Equals(wf.Name, StringComparison.InvariantCultureIgnoreCase) && a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            {
                result = new WorkflowStageTransition
                {
                    Name = name,
                    Workflow = wf,
                    FromStage = fromStage,
                    ToStage = toStage,
                    Actions = stageActions,
                    OwnerGroup = 27,
                    OwnerPermissions = 2072079,
                    TenantUnit = "Organization",
                    TenantUnitId = orgId,
                    CreateDate = currDateTime,
                    CreatedBy = userId,
                    LastModifiedDate = currDateTime,
                    LastModifiedBy = userId
                };
                context.Set<WorkflowStageTransition>().Add(result);
            }
            else
            {
                result = context.Set<WorkflowStageTransition>().Include(a => a.Actions).SingleOrDefault(a => a.Workflow.Name.Equals(wf.Name, StringComparison.InvariantCultureIgnoreCase) && a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
                if(result.Actions != null && result.Actions.Any())
                {
                    result.Actions.Clear();
                    result.Actions.AddRange(stageActions);
                }
                result.FromStage = fromStage;
                result.ToStage = toStage;
                result.LastModifiedBy = userId;
                result.LastModifiedDate = currDateTime;
            }

            return result;
        }

    }
}
