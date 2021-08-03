// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BAPVirtualPathProvider.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text;
using System.Web.Hosting;
using System.Collections;
using System.Web.Caching;
using System.IO;
using System.Collections.Generic;

using BAP.Common;
using BAP.DAL;
using BAP.Log;

namespace BAP.ContentManagement
{
    /// <summary>
    /// Class BAPVirtualPathProvider.
    /// Implements the <see cref="System.Web.Hosting.VirtualPathProvider" />
    /// </summary>
    /// <seealso cref="System.Web.Hosting.VirtualPathProvider" />
    public class BAPVirtualPathProvider : VirtualPathProvider
    {
        /// <summary>
        /// The configuration helper
        /// </summary>
        private IConfigHelper _configHelper;
        /// <summary>
        /// The authentication context
        /// </summary>
        private IAuthorizationContext _authContext;
        /// <summary>
        /// The logger
        /// </summary>
        private ILogger _logger;
        /// <summary>
        /// The full mode
        /// </summary>
        bool _fullMode = false;

        /// <summary>
        /// Prevents a default instance of the <see cref="BAPVirtualPathProvider"/> class from being created.
        /// </summary>
        private BAPVirtualPathProvider() : base()
        {
            _configHelper = null;
            _authContext = null;
            _logger = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPVirtualPathProvider"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="authContext">The authentication context.</param>
        /// <param name="logger">The logger.</param>
        public BAPVirtualPathProvider(IConfigHelper configHelper, IAuthorizationContext authContext, ILogger logger)
        {
            _authContext = authContext;
            _configHelper = configHelper;
            _logger = logger;
            _fullMode = _configHelper != null && _authContext != null;            
        }

        /// <summary>
        /// Pathes the rewrite.
        /// </summary>
        /// <param name="virtulPath">The virtul path.</param>
        /// <returns>System.String.</returns>
        private string PathRewrite(string virtulPath)
        {            
            return virtulPath;
        }

        /// <summary>
        /// Gets a value that indicates whether a file exists in the virtual file system.
        /// </summary>
        /// <param name="virtualPath">The path to the virtual file.</param>
        /// <returns><see langword="true" /> if the file exists in the virtual file system; otherwise, <see langword="false" />.</returns>
        public override bool FileExists(string virtualPath)
        {
            virtualPath = PathRewrite(virtualPath);

            if(!_fullMode)
                return base.FileExists(virtualPath);

            using (var cmsEngine = new CMSEngine(_configHelper, _authContext, _logger))
            {
                if (cmsEngine.IsRelevantViewPath(virtualPath))
                {
                    if (cmsEngine.ViewExists(virtualPath))
                        return true;
                    else
                        return base.FileExists(virtualPath);
                }
                else
                    return base.FileExists(virtualPath);
            }                                                  
        }

        /// <summary>
        /// Gets a virtual file from the virtual file system.
        /// </summary>
        /// <param name="virtualPath">The path to the virtual file.</param>
        /// <returns>A descendent of the <see cref="T:System.Web.Hosting.VirtualFile" /> class that represents a file in the virtual file system.</returns>
        public override VirtualFile GetFile(string virtualPath)
        {
            virtualPath = PathRewrite(virtualPath);

            if (!_fullMode)
                return base.GetFile(virtualPath);

            using (var cmsEngine = new CMSEngine(_configHelper, _authContext, _logger))
            {
                if (cmsEngine.IsRelevantViewPath(virtualPath))
                {
                    var viewContent = cmsEngine.ViewContent(virtualPath);
                    if (viewContent == null)
                        return base.GetFile(virtualPath);
                    else
                    {
                        byte[] content = Encoding.UTF8.GetBytes(viewContent);
                        return new BAPVirtualFile(virtualPath, content);
                    }
                }
                else
                {
                    return base.GetFile(virtualPath);
                }
            }                
        }

        /// <summary>
        /// Creates a cache dependency based on the specified virtual paths.
        /// </summary>
        /// <param name="virtualPath">The path to the primary virtual resource.</param>
        /// <param name="virtualPathDependencies">An array of paths to other resources required by the primary virtual resource.</param>
        /// <param name="utcStart">The UTC time at which the virtual resources were read.</param>
        /// <returns>A <see cref="T:System.Web.Caching.CacheDependency" /> object for the specified virtual resources.</returns>
        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            virtualPath = PathRewrite(virtualPath);

            if(_fullMode)
            using (var cmsEngine = new CMSEngine(_configHelper, _authContext, _logger))
            {
                if (cmsEngine.IsRelevantViewPath(virtualPath))
                {
                    if (cmsEngine.ViewExists(virtualPath))
                    {
                        return BAPViewCacheDependencyManager.Instance.Get(virtualPath);
                    }
                }
            }
                
            return Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }

        /// <summary>
        /// Returns a hash of the specified virtual paths.
        /// </summary>
        /// <param name="virtualPath">The path to the primary virtual resource.</param>
        /// <param name="virtualPathDependencies">An array of paths to other virtual resources required by the primary virtual resource.</param>
        /// <returns>A hash of the specified virtual paths.</returns>
        public override string GetFileHash(string virtualPath, IEnumerable virtualPathDependencies)
        {
            virtualPath = PathRewrite(virtualPath);

            if (_fullMode)
            using (var cmsEngine = new CMSEngine(_configHelper, _authContext, _logger))
            {
                if (cmsEngine.IsRelevantViewPath(virtualPath))
                {
                    if (cmsEngine.ViewExists(virtualPath))
                    {
                        var viewHash = cmsEngine.ViewHash(virtualPath);
                        if (viewHash != null)
                        {
                            return BitConverter.ToString(viewHash);
                        }
                    }
                }
            }
                    
            return Previous.GetFileHash(virtualPath, virtualPathDependencies);
        }
    }

    /// <summary>
    /// Class BAPVirtualFile.
    /// Implements the <see cref="System.Web.Hosting.VirtualFile" />
    /// </summary>
    /// <seealso cref="System.Web.Hosting.VirtualFile" />
    public class BAPVirtualFile : VirtualFile
    {
        /// <summary>
        /// The view content
        /// </summary>
        private byte[] viewContent;

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPVirtualFile"/> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        /// <param name="viewContent">Content of the view.</param>
        public BAPVirtualFile(string virtualPath, byte[] viewContent) : base(virtualPath)
        {
            this.viewContent = viewContent;
        }

        /// <summary>
        /// When overridden in a derived class, returns a read-only stream to the virtual resource.
        /// </summary>
        /// <returns>A read-only stream to the virtual file.</returns>
        public override Stream Open()
        {
            return new MemoryStream(viewContent);
        }
    }

    /// <summary>
    /// Class BAPViewCacheDependency.
    /// Implements the <see cref="System.Web.Caching.CacheDependency" />
    /// </summary>
    /// <seealso cref="System.Web.Caching.CacheDependency" />
    public class BAPViewCacheDependency : CacheDependency
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BAPViewCacheDependency"/> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        public BAPViewCacheDependency(string virtualPath)
        {
            base.SetUtcLastModified(DateTime.UtcNow);
        }

        /// <summary>
        /// Invalidates this instance.
        /// </summary>
        public void Invalidate()
        {
            base.NotifyDependencyChanged(this, EventArgs.Empty);
            base.SetUtcLastModified(DateTime.UtcNow);
        }
    }

    /// <summary>
    /// Class BAPViewCacheDependencyManager.
    /// </summary>
    public class BAPViewCacheDependencyManager
    {
        /// <summary>
        /// The dependencies
        /// </summary>
        private static Dictionary<string, BAPViewCacheDependency> dependencies = new Dictionary<string, BAPViewCacheDependency>();
        /// <summary>
        /// The instance
        /// </summary>
        private static volatile BAPViewCacheDependencyManager instance;
        /// <summary>
        /// The synchronize root
        /// </summary>
        private static object syncRoot = new Object();

        /// <summary>
        /// Prevents a default instance of the <see cref="BAPViewCacheDependencyManager"/> class from being created.
        /// </summary>
        private BAPViewCacheDependencyManager()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static BAPViewCacheDependencyManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new BAPViewCacheDependencyManager();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the specified virtual path.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        /// <returns>CacheDependency.</returns>
        public CacheDependency Get(string virtualPath)
        {
            if (!dependencies.ContainsKey(virtualPath))
                dependencies.Add(virtualPath, new BAPViewCacheDependency(virtualPath));

            return dependencies[virtualPath];
        }

        /// <summary>
        /// Invalidates the specified virtual path.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        public void Invalidate(string virtualPath)
        {
            if (dependencies.ContainsKey(virtualPath))
            {
                var dependency = dependencies[virtualPath];
                dependency.Invalidate();                
            }
        }
    }
}
