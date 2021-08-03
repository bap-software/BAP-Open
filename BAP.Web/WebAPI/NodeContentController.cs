using System;
using System.Web.Http;
using System.Linq;

using BAP.DAL;
using BAP.Log;
using BAP.Lookups;
using BAP.Common;
using BAP.FileSystem;
using BAP.ContentManagement;
using BAP.Web.WebAPI.Contracts;


namespace BAP.Web.WebAPI
{
    [Authorize]
    public class NodeContentController : BaseCmsController
    {
        private const string _externalContentStart = "<!--EXTERNAL-START-->";
        private const string _externalContentEnd = "<!--EXTERNAL-END-->";
        private const string _wrapExternalStart = "<div class='container'>";
        private const string _wrapExternalEnd = "</div>";
        public NodeContentController(ILogger logger, IConfigHelper configHelper, IFileProcessor fileProc, ILookupEngine lookupEngine, IAuthorizationContext context)
            : base(logger, configHelper, fileProc, lookupEngine, context)
        {
        }

        [HttpGet]
        public GetContentResponse Get(int nodeId, RequestSourceApp sourceApp = RequestSourceApp.BAPPlatformCMS)
        {
            GetContentResponse result = new GetContentResponse
            {
                ContentNodeId = -1
            };
            //Get current node instance
            var assemblies = GetAssembliesToScan();
            CMSNode cmsNode = null;
            using (var _cmsEngine = new CMSEngine(_configHelper, _context, _logger))
            {
                cmsNode = _cmsEngine.GetSingleNodeById(nodeId, assemblies);
            }

            if (cmsNode != null && cmsNode.Content != null && cmsNode.Content.Views != null)
            {
                result.ContentNodeId = cmsNode.Content.Id;
                var viewObject = cmsNode.Content.Views.FirstOrDefault(a => a.ViewName == cmsNode.Content.View);
                if(cmsNode.Content.Views.FirstOrDefault(a => a.ViewName == cmsNode.Content.View) != null)
                {
                    result.HtmlContent = viewObject.ViewContent;
                    if(sourceApp > RequestSourceApp.BAPPlatformCMS)
                    {
                        var index = result.HtmlContent.IndexOf(_externalContentStart);
                        if(index > -1)
                        {
                            var index2 = result.HtmlContent.IndexOf(_externalContentEnd);
                            if(index2 > 0)
                            {
                                result.HtmlContent = result.HtmlContent.Substring(index + _externalContentStart.Length, index2 - (index + _externalContentStart.Length)).Trim("\r\n".ToCharArray());
                            }
                            else
                            {
                                result.HtmlContent = "";
                            }
                        }
                        else
                        {
                            result.HtmlContent = "";
                        }
                    }
                }                
            }

            return result;
        }

        [HttpPut]
        public UpdateNodeContentResponse Put([FromBody] UpdateNodeContentRequest request)
        {
            try
            {
                var assemblies = GetAssembliesToScan();
                using (var _cmsEngine = new CMSEngine(_configHelper, _context, _logger))
                {
                    var cmsNode = _cmsEngine.GetSingleNodeById(request.NodeId, assemblies);
                    var viewObject = cmsNode.Content.Views.FirstOrDefault(a => a.ViewName == cmsNode.Content.View);
                    if(viewObject != null)
                    {
                        var newContent = request.ContentHtml;
                        if (request.SourceApp > RequestSourceApp.BAPPlatformCMS)
                        {
                            var oldContent = viewObject.ViewContent;

                            var imgIndex = newContent.IndexOf("src=\"");
                            while(imgIndex > 0)
                            {
                                var check = newContent.Substring(imgIndex + 5, 8);
                                if(!check.Equals("/content", StringComparison.InvariantCultureIgnoreCase) && !check.StartsWith("/file"))
                                {
                                    newContent = newContent.Insert(imgIndex + 5, "/content/");
                                }
                                imgIndex = newContent.IndexOf("src=\"", imgIndex + 5);
                            }

                            if (!string.IsNullOrEmpty(oldContent))
                            {
                                if (oldContent.Contains(_externalContentStart))
                                {
                                    var index1 = oldContent.IndexOf(_externalContentStart);
                                    var index2 = oldContent.IndexOf(_externalContentEnd);
                                    if (index1 > -1 && index2 > 0)
                                    {
                                        var toReplace = oldContent.Substring(index1, index2 + _externalContentEnd.Length - index1);
                                        var newToPut = _externalContentStart + "\r\n" + newContent + "\r\n" + _externalContentEnd + "\r\n";
                                        newContent = oldContent.Replace(toReplace + "\r\n", newToPut).Replace(toReplace, newToPut);
                                    }
                                    else
                                    {
                                        newContent = CleanContent(oldContent) + "\r\n" + _wrapExternalStart + "\r\n" + _externalContentStart + "\r\n" + newContent + "\r\n" + _externalContentEnd + "\r\n" + _wrapExternalEnd;
                                    }
                                }
                                else
                                {
                                    newContent = CleanContent(oldContent) + "\r\n" + _wrapExternalStart + "\r\n" + _externalContentStart + "\r\n" + newContent + "\r\n" + _externalContentEnd + "\r\n" + _wrapExternalEnd;
                                }
                            }
                            else
                            {
                                newContent = _wrapExternalStart + "\r\n" + _externalContentStart + "\r\n" + newContent + "\r\n" + _externalContentEnd + "\r\n" + _wrapExternalEnd;
                            }
                        }                        
                        _cmsEngine.SaveContent(cmsNode, newContent, viewObject.Id, true);
                    }                    
                }
            }
            catch (Exception exc)
            {
                _logger.LogException("NodeContentController", "PUT", exc);
                return new UpdateNodeContentResponse
                {
                    Success = false,
                    ErrorMessage = "Failed to process update content request."
                };
            }
            return new UpdateNodeContentResponse
            {
                Success = true
            };
        }

        string CleanContent(string content)
        {
            if (string.IsNullOrEmpty(content))
                return content;

            return content.Replace(_externalContentStart + "\r\n", "").Replace(_externalContentStart, "")
                .Replace(_externalContentEnd + "\r\n", "").Replace(_externalContentEnd, "")
                .Replace(_wrapExternalStart + "\r\n", "").Replace(_wrapExternalStart, "")
                .Replace(_externalContentEnd + "\r\n", "").Replace(_externalContentEnd, "");
        }
    }    
}
