// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="AuthorizationContext.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Net;
using System.Text;
using System.Web;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Identity;

using Newtonsoft.Json.Linq;

using BAP.DAL.Entities;
using BAP.Common;
using BAP.Common.AppSettings;
using BAP.Common.AppSettings.SettingsTypes;
using BAP.Common.Exceptions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BAP.DAL
{
    /// <summary>
    /// Class BuiltInUser.
    /// </summary>
    class BuiltInUser
    {
        /// <summary>
        /// Gets or sets the organization user identifier.
        /// </summary>
        /// <value>The organization user identifier.</value>
        public int OrganizationUserId { get; set; }
        /// <summary>
        /// Gets or sets the ASP net user identifier.
        /// </summary>
        /// <value>The ASP net user identifier.</value>
        public string AspNetUserId { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public List<string> Roles { get; set; }
        /// <summary>
        /// Gets or sets the logged on.
        /// </summary>
        /// <value>The logged on.</value>
        public DateTime LoggedOn { get; set; }
    }

    /// <summary>
    /// Class BuiltInUserExtensions.
    /// </summary>
    static class BuiltInUserExtensions
    {
        /// <summary>
        /// Clones the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>BuiltInUser.</returns>
        public static BuiltInUser Clone(this BuiltInUser user)
        {
            if (user != null)
                return new BuiltInUser
                {
                    OrganizationUserId = user.OrganizationUserId,
                    AspNetUserId = user.AspNetUserId,
                    LoggedOn = user.LoggedOn,
                    Roles = user.Roles,
                    UserName = user.UserName
                };

            return null;
        }
    }

    /// <summary>
    /// Singletone class to keep methods to access current autorization mechanism: curent user, roles, etc.
    /// </summary>
    public sealed class AuthorizationContext : IAuthorizationContext
    {
        /// <summary>
        /// The roles
        /// </summary>
        List<IBapRole> _roles = null;
        /// <summary>
        /// The permissions
        /// </summary>
        List<IBapPermission> _permissions = null;
        /// <summary>
        /// The built in users
        /// </summary>
        Dictionary<string, BuiltInUser> _builtInUsers = null;
        /// <summary>
        /// The current built in user
        /// </summary>
        BuiltInUser _currentBuiltInUser = null;
        /// <summary>
        /// The built in user session timeout seconds
        /// </summary>
        int _builtInUserSessionTimeoutSeconds = 1200; //20 minutes

        /// <summary>
        /// The lock
        /// </summary>
        private readonly object _lock = new object();

        /// <summary>
        /// The configuration helper
        /// </summary>
        IConfigHelper _configHelper;
        
        /// <summary>
        /// Prevents a default instance of the <see cref="AuthorizationContext"/> class from being created.
        /// </summary>
        private AuthorizationContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationContext"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public AuthorizationContext(IConfigHelper config)
        {
            _configHelper = config;
            Initialize();
        }
        /// <summary>
        /// The in memory list of available user roles.
        /// </summary>
        /// <value>The users in roles.</value>
        private Dictionary<string, Dictionary<string, bool>> UsersInRoles
        {
            get
            {
                Dictionary<string, Dictionary<string, bool>> result = null;
                using (ApplicationCache cache = new ApplicationCache(_configHelper))
                {
                    result = (Dictionary<string, Dictionary<string, bool>>)cache["USERS_ROLES"];
                    if(result == null)
                    {
                        result = new Dictionary<string, Dictionary<string, bool>>();
                        cache["USERS_ROLES"] = result;
                    }    
                }
                return result;    
            }
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            if (_roles == null)
            {
                lock (_lock)
                {
                    if (_roles == null)
                    {
                        _roles = new List<IBapRole>();
                        _permissions = new List<IBapPermission>();

                        var type = typeof(IRolePermissionProvider);
                        List<Type> types = null;
                        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("BAP"));
                        foreach(var asm in assemblies)
                        {
                            try
                            {
                                if (types == null)
                                    types = new List<Type>();
                                types.AddRange(asm.GetTypes().Where(p => type.IsAssignableFrom(p) && p.IsClass).ToList());
                            }
                            catch
                            {
                                //Do nothing - if cannot read assemblies that we do not search over them 
                            }
                        }
                        
                        
                        if (types != null && types.Any())
                        {
                            foreach (var t in types)
                            {
                                IRolePermissionProvider roleProvider = null;
                                try
                                {
                                    roleProvider = (IRolePermissionProvider)Activator.CreateInstance(t);
                                }
                                catch { 
                                    //Do nothing - if some assembly failed to give provider instance then we just bypass it.
                                }
                                
                                if (roleProvider != null)
                                {
                                    _roles.AddRange(roleProvider.Roles.ToArray());
                                    _permissions.AddRange(roleProvider.Permissions.ToArray());
                                }
                            }
                        }
                    }

                    if (_builtInUsers == null)
                    {
                        using (var db = new BapDb(_configHelper))
                        {
                            var orgUsers = db.Set<OrganizationUser>().Where(a => a.IsBuiltIn).ToList();
                            if (orgUsers != null && orgUsers.Count > 0)
                            {
                                _builtInUsers = new Dictionary<string, BuiltInUser>();
                                foreach (var orgUser in orgUsers)
                                {
                                    if (string.IsNullOrEmpty(orgUser.UserName))
                                        continue;

                                    _builtInUsers.Add(orgUser.UserName, new BuiltInUser
                                    {
                                        AspNetUserId = orgUser.AspNetUserId,
                                        OrganizationUserId = orgUser.Id,
                                        UserName = orgUser.UserName
                                    });
                                    //TODO: Roles will be filled later
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Repository filter instance, has to be injected where this instance is created.
        /// </summary>
        /// <value>The repository filter.</value>
        public IRepositoryFilter RepositoryFilter { get; set; } = null;

        /// <summary>
        /// Gets the name of the host.
        /// </summary>
        /// <value>The name of the host.</value>
        public string HostName
        {
            get
            {
                try
                {
                    if (HttpContext.Current != null && HttpContext.Current.Request != null && HttpContext.Current.Request.Url != null)
                        return HttpContext.Current.Request.Url.Authority;
                }
                catch
                {
                    return "127.0.0.1";
                }
                return "127.0.0.1";
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</value>
        public bool IsAuthenticated
        {
            get
            {
                if (CurrentBuiltInUser != null)
                    return true;

                var userId = GetCurrentUserId();
                return !string.IsNullOrEmpty(userId);
            }
        }

        /// <summary>
        /// Logins the built in user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool LoginBuiltInUser(string userName)
        {

            if (_builtInUsers == null || _builtInUsers.Count == 0 || string.IsNullOrEmpty(userName))
                return false;

            if (_builtInUsers.Any(a => a.Key.Equals(userName, StringComparison.InvariantCultureIgnoreCase)))
            {
                _currentBuiltInUser = _builtInUsers.FirstOrDefault(a => a.Key.Equals(userName, StringComparison.InvariantCultureIgnoreCase)).Value;
                _currentBuiltInUser.LoggedOn = DateTime.Now;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Logoffs the built in user.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool LogoffBuiltInUser()
        {
            if (_builtInUsers == null || _builtInUsers.Count == 0 || _currentBuiltInUser == null)
                return false;

            _currentBuiltInUser = null;
            return true;
        }

        /// <summary>
        /// Gets the current built in user.
        /// </summary>
        /// <value>The current built in user.</value>
        private BuiltInUser CurrentBuiltInUser
        {
            get
            {
                if (_currentBuiltInUser != null && (DateTime.Now - _currentBuiltInUser.LoggedOn).Seconds >= _builtInUserSessionTimeoutSeconds)
                {
                    _currentBuiltInUser = null;
                }
                return _currentBuiltInUser;
            }
        }

        /// <summary>
        /// Determines whether [is current user in role] [the specified role name].
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns><c>true</c> if [is current user in role] [the specified role name]; otherwise, <c>false</c>.</returns>
        public bool IsCurrentUserInRole(string roleName)
        {
            var currentUserId = GetCurrentUserId();
            if (!string.IsNullOrEmpty(currentUserId))
            {
                if (UsersInRoles.ContainsKey(currentUserId) && UsersInRoles[currentUserId] != null && UsersInRoles[currentUserId].ContainsKey(roleName))
                    return UsersInRoles[currentUserId][roleName];
                else
                {
                    using (var db = new IdentityDbContext<IdentityUser>(_configHelper.BapDbConnName))
                    {
                        var store = new UserStore<IdentityUser>(db);
                        var manager = new UserManager<IdentityUser>(store);
                        var result = manager.IsInRole(currentUserId, roleName);
                        if (!UsersInRoles.ContainsKey(currentUserId))
                            UsersInRoles.Add(currentUserId, new Dictionary<string, bool>());
                        if (!UsersInRoles[currentUserId].ContainsKey(roleName))
                            UsersInRoles[currentUserId].Add(roleName, result);
                        else
                            UsersInRoles[currentUserId][roleName] = result;
                        return result;
                    }
                }                
            }
                        
            return false;
        }

        /// <summary>
        /// Gets the current user identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetCurrentUserId()
        {
            var tmpUser = CurrentBuiltInUser.Clone();
            if (tmpUser != null)
                return tmpUser.AspNetUserId;

            var user = string.Empty;
            if (HttpContext.Current != null && HttpContext.Current.User != null
                && HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.IsAuthenticated)
                user = HttpContext.Current.User.Identity.GetUserId();

            return user;
        }

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetCurrentUserName()
        {
            var tmpUser = CurrentBuiltInUser.Clone();
            if (tmpUser != null)
                return tmpUser.UserName;

            var result = string.Empty;
            if (HttpContext.Current != null && HttpContext.Current.User != null
                && HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.IsAuthenticated)
                result = HttpContext.Current.User.Identity.GetUserName();

            return result;
        }

        /// <summary>
        /// Gets the full name of the current user.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetCurrentUserFullName()
        {
            var result = string.Empty;
            var userId = GetCurrentUserId();

            if (!string.IsNullOrEmpty(userId))
            {
                using (var db = new BapDb(_configHelper))
                {
                    var orgUser = db.Set<OrganizationUser>().SingleOrDefault(a => a.AspNetUserId == userId);
                    if (orgUser != null)
                    {
                        result = orgUser.FullName;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the current organization identifier.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <returns>System.Int32.</returns>
        public int GetCurrentOrganizationId(IConfigHelper configHelper = null)
        {
            var result = 0;
            Organization org = GetCurrentOrganization(configHelper??_configHelper);
            if (org != null)
                result = org.Id;

            return result;
        }

        /// <summary>
        /// Gets the current organization.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <returns>Organization.</returns>
        /// <exception cref="BAPAuthorizationException">Invalid user in the system</exception>
        /// <exception cref="BAPNoDefaultOrganization"></exception>
        public Organization GetCurrentOrganization(IConfigHelper configHelper)
        {
            Organization result = null;
            using (ApplicationCache cache = new ApplicationCache(configHelper))
            {
                using (var db = new BapDb(_configHelper))
                {
                    var user = GetCurrentUserId();
                    if (!string.IsNullOrEmpty(user))
                    {
                        result = (Organization)cache["user_org_" + user];
                        if (result == null)
                        {
                            var orgUser = db.Set<OrganizationUser>().Include("Organization").Include("Organization.OrganizationModules").SingleOrDefault(p => p.AspNetUserId == user);
                            if (orgUser != null)
                            {
                                if (orgUser.Organization.HostName != HostName)
                                {
                                    if (orgUser.Organization.HostNameAliases.All(a => a != HostName))
                                        throw new BAPAuthorizationException("Invalid user in the system");
                                }
                                //orgUser.Organization.OrganizationModules = db.Set<OrganizationModule>().Where(o => o.OrganizationId == orgUser.Organization.Id).ToList();
                                result = orgUser.Organization;
                                cache["user_org_" + user] = result;
                            }
                        }
                    }
                    if (result == null && configHelper != null)
                    {
                        result = (Organization)cache["hostname_org_" + HostName];
                        if (result == null)
                        {
                            var org = db.Set<Organization>().Include("OrganizationModules").FirstOrDefault(o => o.HostName == HostName || o.HostNameAliasesText.Contains(HostName));
                            if (org != null)
                            {
                                result = org;
                                cache["hostname_org_" + HostName] = org;
                            }
                        }
                    }
                }
            }            

            if (result == null && (AppSettingsProvider.SetupStatus == SelfSetupStatus.Finish || AppSettingsProvider.SetupStatus == SelfSetupStatus.None))
                throw new BAPNoDefaultOrganization(Resources.Resources.ErrorText_NoDefaultOrganization);

            return result;
        }

        /// <summary>
        /// Gets the current roles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        public int GetCurrentRoles(string userId, IConfigHelper configHelper, IBapEntity entity = null)
        {
            int result = 0;           
            if (_roles != null && _roles.Count > 0)
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    foreach (var role in _roles)
                    {
                        if (IsCurrentUserInRole(role.Name))
                            result += role.Id;
                    }
                }
                else
                {
                    foreach (var role in _roles)
                    {
                        if (role.IsPublic)
                            result += role.Id;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the current role names.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String[].</returns>
        public string[] GetCurrentRoleNames(string userId, IConfigHelper configHelper, IBapEntity entity = null)
        {
            List<string> result = new List<string>();            
            if (_roles != null && _roles.Count > 0)
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    foreach (var role in _roles)
                    {
                        if (IsCurrentUserInRole(role.Name))
                            result.Add(role.Name);
                    }
                }
                else
                {
                    foreach (var role in _roles)
                    {
                        if (role.IsPublic)
                            result.Add(role.Name);
                    }
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Gets the current user read permissions.
        /// </summary>
        /// <param name="userRoles">The user roles.</param>
        /// <param name="allPermissions">All permissions.</param>
        /// <returns>System.Int32.</returns>
        public int GetCurrentUserReadPermissions(int userRoles, int allPermissions)
        {
            int result = 0;
            if (_permissions != null && _permissions.Count > 0)
            {
                foreach (var permission in _permissions)
                {
                    if (IsInBitMap(userRoles, permission.Role.Id))
                    {
                        if (IsInBitMap(allPermissions, permission.Id))
                            result += permission.Id;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Reads the cookie.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        public string ReadCookie(string name)
        {
            string result = null;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null)
                result = cookie.Value;

            return result;
        }
        /// <summary>
        /// Saves the cookie.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public void SaveCookie(string name, string value)
        {
            HttpCookie cookie = new HttpCookie(name, value);
            HttpContext.Current.Response.SetCookie(cookie);
        }

        /// <summary>
        /// Removes the cookie.
        /// </summary>
        /// <param name="name">The name.</param>
        public void RemoveCookie(string name)
        {
            HttpContext.Current.Request.Cookies.Remove(name);
            HttpContext.Current.Response.Cookies.Remove(name);
        }

        /// <summary>
        /// Determines whether [is in bit map] [the specified bitmap].
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [is in bit map] [the specified bitmap]; otherwise, <c>false</c>.</returns>
        private bool IsInBitMap(int bitmap, int value)
        {
            return (bitmap & value) == value;
        }

        /// <summary>
        /// The bearer token cookie
        /// </summary>
        private const string _bearerTokenCookie = "__BAP_Bearer_Token";
        /// <summary>
        /// The bearrer token
        /// </summary>
        private string _bearrerToken = string.Empty;
        /// <summary>
        /// Requests the bearrer token.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public void RequestBearrerToken(string userName, string password)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
                var request = WebRequest.Create(string.Format("{0}://{1}/token", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority)) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                var authCredentials = "grant_type=password&userName=" + userName + "&password=" + password;
                byte[] bytes = Encoding.UTF8.GetBytes(authCredentials);
                request.ContentLength = bytes.Length;
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    var encoding = Encoding.UTF8;
                    var responseText = string.Empty;
                    using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                    {
                        responseText = reader.ReadToEnd();
                    }
                    dynamic d = JObject.Parse(responseText);
                    _bearrerToken = d.access_token;
                    SaveCookie(_bearerTokenCookie, _bearrerToken);
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Gets the bearrer token.
        /// </summary>
        /// <value>The bearrer token.</value>
        public string BearrerToken
        {
            get
            {
                if (!IsAuthenticated)
                    return string.Empty;

                if (string.IsNullOrEmpty(_bearrerToken))
                {
                    var tmp = ReadCookie(_bearerTokenCookie);
                    if (!string.IsNullOrEmpty(tmp))
                        _bearrerToken = tmp;
                }
                return _bearrerToken;
            }
        }
    }
}
