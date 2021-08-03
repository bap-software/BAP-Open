using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.Collections.Generic;
using Newtonsoft.Json;

using BAP.DAL;
using BAP.DAL.Entities;
using BAP.Common;
using BAP.Email;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;
using BAP.UI.Controllers;
using BAP.ContentManagement;
using BAP.ContentManagement.DesignerSettings;
using BAP.Web.Areas.Administration.Models;

namespace BAP.Web.Areas.Administration.Controllers
{
    public class AAttributes
    {
        public string id { get; set; }
        public string href { get; set; }
        public string @class { get; set; }
        public string tabindex { get; set; }

    }
    public class LiAttributes
    {
        public string id { get; set; }     
        public string @class { get; set; }
        public string role { get; set; }
    }
    public class JsTreeNodeState
    {
        public bool opened { get; set; }
        public bool disabled { get; set; }
        public bool selected { get; set; }
    }
    public class JsTreeNode
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public JsTreeNodeState state { get; set; }
        public LiAttributes li_attr { get; set; }
        public AAttributes a_attr { get; set; }
    }
    
    [ContentManagement(allowed: false)]
    [Authorize(Roles = "Administrator,ContentManager")]
    public class ContentManagementController : BaseController<ContentNode>
    {
        private ApplicationCache _cache;

        public ContentManagementController(ILogger logger, Common.IConfigHelper configHelper, ILookupEngine lookupEngine, IMailer mailer, IAuthorizationContext context, IFileProcessor fileProcessor) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<ContentNode>(configHelper, context))
        {
            _cache = new ApplicationCache(configHelper);
        }

        // GET: Administration/ContentManagement
        public ActionResult Index(string currentUrl, string currentTab, int? currentViewId)
        {
            var data = PrepareData(currentUrl, currentTab, currentViewId);
            return View(data);
        }

        [HttpPost]
        public ActionResult GetLookups()
        {
            var lookups = _lookupEngine.GetLookups();
            return Json(lookups);
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public ActionResult PageAction(string newPageName, string actionType, string currentUrl, string currentTab)
        {            
            try
            {            
                var currentNode = GetNodeByUrl(currentUrl, _cmsEngine.GetTree(GetAssemblies()));
                BAPContentManagementData data = null;
                switch (actionType.ToLower())
                {
                    case "create":               
                        if(!newPageName.IsNullOrEmpty())
                        {
                            var node = _cmsEngine.AddNewNode(newPageName, currentNode);
                            data = PrepareData(node.Url, "settings");                            
                        }
                        else
                        {
                            data = PrepareData(currentUrl, currentTab);
                        }
                        return View("Index", data);
                    
                    case "rename":
                        if (!newPageName.IsNullOrEmpty())
                        {
                            if (!_cmsEngine.RenameNode(currentNode, newPageName))
                                ClientNotify(Resources.Resources.ErrorText_NoPageRenamed, Resources.Resources.ErrorText_Error);
                        }
                        data = PrepareData(currentNode.Url, currentTab);
                        return View("Index", data);                        

                    case "delete":
                        var isRemoved = false;
                        if(currentNode.NodeId > 0)
                        {
                            var parent = currentNode.Parent;                           
                            if(_cmsEngine.RemoveNode(currentNode))
                            {
                                _cmsEngine.ClearCache();
                                data = PrepareData(parent.Url, currentTab);
                                isRemoved = true;
                            }                                                            
                        }       
                        if(!isRemoved)
                        {
                            data = PrepareData(currentUrl, currentTab);
                        }
                        return View("Index", data);
                    
                    case "clearcache":
                        _cmsEngine.ClearCache();
                        data = PrepareData(currentUrl, currentTab);
                        return View("Index", data);

                    default:
                        data = PrepareData(currentUrl, currentTab);
                        return View("Index", data);
                }

            }
            catch (Exception exc)
            {
                _logger.LogException("ContentManagement", "PageAction", exc);
                ClientNotify(exc.Message, "Error");                
            }

            //We should not get this far
            return RedirectToAction("Index", new { currentUrl = currentUrl, currentTab = "preview" });
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DesignAction(int? nodeId, string designActionType, string designContent, string currentUrl, string currentTab, int? currentViewId, string newPageView = "")
        {
            try
            {
                var data = PrepareData(currentUrl, currentTab);
                switch (designActionType.ToLower())
                {
                    case "save":
						if (string.IsNullOrEmpty(newPageView))
							_cmsEngine.SaveContent(data.CurrentNode, designContent, currentViewId);
						else
							_cmsEngine.CreateNewView(data.CurrentNode, newPageView, designContent);
                        break;

					case "delete":
						_cmsEngine.DeleteContent(data.CurrentNode, currentViewId);
						break;

					case "extra":
						_cmsEngine.AssignExtraViews(data.CurrentNode, currentViewId);
						break;

                    case "clearcache":
                        _cmsEngine.ClearCache();
                        break;
                }
            }
            catch (Exception exc)
            {
                _logger.LogException("ContentManagementController", "DesignAction", exc);
                ClientNotify(exc.Message, "Error");
            }

            return RedirectToAction("Index", new { currentUrl = currentUrl, currentTab = "design", currentViewId = currentViewId });
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult SavePageSettings(CMSNode currentNode, string currentUrl, string currentTab)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _cmsEngine.SaveContentSettings(currentNode);
                    _cmsEngine.UpdateNodeSettings(currentNode.Content, 0, currentTab, null, null, null);                   

                    var data = PrepareData(currentNode.Content.AliasPath, currentTab);                    
                    return View("Index", data);
                }
                else
                {
                    var data = PrepareData(currentUrl, currentTab);
                    data.CurrentNode = currentNode;
                    return View("Index", data);
                }
            }
            catch (Exception exc)
            {
                _logger.LogException("ContentManagement", "SavePageSettings", exc);
                ClientNotify(exc.Message, "Error");
            }

            return RedirectToAction("Index", new { currentUrl = currentUrl, currentTab = currentTab });
        }

        
        #region private methods

        private List<Assembly> GetAssemblies()
        {
            var cacheKey = "CACHE_RUNNING_ASSEMBLIES";
            var assemblies = (List<Assembly>)_cache[cacheKey];
            if(assemblies == null)
            {
                assemblies = new List<Assembly>
                {
                    Assembly.GetExecutingAssembly()
                };
                assemblies.AddRange(BAP.UI.PluginAreaBootstrapper.PluginAssemblies);
                _cache[cacheKey] = assemblies;
            }
            return assemblies;
        }
        private BAPContentManagementData PrepareData(string currentUrl = null, string currentTab = null, int? currentViewId = null)
        {            
            var data = new BAPContentManagementData();
            data.RootNode = _cmsEngine.GetTree(GetAssemblies());            
            data.CurrentTab = currentTab;            
            data.CurrentNode = GetNodeByUrl(currentUrl, data.RootNode);            

            // if no node found by url - taking default one
            if(data.CurrentNode == null)
            {
                if (data.RootNode != null && data.RootNode.Children.Any())
                    data.CurrentNode = data.RootNode.Children.First();
                else
                    data.CurrentNode = data.RootNode;
            }

            if (data.CurrentNode == null)
                return data;

            //Design components can be assigned only if content is in place
            data.DesignComponets = _cmsEngine.GetDesignComponents(data.CurrentNode);

            // if current node in place - taking its content       
            var viewData = _cmsEngine.PullViewData(data.CurrentNode, currentViewId);
            if(viewData != null)
            {
                data.CurrentViewId = viewData.ViewId;
                data.CurrentViewContent = viewData.ViewContent;                
            }
            if(data.CurrentNode.Content != null && !string.IsNullOrEmpty(data.CurrentNode.Content.PageSettingsJson))
            {
                data.CurrentNode.PageSettings = JsonConvert.DeserializeObject<PageSettings>(data.CurrentNode.Content.PageSettingsJson);
                data.CurrentTab = data.CurrentNode.PageSettings.CurrentPageTab;
            }
            else
            {
                data.CurrentNode.PageSettings = (new PageSettings()).Init();
            }
            
            //Design components can be assigned only if content is in place
            data.DesignComponets = _cmsEngine.GetDesignComponents(data.CurrentNode);

            //Tree view JSON data - straight to ViewBag
            var jsonData = GetCmsTreeViewData(data);
            ViewBag.TreeViewJsonData = JsonConvert.SerializeObject(jsonData, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore });

            return data;
        }

        public List<JsTreeNode> GetCmsTreeViewData(BAPContentManagementData data, string area = "Administration", string controller = "ContentManagement", string action = "Index")
        {
            var result = new List<JsTreeNode>();
            if (data != null && data.RootNode != null)
            {
                ProcessNodes(data, data.RootNode, result, 1, null, area, controller, action);
            }
            return result;
        }
        public int ProcessNodes(BAPContentManagementData data, CMSNode node, List<JsTreeNode> list, int index, JsTreeNode parent = null, string area = "", string controller = "", string action = "")
        {
            if (data == null || node == null || list == null)
                return index;
            index++;

            string routeValues = "?currentUrl=" + HttpUtility.UrlEncode(node.Url);
            string navigateUrl = "/" + area + "/" + controller + "/" + action + routeValues;
            var jsNode = new JsTreeNode
            {
                id = "js_" + index.ToString(),
                a_attr = new AAttributes { href = navigateUrl },
                text = node.Title,
                parent = parent != null ? parent.id : "#",
                state = new JsTreeNodeState
                {
                    selected = data.CurrentNode != null && data.CurrentNode == node,
                    opened = node.Expanded,
                    disabled = false
                }
            };
            list.Add(jsNode);
            if (node.Children != null && node.Children.Count > 0)
            {
                foreach (var child in node.Children)
                {
                    index = ProcessNodes(data, child, list, index, jsNode, area, controller, action);
                }
            }

            return index;
        }

        private CMSNode GetNodeByUrl(string url, CMSNode node)
        {
            if (url == "")
                url = null;

            if (node == null)
                return null;

            CMSNode result = null;
            if (node.Url == url)
                result = node;
            else
            {
                if(node.Children !=  null)
                {
                    foreach(var child in node.Children)
                    {
                        var res = GetNodeByUrl(url, child);
                        if(res != null)
                        {
                            result = res;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {                
                if (_cache != null)
                    _cache.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}
