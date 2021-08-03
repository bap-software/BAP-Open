// ***********************************************************************
// Assembly         : BAP.Resources
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="Resources.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;
using System.Resources;
using System.Web.Mvc;

namespace BAP.Resources
{
    /// <summary>
    /// Class FakeResourceManager.
    /// Implements the <see cref="System.Resources.ResourceManager" />
    /// </summary>
    /// <seealso cref="System.Resources.ResourceManager" />
    internal class FakeResourceManager : ResourceManager
    {
        /// <summary>
        /// Returns the value of the specified string resource.
        /// </summary>
        /// <param name="name">The name of the resource to retrieve.</param>
        /// <returns>The value of the resource localized for the caller's current UI culture, or <see langword="null" /> if <paramref name="name" /> cannot be found in a resource set.</returns>
        public override string GetString(string name)
        {
            return "Some Fake";
        }

        /// <summary>
        /// Returns the value of the string resource localized for the specified culture.
        /// </summary>
        /// <param name="name">The name of the resource to retrieve.</param>
        /// <param name="culture">An object that represents the culture for which the resource is localized.</param>
        /// <returns>The value of the resource localized for the specified culture, or <see langword="null" /> if <paramref name="name" /> cannot be found in a resource set.</returns>
        public override string GetString(string name, CultureInfo culture)
        {
            return "Some Cultural Fake";
        }
    }
    /// <summary>
    /// A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources
    {

        /// <summary>
        /// The resource man
        /// </summary>
        protected static ResourceManager resourceMan;

        /// <summary>
        /// The resource culture
        /// </summary>
        protected static global::System.Globalization.CultureInfo resourceCulture;

        /// <summary>
        /// Reads the type of the resource manager string by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="resourceType">Type of the resource.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.String.</returns>
        protected static string ReadResourceManagerStringByType(string name, CultureInfo culture, Type resourceType, string defaultValue = "")
        {
            var result = string.Empty;
            try
            {
                var valueName = name;
                if (string.IsNullOrEmpty(ResourceManager.BaseName))
                {
                    valueName = resourceType.FullName + "." + name;
                }
                result = ResourceManager.GetString(valueName, culture);
                //We expect to receive string value, not null. If null comes means we have no such value at all and thus we put default value.
                if (result == null)
                    result = defaultValue;
            }
            catch (Exception)
            {
                result = defaultValue;
            }
            return result;
        }

        /// <summary>
        /// Resources the manager get string.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.String.</returns>
        private static string ResourceManagerGetString(string name, CultureInfo culture, string defaultValue = "")
        {
            return ReadResourceManagerStringByType(name, culture, typeof(Resources), defaultValue);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resources"/> class.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public Resources()
        {
        }

        /// <summary>
        /// Returns the cached ResourceManager instance used by this class.
        /// </summary>
        /// <value>The resource manager.</value>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    ResourceManager temp = DependencyResolver.Current.GetService<ResourceManager>();
                    if(temp == null)
                        temp = new FakeResourceManager();
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        /// Overrides the current thread's CurrentUICulture property for all
        /// resource lookups using this strongly typed resource class.
        /// </summary>
        /// <value>The culture.</value>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        public static string GetString(string resourceName, string defaultValue)
        {
            return ResourceManagerGetString(resourceName, resourceCulture, defaultValue);
        }

        /// <summary>
        /// Looks up a localized string similar to Localization's Value was saved!.
        /// </summary>
        /// <value>The UI text Localization saved.</value>
        public static string UIText_Localizations_InlineSaved
        {
            get
            {
                return ResourceManagerGetString("UIText_Localizations_InlineSaved", resourceCulture, "Localization Saved");
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Localization's Value was not saved!.
        /// </summary>
        /// <value>The UI text Localization was not saved.</value>
        public static string UIText_Localizations_InlineSaveError
        {
            get
            {
                return ResourceManagerGetString("UIText_Localizations_InlineSaveError", resourceCulture, "Error happened while saving localization");
            }
        }

        /// <summary>
        /// Looks up a localized string similar to A user with email {0} is not registered.
        /// </summary>
        /// <value>The account user with email not registered.</value>
        public static string Account_UserWithEmail_NotRegistered
        {
            get
            {
                return ResourceManagerGetString("Account_UserWithEmail_NotRegistered", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Keep view file {0} is not registered.
        /// </summary>
        /// <value>The account user with email not registered.</value>
        public static string FieldLabel_ContentNode_KeepViewFile
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_KeepViewFile", resourceCulture, "Keep view file?");
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to Your application description page..
        /// </summary>
        /// <value>The code text about application description.</value>
        public static string CodeText_AboutApplicationDescription
        {
            get
            {
                return ResourceManagerGetString("CodeText_AboutApplicationDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Add user.
        /// </summary>
        /// <value>The code text add user.</value>
        public static string CodeText_AddUser
        {
            get
            {
                return ResourceManagerGetString("CodeText_AddUser", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to User has been added to the this agent..
        /// </summary>
        /// <value>The code text add user success.</value>
        public static string CodeText_AddUserSuccess
        {
            get
            {
                return ResourceManagerGetString("CodeText_AddUserSuccess", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Your contact page..
        /// </summary>
        /// <value>The code text contact page description.</value>
        public static string CodeText_ContactPageDescription
        {
            get
            {
                return ResourceManagerGetString("CodeText_ContactPageDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Contact via.
        /// </summary>
        /// <value>The code text contact via.</value>
        public static string CodeText_ContactVia
        {
            get
            {
                return ResourceManagerGetString("CodeText_ContactVia", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to User has been created and added to this agent..
        /// </summary>
        /// <value>The code text create user success.</value>
        public static string CodeText_CreateUserSuccess
        {
            get
            {
                return ResourceManagerGetString("CodeText_CreateUserSuccess", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to from.
        /// </summary>
        /// <value>The code text from.</value>
        public static string CodeText_From
        {
            get
            {
                return ResourceManagerGetString("CodeText_From", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to User has been removed from agent, but it's still available within list of logins..
        /// </summary>
        /// <value>The code text remove agent user success.</value>
        public static string CodeText_RemoveAgentUserSuccess
        {
            get
            {
                return ResourceManagerGetString("CodeText_RemoveAgentUserSuccess", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Please reset your password by clicking &lt;a href="{0}"&gt;here.&lt;/a&gt;.
        /// </summary>
        /// <value>The code text reset password email.</value>
        public static string CodeText_ResetPasswordEmail
        {
            get
            {
                return ResourceManagerGetString("CodeText_ResetPasswordEmail", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Agent.
        /// </summary>
        /// <value>The entity label agent.</value>
        public static string EntityLabel_Agent
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Agent", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Agent's User.
        /// </summary>
        /// <value>The entity label agent user.</value>
        public static string EntityLabel_AgentUser
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_AgentUser", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attachment.
        /// </summary>
        /// <value>The entity label attachment.</value>
        public static string EntityLabel_Attachment
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Attachment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to History Item.
        /// </summary>
        /// <value>The entity label attachment history.</value>
        public static string EntityLabel_AttachmentHistory
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_AttachmentHistory", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to History Items.
        /// </summary>
        /// <value>The entity label attachment history items.</value>
        public static string EntityLabel_AttachmentHistoryItems
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_AttachmentHistoryItems", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Blog.
        /// </summary>
        /// <value>The entity label blog.</value>
        public static string EntityLabel_Blog
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Blog", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to BlogAuthor.
        /// </summary>
        /// <value>The entity label blog author.</value>
        public static string EntityLabel_BlogAuthor
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_BlogAuthor", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Blog Comment.
        /// </summary>
        /// <value>The entity label blog comment.</value>
        public static string EntityLabel_BlogComment
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_BlogComment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Blog Post.
        /// </summary>
        /// <value>The entity label blog post.</value>
        public static string EntityLabel_BlogPost
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_BlogPost", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Control.
        /// </summary>
        /// <value>The entity label content control.</value>
        public static string EntityLabel_ContentControl
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_ContentControl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Control Type.
        /// </summary>
        /// <value>The type of the entity label content control.</value>
        public static string EntityLabel_ContentControlType
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_ContentControlType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Management.
        /// </summary>
        /// <value>The entity label content management.</value>
        public static string EntityLabel_ContentManagement
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_ContentManagement", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Country.
        /// </summary>
        /// <value>The entity label country.</value>
        public static string EntityLabel_Country
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Country", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Currency.
        /// </summary>
        /// <value>The entity label currency.</value>
        public static string EntityLabel_Currency
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Currency", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Custom configuration.
        /// </summary>
        /// <value>The entity label custom configuration.</value>
        public static string EntityLabel_CustomConfiguration
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_CustomConfiguration", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Document Template.
        /// </summary>
        /// <value>The entity label document template.</value>
        public static string EntityLabel_DocumentTemplate
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_DocumentTemplate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Event Log.
        /// </summary>
        /// <value>The entity label event log.</value>
        public static string EntityLabel_EventLog
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_EventLog", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File System and Media Manager.
        /// </summary>
        /// <value>The entity label file system.</value>
        public static string EntityLabel_FileSystem
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_FileSystem", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Lookup.
        /// </summary>
        /// <value>The entity label lookup.</value>
        public static string EntityLabel_Lookup
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Lookup", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Lookup Value.
        /// </summary>
        /// <value>The entity label lookup value.</value>
        public static string EntityLabel_LookupValue
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_LookupValue", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Messages.
        /// </summary>
        /// <value>The entity label messages.</value>
        public static string EntityLabel_Messages
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Messages", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Module.
        /// </summary>
        /// <value>The entity label module.</value>
        public static string EntityLabel_Module
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Module", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Organization Services.
        /// </summary>
        /// <value>The entity label localization.</value>
        public static string EntityLabel_Localization
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Localization", resourceCulture, "Localization");
            }
        }

        /// <summary>
        /// Looks up a localized string similar to News Letter.
        /// </summary>
        /// <value>The entity label news letter.</value>
        public static string EntityLabel_NewsLetter
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_NewsLetter", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Organization.
        /// </summary>
        /// <value>The entity label organization.</value>
        public static string EntityLabel_Organization
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Organization", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Organization Services.
        /// </summary>
        /// <value>The entity label organization service.</value>
        public static string EntityLabel_OrganizationService
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_OrganizationService", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to User.
        /// </summary>
        /// <value>The entity label organization user.</value>
        public static string EntityLabel_OrganizationUser
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_OrganizationUser", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Property.
        /// </summary>
        /// <value>The entity label property.</value>
        public static string EntityLabel_Property
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Property", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Scheduled Tasks.
        /// </summary>
        /// <value>The entity label scheduled task.</value>
        public static string EntityLabel_ScheduledTask
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_ScheduledTask", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to State.
        /// </summary>
        /// <value>The state of the entity label.</value>
        public static string EntityLabel_State
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_State", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subscriber.
        /// </summary>
        /// <value>The entity label subscriber.</value>
        public static string EntityLabel_Subscriber
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Subscriber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subscription.
        /// </summary>
        /// <value>The entity label subscription.</value>
        public static string EntityLabel_Subscription
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Subscription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflow Action.
        /// </summary>
        /// <value>The entity label workflow action.</value>
        public static string EntityLabel_WorkflowAction
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_WorkflowAction", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflow Action Attribute.
        /// </summary>
        /// <value>The entity label workflow action attribute.</value>
        public static string EntityLabel_WorkflowActionAttribute
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_WorkflowActionAttribute", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflows.
        /// </summary>
        /// <value>The entity label workflow class.</value>
        public static string EntityLabel_WorkflowClass
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_WorkflowClass", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflow Stage.
        /// </summary>
        /// <value>The entity label workflow stage.</value>
        public static string EntityLabel_WorkflowStage
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_WorkflowStage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflow Stage Transition.
        /// </summary>
        /// <value>The entity label workflow stage transitions.</value>
        public static string EntityLabel_WorkflowStageTransitions
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_WorkflowStageTransitions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Both.
        /// </summary>
        /// <value>The enum value attribute direction both.</value>
        public static string EnumValue_AttributeDirection_Both
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeDirection_Both", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Input.
        /// </summary>
        /// <value>The enum value attribute direction input.</value>
        public static string EnumValue_AttributeDirection_Input
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeDirection_Input", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to None.
        /// </summary>
        /// <value>The enum value attribute direction none.</value>
        public static string EnumValue_AttributeDirection_None
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeDirection_None", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Output.
        /// </summary>
        /// <value>The enum value attribute direction output.</value>
        public static string EnumValue_AttributeDirection_Output
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeDirection_Output", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Currency.
        /// </summary>
        /// <value>The enum value attribute type currency.</value>
        public static string EnumValue_AttributeType_Currency
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeType_Currency", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Date.
        /// </summary>
        /// <value>The enum value attribute type date.</value>
        public static string EnumValue_AttributeType_Date
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeType_Date", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to DateTime.
        /// </summary>
        /// <value>The enum value attribute type date time.</value>
        public static string EnumValue_AttributeType_DateTime
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeType_DateTime", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Email.
        /// </summary>
        /// <value>The enum value attribute type email.</value>
        public static string EnumValue_AttributeType_Email
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeType_Email", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File.
        /// </summary>
        /// <value>The enum value attribute type file.</value>
        public static string EnumValue_AttributeType_File
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeType_File", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to None.
        /// </summary>
        /// <value>The enum value attribute type none.</value>
        public static string EnumValue_AttributeType_None
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeType_None", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Number.
        /// </summary>
        /// <value>The enum value attribute type number.</value>
        public static string EnumValue_AttributeType_Number
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeType_Number", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Text.
        /// </summary>
        /// <value>The enum value attribute type text.</value>
        public static string EnumValue_AttributeType_Text
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeType_Text", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Time.
        /// </summary>
        /// <value>The enum value attribute type time.</value>
        public static string EnumValue_AttributeType_Time
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeType_Time", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Url.
        /// </summary>
        /// <value>The enum value attribute type URL.</value>
        public static string EnumValue_AttributeType_Url
        {
            get
            {
                return ResourceManagerGetString("EnumValue_AttributeType_Url", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to between.
        /// </summary>
        /// <value>The enum value criteria compare operator between.</value>
        public static string EnumValue_CriteriaCompareOperator_Between
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_Between", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to contains.
        /// </summary>
        /// <value>The enum value criteria compare operator contains.</value>
        public static string EnumValue_CriteriaCompareOperator_Contains
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_Contains", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to custom.
        /// </summary>
        /// <value>The enum value criteria compare operator custom.</value>
        public static string EnumValue_CriteriaCompareOperator_Custom
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_Custom", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to end with.
        /// </summary>
        /// <value>The enum value criteria compare operator end with.</value>
        public static string EnumValue_CriteriaCompareOperator_EndWith
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_EndWith", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to =.
        /// </summary>
        /// <value>The enum value criteria compare operator equal.</value>
        public static string EnumValue_CriteriaCompareOperator_Equal
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_Equal", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to is one of.
        /// </summary>
        /// <value>The enum value criteria compare operator is one of.</value>
        public static string EnumValue_CriteriaCompareOperator_IsOneOf
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_IsOneOf", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to &lt;.
        /// </summary>
        /// <value>The enum value criteria compare operator less.</value>
        public static string EnumValue_CriteriaCompareOperator_Less
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_Less", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to &lt;=.
        /// </summary>
        /// <value>The enum value criteria compare operator less equal.</value>
        public static string EnumValue_CriteriaCompareOperator_LessEqual
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_LessEqual", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to &gt;.
        /// </summary>
        /// <value>The enum value criteria compare operator more.</value>
        public static string EnumValue_CriteriaCompareOperator_More
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_More", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to &gt;=.
        /// </summary>
        /// <value>The enum value criteria compare operator more equal.</value>
        public static string EnumValue_CriteriaCompareOperator_MoreEqual
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_MoreEqual", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to None.
        /// </summary>
        /// <value>The enum value criteria compare operator none.</value>
        public static string EnumValue_CriteriaCompareOperator_None
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_None", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to &lt;&gt;.
        /// </summary>
        /// <value>The enum value criteria compare operator not equal.</value>
        public static string EnumValue_CriteriaCompareOperator_NotEqual
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_NotEqual", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to not one of.
        /// </summary>
        /// <value>The enum value criteria compare operator not one of.</value>
        public static string EnumValue_CriteriaCompareOperator_NotOneOf
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_NotOneOf", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to start with.
        /// </summary>
        /// <value>The enum value criteria compare operator start with.</value>
        public static string EnumValue_CriteriaCompareOperator_StartWith
        {
            get
            {
                return ResourceManagerGetString("EnumValue_CriteriaCompareOperator_StartWith", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Agent has no email address.
        /// </summary>
        /// <value>The error text agent has no email.</value>
        public static string ErrorText_AgentHasNoEmail
        {
            get
            {
                return ResourceManagerGetString("ErrorText_AgentHasNoEmail", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Error.
        /// </summary>
        /// <value>The error text error.</value>
        public static string ErrorText_Error
        {
            get
            {
                return ResourceManagerGetString("ErrorText_Error", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Something went wrong, cannot send email. Please contact System Administrator..
        /// </summary>
        /// <value>The error text general cannot send email.</value>
        public static string ErrorText_GeneralCannotSendEmail
        {
            get
            {
                return ResourceManagerGetString("ErrorText_GeneralCannotSendEmail", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Invalid login attempt..
        /// </summary>
        /// <value>The error text invalid login attempt.</value>
        public static string ErrorText_InvalidLoginAttempt
        {
            get
            {
                return ResourceManagerGetString("ErrorText_InvalidLoginAttempt", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Invalid code..
        /// </summary>
        /// <value>The error text invalid verified code.</value>
        public static string ErrorText_InvalidVerifiedCode
        {
            get
            {
                return ResourceManagerGetString("ErrorText_InvalidVerifiedCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to An error has occurred..
        /// </summary>
        /// <value>The error text manage logins generic.</value>
        public static string ErrorText_ManageLoginsGeneric
        {
            get
            {
                return ResourceManagerGetString("ErrorText_ManageLoginsGeneric", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to The new password and confirmation password do not match..
        /// </summary>
        /// <value>The error text new password confirmation.</value>
        public static string ErrorText_NewPasswordConfirmation
        {
            get
            {
                return ResourceManagerGetString("ErrorText_NewPasswordConfirmation", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Agent cannot be created..
        /// </summary>
        /// <value>The error text no agent created.</value>
        public static string ErrorText_NoAgentCreated
        {
            get
            {
                return ResourceManagerGetString("ErrorText_NoAgentCreated", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No agent details found..
        /// </summary>
        /// <value>The error text no agent found.</value>
        public static string ErrorText_NoAgentFound
        {
            get
            {
                return ResourceManagerGetString("ErrorText_NoAgentFound", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to User cannot be created for an agent..
        /// </summary>
        /// <value>The error text no agent user created.</value>
        public static string ErrorText_NoAgentUserCreated
        {
            get
            {
                return ResourceManagerGetString("ErrorText_NoAgentUserCreated", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cannot register user - default organization is not set. Please contact system administratot..
        /// </summary>
        /// <value>The error text no default organization.</value>
        public static string ErrorText_NoDefaultOrganization
        {
            get
            {
                return ResourceManagerGetString("ErrorText_NoDefaultOrganization", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No email request received..
        /// </summary>
        /// <value>The error text no email request.</value>
        public static string ErrorText_NoEmailRequest
        {
            get
            {
                return ResourceManagerGetString("ErrorText_NoEmailRequest", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No mailing service configured..
        /// </summary>
        /// <value>The error text no mail service configured.</value>
        public static string ErrorText_NoMailServiceConfigured
        {
            get
            {
                return ResourceManagerGetString("ErrorText_NoMailServiceConfigured", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Page rename could not be performed..
        /// </summary>
        /// <value>The error text no page renamed.</value>
        public static string ErrorText_NoPageRenamed
        {
            get
            {
                return ResourceManagerGetString("ErrorText_NoPageRenamed", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Static HTML is not allowed on the root of the web site. Please choose parent folder for it..
        /// </summary>
        /// <value>The error text no static HTML allowed.</value>
        public static string ErrorText_NoStaticHtmlAllowed
        {
            get
            {
                return ResourceManagerGetString("ErrorText_NoStaticHtmlAllowed", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to The {0} must be at least {2} characters long..
        /// </summary>
        /// <value>The length of the error text password.</value>
        public static string ErrorText_PasswordLength
        {
            get
            {
                return ResourceManagerGetString("ErrorText_PasswordLength", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Failed to verify phone.
        /// </summary>
        /// <value>The error text verify phone number failed.</value>
        public static string ErrorText_VerifyPhoneNumberFailed
        {
            get
            {
                return ResourceManagerGetString("ErrorText_VerifyPhoneNumberFailed", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cannot add workflow action {0}, it is already present as action item..
        /// </summary>
        /// <value>The error text workflow action already workflow transtion action.</value>
        public static string ErrorText_WorkflowActionAlreadyWorkflowTranstionAction
        {
            get
            {
                return ResourceManagerGetString("ErrorText_WorkflowActionAlreadyWorkflowTranstionAction", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address 1.
        /// </summary>
        /// <value>The field label agent address line1.</value>
        public static string FieldLabel_Agent_AddressLine1
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_AddressLine1", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address 2.
        /// </summary>
        /// <value>The field label agent address line2.</value>
        public static string FieldLabel_Agent_AddressLine2
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_AddressLine2", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Mobile.
        /// </summary>
        /// <value>The field label agent cell number.</value>
        public static string FieldLabel_Agent_CellNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_CellNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to City.
        /// </summary>
        /// <value>The field label agent city.</value>
        public static string FieldLabel_Agent_City
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_City", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Country.
        /// </summary>
        /// <value>The field label agent country.</value>
        public static string FieldLabel_Agent_Country
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_Country", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to County.
        /// </summary>
        /// <value>The field label agent county.</value>
        public static string FieldLabel_Agent_County
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_County", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label agent create date.</value>
        public static string FieldLabel_Agent_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label agent created by user.</value>
        public static string FieldLabel_Agent_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label agent description.</value>
        public static string FieldLabel_Agent_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Email.
        /// </summary>
        /// <value>The field label agent email.</value>
        public static string FieldLabel_Agent_Email
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_Email", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Fax.
        /// </summary>
        /// <value>The field label agent fax number.</value>
        public static string FieldLabel_Agent_FaxNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_FaxNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to First Name.
        /// </summary>
        /// <value>The first name of the field label agent.</value>
        public static string FieldLabel_Agent_FirstName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_FirstName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address.
        /// </summary>
        /// <value>The field label agent full address.</value>
        public static string FieldLabel_Agent_FullAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_FullAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The full name of the field label agent.</value>
        public static string FieldLabel_Agent_FullName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_FullName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Id.
        /// </summary>
        /// <value>The field label agent identifier.</value>
        public static string FieldLabel_Agent_Id
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_Id", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Insurance Id.
        /// </summary>
        /// <value>The field label agent insurance identifier.</value>
        public static string FieldLabel_Agent_InsuranceId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_InsuranceId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label agent last modified by user.</value>
        public static string FieldLabel_Agent_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label agent last modified date.</value>
        public static string FieldLabel_Agent_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Name.
        /// </summary>
        /// <value>The last name of the field label agent.</value>
        public static string FieldLabel_Agent_LastName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_LastName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Licence Id.
        /// </summary>
        /// <value>The field label agent licence identifier.</value>
        public static string FieldLabel_Agent_LicenceId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_LicenceId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Middle Name.
        /// </summary>
        /// <value>The name of the field label agent middle.</value>
        public static string FieldLabel_Agent_MiddleName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_MiddleName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Personal Id.
        /// </summary>
        /// <value>The field label agent personal identifier.</value>
        public static string FieldLabel_Agent_PersonalId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_PersonalId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Phone.
        /// </summary>
        /// <value>The field label agent phone number.</value>
        public static string FieldLabel_Agent_PhoneNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_PhoneNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to State.
        /// </summary>
        /// <value>The state of the field label agent.</value>
        public static string FieldLabel_Agent_State
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_State", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Tax Id.
        /// </summary>
        /// <value>The field label agent tax identifier.</value>
        public static string FieldLabel_Agent_TaxId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_TaxId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Zip.
        /// </summary>
        /// <value>The field label agent zip.</value>
        public static string FieldLabel_Agent_Zip
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Agent_Zip", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Token Expires At.
        /// </summary>
        /// <value>The field label attachment access token expires at.</value>
        public static string FieldLabel_Attachment_AccessTokenExpiresAt
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_AccessTokenExpiresAt", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Allowed to Roles.
        /// </summary>
        /// <value>The field label attachment allowed to roles.</value>
        public static string FieldLabel_Attachment_AllowedToRoles
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_AllowedToRoles", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Alt Text.
        /// </summary>
        /// <value>The field label attachment alt text.</value>
        public static string FieldLabel_Attachment_AltText
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_AltText", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Type.
        /// </summary>
        /// <value>The type of the field label attachment attachment.</value>
        public static string FieldLabel_Attachment_AttachmentType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_AttachmentType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label attachment create date.</value>
        public static string FieldLabel_Attachment_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label attachment created by user.</value>
        public static string FieldLabel_Attachment_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label attachment description.</value>
        public static string FieldLabel_Attachment_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Upload File.
        /// </summary>
        /// <value>The field label attachment file.</value>
        public static string FieldLabel_Attachment_File
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_File", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Id.
        /// </summary>
        /// <value>The field label attachment identifier.</value>
        public static string FieldLabel_Attachment_Id
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_Id", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Secured?.
        /// </summary>
        /// <value>The field label attachment is secured.</value>
        public static string FieldLabel_Attachment_IsSecured
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_IsSecured", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Keywords.
        /// </summary>
        /// <value>The field label attachment keywords.</value>
        public static string FieldLabel_Attachment_Keywords
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_Keywords", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label attachment last modified by user.</value>
        public static string FieldLabel_Attachment_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label attachment last modified date.</value>
        public static string FieldLabel_Attachment_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Size.
        /// </summary>
        /// <value>The length of the field label attachment.</value>
        public static string FieldLabel_Attachment_Length
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_Length", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Mime Type.
        /// </summary>
        /// <value>The type of the field label attachment MIME.</value>
        public static string FieldLabel_Attachment_MimeType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_MimeType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label attachment.</value>
        public static string FieldLabel_Attachment_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Path Aliases.
        /// </summary>
        /// <value>The field label attachment path aliases.</value>
        public static string FieldLabel_Attachment_PathAliases
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_PathAliases", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Path Url.
        /// </summary>
        /// <value>The field label attachment path URL.</value>
        public static string FieldLabel_Attachment_PathUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_PathUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Access Token.
        /// </summary>
        /// <value>The field label attachment public access token.</value>
        public static string FieldLabel_Attachment_PublicAccessToken
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_PublicAccessToken", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Published.
        /// </summary>
        /// <value>The field label attachment published.</value>
        public static string FieldLabel_Attachment_Published
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_Published", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Publish From.
        /// </summary>
        /// <value>The field label attachment publish from.</value>
        public static string FieldLabel_Attachment_PublishFrom
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_PublishFrom", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Publish To.
        /// </summary>
        /// <value>The field label attachment publish to.</value>
        public static string FieldLabel_Attachment_PublishTo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_PublishTo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Status.
        /// </summary>
        /// <value>The field label attachment status.</value>
        public static string FieldLabel_Attachment_Status
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_Status", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Status Date.
        /// </summary>
        /// <value>The field label attachment status date.</value>
        public static string FieldLabel_Attachment_StatusDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_StatusDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Thumbnail.
        /// </summary>
        /// <value>The field label attachment thumbnail.</value>
        public static string FieldLabel_Attachment_Thumbnail
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_Thumbnail", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Title Text.
        /// </summary>
        /// <value>The field label attachment title text.</value>
        public static string FieldLabel_Attachment_TitleText
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachment_TitleText", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attachment.
        /// </summary>
        /// <value>The field label attachment history attachment.</value>
        public static string FieldLabel_AttachmentHistory_Attachment
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_AttachmentHistory_Attachment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label attachment history create date.</value>
        public static string FieldLabel_AttachmentHistory_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_AttachmentHistory_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label attachment history created by user.</value>
        public static string FieldLabel_AttachmentHistory_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_AttachmentHistory_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File Name.
        /// </summary>
        /// <value>The name of the field label attachment history file.</value>
        public static string FieldLabel_AttachmentHistory_FileName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_AttachmentHistory_FileName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File Path.
        /// </summary>
        /// <value>The field label attachment history file path.</value>
        public static string FieldLabel_AttachmentHistory_FilePath
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_AttachmentHistory_FilePath", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Id.
        /// </summary>
        /// <value>The field label attachment history identifier.</value>
        public static string FieldLabel_AttachmentHistory_Id
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_AttachmentHistory_Id", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label attachment history last modified by user.</value>
        public static string FieldLabel_AttachmentHistory_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_AttachmentHistory_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label attachment history last modified date.</value>
        public static string FieldLabel_AttachmentHistory_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_AttachmentHistory_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Length.
        /// </summary>
        /// <value>The length of the field label attachment history.</value>
        public static string FieldLabel_AttachmentHistory_Length
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_AttachmentHistory_Length", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File Description.
        /// </summary>
        /// <value>The field label bap file description.</value>
        public static string FieldLabel_BAPFile_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFile_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified.
        /// </summary>
        /// <value>The field label bap file last modified.</value>
        public static string FieldLabel_BAPFile_LastModified
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFile_LastModified", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Mime Type.
        /// </summary>
        /// <value>The type of the field label bap file MIME.</value>
        public static string FieldLabel_BAPFile_MimeType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFile_MimeType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File Name.
        /// </summary>
        /// <value>The name of the field label bap file.</value>
        public static string FieldLabel_BAPFile_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFile_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Size.
        /// </summary>
        /// <value>The size of the field label bap file.</value>
        public static string FieldLabel_BAPFile_Size
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFile_Size", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File Type.
        /// </summary>
        /// <value>The type of the field label bap file.</value>
        public static string FieldLabel_BAPFile_Type
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFile_Type", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File Filter.
        /// </summary>
        /// <value>The field label bap file system folder current file filter.</value>
        public static string FieldLabel_BAPFileSystemFolder_CurrentFileFilter
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFileSystemFolder_CurrentFileFilter", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File Sort.
        /// </summary>
        /// <value>The field label bap file system folder current file sort.</value>
        public static string FieldLabel_BAPFileSystemFolder_CurrentFileSort
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFileSystemFolder_CurrentFileSort", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Current Folder.
        /// </summary>
        /// <value>The field label bap file system folder current folder.</value>
        public static string FieldLabel_BAPFileSystemFolder_CurrentFolder
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFileSystemFolder_CurrentFolder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Current Folder Files.
        /// </summary>
        /// <value>The field label bap file system folder current folder files.</value>
        public static string FieldLabel_BAPFileSystemFolder_CurrentFolderFiles
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFileSystemFolder_CurrentFolderFiles", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Files Per Page.
        /// </summary>
        /// <value>The field label bap file system folder files per page.</value>
        public static string FieldLabel_BAPFileSystemFolder_FilesPerPage
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFileSystemFolder_FilesPerPage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Page Count.
        /// </summary>
        /// <value>The field label bap file system folder page count.</value>
        public static string FieldLabel_BAPFileSystemFolder_PageCount
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFileSystemFolder_PageCount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Page #.
        /// </summary>
        /// <value>The field label bap file system folder page number.</value>
        public static string FieldLabel_BAPFileSystemFolder_PageNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFileSystemFolder_PageNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Root Folder.
        /// </summary>
        /// <value>The field label bap file system folder root folders.</value>
        public static string FieldLabel_BAPFileSystemFolder_RootFolders
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFileSystemFolder_RootFolders", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Child Folders.
        /// </summary>
        /// <value>The field label bap folder child folders.</value>
        public static string FieldLabel_BAPFolder_ChildFolders
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFolder_ChildFolders", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Folder Description.
        /// </summary>
        /// <value>The field label bap folder description.</value>
        public static string FieldLabel_BAPFolder_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFolder_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Folder Relative Path.
        /// </summary>
        /// <value>The field label bap folder full relative path.</value>
        public static string FieldLabel_BAPFolder_FullRelativePath
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFolder_FullRelativePath", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Folder Name.
        /// </summary>
        /// <value>The name of the field label bap folder.</value>
        public static string FieldLabel_BAPFolder_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFolder_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Parent Folder.
        /// </summary>
        /// <value>The field label bap folder parent folder.</value>
        public static string FieldLabel_BAPFolder_ParentFolder
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BAPFolder_ParentFolder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Add a Comment.
        /// </summary>
        /// <value>The field label blog add comment.</value>
        public static string FieldLabel_Blog_AddComment
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_AddComment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Archives.
        /// </summary>
        /// <value>The field label blog archives.</value>
        public static string FieldLabel_Blog_Archives
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Archives", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to BAP Blog.
        /// </summary>
        /// <value>The field label blog bap blog.</value>
        public static string FieldLabel_Blog_BAPBlog
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_BAPBlog", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to BAP Software Ltd..
        /// </summary>
        /// <value>The field label blog bap software.</value>
        public static string FieldLabel_Blog_BAPSoftware
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_BAPSoftware", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Author.
        /// </summary>
        /// <value>The field label blog blog author.</value>
        public static string FieldLabel_Blog_BlogAuthor
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_BlogAuthor", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Comments.
        /// </summary>
        /// <value>The field label blog blog comments.</value>
        public static string FieldLabel_Blog_BlogComments
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_BlogComments", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Posts.
        /// </summary>
        /// <value>The field label blog blog posts.</value>
        public static string FieldLabel_Blog_BlogPosts
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_BlogPosts", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Blogs.
        /// </summary>
        /// <value>The field label blog blogs.</value>
        public static string FieldLabel_Blog_Blogs
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Blogs", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Categories.
        /// </summary>
        /// <value>The field label blog categories.</value>
        public static string FieldLabel_Blog_Categories
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Categories", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Comment.
        /// </summary>
        /// <value>The field label blog comment.</value>
        public static string FieldLabel_Blog_Comment
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Comment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Like or Dislike.
        /// </summary>
        /// <value>The field label blog comment like or dislike.</value>
        public static string FieldLabel_Blog_Comment_LikeOrDislike
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Comment_LikeOrDislike", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Notify me of follow-up comments by email.
        /// </summary>
        /// <value>The field label blog comment notify me.</value>
        public static string FieldLabel_Blog_Comment_NotifyMe
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Comment_NotifyMe", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Reply.
        /// </summary>
        /// <value>The field label blog comment reply.</value>
        public static string FieldLabel_Blog_Comment_Reply
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Comment_Reply", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Submit Comment.
        /// </summary>
        /// <value>The field label blog comment submit.</value>
        public static string FieldLabel_Blog_Comment_Submit
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Comment_Submit", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Your Name.
        /// </summary>
        /// <value>The name of the field label blog comment your.</value>
        public static string FieldLabel_Blog_Comment_YourName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Comment_YourName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Your Title.
        /// </summary>
        /// <value>The field label blog comment your title.</value>
        public static string FieldLabel_Blog_Comment_YourTitle
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Comment_YourTitle", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Contact us.
        /// </summary>
        /// <value>The field label blog contact us.</value>
        public static string FieldLabel_Blog_ContactUs
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_ContactUs", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Create At.
        /// </summary>
        /// <value>The field label blog create date.</value>
        public static string FieldLabel_Blog_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label blog created by user.</value>
        public static string FieldLabel_Blog_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label blog description.</value>
        public static string FieldLabel_Blog_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Maximum 4000 characters allowed.
        /// </summary>
        /// <value>The field label blog description maximum characters.</value>
        public static string FieldLabel_Blog_Description_MaxCharacters
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Description_MaxCharacters", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Follow Us.
        /// </summary>
        /// <value>The field label blog follow us.</value>
        public static string FieldLabel_Blog_FollowUs
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_FollowUs", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label blog last modified by user.</value>
        public static string FieldLabel_Blog_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label blog last modified date.</value>
        public static string FieldLabel_Blog_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Image.
        /// </summary>
        /// <value>The field label blog main image URL.</value>
        public static string FieldLabel_Blog_MainImageUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_MainImageUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label blog.</value>
        public static string FieldLabel_Blog_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Posted By.
        /// </summary>
        /// <value>The field label blog posted by.</value>
        public static string FieldLabel_Blog_PostedBy
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_PostedBy", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Powered by BAP-Software.
        /// </summary>
        /// <value>The field label blog powered by.</value>
        public static string FieldLabel_Blog_PoweredBy
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_PoweredBy", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Read More.
        /// </summary>
        /// <value>The field label blog read more.</value>
        public static string FieldLabel_Blog_ReadMore
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_ReadMore", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Recent Post.
        /// </summary>
        /// <value>The field label blog recent post.</value>
        public static string FieldLabel_Blog_RecentPost
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_RecentPost", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Search Our Stories....
        /// </summary>
        /// <value>The field label blog search.</value>
        public static string FieldLabel_Blog_Search
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Search", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Search for:.
        /// </summary>
        /// <value>The field label blog search for.</value>
        public static string FieldLabel_Blog_SearchFor
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_SearchFor", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label blog short description.</value>
        public static string FieldLabel_Blog_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Tags.
        /// </summary>
        /// <value>The field label blog tags.</value>
        public static string FieldLabel_Blog_Tags
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Tags", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Uncategorized.
        /// </summary>
        /// <value>The field label blog uncategorized.</value>
        public static string FieldLabel_Blog_Uncategorized
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Blog_Uncategorized", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label blog author create date.</value>
        public static string FieldLabel_BlogAuthor_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogAuthor_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label blog author created by user.</value>
        public static string FieldLabel_BlogAuthor_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogAuthor_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Email.
        /// </summary>
        /// <value>The field label blog author email.</value>
        public static string FieldLabel_BlogAuthor_Email
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogAuthor_Email", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to First Name.
        /// </summary>
        /// <value>The first name of the field label blog author.</value>
        public static string FieldLabel_BlogAuthor_FirstName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogAuthor_FirstName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label blog author last modified by user.</value>
        public static string FieldLabel_BlogAuthor_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogAuthor_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label blog author last modified date.</value>
        public static string FieldLabel_BlogAuthor_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogAuthor_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Name.
        /// </summary>
        /// <value>The last name of the field label blog author.</value>
        public static string FieldLabel_BlogAuthor_LastName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogAuthor_LastName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to LoginUser.
        /// </summary>
        /// <value>The field label blog author login.</value>
        public static string FieldLabel_BlogAuthor_Login
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogAuthor_Login", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Nick Name.
        /// </summary>
        /// <value>The name of the field label blog author nick.</value>
        public static string FieldLabel_BlogAuthor_NickName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogAuthor_NickName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Web Site.
        /// </summary>
        /// <value>The field label blog author web site.</value>
        public static string FieldLabel_BlogAuthor_WebSite
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogAuthor_WebSite", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to You need to sign-up to leave comments.
        /// </summary>
        /// <value>The field label blog comment authentication needed.</value>
        public static string FieldLabel_BlogComment_AuthNeeded
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_AuthNeeded", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Author.
        /// </summary>
        /// <value>The field label blog comment author.</value>
        public static string FieldLabel_BlogComment_Author
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_Author", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Blog.
        /// </summary>
        /// <value>The field label blog comment blog.</value>
        public static string FieldLabel_BlogComment_Blog
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_Blog", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Comment author user.
        /// </summary>
        /// <value>The field label blog comment comment author user.</value>
        public static string FieldLabel_BlogComment_CommentAuthorUser
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_CommentAuthorUser", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label blog comment create date.</value>
        public static string FieldLabel_BlogComment_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label blog comment created by user.</value>
        public static string FieldLabel_BlogComment_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Dislike number.
        /// </summary>
        /// <value>The field label blog comment dislike number.</value>
        public static string FieldLabel_BlogComment_DislikeNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_DislikeNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label blog comment last modified by user.</value>
        public static string FieldLabel_BlogComment_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified.
        /// </summary>
        /// <value>The field label blog comment last modified date.</value>
        public static string FieldLabel_BlogComment_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Like number.
        /// </summary>
        /// <value>The field label blog comment like number.</value>
        public static string FieldLabel_BlogComment_LikeNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_LikeNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Notify author by email.
        /// </summary>
        /// <value>The field label blog comment notify author by email.</value>
        public static string FieldLabel_BlogComment_NotifyAuthorByEmail
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_NotifyAuthorByEmail", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Text.
        /// </summary>
        /// <value>The field label blog comment text.</value>
        public static string FieldLabel_BlogComment_Text
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_Text", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Maximum 4000 characters allowed.
        /// </summary>
        /// <value>The field label blog comment text maximum characters.</value>
        public static string FieldLabel_BlogComment_Text_MaxCharacters
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_Text_MaxCharacters", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Title.
        /// </summary>
        /// <value>The field label blog comment title.</value>
        public static string FieldLabel_BlogComment_Title
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogComment_Title", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Blog.
        /// </summary>
        /// <value>The field label blog post blog.</value>
        public static string FieldLabel_BlogPost_Blog
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogPost_Blog", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Blog Comments.
        /// </summary>
        /// <value>The field label blog post blog comments.</value>
        public static string FieldLabel_BlogPost_BlogComments
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogPost_BlogComments", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Blog post.
        /// </summary>
        /// <value>The field label blog post blog post.</value>
        public static string FieldLabel_BlogPost_BlogPost
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogPost_BlogPost", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Create date.
        /// </summary>
        /// <value>The field label blog post create date.</value>
        public static string FieldLabel_BlogPost_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogPost_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label blog post created by user.</value>
        public static string FieldLabel_BlogPost_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogPost_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Modified By.
        /// </summary>
        /// <value>The name of the field label blog post last modified by user.</value>
        public static string FieldLabel_BlogPost_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogPost_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last modified date.
        /// </summary>
        /// <value>The field label blog post last modified date.</value>
        public static string FieldLabel_BlogPost_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogPost_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Main Image Url.
        /// </summary>
        /// <value>The field label blog post main image URL.</value>
        public static string FieldLabel_BlogPost_MainImageUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogPost_MainImageUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Blog Images.
        /// </summary>
        /// <value>The field label blog post post images.</value>
        public static string FieldLabel_BlogPost_PostImages
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogPost_PostImages", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short description.
        /// </summary>
        /// <value>The field label blog post short description.</value>
        public static string FieldLabel_BlogPost_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogPost_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Text.
        /// </summary>
        /// <value>The field label blog post text.</value>
        public static string FieldLabel_BlogPost_Text
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogPost_Text", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Maximum 4000 characters allowed.
        /// </summary>
        /// <value>The field label blog post text maximum characters.</value>
        public static string FieldLabel_BlogPost_Text_MaxCharacters
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogPost_Text_MaxCharacters", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Title.
        /// </summary>
        /// <value>The field label blog post title.</value>
        public static string FieldLabel_BlogPost_Title
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BlogPost_Title", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Selected Provider.
        /// </summary>
        /// <value>The field label code selected provider.</value>
        public static string FieldLabel_Code_SelectedProvider
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Code_SelectedProvider", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created.
        /// </summary>
        /// <value>The field label common create date.</value>
        public static string FieldLabel_Common_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Common_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created by.
        /// </summary>
        /// <value>The field label common created by.</value>
        public static string FieldLabel_Common_CreatedBy
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Common_CreatedBy", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created by.
        /// </summary>
        /// <value>The name of the field label common created by user.</value>
        public static string FieldLabel_Common_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Common_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label common description.</value>
        public static string FieldLabel_Common_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Common_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last modified by.
        /// </summary>
        /// <value>The field label common last modified by.</value>
        public static string FieldLabel_Common_LastModifiedBy
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Common_LastModifiedBy", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last modified by.
        /// </summary>
        /// <value>The name of the field label common last modified by user.</value>
        public static string FieldLabel_Common_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Common_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last modified.
        /// </summary>
        /// <value>The field label common last modified date.</value>
        public static string FieldLabel_Common_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Common_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label common.</value>
        public static string FieldLabel_Common_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Common_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short name.
        /// </summary>
        /// <value>The short name of the field label common.</value>
        public static string FieldLabel_Common_ShortName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Common_ShortName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to HTML Tag.
        /// </summary>
        /// <value>The field label content control container tag.</value>
        public static string FieldLabel_ContentControl_ContainerTag
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControl_ContainerTag", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content After.
        /// </summary>
        /// <value>The field label content control content after.</value>
        public static string FieldLabel_ContentControl_ContentAfter
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControl_ContentAfter", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Before.
        /// </summary>
        /// <value>The field label content control content before.</value>
        public static string FieldLabel_ContentControl_ContentBefore
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControl_ContentBefore", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Holder Field Id.
        /// </summary>
        /// <value>The field label content control content holder field identifier.</value>
        public static string FieldLabel_ContentControl_ContentHolderFieldId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControl_ContentHolderFieldId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Dialog Content.
        /// </summary>
        /// <value>The content of the field label content control dialog.</value>
        public static string FieldLabel_ContentControl_DialogContent
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControl_DialogContent", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Use CKEditor?.
        /// </summary>
        /// <value>The field label content control has ck editor.</value>
        public static string FieldLabel_ContentControl_HasCKEditor
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControl_HasCKEditor", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Has dialog?.
        /// </summary>
        /// <value>The field label content control has dialog.</value>
        public static string FieldLabel_ContentControl_HasDialog
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControl_HasDialog", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Icon CSS.
        /// </summary>
        /// <value>The field label content control icon CSS.</value>
        public static string FieldLabel_ContentControl_IconCss
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControl_IconCss", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Javascript Content.
        /// </summary>
        /// <value>The content of the field label content control java script.</value>
        public static string FieldLabel_ContentControl_JavaScriptContent
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControl_JavaScriptContent", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Main CSS.
        /// </summary>
        /// <value>The field label content control main CSS.</value>
        public static string FieldLabel_ContentControl_MainCss
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControl_MainCss", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Control Type.
        /// </summary>
        /// <value>The type of the field label content control.</value>
        public static string FieldLabel_ContentControl_Type
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControl_Type", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Caption.
        /// </summary>
        /// <value>The field label content control parameter caption.</value>
        public static string FieldLabel_ContentControlParameter_Caption
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_Caption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View Control.
        /// </summary>
        /// <value>The field label content control parameter content view control.</value>
        public static string FieldLabel_ContentControlParameter_ContentViewControl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_ContentViewControl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Control Id.
        /// </summary>
        /// <value>The field label content control parameter content view control identifier.</value>
        public static string FieldLabel_ContentControlParameter_ContentViewControlId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_ContentViewControlId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label content control parameter create date.</value>
        public static string FieldLabel_ContentControlParameter_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label content control parameter created by user.</value>
        public static string FieldLabel_ContentControlParameter_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to CSS Class.
        /// </summary>
        /// <value>The field label content control parameter CSS class.</value>
        public static string FieldLabel_ContentControlParameter_CssClass
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_CssClass", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Data Source.
        /// </summary>
        /// <value>The field label content control parameter data source.</value>
        public static string FieldLabel_ContentControlParameter_DataSource
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_DataSource", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Data Type.
        /// </summary>
        /// <value>The type of the field label content control parameter data.</value>
        public static string FieldLabel_ContentControlParameter_DataType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_DataType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Default Error Message.
        /// </summary>
        /// <value>The field label content control parameter default error message.</value>
        public static string FieldLabel_ContentControlParameter_DefaultErrorMessage
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_DefaultErrorMessage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Default Value.
        /// </summary>
        /// <value>The field label content control parameter default value.</value>
        public static string FieldLabel_ContentControlParameter_DefaultValue
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_DefaultValue", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label content control parameter description.</value>
        public static string FieldLabel_ContentControlParameter_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Form Control.
        /// </summary>
        /// <value>The field label content control parameter form control.</value>
        public static string FieldLabel_ContentControlParameter_FormControl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_FormControl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Read only?.
        /// </summary>
        /// <value>The field label content control parameter is read only.</value>
        public static string FieldLabel_ContentControlParameter_IsReadOnly
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_IsReadOnly", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Required?.
        /// </summary>
        /// <value>The field label content control parameter is required.</value>
        public static string FieldLabel_ContentControlParameter_IsRequired
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_IsRequired", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Visible?.
        /// </summary>
        /// <value>The field label content control parameter is visible.</value>
        public static string FieldLabel_ContentControlParameter_IsVisible
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_IsVisible", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label content control parameter last modified by user.</value>
        public static string FieldLabel_ContentControlParameter_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label content control parameter last modified date.</value>
        public static string FieldLabel_ContentControlParameter_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label content control parameter.</value>
        public static string FieldLabel_ContentControlParameter_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Parameter Name.
        /// </summary>
        /// <value>The name of the field label content control parameter parameter.</value>
        public static string FieldLabel_ContentControlParameter_ParameterName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_ParameterName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Place Holder.
        /// </summary>
        /// <value>The field label content control parameter place holder.</value>
        public static string FieldLabel_ContentControlParameter_PlaceHolder
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_PlaceHolder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label content control parameter short description.</value>
        public static string FieldLabel_ContentControlParameter_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentControlParameter_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Node.
        /// </summary>
        /// <value>The field label content localization content node.</value>
        public static string FieldLabel_ContentLocalization_ContentNode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentLocalization_ContentNode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Node Id.
        /// </summary>
        /// <value>The field label content localization content node identifier.</value>
        public static string FieldLabel_ContentLocalization_ContentNodeId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentLocalization_ContentNodeId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label content localization create date.</value>
        public static string FieldLabel_ContentLocalization_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentLocalization_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label content localization created by user.</value>
        public static string FieldLabel_ContentLocalization_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentLocalization_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Culture.
        /// </summary>
        /// <value>The field label content localization culture code.</value>
        public static string FieldLabel_ContentLocalization_CultureCode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentLocalization_CultureCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Default?.
        /// </summary>
        /// <value>The field label content localization is default.</value>
        public static string FieldLabel_ContentLocalization_IsDefault
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentLocalization_IsDefault", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label content localization last modified by user.</value>
        public static string FieldLabel_ContentLocalization_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentLocalization_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label content localization last modified date.</value>
        public static string FieldLabel_ContentLocalization_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentLocalization_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label content localization.</value>
        public static string FieldLabel_ContentLocalization_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentLocalization_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Text.
        /// </summary>
        /// <value>The field label content localization text.</value>
        public static string FieldLabel_ContentLocalization_Text
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentLocalization_Text", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Action.
        /// </summary>
        /// <value>The field label content node action.</value>
        public static string FieldLabel_ContentNode_Action
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_Action", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Action Parameters.
        /// </summary>
        /// <value>The field label content node action parameters.</value>
        public static string FieldLabel_ContentNode_ActionParams
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_ActionParams", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Alias.
        /// </summary>
        /// <value>The field label content node alias.</value>
        public static string FieldLabel_ContentNode_Alias
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_Alias", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Alias Path.
        /// </summary>
        /// <value>The field label content node alias path.</value>
        public static string FieldLabel_ContentNode_AliasPath
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_AliasPath", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Allow children?.
        /// </summary>
        /// <value>The field label content node allow children.</value>
        public static string FieldLabel_ContentNode_AllowChildren
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_AllowChildren", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Routing Area.
        /// </summary>
        /// <value>The field label content node area.</value>
        public static string FieldLabel_ContentNode_Area
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_Area", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Children.
        /// </summary>
        /// <value>The field label content node child nodes.</value>
        public static string FieldLabel_ContentNode_ChildNodes
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_ChildNodes", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Author.
        /// </summary>
        /// <value>The field label content node content author.</value>
        public static string FieldLabel_ContentNode_ContentAuthor
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_ContentAuthor", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Description.
        /// </summary>
        /// <value>The field label content node content description.</value>
        public static string FieldLabel_ContentNode_ContentDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_ContentDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Keywords.
        /// </summary>
        /// <value>The field label content node content keywords.</value>
        public static string FieldLabel_ContentNode_ContentKeywords
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_ContentKeywords", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Tag Group.
        /// </summary>
        /// <value>The field label content node content tag group.</value>
        public static string FieldLabel_ContentNode_ContentTagGroup
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_ContentTagGroup", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Tags.
        /// </summary>
        /// <value>The field label content node content tags.</value>
        public static string FieldLabel_ContentNode_ContentTags
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_ContentTags", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Title.
        /// </summary>
        /// <value>The field label content node content title.</value>
        public static string FieldLabel_ContentNode_ContentTitle
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_ContentTitle", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Controller.
        /// </summary>
        /// <value>The field label content node controller.</value>
        public static string FieldLabel_ContentNode_Controller
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_Controller", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label content node create date.</value>
        public static string FieldLabel_ContentNode_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label content node created by user.</value>
        public static string FieldLabel_ContentNode_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Culture.
        /// </summary>
        /// <value>The field label content node culture.</value>
        public static string FieldLabel_ContentNode_Culture
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_Culture", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Defalt CSS.
        /// </summary>
        /// <value>The field label content node default CSS.</value>
        public static string FieldLabel_ContentNode_DefaultCss
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_DefaultCss", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label content node description.</value>
        public static string FieldLabel_ContentNode_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled?.
        /// </summary>
        /// <value>The field label content node enabled.</value>
        public static string FieldLabel_ContentNode_Enabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_Enabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to HTTP Method.
        /// </summary>
        /// <value>The field label content node HTTP method.</value>
        public static string FieldLabel_ContentNode_HttpMethod
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_HttpMethod", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Home page?.
        /// </summary>
        /// <value>The field label content node is home.</value>
        public static string FieldLabel_ContentNode_IsHome
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_IsHome", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label content node last modified by user.</value>
        public static string FieldLabel_ContentNode_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label content node last modified date.</value>
        public static string FieldLabel_ContentNode_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Layout Path.
        /// </summary>
        /// <value>The field label content node layout path.</value>
        public static string FieldLabel_ContentNode_LayoutPath
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_LayoutPath", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Menu Caption.
        /// </summary>
        /// <value>The field label content node menu caption.</value>
        public static string FieldLabel_ContentNode_MenuCaption
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_MenuCaption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Menu Clickable?.
        /// </summary>
        /// <value>The field label content node menu clicable.</value>
        public static string FieldLabel_ContentNode_MenuClicable
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_MenuClicable", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Menu Extra Attributes.
        /// </summary>
        /// <value>The field label content node menu extra attributes.</value>
        public static string FieldLabel_ContentNode_MenuExtraAttributes
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_MenuExtraAttributes", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Menu Icon.
        /// </summary>
        /// <value>The field label content node menu icon.</value>
        public static string FieldLabel_ContentNode_MenuIcon
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_MenuIcon", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Menu Sort Order.
        /// </summary>
        /// <value>The field label content node menu sort order.</value>
        public static string FieldLabel_ContentNode_MenuSortOrder
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_MenuSortOrder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label content node.</value>
        public static string FieldLabel_ContentNode_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Namespaces.
        /// </summary>
        /// <value>The field label content node name spaces.</value>
        public static string FieldLabel_ContentNode_NameSpaces
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_NameSpaces", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Navigation Type.
        /// </summary>
        /// <value>The type of the field label content node navigation.</value>
        public static string FieldLabel_ContentNode_NavigationType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_NavigationType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Parent Node.
        /// </summary>
        /// <value>The field label content node parent node.</value>
        public static string FieldLabel_ContentNode_ParentNode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_ParentNode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Rating.
        /// </summary>
        /// <value>The field label content node rating.</value>
        public static string FieldLabel_ContentNode_Rating
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_Rating", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Roles.
        /// </summary>
        /// <value>The field label content node roles.</value>
        public static string FieldLabel_ContentNode_Roles
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_Roles", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Route Pattern.
        /// </summary>
        /// <value>The field label content node route URL.</value>
        public static string FieldLabel_ContentNode_RouteUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_RouteUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label content node short description.</value>
        public static string FieldLabel_ContentNode_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Show in menu?.
        /// </summary>
        /// <value>The field label content node show in menu.</value>
        public static string FieldLabel_ContentNode_ShowInMenu
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_ShowInMenu", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Show in sitemap?.
        /// </summary>
        /// <value>The field label content node show in sitemap.</value>
        public static string FieldLabel_ContentNode_ShowInSitemap
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_ShowInSitemap", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sitemap Change Frequency.
        /// </summary>
        /// <value>The field label content node sitemap change frequency.</value>
        public static string FieldLabel_ContentNode_SitemapChangeFrequency
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_SitemapChangeFrequency", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sitemap Priority.
        /// </summary>
        /// <value>The field label content node sitemap priority.</value>
        public static string FieldLabel_ContentNode_SitemapPriority
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_SitemapPriority", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to URL Aliases.
        /// </summary>
        /// <value>The field label content node URL aliases.</value>
        public static string FieldLabel_ContentNode_UrlAliases
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_UrlAliases", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Url Target.
        /// </summary>
        /// <value>The field label content node URL target.</value>
        public static string FieldLabel_ContentNode_UrlTarget
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_UrlTarget", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View.
        /// </summary>
        /// <value>The field label content node view.</value>
        public static string FieldLabel_ContentNode_View
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_View", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Views.
        /// </summary>
        /// <value>The field label content node views.</value>
        public static string FieldLabel_ContentNode_Views
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNode_Views", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Action.
        /// </summary>
        /// <value>The field label content node route action.</value>
        public static string FieldLabel_ContentNodeRoute_Action
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_Action", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Area.
        /// </summary>
        /// <value>The field label content node route area.</value>
        public static string FieldLabel_ContentNodeRoute_Area
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_Area", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Node.
        /// </summary>
        /// <value>The field label content node route content node.</value>
        public static string FieldLabel_ContentNodeRoute_ContentNode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_ContentNode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Node Id.
        /// </summary>
        /// <value>The field label content node route content node identifier.</value>
        public static string FieldLabel_ContentNodeRoute_ContentNodeId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_ContentNodeId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Controller.
        /// </summary>
        /// <value>The field label content node route controller.</value>
        public static string FieldLabel_ContentNodeRoute_Controller
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_Controller", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label content node route create date.</value>
        public static string FieldLabel_ContentNodeRoute_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label content node route created by user.</value>
        public static string FieldLabel_ContentNodeRoute_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Data Tokens.
        /// </summary>
        /// <value>The field label content node route data tokens.</value>
        public static string FieldLabel_ContentNodeRoute_DataTokens
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_DataTokens", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label content node route description.</value>
        public static string FieldLabel_ContentNodeRoute_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label content node route last modified by user.</value>
        public static string FieldLabel_ContentNodeRoute_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label content node route last modified date.</value>
        public static string FieldLabel_ContentNodeRoute_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label content node route.</value>
        public static string FieldLabel_ContentNodeRoute_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Namespaces.
        /// </summary>
        /// <value>The field label content node route name spaces.</value>
        public static string FieldLabel_ContentNodeRoute_NameSpaces
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_NameSpaces", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Roles.
        /// </summary>
        /// <value>The field label content node route roles.</value>
        public static string FieldLabel_ContentNodeRoute_Roles
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_Roles", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Route Name.
        /// </summary>
        /// <value>The name of the field label content node route route.</value>
        public static string FieldLabel_ContentNodeRoute_RouteName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_RouteName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Route Parameters.
        /// </summary>
        /// <value>The field label content node route route parameters.</value>
        public static string FieldLabel_ContentNodeRoute_RouteParameters
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_RouteParameters", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Url.
        /// </summary>
        /// <value>The field label content node route URL.</value>
        public static string FieldLabel_ContentNodeRoute_Url
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentNodeRoute_Url", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Node.
        /// </summary>
        /// <value>The field label content view content node.</value>
        public static string FieldLabel_ContentView_ContentNode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_ContentNode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Node Id.
        /// </summary>
        /// <value>The field label content view content node identifier.</value>
        public static string FieldLabel_ContentView_ContentNodeId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_ContentNodeId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Nodes.
        /// </summary>
        /// <value>The field label content view content nodes.</value>
        public static string FieldLabel_ContentView_ContentNodes
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_ContentNodes", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label content view create date.</value>
        public static string FieldLabel_ContentView_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label content view created by user.</value>
        public static string FieldLabel_ContentView_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label content view description.</value>
        public static string FieldLabel_ContentView_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled?.
        /// </summary>
        /// <value>The field label content view enabled.</value>
        public static string FieldLabel_ContentView_Enabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_Enabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Layout?.
        /// </summary>
        /// <value>The field label content view is layout.</value>
        public static string FieldLabel_ContentView_IsLayout
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_IsLayout", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Main?.
        /// </summary>
        /// <value>The field label content view is main.</value>
        public static string FieldLabel_ContentView_IsMain
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_IsMain", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Partial?.
        /// </summary>
        /// <value>The field label content view is partial.</value>
        public static string FieldLabel_ContentView_IsPartial
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_IsPartial", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shared?.
        /// </summary>
        /// <value>The field label content view is shared.</value>
        public static string FieldLabel_ContentView_IsShared
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_IsShared", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label content view last modified by user.</value>
        public static string FieldLabel_ContentView_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label content view last modified date.</value>
        public static string FieldLabel_ContentView_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Layout Path.
        /// </summary>
        /// <value>The field label content view layout path.</value>
        public static string FieldLabel_ContentView_LayoutPath
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_LayoutPath", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label content view.</value>
        public static string FieldLabel_ContentView_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Roles.
        /// </summary>
        /// <value>The field label content view roles.</value>
        public static string FieldLabel_ContentView_Roles
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_Roles", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View Content.
        /// </summary>
        /// <value>The content of the field label content view view.</value>
        public static string FieldLabel_ContentView_ViewContent
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_ViewContent", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View Name.
        /// </summary>
        /// <value>The name of the field label content view view.</value>
        public static string FieldLabel_ContentView_ViewName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_ViewName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View Path.
        /// </summary>
        /// <value>The field label content view view path.</value>
        public static string FieldLabel_ContentView_ViewPath
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentView_ViewPath", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Container Content.
        /// </summary>
        /// <value>The content of the field label content view control container.</value>
        public static string FieldLabel_ContentViewControl_ContainerContent
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ContainerContent", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Container CSS.
        /// </summary>
        /// <value>The field label content view control container CSS.</value>
        public static string FieldLabel_ContentViewControl_ContainerCss
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ContainerCss", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Container Tag.
        /// </summary>
        /// <value>The field label content view control container tag.</value>
        public static string FieldLabel_ContentViewControl_ContainerTag
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ContainerTag", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content After.
        /// </summary>
        /// <value>The field label content view control content after.</value>
        public static string FieldLabel_ContentViewControl_ContentAfter
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ContentAfter", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Before.
        /// </summary>
        /// <value>The field label content view control content before.</value>
        public static string FieldLabel_ContentViewControl_ContentBefore
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ContentBefore", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Control.
        /// </summary>
        /// <value>The field label content view control content control.</value>
        public static string FieldLabel_ContentViewControl_ContentControl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ContentControl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Control Id.
        /// </summary>
        /// <value>The field label content view control content control identifier.</value>
        public static string FieldLabel_ContentViewControl_ContentControlId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ContentControlId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Node.
        /// </summary>
        /// <value>The field label content view control content node.</value>
        public static string FieldLabel_ContentViewControl_ContentNode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ContentNode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Node Id.
        /// </summary>
        /// <value>The field label content view control content node identifier.</value>
        public static string FieldLabel_ContentViewControl_ContentNodeId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ContentNodeId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content View.
        /// </summary>
        /// <value>The field label content view control content view.</value>
        public static string FieldLabel_ContentViewControl_ContentView
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ContentView", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content View Id.
        /// </summary>
        /// <value>The field label content view control content view identifier.</value>
        public static string FieldLabel_ContentViewControl_ContentViewId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ContentViewId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Control Id.
        /// </summary>
        /// <value>The field label content view control control identifier.</value>
        public static string FieldLabel_ContentViewControl_ControlId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ControlId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Control Title.
        /// </summary>
        /// <value>The field label content view control control title.</value>
        public static string FieldLabel_ContentViewControl_ControlTitle
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ControlTitle", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Control Type.
        /// </summary>
        /// <value>The type of the field label content view control control.</value>
        public static string FieldLabel_ContentViewControl_ControlType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_ControlType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label content view control create date.</value>
        public static string FieldLabel_ContentViewControl_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label content view control created by user.</value>
        public static string FieldLabel_ContentViewControl_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label content view control description.</value>
        public static string FieldLabel_ContentViewControl_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Read only?.
        /// </summary>
        /// <value>The field label content view control is read only.</value>
        public static string FieldLabel_ContentViewControl_IsReadOnly
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_IsReadOnly", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Visible?.
        /// </summary>
        /// <value>The field label content view control is visible.</value>
        public static string FieldLabel_ContentViewControl_IsVisible
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_IsVisible", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to JavaScript.
        /// </summary>
        /// <value>The field label content view control java script.</value>
        public static string FieldLabel_ContentViewControl_JavaScript
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_JavaScript", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label content view control last modified by user.</value>
        public static string FieldLabel_ContentViewControl_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label content view control last modified date.</value>
        public static string FieldLabel_ContentViewControl_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label content view control.</value>
        public static string FieldLabel_ContentViewControl_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Style.
        /// </summary>
        /// <value>The content of the field label content view control style.</value>
        public static string FieldLabel_ContentViewControl_StyleContent
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ContentViewControl_StyleContent", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Flag SVG 1x1.
        /// </summary>
        /// <value>The field label country flag SVG11 path.</value>
        public static string FieldLabel_Country_FlagSvg11Path
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Country_FlagSvg11Path", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Flag SVG 4x3.
        /// </summary>
        /// <value>The field label country flag SVG43 path.</value>
        public static string FieldLabel_Country_FlagSvg43Path
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Country_FlagSvg43Path", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to States.
        /// </summary>
        /// <value>The field label country states.</value>
        public static string FieldLabel_Country_States
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Country_States", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Three letters code.
        /// </summary>
        /// <value>The field label country three letter code.</value>
        public static string FieldLabel_Country_ThreeLetterCode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Country_ThreeLetterCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Two letters code.
        /// </summary>
        /// <value>The field label country two letter code.</value>
        public static string FieldLabel_Country_TwoLetterCode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Country_TwoLetterCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label currency create date.</value>
        public static string FieldLabel_Currency_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Currency_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label currency created by user.</value>
        public static string FieldLabel_Currency_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Currency_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label currency description.</value>
        public static string FieldLabel_Currency_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Currency_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Exchange Rate.
        /// </summary>
        /// <value>The field label currency exchange rate.</value>
        public static string FieldLabel_Currency_ExchangeRate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Currency_ExchangeRate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Format string.
        /// </summary>
        /// <value>The field label currency format string.</value>
        public static string FieldLabel_Currency_FormatString
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Currency_FormatString", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled?.
        /// </summary>
        /// <value>The field label currency is enabled.</value>
        public static string FieldLabel_Currency_IsEnabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Currency_IsEnabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Is Main.
        /// </summary>
        /// <value>The field label currency is main.</value>
        public static string FieldLabel_Currency_IsMain
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Currency_IsMain", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label currency last modified by user.</value>
        public static string FieldLabel_Currency_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Currency_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label currency last modified date.</value>
        public static string FieldLabel_Currency_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Currency_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label currency.</value>
        public static string FieldLabel_Currency_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Currency_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Round to.
        /// </summary>
        /// <value>The field label currency round to.</value>
        public static string FieldLabel_Currency_RoundTo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Currency_RoundTo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Symbol.
        /// </summary>
        /// <value>The field label currency symbol.</value>
        public static string FieldLabel_Currency_Symbol
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Currency_Symbol", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Three Letter Code.
        /// </summary>
        /// <value>The field label currency three letter code.</value>
        public static string FieldLabel_Currency_ThreeLetterCode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Currency_ThreeLetterCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Assembly name.
        /// </summary>
        /// <value>The name of the field label custom configuration assembly.</value>
        public static string FieldLabel_CustomConfiguration_AssemblyName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomConfiguration_AssemblyName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Class name.
        /// </summary>
        /// <value>The name of the field label custom configuration class.</value>
        public static string FieldLabel_CustomConfiguration_ClassName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomConfiguration_ClassName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Current сonfiguration.
        /// </summary>
        /// <value>The field label custom configuration current configuration.</value>
        public static string FieldLabel_CustomConfiguration_CurrentConfiguration
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomConfiguration_CurrentConfiguration", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Default сonfiguration.
        /// </summary>
        /// <value>The field label custom configuration default configuration.</value>
        public static string FieldLabel_CustomConfiguration_DefaultConfiguration
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomConfiguration_DefaultConfiguration", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created.
        /// </summary>
        /// <value>The field label document template create date.</value>
        public static string FieldLabel_DocumentTemplate_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DocumentTemplate_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label document template created by user.</value>
        public static string FieldLabel_DocumentTemplate_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DocumentTemplate_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label document template description.</value>
        public static string FieldLabel_DocumentTemplate_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DocumentTemplate_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Maximum 4000 characters allowed.
        /// </summary>
        /// <value>The field label document template description maximum characters.</value>
        public static string FieldLabel_DocumentTemplate_Description_MaxCharacters
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DocumentTemplate_Description_MaxCharacters", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled.
        /// </summary>
        /// <value>The field label document template is enabled.</value>
        public static string FieldLabel_DocumentTemplate_IsEnabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DocumentTemplate_IsEnabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last modified by.
        /// </summary>
        /// <value>The name of the field label document template last modified by user.</value>
        public static string FieldLabel_DocumentTemplate_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DocumentTemplate_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last modified.
        /// </summary>
        /// <value>The field label document template last modified date.</value>
        public static string FieldLabel_DocumentTemplate_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DocumentTemplate_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label document template.</value>
        public static string FieldLabel_DocumentTemplate_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DocumentTemplate_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short description.
        /// </summary>
        /// <value>The field label document template short description.</value>
        public static string FieldLabel_DocumentTemplate_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DocumentTemplate_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Template body.
        /// </summary>
        /// <value>The field label document template template body.</value>
        public static string FieldLabel_DocumentTemplate_TemplateBody
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DocumentTemplate_TemplateBody", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Template Text.
        /// </summary>
        /// <value>The field label document template template body text.</value>
        public static string FieldLabel_DocumentTemplate_TemplateBodyText
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DocumentTemplate_TemplateBodyText", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Template URL.
        /// </summary>
        /// <value>The field label document template template body URL.</value>
        public static string FieldLabel_DocumentTemplate_TemplateBodyUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DocumentTemplate_TemplateBodyUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Template type.
        /// </summary>
        /// <value>The type of the field label document template template.</value>
        public static string FieldLabel_DocumentTemplate_TemplateType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DocumentTemplate_TemplateType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label event log create date.</value>
        public static string FieldLabel_EventLog_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label event log created by user.</value>
        public static string FieldLabel_EventLog_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label event log description.</value>
        public static string FieldLabel_EventLog_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Event Code.
        /// </summary>
        /// <value>The field label event log event code.</value>
        public static string FieldLabel_EventLog_EventCode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_EventCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Machine Name.
        /// </summary>
        /// <value>The name of the field label event log event machine.</value>
        public static string FieldLabel_EventLog_EventMachineName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_EventMachineName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Event Source.
        /// </summary>
        /// <value>The field label event log event source.</value>
        public static string FieldLabel_EventLog_EventSource
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_EventSource", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Event Time.
        /// </summary>
        /// <value>The field label event log event time.</value>
        public static string FieldLabel_EventLog_EventTime
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_EventTime", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Event Type.
        /// </summary>
        /// <value>The type of the field label event log event.</value>
        public static string FieldLabel_EventLog_EventType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_EventType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Event URL.
        /// </summary>
        /// <value>The field label event log event URL.</value>
        public static string FieldLabel_EventLog_EventUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_EventUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to URL Referrer.
        /// </summary>
        /// <value>The field label event log event URL referrer.</value>
        public static string FieldLabel_EventLog_EventUrlReferrer
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_EventUrlReferrer", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to User Agent.
        /// </summary>
        /// <value>The field label event log event user agent.</value>
        public static string FieldLabel_EventLog_EventUserAgent
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_EventUserAgent", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Id.
        /// </summary>
        /// <value>The field label event log identifier.</value>
        public static string FieldLabel_EventLog_Id
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_Id", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to IP Address.
        /// </summary>
        /// <value>The field label event log ip address.</value>
        public static string FieldLabel_EventLog_IpAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_IpAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label event log last modified by user.</value>
        public static string FieldLabel_EventLog_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label event log last modified date.</value>
        public static string FieldLabel_EventLog_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EventLog_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Category code.
        /// </summary>
        /// <value>The field label generic category code.</value>
        public static string FieldLabel_Generic_CategoryCode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Generic_CategoryCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Create date.
        /// </summary>
        /// <value>The field label generic create date.</value>
        public static string FieldLabel_Generic_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Generic_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created by user name.
        /// </summary>
        /// <value>The name of the field label generic created by user.</value>
        public static string FieldLabel_Generic_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Generic_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Culture code.
        /// </summary>
        /// <value>The field label generic culture code.</value>
        public static string FieldLabel_Generic_CultureCode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Generic_CultureCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label generic description.</value>
        public static string FieldLabel_Generic_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Generic_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Display Name.
        /// </summary>
        /// <value>The display name of the field label generic.</value>
        public static string FieldLabel_Generic_DisplayName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Generic_DisplayName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Is enabled.
        /// </summary>
        /// <value>The field label generic is enabled.</value>
        public static string FieldLabel_Generic_IsEnabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Generic_IsEnabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last modified by user name.
        /// </summary>
        /// <value>The name of the field label generic last modified by user.</value>
        public static string FieldLabel_Generic_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Generic_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last modified date.
        /// </summary>
        /// <value>The field label generic last modified date.</value>
        public static string FieldLabel_Generic_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Generic_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Localization Id.
        /// </summary>
        /// <value>The field label generic localization identifier.</value>
        public static string FieldLabel_Generic_LocalizationId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Generic_LocalizationId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label generic.</value>
        public static string FieldLabel_Generic_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Generic_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address.
        /// </summary>
        /// <value>The field label login address line1.</value>
        public static string FieldLabel_Login_AddressLine1
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_AddressLine1", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Additional Address.
        /// </summary>
        /// <value>The field label login address line2.</value>
        public static string FieldLabel_Login_AddressLine2
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_AddressLine2", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to City.
        /// </summary>
        /// <value>The field label login city.</value>
        public static string FieldLabel_Login_City
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_City", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Code.
        /// </summary>
        /// <value>The field label login code.</value>
        public static string FieldLabel_Login_Code
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_Code", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label login company description.</value>
        public static string FieldLabel_Login_CompanyDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_CompanyDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Company Name.
        /// </summary>
        /// <value>The name of the field label login company.</value>
        public static string FieldLabel_Login_CompanyName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_CompanyName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Company Number.
        /// </summary>
        /// <value>The field label login company number.</value>
        public static string FieldLabel_Login_CompanyNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_CompanyNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Confirm password.
        /// </summary>
        /// <value>The field label login confirm password.</value>
        public static string FieldLabel_Login_ConfirmPassword
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_ConfirmPassword", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Country.
        /// </summary>
        /// <value>The field label login country.</value>
        public static string FieldLabel_Login_Country
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_Country", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to County.
        /// </summary>
        /// <value>The field label login county.</value>
        public static string FieldLabel_Login_County
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_County", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Current password.
        /// </summary>
        /// <value>The field label login current password.</value>
        public static string FieldLabel_Login_CurrentPassword
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_CurrentPassword", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Email.
        /// </summary>
        /// <value>The field label login email.</value>
        public static string FieldLabel_Login_Email
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_Email", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Fax.
        /// </summary>
        /// <value>The field label login fax number.</value>
        public static string FieldLabel_Login_FaxNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_FaxNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to First Name.
        /// </summary>
        /// <value>The first name of the field label login.</value>
        public static string FieldLabel_Login_FirstName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_FirstName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Home Phone.
        /// </summary>
        /// <value>The field label login home phone.</value>
        public static string FieldLabel_Login_HomePhone
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_HomePhone", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Insurance No.
        /// </summary>
        /// <value>The field label login insurance number.</value>
        public static string FieldLabel_Login_InsuranceNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_InsuranceNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Name.
        /// </summary>
        /// <value>The last name of the field label login.</value>
        public static string FieldLabel_Login_LastName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_LastName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Licence No.
        /// </summary>
        /// <value>The field label login licence number.</value>
        public static string FieldLabel_Login_LicenceNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_LicenceNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Middle Name.
        /// </summary>
        /// <value>The name of the field label login middle.</value>
        public static string FieldLabel_Login_MiddleName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_MiddleName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Mobile Phone.
        /// </summary>
        /// <value>The field label login mobile phone.</value>
        public static string FieldLabel_Login_MobilePhone
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_MobilePhone", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Password.
        /// </summary>
        /// <value>The field label login password.</value>
        public static string FieldLabel_Login_Password
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_Password", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Phone Number.
        /// </summary>
        /// <value>The field label login phone number.</value>
        public static string FieldLabel_Login_PhoneNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_PhoneNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Registration Type.
        /// </summary>
        /// <value>The type of the field label login registration.</value>
        public static string FieldLabel_Login_RegistrationType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_RegistrationType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Remember this browser?.
        /// </summary>
        /// <value>The field label login remember browser.</value>
        public static string FieldLabel_Login_RememberBrowser
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_RememberBrowser", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Remember me?.
        /// </summary>
        /// <value>The field label login remember me.</value>
        public static string FieldLabel_Login_RememberMe
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_RememberMe", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to State.
        /// </summary>
        /// <value>The state of the field label login.</value>
        public static string FieldLabel_Login_State
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_State", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subscription Term.
        /// </summary>
        /// <value>The field label login subscription term.</value>
        public static string FieldLabel_Login_SubscriptionTerm
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_SubscriptionTerm", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subscription Type.
        /// </summary>
        /// <value>The type of the field label login subscription.</value>
        public static string FieldLabel_Login_SubscriptionType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_SubscriptionType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Tax No.
        /// </summary>
        /// <value>The field label login tax number.</value>
        public static string FieldLabel_Login_TaxNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_TaxNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Web Site.
        /// </summary>
        /// <value>The field label login URL.</value>
        public static string FieldLabel_Login_Url
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_Url", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Work Phone.
        /// </summary>
        /// <value>The field label login work phone.</value>
        public static string FieldLabel_Login_WorkPhone
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_WorkPhone", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Ext..
        /// </summary>
        /// <value>The field label login work phone ex.</value>
        public static string FieldLabel_Login_WorkPhoneEx
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_WorkPhoneEx", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Zip.
        /// </summary>
        /// <value>The field label login zip.</value>
        public static string FieldLabel_Login_Zip
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Login_Zip", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Create Date.
        /// </summary>
        /// <value>The field label lookup create date.</value>
        public static string FieldLabel_Lookup_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label lookup created by user.</value>
        public static string FieldLabel_Lookup_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Date Range From.
        /// </summary>
        /// <value>The field label lookup date range from.</value>
        public static string FieldLabel_Lookup_DateRangeFrom
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_DateRangeFrom", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Date Range To.
        /// </summary>
        /// <value>The field label lookup date range to.</value>
        public static string FieldLabel_Lookup_DateRangeTo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_DateRangeTo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label lookup description.</value>
        public static string FieldLabel_Lookup_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Assembly.
        /// </summary>
        /// <value>The field label lookup entity assembly.</value>
        public static string FieldLabel_Lookup_EntityAssembly
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_EntityAssembly", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Class.
        /// </summary>
        /// <value>The field label lookup entity class.</value>
        public static string FieldLabel_Lookup_EntityClass
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_EntityClass", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Entity Filter.
        /// </summary>
        /// <value>The field label lookup entity filter.</value>
        public static string FieldLabel_Lookup_EntityFilter
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_EntityFilter", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Entity Name.
        /// </summary>
        /// <value>The name of the field label lookup entity.</value>
        public static string FieldLabel_Lookup_EntityName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_EntityName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Entity Name Field.
        /// </summary>
        /// <value>The field label lookup entity name field.</value>
        public static string FieldLabel_Lookup_EntityNameField
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_EntityNameField", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Entity Order By.
        /// </summary>
        /// <value>The field label lookup entity order by.</value>
        public static string FieldLabel_Lookup_EntityOrderBy
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_EntityOrderBy", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Entity Value Field.
        /// </summary>
        /// <value>The field label lookup entity value field.</value>
        public static string FieldLabel_Lookup_EntityValueField
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_EntityValueField", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Float Range From.
        /// </summary>
        /// <value>The field label lookup float range from.</value>
        public static string FieldLabel_Lookup_FloatRangeFrom
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_FloatRangeFrom", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Float Range Step.
        /// </summary>
        /// <value>The field label lookup float range step.</value>
        public static string FieldLabel_Lookup_FloatRangeStep
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_FloatRangeStep", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Float Range To.
        /// </summary>
        /// <value>The field label lookup float range to.</value>
        public static string FieldLabel_Lookup_FloatRangeTo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_FloatRangeTo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Id.
        /// </summary>
        /// <value>The field label lookup identifier.</value>
        public static string FieldLabel_Lookup_Id
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_Id", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Int. Range From.
        /// </summary>
        /// <value>The field label lookup int range from.</value>
        public static string FieldLabel_Lookup_IntRangeFrom
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_IntRangeFrom", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Int. Range To.
        /// </summary>
        /// <value>The field label lookup int range to.</value>
        public static string FieldLabel_Lookup_IntRangeTo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_IntRangeTo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label lookup last modified by user.</value>
        public static string FieldLabel_Lookup_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label lookup last modified date.</value>
        public static string FieldLabel_Lookup_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label lookup.</value>
        public static string FieldLabel_Lookup_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Parent Lookup.
        /// </summary>
        /// <value>The field label lookup parent lookup.</value>
        public static string FieldLabel_Lookup_ParentLookup
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_ParentLookup", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Range Prefix.
        /// </summary>
        /// <value>The field label lookup range prefix.</value>
        public static string FieldLabel_Lookup_RangePrefix
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_RangePrefix", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Type.
        /// </summary>
        /// <value>The type of the field label lookup.</value>
        public static string FieldLabel_Lookup_Type
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Lookup_Type", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Create Date.
        /// </summary>
        /// <value>The field label lookup value create date.</value>
        public static string FieldLabel_LookupValue_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_LookupValue_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The field label lookup value created by.</value>
        public static string FieldLabel_LookupValue_CreatedBy
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_LookupValue_CreatedBy", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label lookup value created by user.</value>
        public static string FieldLabel_LookupValue_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_LookupValue_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Culture Code.
        /// </summary>
        /// <value>The field label lookup value culture code.</value>
        public static string FieldLabel_LookupValue_CultureCode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_LookupValue_CultureCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label lookup value description.</value>
        public static string FieldLabel_LookupValue_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_LookupValue_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Id.
        /// </summary>
        /// <value>The field label lookup value identifier.</value>
        public static string FieldLabel_LookupValue_Id
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_LookupValue_Id", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Lookup Key.
        /// </summary>
        /// <value>The field label lookup value key.</value>
        public static string FieldLabel_LookupValue_Key
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_LookupValue_Key", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The field label lookup value last modified by.</value>
        public static string FieldLabel_LookupValue_LastModifiedBy
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_LookupValue_LastModifiedBy", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label lookup value last modified by user.</value>
        public static string FieldLabel_LookupValue_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_LookupValue_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label lookup value last modified date.</value>
        public static string FieldLabel_LookupValue_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_LookupValue_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Order.
        /// </summary>
        /// <value>The field label lookup value order.</value>
        public static string FieldLabel_LookupValue_Order
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_LookupValue_Order", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Parent Key.
        /// </summary>
        /// <value>The field label lookup value parent key.</value>
        public static string FieldLabel_LookupValue_ParentKey
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_LookupValue_ParentKey", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Text.
        /// </summary>
        /// <value>The field label lookup value text.</value>
        public static string FieldLabel_LookupValue_Text
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_LookupValue_Text", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Black copy.
        /// </summary>
        /// <value>The field label message black copy address.</value>
        public static string FieldLabel_Message_BlackCopyAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Message_BlackCopyAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Body.
        /// </summary>
        /// <value>The field label message body.</value>
        public static string FieldLabel_Message_Body
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Message_Body", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Copy.
        /// </summary>
        /// <value>The field label message copy address.</value>
        public static string FieldLabel_Message_CopyAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Message_CopyAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Create date.
        /// </summary>
        /// <value>The field label message create date.</value>
        public static string FieldLabel_Message_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Message_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label message created by user.</value>
        public static string FieldLabel_Message_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Message_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to From.
        /// </summary>
        /// <value>The field label message from address.</value>
        public static string FieldLabel_Message_FromAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Message_FromAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Modified By.
        /// </summary>
        /// <value>The name of the field label message last modified by user.</value>
        public static string FieldLabel_Message_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Message_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last modified date.
        /// </summary>
        /// <value>The field label message last modified date.</value>
        public static string FieldLabel_Message_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Message_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sent.
        /// </summary>
        /// <value>The field label message sent.</value>
        public static string FieldLabel_Message_Sent
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Message_Sent", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sent date.
        /// </summary>
        /// <value>The field label message sent date.</value>
        public static string FieldLabel_Message_SentDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Message_SentDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subject.
        /// </summary>
        /// <value>The field label message subject.</value>
        public static string FieldLabel_Message_Subject
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Message_Subject", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to To.
        /// </summary>
        /// <value>The field label message to address.</value>
        public static string FieldLabel_Message_ToAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Message_ToAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Message was sent.
        /// </summary>
        /// <value>The field label message was sent.</value>
        public static string FieldLabel_MessageWasSent
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_MessageWasSent", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Bitmask.
        /// </summary>
        /// <value>The field label module bit mask.</value>
        public static string FieldLabel_Module_BitMask
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Module_BitMask", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Create date.
        /// </summary>
        /// <value>The field label module create date.</value>
        public static string FieldLabel_Module_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Module_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created by.
        /// </summary>
        /// <value>The name of the field label module created by user.</value>
        public static string FieldLabel_Module_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Module_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label module description.</value>
        public static string FieldLabel_Module_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Module_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled.
        /// </summary>
        /// <value>The field label module enabled.</value>
        public static string FieldLabel_Module_Enabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Module_Enabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Global Id.
        /// </summary>
        /// <value>The field label module global identifier.</value>
        public static string FieldLabel_Module_GlobalId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Module_GlobalId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last modified by.
        /// </summary>
        /// <value>The name of the field label module last modified by user.</value>
        public static string FieldLabel_Module_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Module_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last modified date.
        /// </summary>
        /// <value>The field label module last modified date.</value>
        public static string FieldLabel_Module_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Module_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label module.</value>
        public static string FieldLabel_Module_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Module_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Organizations.
        /// </summary>
        /// <value>The field label module organizations.</value>
        public static string FieldLabel_Module_Organizations
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Module_Organizations", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Roles.
        /// </summary>
        /// <value>The field label module roles.</value>
        public static string FieldLabel_Module_Roles
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Module_Roles", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short description.
        /// </summary>
        /// <value>The field label module short description.</value>
        public static string FieldLabel_Module_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Module_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Create date.
        /// </summary>
        /// <value>The field label news letter create date.</value>
        public static string FieldLabel_NewsLetter_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_NewsLetter_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Image path.
        /// </summary>
        /// <value>The field label news letter image path.</value>
        public static string FieldLabel_NewsLetter_ImagePath
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_NewsLetter_ImagePath", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Publish date.
        /// </summary>
        /// <value>The field label news letter publish date.</value>
        public static string FieldLabel_NewsLetter_PublishDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_NewsLetter_PublishDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Published.
        /// </summary>
        /// <value>The field label news letter published.</value>
        public static string FieldLabel_NewsLetter_Published
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_NewsLetter_Published", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subtitle.
        /// </summary>
        /// <value>The field label news letter subtitle.</value>
        public static string FieldLabel_NewsLetter_Subtitle
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_NewsLetter_Subtitle", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Text html.
        /// </summary>
        /// <value>The field label news letter text HTML.</value>
        public static string FieldLabel_NewsLetter_TextHtml
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_NewsLetter_TextHtml", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Title.
        /// </summary>
        /// <value>The field label news letter title.</value>
        public static string FieldLabel_NewsLetter_Title
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_NewsLetter_Title", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address 1.
        /// </summary>
        /// <value>The field label organization address line1.</value>
        public static string FieldLabel_Organization_AddressLine1
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_AddressLine1", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Users.
        /// </summary>
        /// <value>The field label organization users.</value>
        public static string FieldLabel_Organization_Users
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_Users", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subscriptions.
        /// </summary>
        /// <value>The field label organization subscriptions.</value>
        public static string FieldLabel_Organization_Subscriptions
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_Subscriptions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address 2.
        /// </summary>
        /// <value>The field label organization address line2.</value>
        public static string FieldLabel_Organization_AddressLine2
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_AddressLine2", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Authentication Cookie Expiration Time.
        /// </summary>
        /// <value>The field label organization authentication cookie expiration time.</value>
        public static string FieldLabel_Organization_AuthCookieExpirationTime
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_AuthCookieExpirationTime", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Authentication Cookie Name.
        /// </summary>
        /// <value>The name of the field label organization authentication cookie.</value>
        public static string FieldLabel_Organization_AuthCookieName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_AuthCookieName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Default Coontact Email.
        /// </summary>
        /// <value>The field label organization bap default contact email.</value>
        public static string FieldLabel_Organization_BapDefaultContactEmail
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_BapDefaultContactEmail", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Default From Email.
        /// </summary>
        /// <value>The field label organization bap default from email.</value>
        public static string FieldLabel_Organization_BapDefaultFromEmail
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_BapDefaultFromEmail", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Base Folder.
        /// </summary>
        /// <value>The field label organization base folder.</value>
        public static string FieldLabel_Organization_BaseFolder
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_BaseFolder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Base Folder.
        /// </summary>
        /// <value>The field label organization base folder text.</value>
        public static string FieldLabel_Organization_BaseFolderText
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_BaseFolderText", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Bearer Token Expiration Time.
        /// </summary>
        /// <value>The field label organization bearer token expiration time.</value>
        public static string FieldLabel_Organization_BearerTokenExpirationTime
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_BearerTokenExpirationTime", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Blog url.
        /// </summary>
        /// <value>The field label organization blog URL.</value>
        public static string FieldLabel_Organization_BlogUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_BlogUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to City.
        /// </summary>
        /// <value>The field label organization city.</value>
        public static string FieldLabel_Organization_City
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_City", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Contact email.
        /// </summary>
        /// <value>The field label organization contact email.</value>
        public static string FieldLabel_Organization_ContactEmail
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_ContactEmail", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cookues Popup?.
        /// </summary>
        /// <value>The field label organization cookies popup enabled.</value>
        public static string FieldLabel_Organization_CookiesPopupEnabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_CookiesPopupEnabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Country.
        /// </summary>
        /// <value>The field label organization country.</value>
        public static string FieldLabel_Organization_Country
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_Country", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to County.
        /// </summary>
        /// <value>The field label organization county.</value>
        public static string FieldLabel_Organization_County
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_County", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label organization create date.</value>
        public static string FieldLabel_Organization_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label organization created by user.</value>
        public static string FieldLabel_Organization_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label organization description.</value>
        public static string FieldLabel_Organization_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Facebook.
        /// </summary>
        /// <value>The field label organization facebook URL.</value>
        public static string FieldLabel_Organization_FacebookUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_FacebookUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Fax.
        /// </summary>
        /// <value>The field label organization fax number.</value>
        public static string FieldLabel_Organization_FaxNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_FaxNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to GDPR Popup?.
        /// </summary>
        /// <value>The field label organization GDPR popup enabled.</value>
        public static string FieldLabel_Organization_GdprPopupEnabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_GdprPopupEnabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Get Bearer Token on Login?.
        /// </summary>
        /// <value>The field label organization get bearrer token during login.</value>
        public static string FieldLabel_Organization_GetBearrerTokenDuringLogin
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_GetBearrerTokenDuringLogin", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Google+.
        /// </summary>
        /// <value>The field label organization googleplus URL.</value>
        public static string FieldLabel_Organization_GoogleplusUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_GoogleplusUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Host Name.
        /// </summary>
        /// <value>The name of the field label organization host.</value>
        public static string FieldLabel_Organization_HostName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_HostName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Host Name Aliases.
        /// </summary>
        /// <value>The field label organization host name aliases.</value>
        public static string FieldLabel_Organization_HostNameAliases
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_HostNameAliases", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Host Name Aliases.
        /// </summary>
        /// <value>The field label organization host name aliases text.</value>
        public static string FieldLabel_Organization_HostNameAliasesText
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_HostNameAliasesText", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Id.
        /// </summary>
        /// <value>The field label organization identifier.</value>
        public static string FieldLabel_Organization_Id
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_Id", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Imlemented Cultures.
        /// </summary>
        /// <value>The field label organization implemented cultures.</value>
        public static string FieldLabel_Organization_ImplementedCultures
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_ImplementedCultures", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Implemented Cultures.
        /// </summary>
        /// <value>The field label organization implemented cultures text.</value>
        public static string FieldLabel_Organization_ImplementedCulturesText
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_ImplementedCulturesText", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Instagram.
        /// </summary>
        /// <value>The field label organization instagram URL.</value>
        public static string FieldLabel_Organization_InstagramUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_InstagramUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label organization last modified by user.</value>
        public static string FieldLabel_Organization_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label organization last modified date.</value>
        public static string FieldLabel_Organization_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Linkedin.
        /// </summary>
        /// <value>The field label organization linkedin URL.</value>
        public static string FieldLabel_Organization_LinkedinUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_LinkedinUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Upload logo.
        /// </summary>
        /// <value>The field label organization logo file.</value>
        public static string FieldLabel_Organization_LogoFile
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_LogoFile", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Logo file.
        /// </summary>
        /// <value>The field label organization logo path URL.</value>
        public static string FieldLabel_Organization_LogoPathUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_LogoPathUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Modules.
        /// </summary>
        /// <value>The field label organization modules.</value>
        public static string FieldLabel_Organization_Modules
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_Modules", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label organization.</value>
        public static string FieldLabel_Organization_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Modules.
        /// </summary>
        /// <value>The field label organization organization modules.</value>
        public static string FieldLabel_Organization_OrganizationModules
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_OrganizationModules", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Organization type.
        /// </summary>
        /// <value>The type of the field label organization organization.</value>
        public static string FieldLabel_Organization_OrganizationType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_OrganizationType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Ext..
        /// </summary>
        /// <value>The field label organization phone extension.</value>
        public static string FieldLabel_Organization_PhoneExtension
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_PhoneExtension", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Phone.
        /// </summary>
        /// <value>The field label organization phone number.</value>
        public static string FieldLabel_Organization_PhoneNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_PhoneNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Public Folder.
        /// </summary>
        /// <value>The field label organization public folder.</value>
        public static string FieldLabel_Organization_PublicFolder
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_PublicFolder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Public Folder.
        /// </summary>
        /// <value>The field label organization public folder text.</value>
        public static string FieldLabel_Organization_PublicFolderText
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_PublicFolderText", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to reCaptcha Secret Key.
        /// </summary>
        /// <value>The field label organization re captcha secret key.</value>
        public static string FieldLabel_Organization_reCaptchaSecretKey
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_reCaptchaSecretKey", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to reCaptcha Site Key.
        /// </summary>
        /// <value>The field label organization re captcha site key.</value>
        public static string FieldLabel_Organization_reCaptchaSiteKey
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_reCaptchaSiteKey", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to SMTP Host Name.
        /// </summary>
        /// <value>The name of the field label organization SMTP host.</value>
        public static string FieldLabel_Organization_SmtpHostName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_SmtpHostName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to SMTP Port.
        /// </summary>
        /// <value>The field label organization SMTP port.</value>
        public static string FieldLabel_Organization_SmtpPort
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_SmtpPort", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to SMTP User Name.
        /// </summary>
        /// <value>The name of the field label organization SMTP user.</value>
        public static string FieldLabel_Organization_SmtpUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_SmtpUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to SMTP User Password.
        /// </summary>
        /// <value>The field label organization SMTP user password.</value>
        public static string FieldLabel_Organization_SmtpUserPassword
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_SmtpUserPassword", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to SMTP Use SSL?.
        /// </summary>
        /// <value>The field label organization SMTP use SSL.</value>
        public static string FieldLabel_Organization_SmtpUseSsl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_SmtpUseSsl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to State.
        /// </summary>
        /// <value>The state of the field label organization.</value>
        public static string FieldLabel_Organization_State
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_State", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Status.
        /// </summary>
        /// <value>The field label organization status.</value>
        public static string FieldLabel_Organization_Status
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_Status", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Status Date.
        /// </summary>
        /// <value>The field label organization status date.</value>
        public static string FieldLabel_Organization_StatusDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_StatusDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Support email.
        /// </summary>
        /// <value>The field label organization support email.</value>
        public static string FieldLabel_Organization_SupportEmail
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_SupportEmail", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Tax Id.
        /// </summary>
        /// <value>The field label organization tax identifier.</value>
        public static string FieldLabel_Organization_TaxId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_TaxId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Twitter.
        /// </summary>
        /// <value>The field label organization twitter URL.</value>
        public static string FieldLabel_Organization_TwitterUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_TwitterUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Web site.
        /// </summary>
        /// <value>The field label organization URL.</value>
        public static string FieldLabel_Organization_Url
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_Url", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Web API Allow Insecure HTTP.
        /// </summary>
        /// <value>The field label organization web API allow insecure HTTP.</value>
        public static string FieldLabel_Organization_WebApiAllowInsecureHttp
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_WebApiAllowInsecureHttp", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Web API Publid Client Id.
        /// </summary>
        /// <value>The field label organization web API public client identifier.</value>
        public static string FieldLabel_Organization_WebApiPublicClientId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_WebApiPublicClientId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Zip.
        /// </summary>
        /// <value>The field label organization zip.</value>
        public static string FieldLabel_Organization_Zip
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Organization_Zip", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Module.
        /// </summary>
        /// <value>The field label organization module module.</value>
        public static string FieldLabel_OrganizationModule_Module
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationModule_Module", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Order.
        /// </summary>
        /// <value>The field label organization module order.</value>
        public static string FieldLabel_OrganizationModule_Order
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationModule_Order", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Organization.
        /// </summary>
        /// <value>The field label organization module organization.</value>
        public static string FieldLabel_OrganizationModule_Organization
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationModule_Organization", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Url.
        /// </summary>
        /// <value>The field label organization module URL alias.</value>
        public static string FieldLabel_OrganizationModule_UrlAlias
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationModule_UrlAlias", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label organization service create date.</value>
        public static string FieldLabel_OrganizationService_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationService_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label organization service created by user.</value>
        public static string FieldLabel_OrganizationService_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationService_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label organization service description.</value>
        public static string FieldLabel_OrganizationService_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationService_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled?.
        /// </summary>
        /// <value>The field label organization service enabled.</value>
        public static string FieldLabel_OrganizationService_Enabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationService_Enabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Icon CSS.
        /// </summary>
        /// <value>The field label organization service icon class.</value>
        public static string FieldLabel_OrganizationService_IconClass
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationService_IconClass", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Image URL.
        /// </summary>
        /// <value>The field label organization service image URL.</value>
        public static string FieldLabel_OrganizationService_ImageUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationService_ImageUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label organization service last modified by user.</value>
        public static string FieldLabel_OrganizationService_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationService_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label organization service last modified date.</value>
        public static string FieldLabel_OrganizationService_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationService_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label organization service.</value>
        public static string FieldLabel_OrganizationService_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationService_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Order No.
        /// </summary>
        /// <value>The field label organization service order.</value>
        public static string FieldLabel_OrganizationService_Order
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationService_Order", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label organization service short description.</value>
        public static string FieldLabel_OrganizationService_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationService_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Access Failed Count.
        /// </summary>
        /// <value>The field label organization user access failed count.</value>
        public static string FieldLabel_OrganizationUser_AccessFailedCount
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_AccessFailedCount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address 1.
        /// </summary>
        /// <value>The field label organization user address line1.</value>
        public static string FieldLabel_OrganizationUser_AddressLine1
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_AddressLine1", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address 2.
        /// </summary>
        /// <value>The field label organization user address line2.</value>
        public static string FieldLabel_OrganizationUser_AddressLine2
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_AddressLine2", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cell Phone.
        /// </summary>
        /// <value>The field label organization user cell number.</value>
        public static string FieldLabel_OrganizationUser_CellNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_CellNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to City.
        /// </summary>
        /// <value>The field label organization user city.</value>
        public static string FieldLabel_OrganizationUser_City
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_City", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Country.
        /// </summary>
        /// <value>The field label organization user country.</value>
        public static string FieldLabel_OrganizationUser_Country
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_Country", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to County.
        /// </summary>
        /// <value>The field label organization user county.</value>
        public static string FieldLabel_OrganizationUser_County
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_County", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label organization user create date.</value>
        public static string FieldLabel_OrganizationUser_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label organization user created by user.</value>
        public static string FieldLabel_OrganizationUser_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to User Email.
        /// </summary>
        /// <value>The field label organization user email.</value>
        public static string FieldLabel_OrganizationUser_Email
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_Email", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Email Confirmed?.
        /// </summary>
        /// <value>The field label organization user email confirmed.</value>
        public static string FieldLabel_OrganizationUser_EmailConfirmed
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_EmailConfirmed", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to First Name.
        /// </summary>
        /// <value>The first name of the field label organization user.</value>
        public static string FieldLabel_OrganizationUser_FirstName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_FirstName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Full Name.
        /// </summary>
        /// <value>The full name of the field label organization user.</value>
        public static string FieldLabel_OrganizationUser_FullName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_FullName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label organization user last modified by user.</value>
        public static string FieldLabel_OrganizationUser_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label organization user last modified date.</value>
        public static string FieldLabel_OrganizationUser_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Name.
        /// </summary>
        /// <value>The last name of the field label organization user.</value>
        public static string FieldLabel_OrganizationUser_LastName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_LastName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Lockout?.
        /// </summary>
        /// <value>The field label organization user lockout enabled.</value>
        public static string FieldLabel_OrganizationUser_LockoutEnabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_LockoutEnabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Lockout When.
        /// </summary>
        /// <value>The field label organization user lockout end date UTC.</value>
        public static string FieldLabel_OrganizationUser_LockoutEndDateUtc
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_LockoutEndDateUtc", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Middle Name.
        /// </summary>
        /// <value>The name of the field label organization user middle.</value>
        public static string FieldLabel_OrganizationUser_MiddleName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_MiddleName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Home Phone.
        /// </summary>
        /// <value>The field label organization user phone number.</value>
        public static string FieldLabel_OrganizationUser_PhoneNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_PhoneNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Registered days ago.
        /// </summary>
        /// <value>The field label organization user registered days ago.</value>
        public static string FieldLabel_OrganizationUser_RegisteredDaysAgo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_RegisteredDaysAgo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Roles.
        /// </summary>
        /// <value>The field label organization user roles.</value>
        public static string FieldLabel_OrganizationUser_Roles
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_Roles", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to State.
        /// </summary>
        /// <value>The state of the field label organization user.</value>
        public static string FieldLabel_OrganizationUser_State
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_State", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Two Factor?.
        /// </summary>
        /// <value>The field label organization user two factor enabled.</value>
        public static string FieldLabel_OrganizationUser_TwoFactorEnabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_TwoFactorEnabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to User Name.
        /// </summary>
        /// <value>The name of the field label organization user user.</value>
        public static string FieldLabel_OrganizationUser_UserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_UserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Zip.
        /// </summary>
        /// <value>The field label organization user zip.</value>
        public static string FieldLabel_OrganizationUser_Zip
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrganizationUser_Zip", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Added At.
        /// </summary>
        /// <value>The field label property added date.</value>
        public static string FieldLabel_Property_AddedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_AddedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address 1.
        /// </summary>
        /// <value>The field label property address line1.</value>
        public static string FieldLabel_Property_AddressLine1
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_AddressLine1", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address 2.
        /// </summary>
        /// <value>The field label property address line2.</value>
        public static string FieldLabel_Property_AddressLine2
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_AddressLine2", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Asset No.
        /// </summary>
        /// <value>The field label property asset no.</value>
        public static string FieldLabel_Property_AssetNo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_AssetNo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cell No.
        /// </summary>
        /// <value>The field label property cell number.</value>
        public static string FieldLabel_Property_CellNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_CellNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to City.
        /// </summary>
        /// <value>The field label property city.</value>
        public static string FieldLabel_Property_City
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_City", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Comments.
        /// </summary>
        /// <value>The field label property comments.</value>
        public static string FieldLabel_Property_Comments
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Comments", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Country.
        /// </summary>
        /// <value>The field label property country.</value>
        public static string FieldLabel_Property_Country
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Country", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to County.
        /// </summary>
        /// <value>The field label property county.</value>
        public static string FieldLabel_Property_County
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_County", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Create At.
        /// </summary>
        /// <value>The field label property create date.</value>
        public static string FieldLabel_Property_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label property created by user.</value>
        public static string FieldLabel_Property_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Currency.
        /// </summary>
        /// <value>The field label property currency.</value>
        public static string FieldLabel_Property_Currency
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Currency", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label property description.</value>
        public static string FieldLabel_Property_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Electricity?.
        /// </summary>
        /// <value>The field label property electricity.</value>
        public static string FieldLabel_Property_Electricity
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Electricity", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Electric Water Heating?.
        /// </summary>
        /// <value>The field label property electric water heating.</value>
        public static string FieldLabel_Property_ElectricWaterHeating
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_ElectricWaterHeating", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Email.
        /// </summary>
        /// <value>The field label property email.</value>
        public static string FieldLabel_Property_Email
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Email", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to ESR.
        /// </summary>
        /// <value>The field label property energy saving rate.</value>
        public static string FieldLabel_Property_EnergySavingRate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_EnergySavingRate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Fax.
        /// </summary>
        /// <value>The field label property fax number.</value>
        public static string FieldLabel_Property_FaxNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_FaxNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Featured?.
        /// </summary>
        /// <value>The field label property featured.</value>
        public static string FieldLabel_Property_Featured
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Featured", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Garage?.
        /// </summary>
        /// <value>The field label property garage.</value>
        public static string FieldLabel_Property_Garage
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Garage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Gas?.
        /// </summary>
        /// <value>The field label property gas.</value>
        public static string FieldLabel_Property_Gas
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Gas", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Gas Whater Heating?.
        /// </summary>
        /// <value>The field label property gas whater heating.</value>
        public static string FieldLabel_Property_GasWhaterHeating
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_GasWhaterHeating", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Global Central Heating?.
        /// </summary>
        /// <value>The field label property global central heating.</value>
        public static string FieldLabel_Property_GlobalCentralHeating
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_GlobalCentralHeating", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Height.
        /// </summary>
        /// <value>The height of the field label property.</value>
        public static string FieldLabel_Property_Height
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Height", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Hot Water Suply?.
        /// </summary>
        /// <value>The field label property hot water suply.</value>
        public static string FieldLabel_Property_HotWaterSuply
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_HotWaterSuply", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Id.
        /// </summary>
        /// <value>The field label property identifier.</value>
        public static string FieldLabel_Property_Id
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Id", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Internal Status.
        /// </summary>
        /// <value>The field label property internal status.</value>
        public static string FieldLabel_Property_InternalStatus
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_InternalStatus", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Status Set By.
        /// </summary>
        /// <value>The name of the field label property internal status set by user.</value>
        public static string FieldLabel_Property_InternalStatusSetByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_InternalStatusSetByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Internal Status Date.
        /// </summary>
        /// <value>The field label property interna status date.</value>
        public static string FieldLabel_Property_InternaStatusDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_InternaStatusDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Kitchen Square.
        /// </summary>
        /// <value>The field label property kitchen square.</value>
        public static string FieldLabel_Property_KitchenSquare
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_KitchenSquare", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label property last modified by user.</value>
        public static string FieldLabel_Property_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label property last modified date.</value>
        public static string FieldLabel_Property_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Latitude.
        /// </summary>
        /// <value>The field label property latitude.</value>
        public static string FieldLabel_Property_Latitude
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Latitude", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to List Price.
        /// </summary>
        /// <value>The field label property list price.</value>
        public static string FieldLabel_Property_ListPrice
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_ListPrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Living Square.
        /// </summary>
        /// <value>The field label property living square.</value>
        public static string FieldLabel_Property_LivingSquare
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_LivingSquare", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Loan No.
        /// </summary>
        /// <value>The field label property loan no.</value>
        public static string FieldLabel_Property_LoanNo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_LoanNo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Local Central Heating?.
        /// </summary>
        /// <value>The field label property local central heating.</value>
        public static string FieldLabel_Property_LocalCentralHeating
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_LocalCentralHeating", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Longitude.
        /// </summary>
        /// <value>The field label property longitude.</value>
        public static string FieldLabel_Property_Longitude
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Longitude", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Main Image Url.
        /// </summary>
        /// <value>The field label property main image URL.</value>
        public static string FieldLabel_Property_MainImageUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_MainImageUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Map URL.
        /// </summary>
        /// <value>The field label property map URL.</value>
        public static string FieldLabel_Property_MapUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_MapUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Map Zoom.
        /// </summary>
        /// <value>The field label property map zoom.</value>
        public static string FieldLabel_Property_MapZoom
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_MapZoom", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Mark.
        /// </summary>
        /// <value>The field label property mark.</value>
        public static string FieldLabel_Property_Mark
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Mark", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Garages.
        /// </summary>
        /// <value>The field label property no of garages.</value>
        public static string FieldLabel_Property_NoOfGarages
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_NoOfGarages", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Original List Price.
        /// </summary>
        /// <value>The field label property original list price.</value>
        public static string FieldLabel_Property_OriginalListPrice
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_OriginalListPrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Phone.
        /// </summary>
        /// <value>The field label property phone number.</value>
        public static string FieldLabel_Property_PhoneNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_PhoneNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Pool?.
        /// </summary>
        /// <value>The field label property pool.</value>
        public static string FieldLabel_Property_Pool
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Pool", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Price Type.
        /// </summary>
        /// <value>The type of the field label property price.</value>
        public static string FieldLabel_Property_PriceType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_PriceType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Property Type.
        /// </summary>
        /// <value>The type of the field label property property.</value>
        public static string FieldLabel_Property_PropertyType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_PropertyType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Published?.
        /// </summary>
        /// <value>The field label property published.</value>
        public static string FieldLabel_Property_Published
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Published", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Publish From.
        /// </summary>
        /// <value>The field label property publish from.</value>
        public static string FieldLabel_Property_PublishFrom
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_PublishFrom", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Publish To.
        /// </summary>
        /// <value>The field label property publish to.</value>
        public static string FieldLabel_Property_PublishTo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_PublishTo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Section No.
        /// </summary>
        /// <value>The field label property section no.</value>
        public static string FieldLabel_Property_SectionNo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_SectionNo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Secure Parking?.
        /// </summary>
        /// <value>The field label property secure parking.</value>
        public static string FieldLabel_Property_SecureParking
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_SecureParking", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label property short description.</value>
        public static string FieldLabel_Property_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Spa?.
        /// </summary>
        /// <value>The field label property spa.</value>
        public static string FieldLabel_Property_Spa
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Spa", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to State.
        /// </summary>
        /// <value>The state of the field label property.</value>
        public static string FieldLabel_Property_State
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_State", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Status.
        /// </summary>
        /// <value>The field label property status.</value>
        public static string FieldLabel_Property_Status
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Status", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Status Date.
        /// </summary>
        /// <value>The field label property status date.</value>
        public static string FieldLabel_Property_StatusDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_StatusDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Store No.
        /// </summary>
        /// <value>The field label property store no.</value>
        public static string FieldLabel_Property_StoreNo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_StoreNo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Bathrooms.
        /// </summary>
        /// <value>The field label property total bathrooms.</value>
        public static string FieldLabel_Property_TotalBathrooms
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_TotalBathrooms", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Bedrooms.
        /// </summary>
        /// <value>The field label property total bedrooms.</value>
        public static string FieldLabel_Property_TotalBedrooms
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_TotalBedrooms", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Rooms.
        /// </summary>
        /// <value>The field label property total rooms.</value>
        public static string FieldLabel_Property_TotalRooms
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_TotalRooms", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Square.
        /// </summary>
        /// <value>The field label property total square.</value>
        public static string FieldLabel_Property_TotalSquare
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_TotalSquare", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Stores.
        /// </summary>
        /// <value>The field label property total stores.</value>
        public static string FieldLabel_Property_TotalStores
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_TotalStores", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Units.
        /// </summary>
        /// <value>The field label property total units.</value>
        public static string FieldLabel_Property_TotalUnits
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_TotalUnits", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Unit No.
        /// </summary>
        /// <value>The field label property unit no.</value>
        public static string FieldLabel_Property_UnitNo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_UnitNo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attachment File.
        /// </summary>
        /// <value>The field label property upload attachment.</value>
        public static string FieldLabel_Property_UploadAttachment
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_UploadAttachment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label property uploaded attachment.</value>
        public static string FieldLabel_Property_UploadedAttachmentName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_UploadedAttachmentName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Type.
        /// </summary>
        /// <value>The type of the field label property uploaded attachment.</value>
        public static string FieldLabel_Property_UploadedAttachmentType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_UploadedAttachmentType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label property uploaded photo.</value>
        public static string FieldLabel_Property_UploadedPhotoName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_UploadedPhotoName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Image file.
        /// </summary>
        /// <value>The field label property upload photo.</value>
        public static string FieldLabel_Property_UploadPhoto
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_UploadPhoto", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Video Url.
        /// </summary>
        /// <value>The field label property video URL.</value>
        public static string FieldLabel_Property_VideoUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_VideoUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Water Suply?.
        /// </summary>
        /// <value>The field label property water suply.</value>
        public static string FieldLabel_Property_WaterSuply
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_WaterSuply", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Website.
        /// </summary>
        /// <value>The field label property website.</value>
        public static string FieldLabel_Property_Website
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Website", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Zip.
        /// </summary>
        /// <value>The field label property zip.</value>
        public static string FieldLabel_Property_Zip
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Property_Zip", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label property detail create date.</value>
        public static string FieldLabel_PropertyDetail_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyDetail_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label property detail created by user.</value>
        public static string FieldLabel_PropertyDetail_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyDetail_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label property detail description.</value>
        public static string FieldLabel_PropertyDetail_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyDetail_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Id.
        /// </summary>
        /// <value>The field label property detail identifier.</value>
        public static string FieldLabel_PropertyDetail_Id
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyDetail_Id", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label property detail last modified by user.</value>
        public static string FieldLabel_PropertyDetail_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyDetail_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label property detail last modified date.</value>
        public static string FieldLabel_PropertyDetail_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyDetail_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label property detail.</value>
        public static string FieldLabel_PropertyDetail_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyDetail_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Published?.
        /// </summary>
        /// <value>The field label property detail published.</value>
        public static string FieldLabel_PropertyDetail_Published
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyDetail_Published", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Publish From.
        /// </summary>
        /// <value>The field label property detail publish from.</value>
        public static string FieldLabel_PropertyDetail_PublishFrom
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyDetail_PublishFrom", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Publish To.
        /// </summary>
        /// <value>The field label property detail publish to.</value>
        public static string FieldLabel_PropertyDetail_PublishTo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyDetail_PublishTo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label property feature create date.</value>
        public static string FieldLabel_PropertyFeature_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyFeature_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label property feature created by user.</value>
        public static string FieldLabel_PropertyFeature_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyFeature_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Feature.
        /// </summary>
        /// <value>The field label property feature feature.</value>
        public static string FieldLabel_PropertyFeature_Feature
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyFeature_Feature", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Id.
        /// </summary>
        /// <value>The field label property feature identifier.</value>
        public static string FieldLabel_PropertyFeature_Id
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyFeature_Id", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label property feature last modified by user.</value>
        public static string FieldLabel_PropertyFeature_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyFeature_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label property feature last modified date.</value>
        public static string FieldLabel_PropertyFeature_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyFeature_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Published?.
        /// </summary>
        /// <value>The field label property feature published.</value>
        public static string FieldLabel_PropertyFeature_Published
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyFeature_Published", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Publish From.
        /// </summary>
        /// <value>The field label property feature publish from.</value>
        public static string FieldLabel_PropertyFeature_PublishFrom
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyFeature_PublishFrom", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Publish To.
        /// </summary>
        /// <value>The field label property feature publish to.</value>
        public static string FieldLabel_PropertyFeature_PublishTo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PropertyFeature_PublishTo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Create Date.
        /// </summary>
        /// <value>The field label scheduled task create date.</value>
        public static string FieldLabel_ScheduledTask_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By User Name.
        /// </summary>
        /// <value>The name of the field label scheduled task created by user.</value>
        public static string FieldLabel_ScheduledTask_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label scheduled task description.</value>
        public static string FieldLabel_ScheduledTask_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled.
        /// </summary>
        /// <value>The field label scheduled task enabled.</value>
        public static string FieldLabel_ScheduledTask_Enabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_Enabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Executions.
        /// </summary>
        /// <value>The field label scheduled task executions.</value>
        public static string FieldLabel_ScheduledTask_Executions
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_Executions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Interval.
        /// </summary>
        /// <value>The field label scheduled task interval.</value>
        public static string FieldLabel_ScheduledTask_Interval
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_Interval", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Job Assembly.
        /// </summary>
        /// <value>The field label scheduled task job assembly.</value>
        public static string FieldLabel_ScheduledTask_JobAssembly
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_JobAssembly", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Job Class.
        /// </summary>
        /// <value>The field label scheduled task job class.</value>
        public static string FieldLabel_ScheduledTask_JobClass
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_JobClass", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Job Data.
        /// </summary>
        /// <value>The field label scheduled task job data.</value>
        public static string FieldLabel_ScheduledTask_JobData
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_JobData", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Message.
        /// </summary>
        /// <value>The field label scheduled task last message.</value>
        public static string FieldLabel_ScheduledTask_LastMessage
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_LastMessage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By User Name.
        /// </summary>
        /// <value>The name of the field label scheduled task last modified by user.</value>
        public static string FieldLabel_ScheduledTask_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified Date.
        /// </summary>
        /// <value>The field label scheduled task last modified date.</value>
        public static string FieldLabel_ScheduledTask_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Result.
        /// </summary>
        /// <value>The field label scheduled task last result.</value>
        public static string FieldLabel_ScheduledTask_LastResult
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_LastResult", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Run.
        /// </summary>
        /// <value>The field label scheduled task last run.</value>
        public static string FieldLabel_ScheduledTask_LastRun
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_LastRun", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label scheduled task.</value>
        public static string FieldLabel_ScheduledTask_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Next Run.
        /// </summary>
        /// <value>The field label scheduled task next run.</value>
        public static string FieldLabel_ScheduledTask_NextRun
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_NextRun", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Recurring.
        /// </summary>
        /// <value>The field label scheduled task recurring.</value>
        public static string FieldLabel_ScheduledTask_Recurring
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_Recurring", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Running.
        /// </summary>
        /// <value>The field label scheduled task running.</value>
        public static string FieldLabel_ScheduledTask_Running
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_Running", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Name.
        /// </summary>
        /// <value>The short name of the field label scheduled task.</value>
        public static string FieldLabel_ScheduledTask_ShortName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_ShortName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Unique Id.
        /// </summary>
        /// <value>The field label scheduled task unique identifier.</value>
        public static string FieldLabel_ScheduledTask_UniqueId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ScheduledTask_UniqueId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Country.
        /// </summary>
        /// <value>The field label state country.</value>
        public static string FieldLabel_State_Country
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_State_Country", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Maximum 1000 characters allowed.
        /// </summary>
        /// <value>The field label state text maximum characters.</value>
        public static string FieldLabel_State_Text_MaxCharacters
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_State_Text_MaxCharacters", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Three letters code.
        /// </summary>
        /// <value>The field label state three letter code.</value>
        public static string FieldLabel_State_ThreeLetterCode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_State_ThreeLetterCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Two letters code.
        /// </summary>
        /// <value>The field label state two letter code.</value>
        public static string FieldLabel_State_TwoLetterCode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_State_TwoLetterCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Create Date.
        /// </summary>
        /// <value>The field label subscriber create date.</value>
        public static string FieldLabel_Subscriber_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscriber_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By Username.
        /// </summary>
        /// <value>The name of the field label subscriber created by user.</value>
        public static string FieldLabel_Subscriber_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscriber_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Email.
        /// </summary>
        /// <value>The field label subscriber email.</value>
        public static string FieldLabel_Subscriber_Email
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscriber_Email", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled.
        /// </summary>
        /// <value>The field label subscriber enabled.</value>
        public static string FieldLabel_Subscriber_Enabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscriber_Enabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By Username.
        /// </summary>
        /// <value>The name of the field label subscriber last modified by user.</value>
        public static string FieldLabel_Subscriber_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscriber_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified Date.
        /// </summary>
        /// <value>The field label subscriber last modified date.</value>
        public static string FieldLabel_Subscriber_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscriber_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Newsletter.
        /// </summary>
        /// <value>The field label subscriber last newsletter identifier received.</value>
        public static string FieldLabel_Subscriber_LastNewsletterIdReceived
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscriber_LastNewsletterIdReceived", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Register Date.
        /// </summary>
        /// <value>The field label subscriber register date.</value>
        public static string FieldLabel_Subscriber_RegisterDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscriber_RegisterDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Auto Renew?.
        /// </summary>
        /// <value>The field label subscription automatic renew.</value>
        public static string FieldLabel_Subscription_AutoRenew
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_AutoRenew", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Contract Effective Date.
        /// </summary>
        /// <value>The field label subscription contract date.</value>
        public static string FieldLabel_Subscription_ContractDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_ContractDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label subscription create date.</value>
        public static string FieldLabel_Subscription_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label subscription created by user.</value>
        public static string FieldLabel_Subscription_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Initial Term.
        /// </summary>
        /// <value>The field label subscription initial term.</value>
        public static string FieldLabel_Subscription_InitialTerm
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_InitialTerm", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label subscription last modified by user.</value>
        public static string FieldLabel_Subscription_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label subscription last modified date.</value>
        public static string FieldLabel_Subscription_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Organization.
        /// </summary>
        /// <value>The field label subscription organization.</value>
        public static string FieldLabel_Subscription_Organization
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_Organization", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Renewal Term.
        /// </summary>
        /// <value>The field label subscription renewal term.</value>
        public static string FieldLabel_Subscription_RenewalTerm
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_RenewalTerm", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subscription Type.
        /// </summary>
        /// <value>The type of the field label subscription subscription.</value>
        public static string FieldLabel_Subscription_SubscriptionType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_SubscriptionType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subtotal.
        /// </summary>
        /// <value>The field label subscription sub total.</value>
        public static string FieldLabel_Subscription_SubTotal
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_SubTotal", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Term Ends.
        /// </summary>
        /// <value>The field label subscription term end.</value>
        public static string FieldLabel_Subscription_TermEnd
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_TermEnd", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Term range.
        /// </summary>
        /// <value>The field label subscription term range.</value>
        public static string FieldLabel_Subscription_TermRange
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_TermRange", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Term Starts.
        /// </summary>
        /// <value>The field label subscription term start.</value>
        public static string FieldLabel_Subscription_TermStart
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_TermStart", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to User.
        /// </summary>
        /// <value>The field label subscription user.</value>
        public static string FieldLabel_Subscription_User
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Subscription_User", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Action Assembly.
        /// </summary>
        /// <value>The field label workflow action action assembly.</value>
        public static string FieldLabel_WorkflowAction_ActionAssembly
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowAction_ActionAssembly", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Action Class.
        /// </summary>
        /// <value>The field label workflow action action class.</value>
        public static string FieldLabel_WorkflowAction_ActionClass
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowAction_ActionClass", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Action Type.
        /// </summary>
        /// <value>The type of the field label workflow action action.</value>
        public static string FieldLabel_WorkflowAction_ActionType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowAction_ActionType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attributes.
        /// </summary>
        /// <value>The field label workflow action attributes.</value>
        public static string FieldLabel_WorkflowAction_Attributes
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowAction_Attributes", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label workflow action create date.</value>
        public static string FieldLabel_WorkflowAction_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowAction_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label workflow action created by user.</value>
        public static string FieldLabel_WorkflowAction_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowAction_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label workflow action description.</value>
        public static string FieldLabel_WorkflowAction_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowAction_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label workflow action last modified by user.</value>
        public static string FieldLabel_WorkflowAction_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowAction_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label workflow action last modified date.</value>
        public static string FieldLabel_WorkflowAction_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowAction_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label workflow action.</value>
        public static string FieldLabel_WorkflowAction_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowAction_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label workflow action short description.</value>
        public static string FieldLabel_WorkflowAction_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowAction_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflow.
        /// </summary>
        /// <value>The field label workflow action workflow.</value>
        public static string FieldLabel_WorkflowAction_Workflow
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowAction_Workflow", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Direction.
        /// </summary>
        /// <value>The field label workflow action attribute attribute direction.</value>
        public static string FieldLabel_WorkflowActionAttribute_AttributeDirection
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_AttributeDirection", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attribute Type.
        /// </summary>
        /// <value>The type of the field label workflow action attribute attribute.</value>
        public static string FieldLabel_WorkflowActionAttribute_AttributeType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_AttributeType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label workflow action attribute create date.</value>
        public static string FieldLabel_WorkflowActionAttribute_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label workflow action attribute created by user.</value>
        public static string FieldLabel_WorkflowActionAttribute_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Data Source.
        /// </summary>
        /// <value>The field label workflow action attribute data source.</value>
        public static string FieldLabel_WorkflowActionAttribute_DataSource
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_DataSource", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Default Value.
        /// </summary>
        /// <value>The field label workflow action attribute deafult value.</value>
        public static string FieldLabel_WorkflowActionAttribute_DeafultValue
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_DeafultValue", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label workflow action attribute description.</value>
        public static string FieldLabel_WorkflowActionAttribute_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Public?.
        /// </summary>
        /// <value>The field label workflow action attribute is public.</value>
        public static string FieldLabel_WorkflowActionAttribute_IsPublic
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_IsPublic", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Readonly?.
        /// </summary>
        /// <value>The field label workflow action attribute is readonly.</value>
        public static string FieldLabel_WorkflowActionAttribute_IsReadonly
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_IsReadonly", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Visisble?.
        /// </summary>
        /// <value>The field label workflow action attribute is visisble.</value>
        public static string FieldLabel_WorkflowActionAttribute_IsVisisble
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_IsVisisble", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label workflow action attribute last modified by user.</value>
        public static string FieldLabel_WorkflowActionAttribute_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last modified At.
        /// </summary>
        /// <value>The field label workflow action attribute last modified date.</value>
        public static string FieldLabel_WorkflowActionAttribute_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label workflow action attribute.</value>
        public static string FieldLabel_WorkflowActionAttribute_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label workflow action attribute short description.</value>
        public static string FieldLabel_WorkflowActionAttribute_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Action.
        /// </summary>
        /// <value>The field label workflow action attribute workflow action.</value>
        public static string FieldLabel_WorkflowActionAttribute_WorkflowAction
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowActionAttribute_WorkflowAction", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Actions.
        /// </summary>
        /// <value>The field label workflow class actions.</value>
        public static string FieldLabel_WorkflowClass_Actions
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowClass_Actions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Allowed Roles.
        /// </summary>
        /// <value>The field label workflow class allowed roles.</value>
        public static string FieldLabel_WorkflowClass_AllowedRoles
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowClass_AllowedRoles", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Entity Assembly.
        /// </summary>
        /// <value>The field label workflow class bap entity assembly.</value>
        public static string FieldLabel_WorkflowClass_BapEntityAssembly
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowClass_BapEntityAssembly", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Entity Class.
        /// </summary>
        /// <value>The field label workflow class bap entity class.</value>
        public static string FieldLabel_WorkflowClass_BapEntityClass
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowClass_BapEntityClass", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label workflow class create date.</value>
        public static string FieldLabel_WorkflowClass_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowClass_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label workflow class created by user.</value>
        public static string FieldLabel_WorkflowClass_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowClass_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label workflow class description.</value>
        public static string FieldLabel_WorkflowClass_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowClass_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label workflow class last modified by user.</value>
        public static string FieldLabel_WorkflowClass_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowClass_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label workflow class last modified date.</value>
        public static string FieldLabel_WorkflowClass_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowClass_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label workflow class.</value>
        public static string FieldLabel_WorkflowClass_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowClass_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label workflow class short description.</value>
        public static string FieldLabel_WorkflowClass_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowClass_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Stages.
        /// </summary>
        /// <value>The field label workflow class stages.</value>
        public static string FieldLabel_WorkflowClass_Stages
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowClass_Stages", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Transitions.
        /// </summary>
        /// <value>The field label workflow class transitions.</value>
        public static string FieldLabel_WorkflowClass_Transitions
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowClass_Transitions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Entity Assembly.
        /// </summary>
        /// <value>The field label workflow object bap entity assembly.</value>
        public static string FieldLabel_WorkflowObject_BapEntityAssembly
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowObject_BapEntityAssembly", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Entity Class.
        /// </summary>
        /// <value>The field label workflow object bap entity class.</value>
        public static string FieldLabel_WorkflowObject_BapEntityClass
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowObject_BapEntityClass", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Entity Id.
        /// </summary>
        /// <value>The field label workflow object bap entity identifier.</value>
        public static string FieldLabel_WorkflowObject_BapEntityId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowObject_BapEntityId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label workflow object create date.</value>
        public static string FieldLabel_WorkflowObject_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowObject_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label workflow object created by user.</value>
        public static string FieldLabel_WorkflowObject_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowObject_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label workflow object description.</value>
        public static string FieldLabel_WorkflowObject_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowObject_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label workflow object last modified by user.</value>
        public static string FieldLabel_WorkflowObject_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowObject_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label workflow object last modified date.</value>
        public static string FieldLabel_WorkflowObject_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowObject_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label workflow object.</value>
        public static string FieldLabel_WorkflowObject_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowObject_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label workflow object short description.</value>
        public static string FieldLabel_WorkflowObject_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowObject_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflow.
        /// </summary>
        /// <value>The field label workflow object workflow.</value>
        public static string FieldLabel_WorkflowObject_Workflow
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowObject_Workflow", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflow Data.
        /// </summary>
        /// <value>The field label workflow object workflow data.</value>
        public static string FieldLabel_WorkflowObject_WorkflowData
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowObject_WorkflowData", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label workflow stage create date.</value>
        public static string FieldLabel_WorkflowStage_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStage_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label workflow stage created by user.</value>
        public static string FieldLabel_WorkflowStage_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStage_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label workflow stage description.</value>
        public static string FieldLabel_WorkflowStage_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStage_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label workflow stage last modified by user.</value>
        public static string FieldLabel_WorkflowStage_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStage_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label workflow stage last modified date.</value>
        public static string FieldLabel_WorkflowStage_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStage_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label workflow stage.</value>
        public static string FieldLabel_WorkflowStage_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStage_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label workflow stage short description.</value>
        public static string FieldLabel_WorkflowStage_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStage_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Stage Type.
        /// </summary>
        /// <value>The type of the field label workflow stage stage.</value>
        public static string FieldLabel_WorkflowStage_StageType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStage_StageType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflow.
        /// </summary>
        /// <value>The field label workflow stage workflow.</value>
        public static string FieldLabel_WorkflowStage_Workflow
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStage_Workflow", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label workflow stage transition create date.</value>
        public static string FieldLabel_WorkflowStageTransition_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStageTransition_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label workflow stage transition created by user.</value>
        public static string FieldLabel_WorkflowStageTransition_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStageTransition_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label workflow stage transition description.</value>
        public static string FieldLabel_WorkflowStageTransition_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStageTransition_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to From Stage.
        /// </summary>
        /// <value>The field label workflow stage transition from stage.</value>
        public static string FieldLabel_WorkflowStageTransition_FromStage
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStageTransition_FromStage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Injected Actions.
        /// </summary>
        /// <value>The field label workflow stage transition injected actions.</value>
        public static string FieldLabel_WorkflowStageTransition_InjectedActions
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStageTransition_InjectedActions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label workflow stage transition last modified by user.</value>
        public static string FieldLabel_WorkflowStageTransition_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStageTransition_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label workflow stage transition last modified date.</value>
        public static string FieldLabel_WorkflowStageTransition_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStageTransition_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Main Image Url.
        /// </summary>
        /// <value>The field label workflow stage transition main image URL.</value>
        public static string FieldLabel_WorkflowStageTransition_MainImageUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStageTransition_MainImageUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label workflow stage transition.</value>
        public static string FieldLabel_WorkflowStageTransition_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStageTransition_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label workflow stage transition short description.</value>
        public static string FieldLabel_WorkflowStageTransition_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStageTransition_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to To Stage.
        /// </summary>
        /// <value>The field label workflow stage transition to stage.</value>
        public static string FieldLabel_WorkflowStageTransition_ToStage
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStageTransition_ToStage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflow.
        /// </summary>
        /// <value>The field label workflow stage transition workflow.</value>
        public static string FieldLabel_WorkflowStageTransition_Workflow
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkflowStageTransition_Workflow", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label work service create date.</value>
        public static string FieldLabel_WorkService_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkService_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label work service created by user.</value>
        public static string FieldLabel_WorkService_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkService_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Id.
        /// </summary>
        /// <value>The field label work service identifier.</value>
        public static string FieldLabel_WorkService_Id
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkService_Id", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label work service last modified by user.</value>
        public static string FieldLabel_WorkService_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkService_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label work service last modified date.</value>
        public static string FieldLabel_WorkService_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkService_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label work service.</value>
        public static string FieldLabel_WorkService_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkService_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Service Type.
        /// </summary>
        /// <value>The type of the field label work service service.</value>
        public static string FieldLabel_WorkService_ServiceType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_WorkService_ServiceType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Your phone number was added..
        /// </summary>
        /// <value>The status text add phone success.</value>
        public static string StatusText_AddPhoneSuccess
        {
            get
            {
                return ResourceManagerGetString("StatusText_AddPhoneSuccess", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Your password has been changed..
        /// </summary>
        /// <value>The status text password changed.</value>
        public static string StatusText_PasswordChanged
        {
            get
            {
                return ResourceManagerGetString("StatusText_PasswordChanged", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to The external login was removed..
        /// </summary>
        /// <value>The status text password removed.</value>
        public static string StatusText_PasswordRemoved
        {
            get
            {
                return ResourceManagerGetString("StatusText_PasswordRemoved", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Your password has been set..
        /// </summary>
        /// <value>The status text password set.</value>
        public static string StatusText_PasswordSet
        {
            get
            {
                return ResourceManagerGetString("StatusText_PasswordSet", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Your phone number was removed..
        /// </summary>
        /// <value>The status text remove phone success.</value>
        public static string StatusText_RemovePhoneSuccess
        {
            get
            {
                return ResourceManagerGetString("StatusText_RemovePhoneSuccess", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Your two-factor authentication provider has been set..
        /// </summary>
        /// <value>The status text set two factor success.</value>
        public static string StatusText_SetTwoFactorSuccess
        {
            get
            {
                return ResourceManagerGetString("StatusText_SetTwoFactorSuccess", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to We couldn't find it....
        /// </summary>
        /// <value>The UI text 404 error.</value>
        public static string UIText_404Error
        {
            get
            {
                return ResourceManagerGetString("UIText_404Error", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Actions.
        /// </summary>
        /// <value>The UI text actions.</value>
        public static string UIText_Actions
        {
            get
            {
                return ResourceManagerGetString("UIText_Actions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Add.
        /// </summary>
        /// <value>The UI text add.</value>
        public static string UIText_Add
        {
            get
            {
                return ResourceManagerGetString("UIText_Add", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Additional.
        /// </summary>
        /// <value>The UI text additional.</value>
        public static string UIText_Additional
        {
            get
            {
                return ResourceManagerGetString("UIText_Additional", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address.
        /// </summary>
        /// <value>The UI text address.</value>
        public static string UIText_Address
        {
            get
            {
                return ResourceManagerGetString("UIText_Address", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Add to Favorites.
        /// </summary>
        /// <value>The UI text add to favorites.</value>
        public static string UIText_AddToFavorites
        {
            get
            {
                return ResourceManagerGetString("UIText_AddToFavorites", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Agent Name.
        /// </summary>
        /// <value>The name of the UI text agent.</value>
        public static string UIText_AgentName
        {
            get
            {
                return ResourceManagerGetString("UIText_AgentName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Agent(s).
        /// </summary>
        /// <value>The UI text agents.</value>
        public static string UIText_Agents
        {
            get
            {
                return ResourceManagerGetString("UIText_Agents", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to AGENTS &amp; COMPANIES - START NOW!.
        /// </summary>
        /// <value>The UI text agents and companies.</value>
        public static string UIText_AgentsAndCompanies
        {
            get
            {
                return ResourceManagerGetString("UIText_AgentsAndCompanies", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Already have an account?.
        /// </summary>
        /// <value>The UI text already have account.</value>
        public static string UIText_AlreadyHaveAccount
        {
            get
            {
                return ResourceManagerGetString("UIText_AlreadyHaveAccount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to B.A.P..
        /// </summary>
        /// <value>The UI text application logo.</value>
        public static string UIText_ApplicationLogo
        {
            get
            {
                return ResourceManagerGetString("UIText_ApplicationLogo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Application Slogan.
        /// </summary>
        /// <value>The UI text application slogan.</value>
        public static string UIText_ApplicationSlogan
        {
            get
            {
                return ResourceManagerGetString("UIText_ApplicationSlogan", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to B.A.P. Application.
        /// </summary>
        /// <value>The UI text application title.</value>
        public static string UIText_ApplicationTitle
        {
            get
            {
                return ResourceManagerGetString("UIText_ApplicationTitle", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Assemblies.
        /// </summary>
        /// <value>The UI text assemblies.</value>
        public static string UIText_Assemblies
        {
            get
            {
                return ResourceManagerGetString("UIText_Assemblies", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Assemblies and classes.
        /// </summary>
        /// <value>The UI text assemblies classes.</value>
        public static string UIText_Assemblies_Classes
        {
            get
            {
                return ResourceManagerGetString("UIText_Assemblies_Classes", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Assigned To.
        /// </summary>
        /// <value>The UI text assigned to.</value>
        public static string UIText_AssignedTo
        {
            get
            {
                return ResourceManagerGetString("UIText_AssignedTo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attachment.
        /// </summary>
        /// <value>The UI text attachment.</value>
        public static string UIText_Attachment
        {
            get
            {
                return ResourceManagerGetString("UIText_Attachment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attachments.
        /// </summary>
        /// <value>The UI text attachments.</value>
        public static string UIText_Attachments
        {
            get
            {
                return ResourceManagerGetString("UIText_Attachments", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attributes required:.
        /// </summary>
        /// <value>The UI text attributes required.</value>
        public static string UIText_AttributesRequired
        {
            get
            {
                return ResourceManagerGetString("UIText_AttributesRequired", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Back.
        /// </summary>
        /// <value>The UI text back.</value>
        public static string UIText_Back
        {
            get
            {
                return ResourceManagerGetString("UIText_Back", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Back to List.
        /// </summary>
        /// <value>The UI text back to list.</value>
        public static string UIText_BackToList
        {
            get
            {
                return ResourceManagerGetString("UIText_BackToList", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Basic Settings.
        /// </summary>
        /// <value>The UI text basic settings.</value>
        public static string UIText_BasicSettings
        {
            get
            {
                return ResourceManagerGetString("UIText_BasicSettings", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Bathrooms.
        /// </summary>
        /// <value>The UI text bathrooms.</value>
        public static string UIText_Bathrooms
        {
            get
            {
                return ResourceManagerGetString("UIText_Bathrooms", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Bedrooms.
        /// </summary>
        /// <value>The UI text bedrooms.</value>
        public static string UIText_Bedrooms
        {
            get
            {
                return ResourceManagerGetString("UIText_Bedrooms", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Add Views.
        /// </summary>
        /// <value>The UI text button add views.</value>
        public static string UIText_ButtonAddViews
        {
            get
            {
                return ResourceManagerGetString("UIText_ButtonAddViews", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Clear Cache.
        /// </summary>
        /// <value>The UI text button clear cache.</value>
        public static string UIText_ButtonClearCache
        {
            get
            {
                return ResourceManagerGetString("UIText_ButtonClearCache", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customize.
        /// </summary>
        /// <value>The UI text button customize.</value>
        public static string UIText_ButtonCustomize
        {
            get
            {
                return ResourceManagerGetString("UIText_ButtonCustomize", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Publish.
        /// </summary>
        /// <value>The UI text button publish.</value>
        public static string UIText_ButtonPublish
        {
            get
            {
                return ResourceManagerGetString("UIText_ButtonPublish", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cancel.
        /// </summary>
        /// <value>The UI text cancel.</value>
        public static string UIText_Cancel
        {
            get
            {
                return ResourceManagerGetString("UIText_Cancel", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Change Password.
        /// </summary>
        /// <value>The UI text change password.</value>
        public static string UIText_ChangePassword
        {
            get
            {
                return ResourceManagerGetString("UIText_ChangePassword", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Do you want to toggle two factor authentication?.
        /// </summary>
        /// <value>The UI text change two factor authentication question.</value>
        public static string UIText_ChangeTwoFactorAuthQuestion
        {
            get
            {
                return ResourceManagerGetString("UIText_ChangeTwoFactorAuthQuestion", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Change your password.
        /// </summary>
        /// <value>The UI text change your password.</value>
        public static string UIText_ChangeYourPassword
        {
            get
            {
                return ResourceManagerGetString("UIText_ChangeYourPassword", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose business flow:.
        /// </summary>
        /// <value>The UI text choose business flow.</value>
        public static string UIText_ChooseBusinessFlow
        {
            get
            {
                return ResourceManagerGetString("UIText_ChooseBusinessFlow", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose location type.
        /// </summary>
        /// <value>The UI text chooselocationtype.</value>
        public static string UIText_Chooselocationtype
        {
            get
            {
                return ResourceManagerGetString("UIText_Chooselocationtype", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose Type.
        /// </summary>
        /// <value>The type of the UI text choose lookup.</value>
        public static string UIText_ChooseLookupType
        {
            get
            {
                return ResourceManagerGetString("UIText_ChooseLookupType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose operator.
        /// </summary>
        /// <value>The UI text choose operator.</value>
        public static string UIText_ChooseOperator
        {
            get
            {
                return ResourceManagerGetString("UIText_ChooseOperator", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Chosen.
        /// </summary>
        /// <value>The UI text chosen.</value>
        public static string UIText_Chosen
        {
            get
            {
                return ResourceManagerGetString("UIText_Chosen", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Change your password here.
        /// </summary>
        /// <value>The UI text ch password title.</value>
        public static string UIText_ChPasswordTitle
        {
            get
            {
                return ResourceManagerGetString("UIText_ChPasswordTitle", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Clone to different language.
        /// </summary>
        /// <value>The UI text clone locale.</value>
        public static string UIText_CloneLocale
        {
            get
            {
                return ResourceManagerGetString("UIText_CloneLocale", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Close.
        /// </summary>
        /// <value>The UI text close.</value>
        public static string UIText_Close
        {
            get
            {
                return ResourceManagerGetString("UIText_Close", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Code from Youtube or Vimeo only.
        /// </summary>
        /// <value>The UI text code from video hosting.</value>
        public static string UIText_CodeFromVideoHosting
        {
            get
            {
                return ResourceManagerGetString("UIText_CodeFromVideoHosting", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to .
        /// </summary>
        /// <value>The UI text contact address.</value>
        public static string UIText_ContactAddress
        {
            get
            {
                return ResourceManagerGetString("UIText_ContactAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to info@bap-software.com.
        /// </summary>
        /// <value>The UI text contact email.</value>
        public static string UIText_ContactEmail
        {
            get
            {
                return ResourceManagerGetString("UIText_ContactEmail", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to +353 1 254 8862.
        /// </summary>
        /// <value>The UI text contact phone.</value>
        public static string UIText_ContactPhone
        {
            get
            {
                return ResourceManagerGetString("UIText_ContactPhone", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Contact us quickly.
        /// </summary>
        /// <value>The UI text contact us quick.</value>
        public static string UIText_ContactUsQuick
        {
            get
            {
                return ResourceManagerGetString("UIText_ContactUsQuick", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Management.
        /// </summary>
        /// <value>The UI text content management.</value>
        public static string UIText_ContentManagement
        {
            get
            {
                return ResourceManagerGetString("UIText_ContentManagement", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to I have read this notice.
        /// </summary>
        /// <value>The UI text cookies button.</value>
        public static string UIText_Cookies_Button
        {
            get
            {
                return ResourceManagerGetString("UIText_Cookies_Button", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Important information regarding cookies.
        /// </summary>
        /// <value>The UI text cookies header.</value>
        public static string UIText_Cookies_Header
        {
            get
            {
                return ResourceManagerGetString("UIText_Cookies_Header", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to You can find out more here..
        /// </summary>
        /// <value>The UI text cookies link.</value>
        public static string UIText_Cookies_Link
        {
            get
            {
                return ResourceManagerGetString("UIText_Cookies_Link", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to for the use of cookies..
        /// </summary>
        /// <value>The UI text cookies text end.</value>
        public static string UIText_Cookies_Text_End
        {
            get
            {
                return ResourceManagerGetString("UIText_Cookies_Text_End", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to We use cookies to improve website performance, analysis, and personalization of websites. By using the site or by clicking I agree you agree to our.
        /// </summary>
        /// <value>The UI text cookies text start.</value>
        public static string UIText_Cookies_Text_Start
        {
            get
            {
                return ResourceManagerGetString("UIText_Cookies_Text_Start", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Coordinates.
        /// </summary>
        /// <value>The UI text coordinates.</value>
        public static string UIText_Coordinates
        {
            get
            {
                return ResourceManagerGetString("UIText_Coordinates", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Create.
        /// </summary>
        /// <value>The UI text create.</value>
        public static string UIText_Create
        {
            get
            {
                return ResourceManagerGetString("UIText_Create", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Quickly register new account with us.
        /// </summary>
        /// <value>The UI text create new account.</value>
        public static string UIText_CreateNewAccount
        {
            get
            {
                return ResourceManagerGetString("UIText_CreateNewAccount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Custom configuration was saved!.
        /// </summary>
        /// <value>The UI text custom configuration saved.</value>
        public static string UIText_CustomConfiguration_Saved
        {
            get
            {
                return ResourceManagerGetString("UIText_CustomConfiguration_Saved", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Default Order.
        /// </summary>
        /// <value>The UI text default order.</value>
        public static string UIText_DefaultOrder
        {
            get
            {
                return ResourceManagerGetString("UIText_DefaultOrder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Delete.
        /// </summary>
        /// <value>The UI text delete.</value>
        public static string UIText_Delete
        {
            get
            {
                return ResourceManagerGetString("UIText_Delete", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The UI text description.</value>
        public static string UIText_Description
        {
            get
            {
                return ResourceManagerGetString("UIText_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Details.
        /// </summary>
        /// <value>The UI text details.</value>
        public static string UIText_Details
        {
            get
            {
                return ResourceManagerGetString("UIText_Details", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Disable two factor authentication.
        /// </summary>
        /// <value>The UI text disable two factor authentication.</value>
        public static string UIText_DisableTwoFactorAuth
        {
            get
            {
                return ResourceManagerGetString("UIText_DisableTwoFactorAuth", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Select.
        /// </summary>
        /// <value>The UI text drop down select option.</value>
        public static string UIText_DropDown_SelectOption
        {
            get
            {
                return ResourceManagerGetString("UIText_DropDown_SelectOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Edit.
        /// </summary>
        /// <value>The UI text edit.</value>
        public static string UIText_Edit
        {
            get
            {
                return ResourceManagerGetString("UIText_Edit", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enable two factor authentication.
        /// </summary>
        /// <value>The UI text enable two factor authentication.</value>
        public static string UIText_EnableTwoFactorAuth
        {
            get
            {
                return ResourceManagerGetString("UIText_EnableTwoFactorAuth", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Error Details.
        /// </summary>
        /// <value>The UI text error details.</value>
        public static string UIText_ErrorDetails
        {
            get
            {
                return ResourceManagerGetString("UIText_ErrorDetails", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cannot create attachment if file is not uploaded..
        /// </summary>
        /// <value>The UI text error no file no attachment.</value>
        public static string UIText_ErrorNoFileNoAttachment
        {
            get
            {
                return ResourceManagerGetString("UIText_ErrorNoFileNoAttachment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to External Logins.
        /// </summary>
        /// <value>The UI text external logins.</value>
        public static string UIText_ExternalLogins
        {
            get
            {
                return ResourceManagerGetString("UIText_ExternalLogins", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Extra information.
        /// </summary>
        /// <value>The UI text extrainformation.</value>
        public static string UIText_Extrainformation
        {
            get
            {
                return ResourceManagerGetString("UIText_Extrainformation", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Featured Properties.
        /// </summary>
        /// <value>The UI text featured properties.</value>
        public static string UIText_FeaturedProperties
        {
            get
            {
                return ResourceManagerGetString("UIText_FeaturedProperties", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Features.
        /// </summary>
        /// <value>The UI text features.</value>
        public static string UIText_Features
        {
            get
            {
                return ResourceManagerGetString("UIText_Features", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File not found.
        /// </summary>
        /// <value>The UI text file not found.</value>
        public static string UIText_FileNotFound
        {
            get
            {
                return ResourceManagerGetString("UIText_FileNotFound", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File not found: {0}..
        /// </summary>
        /// <value>The UI text file path not found.</value>
        public static string UIText_FilePathNotFound
        {
            get
            {
                return ResourceManagerGetString("UIText_FilePathNotFound", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Files must be.
        /// </summary>
        /// <value>The UI text filesmustbe.</value>
        public static string UIText_Filesmustbe
        {
            get
            {
                return ResourceManagerGetString("UIText_Filesmustbe", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File system is not configured.
        /// </summary>
        /// <value>The UI text file system not configured.</value>
        public static string UIText_FileSystemNotConfigured
        {
            get
            {
                return ResourceManagerGetString("UIText_FileSystemNotConfigured", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Find A Property.
        /// </summary>
        /// <value>The UI text find a property.</value>
        public static string UIText_FindAProperty
        {
            get
            {
                return ResourceManagerGetString("UIText_FindAProperty", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Forgot Password.
        /// </summary>
        /// <value>The UI text forgot password.</value>
        public static string UIText_ForgotPassword
        {
            get
            {
                return ResourceManagerGetString("UIText_ForgotPassword", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Forgot your password?.
        /// </summary>
        /// <value>The UI text forgot your password.</value>
        public static string UIText_ForgotYourPassword
        {
            get
            {
                return ResourceManagerGetString("UIText_ForgotYourPassword", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Garages.
        /// </summary>
        /// <value>The UI text garages.</value>
        public static string UIText_Garages
        {
            get
            {
                return ResourceManagerGetString("UIText_Garages", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to I agree and wish to proceed.
        /// </summary>
        /// <value>The UI text GDPR button.</value>
        public static string UIText_Gdpr_Button
        {
            get
            {
                return ResourceManagerGetString("UIText_Gdpr_Button", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Please sign GDPR agreement.
        /// </summary>
        /// <value>The UI text GDPR header.</value>
        public static string UIText_Gdpr_Header
        {
            get
            {
                return ResourceManagerGetString("UIText_Gdpr_Header", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to You can find out more here..
        /// </summary>
        /// <value>The UI text GDPR link.</value>
        public static string UIText_Gdpr_Link
        {
            get
            {
                return ResourceManagerGetString("UIText_Gdpr_Link", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Our site is under compliance with the General Data Protection Regulation (GDPR). The GDPR is an EU legislation that is designed to protect the fundamental rights of citizens and their personal data. This law ensures that people not only know where their private data is kept, but it also holds organizations accountable and transparent in their practices..
        /// </summary>
        /// <value>The UI text GDPR text.</value>
        public static string UIText_Gdpr_Text
        {
            get
            {
                return ResourceManagerGetString("UIText_Gdpr_Text", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to An error occurred while processing your request..
        /// </summary>
        /// <value>The UI text general error text.</value>
        public static string UIText_GeneralErrorText
        {
            get
            {
                return ResourceManagerGetString("UIText_GeneralErrorText", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Getting started.
        /// </summary>
        /// <value>The UI text getting started.</value>
        public static string UIText_GettingStarted
        {
            get
            {
                return ResourceManagerGetString("UIText_GettingStarted", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Hello.
        /// </summary>
        /// <value>The UI text hello.</value>
        public static string UIText_Hello
        {
            get
            {
                return ResourceManagerGetString("UIText_Hello", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Home Page.
        /// </summary>
        /// <value>The UI text home page.</value>
        public static string UIText_HomePage
        {
            get
            {
                return ResourceManagerGetString("UIText_HomePage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Identity.
        /// </summary>
        /// <value>The UI text identity.</value>
        public static string UIText_Identity
        {
            get
            {
                return ResourceManagerGetString("UIText_Identity", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Image.
        /// </summary>
        /// <value>The UI text image.</value>
        public static string UIText_Image
        {
            get
            {
                return ResourceManagerGetString("UIText_Image", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Images.
        /// </summary>
        /// <value>The UI text images.</value>
        public static string UIText_Images
        {
            get
            {
                return ResourceManagerGetString("UIText_Images", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enter Action Attributes.
        /// </summary>
        /// <value>The UI text input wf action attribs.</value>
        public static string UIText_InputWFActionAttribs
        {
            get
            {
                return ResourceManagerGetString("UIText_InputWFActionAttribs", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Item.
        /// </summary>
        /// <value>The UI text item.</value>
        public static string UIText_Item
        {
            get
            {
                return ResourceManagerGetString("UIText_Item", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Keyword.
        /// </summary>
        /// <value>The UI text keyword.</value>
        public static string UIText_Keyword
        {
            get
            {
                return ResourceManagerGetString("UIText_Keyword", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Latest Blog Posts.
        /// </summary>
        /// <value>The UI text latest blog posts.</value>
        public static string UIText_LatestBlogPosts
        {
            get
            {
                return ResourceManagerGetString("UIText_LatestBlogPosts", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Recent Posts.
        /// </summary>
        /// <value>The UI text latest recent posts.</value>
        public static string UIText_LatestRecentPosts
        {
            get
            {
                return ResourceManagerGetString("UIText_LatestRecentPosts", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Leave Comments.
        /// </summary>
        /// <value>The UI text leave comments.</value>
        public static string UIText_LeaveComments
        {
            get
            {
                return ResourceManagerGetString("UIText_LeaveComments", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Entity {0} with Id = {1}, has been cloned to the {2} culture. You can see it under appropriate locale..
        /// </summary>
        /// <value>The UI text localizagion clone done.</value>
        public static string UIText_LocalizagionCloneDone
        {
            get
            {
                return ResourceManagerGetString("UIText_LocalizagionCloneDone", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Location.
        /// </summary>
        /// <value>The UI text location.</value>
        public static string UIText_Location
        {
            get
            {
                return ResourceManagerGetString("UIText_Location", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Lock.
        /// </summary>
        /// <value>The UI text lock.</value>
        public static string UIText_Lock
        {
            get
            {
                return ResourceManagerGetString("UIText_Lock", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Login as account.
        /// </summary>
        /// <value>The UI text login account.</value>
        public static string UIText_LoginAccount
        {
            get
            {
                return ResourceManagerGetString("UIText_LoginAccount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Log in.
        /// </summary>
        /// <value>The UI text login link.</value>
        public static string UIText_LoginLink
        {
            get
            {
                return ResourceManagerGetString("UIText_LoginLink", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Log off.
        /// </summary>
        /// <value>The UI text log off link.</value>
        public static string UIText_LogOffLink
        {
            get
            {
                return ResourceManagerGetString("UIText_LogOffLink", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Main.
        /// </summary>
        /// <value>The UI text main.</value>
        public static string UIText_Main
        {
            get
            {
                return ResourceManagerGetString("UIText_Main", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Main Photo.
        /// </summary>
        /// <value>The UI text main photo.</value>
        public static string UIText_MainPhoto
        {
            get
            {
                return ResourceManagerGetString("UIText_MainPhoto", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Manage.
        /// </summary>
        /// <value>The UI text manage link.</value>
        public static string UIText_ManageLink
        {
            get
            {
                return ResourceManagerGetString("UIText_ManageLink", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Manage your properties with iRealty.guru.
        /// </summary>
        /// <value>The UI text manage your properties.</value>
        public static string UIText_ManageYourProperties
        {
            get
            {
                return ResourceManagerGetString("UIText_ManageYourProperties", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Map.
        /// </summary>
        /// <value>The UI text map.</value>
        public static string UIText_Map
        {
            get
            {
                return ResourceManagerGetString("UIText_Map", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Marketing.
        /// </summary>
        /// <value>The UI text marketing.</value>
        public static string UIText_Marketing
        {
            get
            {
                return ResourceManagerGetString("UIText_Marketing", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Marketing@bap-software.com.
        /// </summary>
        /// <value>The UI text marketing email.</value>
        public static string UIText_MarketingEmail
        {
            get
            {
                return ResourceManagerGetString("UIText_MarketingEmail", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Max Area.
        /// </summary>
        /// <value>The UI text maximum area.</value>
        public static string UIText_MaxArea
        {
            get
            {
                return ResourceManagerGetString("UIText_MaxArea", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Max Price.
        /// </summary>
        /// <value>The UI text maximum price.</value>
        public static string UIText_MaxPrice
        {
            get
            {
                return ResourceManagerGetString("UIText_MaxPrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Max size 10mb.
        /// </summary>
        /// <value>The UI text maxsize10mb.</value>
        public static string UIText_Maxsize10mb
        {
            get
            {
                return ResourceManagerGetString("UIText_Maxsize10mb", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Max size 2mb.
        /// </summary>
        /// <value>The UI text maxsize2mb.</value>
        public static string UIText_Maxsize2mb
        {
            get
            {
                return ResourceManagerGetString("UIText_Maxsize2mb", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Media.
        /// </summary>
        /// <value>The UI text media.</value>
        public static string UIText_Media
        {
            get
            {
                return ResourceManagerGetString("UIText_Media", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Media Resources.
        /// </summary>
        /// <value>The UI text media resources.</value>
        public static string UIText_MediaResources
        {
            get
            {
                return ResourceManagerGetString("UIText_MediaResources", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to About.
        /// </summary>
        /// <value>The UI text menu about.</value>
        public static string UIText_Menu_About
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_About", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Administration.
        /// </summary>
        /// <value>The UI text menu administration.</value>
        public static string UIText_Menu_Administration
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Administration", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Agents.
        /// </summary>
        /// <value>The UI text menu agents.</value>
        public static string UIText_Menu_Agents
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Agents", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Appartment.
        /// </summary>
        /// <value>The UI text menu appartment.</value>
        public static string UIText_Menu_Appartment
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Appartment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Apartment Building.
        /// </summary>
        /// <value>The UI text menu appartment building.</value>
        public static string UIText_Menu_AppartmentBuilding
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_AppartmentBuilding", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attachments.
        /// </summary>
        /// <value>The UI text menu attachments.</value>
        public static string UIText_Menu_Attachments
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Attachments", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Blog.
        /// </summary>
        /// <value>The UI text menu blog.</value>
        public static string UIText_Menu_Blog
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Blog", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Blogs.
        /// </summary>
        /// <value>The UI text menu blogs.</value>
        public static string UIText_Menu_Blogs
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Blogs", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Companies.
        /// </summary>
        /// <value>The UI text menu companies.</value>
        public static string UIText_Menu_Companies
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Companies", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Condominium.
        /// </summary>
        /// <value>The UI text menu condominium.</value>
        public static string UIText_Menu_Condominium
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Condominium", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Contact.
        /// </summary>
        /// <value>The UI text menu contact.</value>
        public static string UIText_Menu_Contact
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Contact", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Controls.
        /// </summary>
        /// <value>The UI text menu content controls.</value>
        public static string UIText_Menu_ContentControls
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_ContentControls", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Control Types.
        /// </summary>
        /// <value>The UI text menu content control types.</value>
        public static string UIText_Menu_ContentControlTypes
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_ContentControlTypes", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Content Management.
        /// </summary>
        /// <value>The UI text menu content management.</value>
        public static string UIText_Menu_ContentManagement
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_ContentManagement", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Countries.
        /// </summary>
        /// <value>The UI text menu countries.</value>
        public static string UIText_Menu_Countries
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Countries", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Currencies.
        /// </summary>
        /// <value>The UI text menu currencies.</value>
        public static string UIText_Menu_Currencies
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Currencies", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Custom Configurations.
        /// </summary>
        /// <value>The UI text menu custom configurations.</value>
        public static string UIText_Menu_CustomConfigurations
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_CustomConfigurations", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Document Templates.
        /// </summary>
        /// <value>The UI text menu document templates.</value>
        public static string UIText_Menu_DocumentTemplates
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_DocumentTemplates", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Email Notifications.
        /// </summary>
        /// <value>The UI text menu email notifications.</value>
        public static string UIText_Menu_EmailNotifications
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_EmailNotifications", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Event Log.
        /// </summary>
        /// <value>The UI text menu event log.</value>
        public static string UIText_Menu_EventLog
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_EventLog", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File System.
        /// </summary>
        /// <value>The UI text menu file system.</value>
        public static string UIText_Menu_FileSystem
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_FileSystem", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to For Rent.
        /// </summary>
        /// <value>The UI text menu for rent.</value>
        public static string UIText_Menu_ForRent
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_ForRent", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to For Sale.
        /// </summary>
        /// <value>The UI text menu for sale.</value>
        public static string UIText_Menu_ForSale
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_ForSale", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Home.
        /// </summary>
        /// <value>The index of the UI text menu.</value>
        public static string UIText_Menu_Index
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Index", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Lookups.
        /// </summary>
        /// <value>The UI text menu lookups.</value>
        public static string UIText_Menu_Lookups
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Lookups", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Messages.
        /// </summary>
        /// <value>The UI text menu messages.</value>
        public static string UIText_Menu_Messages
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Messages", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Modules.
        /// </summary>
        /// <value>The UI text menu modules.</value>
        public static string UIText_Menu_Modules
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Modules", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Modules.
        /// </summary>
        /// <value>The UI text menu localizations.</value>
        public static string UIText_Menu_Localizations
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Localizations", resourceCulture, "Localizations");
            }
        }

        /// <summary>
        /// Looks up a localized string similar to News Letters.
        /// </summary>
        /// <value>The UI text menu news letters.</value>
        public static string UIText_Menu_NewsLetters
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_NewsLetters", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Office.
        /// </summary>
        /// <value>The UI text menu office.</value>
        public static string UIText_Menu_Office
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Office", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Organization.
        /// </summary>
        /// <value>The UI text menu organization.</value>
        public static string UIText_Menu_Organization
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Organization", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Organizations.
        /// </summary>
        /// <value>The UI text menu organizations.</value>
        public static string UIText_Menu_Organizations
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Organizations", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Services.
        /// </summary>
        /// <value>The UI text menu organization services.</value>
        public static string UIText_Menu_OrganizationServices
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_OrganizationServices", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Pricing.
        /// </summary>
        /// <value>The UI text menu pricing.</value>
        public static string UIText_Menu_Pricing
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Pricing", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Property.
        /// </summary>
        /// <value>The UI text menu property.</value>
        public static string UIText_Menu_Property
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Property", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Scheduled Tasks.
        /// </summary>
        /// <value>The UI text menu scheduled tasks.</value>
        public static string UIText_Menu_ScheduledTasks
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_ScheduledTasks", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Services.
        /// </summary>
        /// <value>The UI text menu services.</value>
        public static string UIText_Menu_Services
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Services", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Single Family Home.
        /// </summary>
        /// <value>The UI text menu single home.</value>
        public static string UIText_Menu_SingleHome
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_SingleHome", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Social Networks.
        /// </summary>
        /// <value>The UI text menu social networks.</value>
        public static string UIText_Menu_SocialNetworks
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_SocialNetworks", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Status.
        /// </summary>
        /// <value>The UI text menu status.</value>
        public static string UIText_Menu_Status
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Status", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Stores.
        /// </summary>
        /// <value>The UI text menu stores.</value>
        public static string UIText_Menu_Stores
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Stores", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Newsletter Subscribers.
        /// </summary>
        /// <value>The UI text menu subscribers.</value>
        public static string UIText_Menu_Subscribers
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Subscribers", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subscriptions.
        /// </summary>
        /// <value>The UI text menu subscriptions.</value>
        public static string UIText_Menu_Subscriptions
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Subscriptions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Types.
        /// </summary>
        /// <value>The UI text menu types.</value>
        public static string UIText_Menu_Types
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Types", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Users.
        /// </summary>
        /// <value>The UI text menu users.</value>
        public static string UIText_Menu_Users
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Users", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Villa.
        /// </summary>
        /// <value>The UI text menu villa.</value>
        public static string UIText_Menu_Villa
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Villa", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to WF Action Attributes.
        /// </summary>
        /// <value>The UI text menu workflow action attributes.</value>
        public static string UIText_Menu_WorkflowActionAttributes
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_WorkflowActionAttributes", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflow Actions.
        /// </summary>
        /// <value>The UI text menu workflow actions.</value>
        public static string UIText_Menu_WorkflowActions
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_WorkflowActions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflows.
        /// </summary>
        /// <value>The UI text menu workflow classes.</value>
        public static string UIText_Menu_WorkflowClasses
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_WorkflowClasses", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflows.
        /// </summary>
        /// <value>The UI text menu workflows.</value>
        public static string UIText_Menu_Workflows
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Workflows", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Workflow Stages.
        /// </summary>
        /// <value>The UI text menu workflow stages.</value>
        public static string UIText_Menu_WorkflowStages
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_WorkflowStages", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to WF Stage Transitions.
        /// </summary>
        /// <value>The UI text menu workflow stage transitions.</value>
        public static string UIText_Menu_WorkflowStageTransitions
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_WorkflowStageTransitions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Min Area.
        /// </summary>
        /// <value>The UI text minimum area.</value>
        public static string UIText_MinArea
        {
            get
            {
                return ResourceManagerGetString("UIText_MinArea", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Min Baths.
        /// </summary>
        /// <value>The UI text minimum baths.</value>
        public static string UIText_MinBaths
        {
            get
            {
                return ResourceManagerGetString("UIText_MinBaths", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Min Beds.
        /// </summary>
        /// <value>The UI text minimum beds.</value>
        public static string UIText_MinBeds
        {
            get
            {
                return ResourceManagerGetString("UIText_MinBeds", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Min Price.
        /// </summary>
        /// <value>The UI text minimum price.</value>
        public static string UIText_MinPrice
        {
            get
            {
                return ResourceManagerGetString("UIText_MinPrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to More Details.
        /// </summary>
        /// <value>The UI text more details.</value>
        public static string UIText_MoreDetails
        {
            get
            {
                return ResourceManagerGetString("UIText_MoreDetails", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to My account details.
        /// </summary>
        /// <value>The UI text my account details.</value>
        public static string UIText_MyAccountDetails
        {
            get
            {
                return ResourceManagerGetString("UIText_MyAccountDetails", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Navigate.
        /// </summary>
        /// <value>The UI text navigate.</value>
        public static string UIText_Navigate
        {
            get
            {
                return ResourceManagerGetString("UIText_Navigate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Navigation.
        /// </summary>
        /// <value>The UI text navigation.</value>
        public static string UIText_Navigation
        {
            get
            {
                return ResourceManagerGetString("UIText_Navigation", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No agents are available to assign to the property..
        /// </summary>
        /// <value>The UI text no agents are available.</value>
        public static string UIText_NoAgentsAreAvailable
        {
            get
            {
                return ResourceManagerGetString("UIText_NoAgentsAreAvailable", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No attachments loaded yet.
        /// </summary>
        /// <value>The UI text no attachments loaded yet.</value>
        public static string UIText_NoAttachmentsLoadedYet
        {
            get
            {
                return ResourceManagerGetString("UIText_NoAttachmentsLoadedYet", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No data found.
        /// </summary>
        /// <value>The UI text no data found.</value>
        public static string UIText_NoDataFound
        {
            get
            {
                return ResourceManagerGetString("UIText_NoDataFound", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No images loaded yet.
        /// </summary>
        /// <value>The UI text no images loaded yet.</value>
        public static string UIText_NoImagesLoadedYet
        {
            get
            {
                return ResourceManagerGetString("UIText_NoImagesLoadedYet", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No Products match the search criteria..
        /// </summary>
        /// <value>The UI text no products found.</value>
        public static string UIText_NoProductsFound
        {
            get
            {
                return ResourceManagerGetString("UIText_NoProductsFound", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to This Product doesn't need shipping..
        /// </summary>
        /// <value>The UI text no shipping.</value>
        public static string UIText_NoShipping
        {
            get
            {
                return ResourceManagerGetString("UIText_NoShipping", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sorry, not implemented yet..
        /// </summary>
        /// <value>The UI text not implemented.</value>
        public static string UIText_NotImplemented
        {
            get
            {
                return ResourceManagerGetString("UIText_NotImplemented", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No workflow found for the object.
        /// </summary>
        /// <value>The UI text no workflow.</value>
        public static string UIText_NoWorkflow
        {
            get
            {
                return ResourceManagerGetString("UIText_NoWorkflow", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Object Access.
        /// </summary>
        /// <value>The UI text object acccess.</value>
        public static string UIText_ObjectAcccess
        {
            get
            {
                return ResourceManagerGetString("UIText_ObjectAcccess", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Ok.
        /// </summary>
        /// <value>The UI text ok.</value>
        public static string UIText_Ok
        {
            get
            {
                return ResourceManagerGetString("UIText_Ok", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Date New to Old.
        /// </summary>
        /// <value>The UI text order date new.</value>
        public static string UIText_OrderDateNew
        {
            get
            {
                return ResourceManagerGetString("UIText_OrderDateNew", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Date Old to New.
        /// </summary>
        /// <value>The UI text order date old.</value>
        public static string UIText_OrderDateOld
        {
            get
            {
                return ResourceManagerGetString("UIText_OrderDateOld", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Price High to Low.
        /// </summary>
        /// <value>The UI text order price high.</value>
        public static string UIText_OrderPriceHigh
        {
            get
            {
                return ResourceManagerGetString("UIText_OrderPriceHigh", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Price Low to High.
        /// </summary>
        /// <value>The UI text order price low.</value>
        public static string UIText_OrderPriceLow
        {
            get
            {
                return ResourceManagerGetString("UIText_OrderPriceLow", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Add module.
        /// </summary>
        /// <value>The UI text organization add organization module.</value>
        public static string UIText_Organization_AddOrganizationModule
        {
            get
            {
                return ResourceManagerGetString("UIText_Organization_AddOrganizationModule", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose modules to add:.
        /// </summary>
        /// <value>The UI text organization choose organization modules.</value>
        public static string UIText_Organization_ChooseOrganizationModules
        {
            get
            {
                return ResourceManagerGetString("UIText_Organization_ChooseOrganizationModules", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No organization modules selected.
        /// </summary>
        /// <value>The UI text organization no organization modules selected.</value>
        public static string UIText_Organization_NoOrganizationModulesSelected
        {
            get
            {
                return ResourceManagerGetString("UIText_Organization_NoOrganizationModulesSelected", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to OR.
        /// </summary>
        /// <value>The UI text or word.</value>
        public static string UIText_OrWord
        {
            get
            {
                return ResourceManagerGetString("UIText_OrWord", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Paging.
        /// </summary>
        /// <value>The UI text paging.</value>
        public static string UIText_Paging
        {
            get
            {
                return ResourceManagerGetString("UIText_Paging", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Photo.
        /// </summary>
        /// <value>The UI text photo.</value>
        public static string UIText_Photo
        {
            get
            {
                return ResourceManagerGetString("UIText_Photo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Please confirm.
        /// </summary>
        /// <value>The UI text please confirm.</value>
        public static string UIText_PleaseConfirm
        {
            get
            {
                return ResourceManagerGetString("UIText_PleaseConfirm", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to post comment.
        /// </summary>
        /// <value>The UI text post comment.</value>
        public static string UIText_PostComment
        {
            get
            {
                return ResourceManagerGetString("UIText_PostComment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Primary.
        /// </summary>
        /// <value>The UI text primary.</value>
        public static string UIText_Primary
        {
            get
            {
                return ResourceManagerGetString("UIText_Primary", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Print.
        /// </summary>
        /// <value>The UI text print.</value>
        public static string UIText_Print
        {
            get
            {
                return ResourceManagerGetString("UIText_Print", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Privacy Policy.
        /// </summary>
        /// <value>The UI text privacy policy.</value>
        public static string UIText_Privacy_Policy
        {
            get
            {
                return ResourceManagerGetString("UIText_Privacy_Policy", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to List of properties.
        /// </summary>
        /// <value>The UI text properties page description.</value>
        public static string UIText_PropertiesPageDescription
        {
            get
            {
                return ResourceManagerGetString("UIText_PropertiesPageDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Properties.
        /// </summary>
        /// <value>The UI text properties page title.</value>
        public static string UIText_PropertiesPageTitle
        {
            get
            {
                return ResourceManagerGetString("UIText_PropertiesPageTitle", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Property ID.
        /// </summary>
        /// <value>The UI text property identifier.</value>
        public static string UIText_PropertyID
        {
            get
            {
                return ResourceManagerGetString("UIText_PropertyID", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Property Image.
        /// </summary>
        /// <value>The UI text property image.</value>
        public static string UIText_PropertyImage
        {
            get
            {
                return ResourceManagerGetString("UIText_PropertyImage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Property Specification Description.
        /// </summary>
        /// <value>The UI text property specification description.</value>
        public static string UIText_PropertySpecificationDescription
        {
            get
            {
                return ResourceManagerGetString("UIText_PropertySpecificationDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Property Specification Name.
        /// </summary>
        /// <value>The name of the UI text property specification.</value>
        public static string UIText_PropertySpecificationName
        {
            get
            {
                return ResourceManagerGetString("UIText_PropertySpecificationName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Property Status.
        /// </summary>
        /// <value>The UI text property status.</value>
        public static string UIText_PropertyStatus
        {
            get
            {
                return ResourceManagerGetString("UIText_PropertyStatus", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Property Type.
        /// </summary>
        /// <value>The type of the UI text property.</value>
        public static string UIText_PropertyType
        {
            get
            {
                return ResourceManagerGetString("UIText_PropertyType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Quick links.
        /// </summary>
        /// <value>The UI text quick links.</value>
        public static string UIText_QuickLinks
        {
            get
            {
                return ResourceManagerGetString("UIText_QuickLinks", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Register to.
        /// </summary>
        /// <value>The UI text register link.</value>
        public static string UIText_RegisterLink
        {
            get
            {
                return ResourceManagerGetString("UIText_RegisterLink", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Register as a new user.
        /// </summary>
        /// <value>The UI text register new user.</value>
        public static string UIText_RegisterNewUser
        {
            get
            {
                return ResourceManagerGetString("UIText_RegisterNewUser", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to This is required field.
        /// </summary>
        /// <value>The UI text required field.</value>
        public static string UIText_RequiredField
        {
            get
            {
                return ResourceManagerGetString("UIText_RequiredField", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Resend.
        /// </summary>
        /// <value>The UI text resend.</value>
        public static string UIText_Resend
        {
            get
            {
                return ResourceManagerGetString("UIText_Resend", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Reset Password.
        /// </summary>
        /// <value>The UI text reset password.</value>
        public static string UIText_ResetPassword
        {
            get
            {
                return ResourceManagerGetString("UIText_ResetPassword", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Password reset email has been sent to this email {0}, thank you!.
        /// </summary>
        /// <value>The UI text reset password confirmation.</value>
        public static string UIText_ResetPasswordConfirmation
        {
            get
            {
                return ResourceManagerGetString("UIText_ResetPasswordConfirmation", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to By submitting this form you will send password reset email to the following user:.
        /// </summary>
        /// <value>The UI text reset password notice.</value>
        public static string UIText_ResetPasswordNotice
        {
            get
            {
                return ResourceManagerGetString("UIText_ResetPasswordNotice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Please review validation errors below:.
        /// </summary>
        /// <value>The UI text review validation errors.</value>
        public static string UIText_Review_ValidationErrors
        {
            get
            {
                return ResourceManagerGetString("UIText_Review_ValidationErrors", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Save.
        /// </summary>
        /// <value>The UI text save.</value>
        public static string UIText_Save
        {
            get
            {
                return ResourceManagerGetString("UIText_Save", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Search.
        /// </summary>
        /// <value>The UI text search.</value>
        public static string UIText_Search
        {
            get
            {
                return ResourceManagerGetString("UIText_Search", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Location.
        /// </summary>
        /// <value>The UI text search location.</value>
        public static string UIText_SearchLocation
        {
            get
            {
                return ResourceManagerGetString("UIText_SearchLocation", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Search result.
        /// </summary>
        /// <value>The UI text search results.</value>
        public static string UIText_SearchResults
        {
            get
            {
                return ResourceManagerGetString("UIText_SearchResults", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to See more attachments....
        /// </summary>
        /// <value>The UI text see more attachments.</value>
        public static string UIText_SeeMoreAttachments
        {
            get
            {
                return ResourceManagerGetString("UIText_SeeMoreAttachments", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to See more blog comments....
        /// </summary>
        /// <value>The UI text see more blog comments.</value>
        public static string UIText_SeeMoreBlogComments
        {
            get
            {
                return ResourceManagerGetString("UIText_SeeMoreBlogComments", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to See more blog posts....
        /// </summary>
        /// <value>The UI text see more blog posts.</value>
        public static string UIText_SeeMoreBlogPosts
        {
            get
            {
                return ResourceManagerGetString("UIText_SeeMoreBlogPosts", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to See more states....
        /// </summary>
        /// <value>The UI text see more states.</value>
        public static string UIText_SeeMoreStates
        {
            get
            {
                return ResourceManagerGetString("UIText_SeeMoreStates", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Select.
        /// </summary>
        /// <value>The UI text select.</value>
        public static string UIText_Select
        {
            get
            {
                return ResourceManagerGetString("UIText_Select", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Set Password.
        /// </summary>
        /// <value>The UI text set password.</value>
        public static string UIText_SetPassword
        {
            get
            {
                return ResourceManagerGetString("UIText_SetPassword", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Share this.
        /// </summary>
        /// <value>The UI text share this.</value>
        public static string UIText_ShareThis
        {
            get
            {
                return ResourceManagerGetString("UIText_ShareThis", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to The following shipping options are available.
        /// </summary>
        /// <value>The UI text shipping options available.</value>
        public static string UIText_ShippingOptionsAvailable
        {
            get
            {
                return ResourceManagerGetString("UIText_ShippingOptionsAvailable", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Action Attributes.
        /// </summary>
        /// <value>The UI text show wf action attribs.</value>
        public static string UIText_ShowWFActionAttribs
        {
            get
            {
                return ResourceManagerGetString("UIText_ShowWFActionAttribs", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sort By.
        /// </summary>
        /// <value>The UI text sort by.</value>
        public static string UIText_SortBy
        {
            get
            {
                return ResourceManagerGetString("UIText_SortBy", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Specification.
        /// </summary>
        /// <value>The UI text specification.</value>
        public static string UIText_Specification
        {
            get
            {
                return ResourceManagerGetString("UIText_Specification", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sq Ft.
        /// </summary>
        /// <value>The UI text square measure.</value>
        public static string UIText_SquareMeasure
        {
            get
            {
                return ResourceManagerGetString("UIText_SquareMeasure", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Add Discount Coupon.
        /// </summary>
        /// <value>The UI text store add discount coupon.</value>
        public static string UIText_Store_AddDiscountCoupon
        {
            get
            {
                return ResourceManagerGetString("UIText_Store_AddDiscountCoupon", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Add Payment Option.
        /// </summary>
        /// <value>The UI text store add payment option.</value>
        public static string UIText_Store_AddPaymentOption
        {
            get
            {
                return ResourceManagerGetString("UIText_Store_AddPaymentOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Add Product Category.
        /// </summary>
        /// <value>The UI text store add product category.</value>
        public static string UIText_Store_AddProductCategory
        {
            get
            {
                return ResourceManagerGetString("UIText_Store_AddProductCategory", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Add Shipping Option.
        /// </summary>
        /// <value>The UI text store add shipping option.</value>
        public static string UIText_Store_AddShippingOption
        {
            get
            {
                return ResourceManagerGetString("UIText_Store_AddShippingOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose discount coupons to add:.
        /// </summary>
        /// <value>The UI text store choose discount coupons.</value>
        public static string UIText_Store_ChooseDiscountCoupons
        {
            get
            {
                return ResourceManagerGetString("UIText_Store_ChooseDiscountCoupons", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose payment to add:.
        /// </summary>
        /// <value>The UI text store choose payment.</value>
        public static string UIText_Store_ChoosePayment
        {
            get
            {
                return ResourceManagerGetString("UIText_Store_ChoosePayment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose product categories to add:.
        /// </summary>
        /// <value>The UI text store choose product categories.</value>
        public static string UIText_Store_ChooseProductCategories
        {
            get
            {
                return ResourceManagerGetString("UIText_Store_ChooseProductCategories", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose shipping to add:.
        /// </summary>
        /// <value>The UI text store choose shipping.</value>
        public static string UIText_Store_ChooseShipping
        {
            get
            {
                return ResourceManagerGetString("UIText_Store_ChooseShipping", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No discount coupons selected.
        /// </summary>
        /// <value>The UI text store no discount coupons selected.</value>
        public static string UIText_Store_NoDiscountCouponsSelected
        {
            get
            {
                return ResourceManagerGetString("UIText_Store_NoDiscountCouponsSelected", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No payment methods selected.
        /// </summary>
        /// <value>The UI text store no payment methods selected.</value>
        public static string UIText_Store_NoPaymentMethodsSelected
        {
            get
            {
                return ResourceManagerGetString("UIText_Store_NoPaymentMethodsSelected", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No payment options selected.
        /// </summary>
        /// <value>The UI text store no payment options selected.</value>
        public static string UIText_Store_NoPaymentOptionsSelected
        {
            get
            {
                return ResourceManagerGetString("UIText_Store_NoPaymentOptionsSelected", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No product categories selected.
        /// </summary>
        /// <value>The UI text store no product categories selected.</value>
        public static string UIText_Store_NoProductCategoriesSelected
        {
            get
            {
                return ResourceManagerGetString("UIText_Store_NoProductCategoriesSelected", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No shipping options selected.
        /// </summary>
        /// <value>The UI text store no shipping options selected.</value>
        public static string UIText_Store_NoShippingOptionsSelected
        {
            get
            {
                return ResourceManagerGetString("UIText_Store_NoShippingOptionsSelected", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Submit.
        /// </summary>
        /// <value>The UI text submit.</value>
        public static string UIText_Submit
        {
            get
            {
                return ResourceManagerGetString("UIText_Submit", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subscriptions.
        /// </summary>
        /// <value>The UI text subscriptions.</value>
        public static string UIText_Subscriptions
        {
            get
            {
                return ResourceManagerGetString("UIText_Subscriptions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Support.
        /// </summary>
        /// <value>The UI text support.</value>
        public static string UIText_Support
        {
            get
            {
                return ResourceManagerGetString("UIText_Support", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to support@bap-software.com.
        /// </summary>
        /// <value>The UI text support email.</value>
        public static string UIText_SupportEmail
        {
            get
            {
                return ResourceManagerGetString("UIText_SupportEmail", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Are you sure you want to delete this.
        /// </summary>
        /// <value>The UI text sure to delete.</value>
        public static string UIText_SureToDelete
        {
            get
            {
                return ResourceManagerGetString("UIText_SureToDelete", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Take a tour.
        /// </summary>
        /// <value>The UI text take a tour.</value>
        public static string UIText_TakeATour
        {
            get
            {
                return ResourceManagerGetString("UIText_TakeATour", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Thanks for registering your email {0} to receive our newsletters!.
        /// </summary>
        /// <value>The UI text thanks registering newsletters.</value>
        public static string UIText_ThanksRegisteringNewsletters
        {
            get
            {
                return ResourceManagerGetString("UIText_ThanksRegisteringNewsletters", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Unlock.
        /// </summary>
        /// <value>The UI text unlock.</value>
        public static string UIText_Unlock
        {
            get
            {
                return ResourceManagerGetString("UIText_Unlock", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Upload.
        /// </summary>
        /// <value>The UI text upload.</value>
        public static string UIText_Upload
        {
            get
            {
                return ResourceManagerGetString("UIText_Upload", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Useful Links.
        /// </summary>
        /// <value>The UI text useful links.</value>
        public static string UIText_Useful_Links
        {
            get
            {
                return ResourceManagerGetString("UIText_Useful_Links", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Login to.
        /// </summary>
        /// <value>The UI text use local account.</value>
        public static string UIText_UseLocalAccount
        {
            get
            {
                return ResourceManagerGetString("UIText_UseLocalAccount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Video.
        /// </summary>
        /// <value>The UI text video.</value>
        public static string UIText_Video
        {
            get
            {
                return ResourceManagerGetString("UIText_Video", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View a list of Featured Properties..
        /// </summary>
        /// <value>The UI text view featured list.</value>
        public static string UIText_ViewFeaturedList
        {
            get
            {
                return ResourceManagerGetString("UIText_ViewFeaturedList", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View Hangfire Dashboard.
        /// </summary>
        /// <value>The UI text view hangfire dashboard.</value>
        public static string UIText_ViewHangfireDashboard
        {
            get
            {
                return ResourceManagerGetString("UIText_ViewHangfireDashboard", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Web Site Root.
        /// </summary>
        /// <value>The UI text web site root.</value>
        public static string UIText_WebSiteRoot
        {
            get
            {
                return ResourceManagerGetString("UIText_WebSiteRoot", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Do It.
        /// </summary>
        /// <value>The UI text wf action do it.</value>
        public static string UIText_WFActionDoIt
        {
            get
            {
                return ResourceManagerGetString("UIText_WFActionDoIt", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sorry,it look like an error occured while performing the given action, please contact support for more details and resolution..
        /// </summary>
        /// <value>The UI text wf action error occured.</value>
        public static string UIText_WFActionErrorOccured
        {
            get
            {
                return ResourceManagerGetString("UIText_WFActionErrorOccured", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Actions are required to perform:.
        /// </summary>
        /// <value>The UI text wf actions r required title.</value>
        public static string UIText_WFActionsRRequiredTitle
        {
            get
            {
                return ResourceManagerGetString("UIText_WFActionsRRequiredTitle", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attach Document.
        /// </summary>
        /// <value>The UI text wf attach document.</value>
        public static string UIText_WFAttachDocument
        {
            get
            {
                return ResourceManagerGetString("UIText_WFAttachDocument", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Business Process.
        /// </summary>
        /// <value>The UI text wf bus process title.</value>
        public static string UIText_WFBusProcessTitle
        {
            get
            {
                return ResourceManagerGetString("UIText_WFBusProcessTitle", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose.
        /// </summary>
        /// <value>The UI text wf choose trans.</value>
        public static string UIText_WFChooseTrans
        {
            get
            {
                return ResourceManagerGetString("UIText_WFChooseTrans", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Put stage comment here....
        /// </summary>
        /// <value>The UI text wf comments here.</value>
        public static string UIText_WFCommentsHere
        {
            get
            {
                return ResourceManagerGetString("UIText_WFCommentsHere", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Put some comments before move:.
        /// </summary>
        /// <value>The UI text wf put comments title.</value>
        public static string UIText_WFPutCommentsTitle
        {
            get
            {
                return ResourceManagerGetString("UIText_WFPutCommentsTitle", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Transition is not possible - conditions are not met yet, please check required action to complete if any..
        /// </summary>
        /// <value>The UI text wf trans is not possible.</value>
        public static string UIText_WFTransIsNotPossible
        {
            get
            {
                return ResourceManagerGetString("UIText_WFTransIsNotPossible", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Action already added to the transition..
        /// </summary>
        /// <value>The UI text workflow already added.</value>
        public static string UIText_Workflow_AlreadyAdded
        {
            get
            {
                return ResourceManagerGetString("UIText_Workflow_AlreadyAdded", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Only action of Work type can be added as required to the transition..
        /// </summary>
        /// <value>The UI text workflow not work.</value>
        public static string UIText_Workflow_NotWork
        {
            get
            {
                return ResourceManagerGetString("UIText_Workflow_NotWork", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to You need to agree to terms and conditions before proceeding further..
        /// </summary>
        /// <value>The UI text you must agree.</value>
        public static string UIText_YouMustAgree
        {
            get
            {
                return ResourceManagerGetString("UIText_YouMustAgree", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Organization is unknown.
        /// </summary>
        /// <value>The UI ttext error unknown organization.</value>
        public static string UITtext_Error_UnknownOrganization
        {
            get
            {
                return ResourceManagerGetString("UITtext_Error_UnknownOrganization", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address line.
        /// </summary>
        /// <value>The UI watermark address1.</value>
        public static string UIWatermark_Address1
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_Address1", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Additional address line.
        /// </summary>
        /// <value>The UI watermark address2.</value>
        public static string UIWatermark_Address2
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_Address2", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Any.
        /// </summary>
        /// <value>The UI watermark any.</value>
        public static string UIWatermark_Any
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_Any", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Number.
        /// </summary>
        /// <value>The UI watermark asset no.</value>
        public static string UIWatermark_AssetNo
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_AssetNo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to City.
        /// </summary>
        /// <value>The UI watermark city.</value>
        public static string UIWatermark_City
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_City", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Put some comments....
        /// </summary>
        /// <value>The UI watermark comments.</value>
        public static string UIWatermark_Comments
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_Comments", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to County.
        /// </summary>
        /// <value>The UI watermark county.</value>
        public static string UIWatermark_County
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_County", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Energy saving rate.
        /// </summary>
        /// <value>The UI watermark esr.</value>
        public static string UIWatermark_ESR
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_ESR", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Number.
        /// </summary>
        /// <value>The UI watermark garages.</value>
        public static string UIWatermark_Garages
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_Garages", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Any.
        /// </summary>
        /// <value>The UI watermark keyword.</value>
        public static string UIWatermark_Keyword
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_Keyword", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sq Ft.
        /// </summary>
        /// <value>The UI watermark kitchen square.</value>
        public static string UIWatermark_KitchenSquare
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_KitchenSquare", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Latitude.
        /// </summary>
        /// <value>The UI watermark latitude.</value>
        public static string UIWatermark_Latitude
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_Latitude", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Price.
        /// </summary>
        /// <value>The UI watermark list price.</value>
        public static string UIWatermark_ListPrice
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_ListPrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sq Ft.
        /// </summary>
        /// <value>The UI watermark living square.</value>
        public static string UIWatermark_LivingSquare
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_LivingSquare", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Number.
        /// </summary>
        /// <value>The UI watermark loan no.</value>
        public static string UIWatermark_LoanNo
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_LoanNo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Longitude.
        /// </summary>
        /// <value>The UI watermark longitude.</value>
        public static string UIWatermark_Longitude
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_Longitude", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Google Maps Link.
        /// </summary>
        /// <value>The UI watermark map URL.</value>
        public static string UIWatermark_MapURL
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_MapURL", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sq Ft.
        /// </summary>
        /// <value>The UI watermark maximum area.</value>
        public static string UIWatermark_MaxArea
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_MaxArea", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sq Ft.
        /// </summary>
        /// <value>The UI watermark minimum area.</value>
        public static string UIWatermark_MinArea
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_MinArea", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the UI watermark.</value>
        public static string UIWatermark_Name
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Price.
        /// </summary>
        /// <value>The UI watermark original list price.</value>
        public static string UIWatermark_OriginalListPrice
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_OriginalListPrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Value.
        /// </summary>
        /// <value>The UI watermark property description.</value>
        public static string UIWatermark_PropertyDescription
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_PropertyDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the UI watermark property.</value>
        public static string UIWatermark_PropertyName
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_PropertyName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Put some description....
        /// </summary>
        /// <value>The UI watermark put description here.</value>
        public static string UIWatermark_PutDescriptionHere
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_PutDescriptionHere", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Any.
        /// </summary>
        /// <value>The UI watermark search location.</value>
        public static string UIWatermark_SearchLocation
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_SearchLocation", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Put some short description....
        /// </summary>
        /// <value>The UI watermark short description.</value>
        public static string UIWatermark_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to State.
        /// </summary>
        /// <value>The state of the UI watermark.</value>
        public static string UIWatermark_State
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_State", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Number.
        /// </summary>
        /// <value>The UI watermark total bathrooms.</value>
        public static string UIWatermark_TotalBathrooms
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_TotalBathrooms", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Number.
        /// </summary>
        /// <value>The UI watermark total bedrooms.</value>
        public static string UIWatermark_TotalBedrooms
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_TotalBedrooms", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Number.
        /// </summary>
        /// <value>The UI watermark total rooms.</value>
        public static string UIWatermark_TotalRooms
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_TotalRooms", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sq Ft.
        /// </summary>
        /// <value>The UI watermark total square.</value>
        public static string UIWatermark_TotalSquare
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_TotalSquare", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Number of units.
        /// </summary>
        /// <value>The UI watermark total units.</value>
        public static string UIWatermark_TotalUnits
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_TotalUnits", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to value goes here.
        /// </summary>
        /// <value>The UI watermark value goes here.</value>
        public static string UIWatermark_ValueGoesHere
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_ValueGoesHere", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Video HTML-code.
        /// </summary>
        /// <value>The UI watermark video HTML code.</value>
        public static string UIWatermark_VideoHTMLCode
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_VideoHTMLCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Zip.
        /// </summary>
        /// <value>The UI watermark zip.</value>
        public static string UIWatermark_Zip
        {
            get
            {
                return ResourceManagerGetString("UIWatermark_Zip", resourceCulture);
            }
        }
    }
}
