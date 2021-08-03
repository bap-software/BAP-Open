using BAP.BL.CustomConfigurationNodes;
using BAP.Common;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.Log;
using BAP.Lookups;
using BAP.UI.Controllers;
using BAP.Web.Areas.Administration.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BAP.Web.Areas.Administration.Controllers
{
    public static class CustomConfigurationExtensions
    {
        public static MvcHtmlString CustomConfigurationTreeView(this HtmlHelper helper, BAPCustomConfigurationData data, int treeViewId = 1, string area = "Administration", string controller = "CustomConfigurations", string action = "Index")
        {
            var result = "<ul class=\"jstree-container-ul jstree-children\" role=\"group\">";
            if (data != null && data.RootNode != null)
            {
                int nodeIndex = 0;
                result += ProcessNode(data, data.RootNode, treeViewId, 1, ref nodeIndex, area, controller, action);
            }
            result += "</ul>";
            return MvcHtmlString.Create(result);
        }

        private static string ProcessNode(BAPCustomConfigurationData data, CustomConfigurationNode node, int treeViewId, int level, ref int index, string area = "", string controller = "", string action = "")
        {
            index++;

            string liCss = node.Expanded ? "jstree-open" : "jstree-closed";
            string selectedCss = "";
            if (node.Children == null || node.Children.Count == 0)
            {
                liCss = "jstree-leaf";
                node.Expanded = false;
            }

            string ariaSelected = "false";
            if (data.CurrentNode == node)
            {
                selectedCss = " jstree-clicked";
                ariaSelected = "true";
            }

            string routeValues = "?id=" + node.NodeId;
            string navigateUrl = "/" + area + "/" + controller + "/" + action + routeValues;

            string basicId = string.Format("j{0}_{1}", treeViewId, index);
            string result = "<li role=\"treeitem\" aria-selected=\"" + ariaSelected + "\" aria-level=\"" + level.ToString() + "\" aria-labelledby=\"" + basicId + "_anchor\" aria-expanded=\"" + (node.Expanded ? "true" : "false") + "\" id=\"" + basicId + "\" class=\"jstree-node " + liCss + "\">";
            result += "<i class=\"jstree-icon\" role=\"presentation\"></i>";
            result += "<a class=\"jstree-anchor " + selectedCss + " \" href=\"" + navigateUrl + "\" tabindex=\"-1\" id=\"" + basicId + "_anchor\">";
            result += "<i class=\"jstree-icon jstree-themeicon fa fa-folder text-warning fa-lg jstree-themeicon-custom\" role=\"presentation\"></i>";
            result += node.Title;
            result += "</a>";
            if (node.Children != null && node.Children.Count > 0)
            {
                result += "<ul role=\"group\" class=\"jstree-children\">";
                for (int i = 0; i < node.Children.Count; i++)
                {
                    result += ProcessNode(data, node.Children[i], treeViewId, level + 1, ref index, area, controller, action);
                }
                result += "</ul>";
            }

            return result;
        }
    }

    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = @"Administrator")]
    public class CustomConfigurationsController : BaseController<CustomConfiguration>
    {
        public CustomConfigurationsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<CustomConfiguration>(configHelper, context))
        {
        }

        // GET: Administration/CustomConfigurations
        public ActionResult Index(int? id = null, string currentTab = "defaultConfiguration")
        {
            var data = PrepareData(id, currentTab);
            return View(data);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator,User")]
        public ActionResult UpdateConfiguration(int id, string currentConfiguration)
        {
            var customConfiguration = _bl.GetCustomConfigurationById(id);
            customConfiguration.CurrentConfiguration = currentConfiguration;
            _bl.UpdateCustomConfiguration(customConfiguration);
            return RedirectToAction("Index", new { id, currentTab = "currentConfiguration" });
        }

        #region private methods

        private BAPCustomConfigurationData PrepareData(int? id = null, string currentTab = null)
        {
            var data = new BAPCustomConfigurationData
            {
                RootNode = _bl.GetCustomConfigurationTree(),
                CurrentTab = currentTab
            };

            // if no node found by url - taking default one
            if (data.CurrentNode == null)
            {
                if (data.RootNode != null && data.RootNode.Children.Any())
                {
                    if (id.GetValueOrDefault() > 0)
                        data.CurrentNode = data.RootNode.Children.SelectMany(n => n.Children).FirstOrDefault(n => n.NodeId == id);
                    else
                        data.CurrentNode = data.RootNode.Children.SelectMany(n => n.Children).FirstOrDefault();
                }
                else
                    data.CurrentNode = data.RootNode;
            }

            if (data.CurrentNode == null)
                return data;

            return data;
        }

        #endregion
    }
}
