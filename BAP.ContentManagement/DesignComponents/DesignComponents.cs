// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-08-2020
// ***********************************************************************
// <copyright file="DesignComponents.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using System.Collections.Generic;
using BAP.Common;
using BAP.ContentManagement.DesignComponents.CountryDropdownCtrl;
using BAP.ContentManagement.DesignComponents.GoogleAnalyticsCtrl;
using BAP.ContentManagement.DesignComponents.GoogleCaptchaCtrl;
using BAP.ContentManagement.DesignComponents.GoogleMapCtrl;
using BAP.ContentManagement.DesignComponents.HyperLinkCtrl;
using BAP.ContentManagement.DesignComponents.ImageCtrl;
using BAP.ContentManagement.DesignComponents.LookupCtrl;
using BAP.ContentManagement.DesignComponents.PageAuthorCtrl;
using BAP.ContentManagement.DesignComponents.PageDescriptionCtrl;
using BAP.ContentManagement.DesignComponents.PageKeywordsCtrl;
using BAP.ContentManagement.DesignComponents.PageTitleCtrl;
using BAP.ContentManagement.DesignComponents.SocialLinksCtrl;
using BAP.ContentManagement.DesignComponents.TableCtrl;
using BAP.ContentManagement.DesignComponents.YouTubeCtrl;

namespace BAP.ContentManagement.DesignComponents
{
    /// <summary>
    /// Class DesignComponentsCollection.
    /// </summary>
    public class DesignComponentsCollection
    {
        /// <summary>
        /// The configuration helper
        /// </summary>
        private readonly IConfigHelper _configHelper;
        /// <summary>
        /// The current node
        /// </summary>
        private readonly CMSNode _currentNode = null;
        /// <summary>
        /// The external components
        /// </summary>
        private readonly IList<IContentComponent> _externalComponents = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignComponentsCollection"/> class.
        /// </summary>
        /// <param name="currentNode">The current node.</param>
        /// <param name="externalComponents">The external components.</param>
        /// <param name="configHelper">The configuration helper.</param>
        public DesignComponentsCollection(CMSNode currentNode, IList<Common.IContentComponent> externalComponents, IConfigHelper configHelper)
        {
            _configHelper = configHelper;
            var allComponents = new List<IContentComponent>();
            _currentNode = currentNode;
            _externalComponents = externalComponents;

            ComponentGroups = new List<DesignComponentGroup>();
            var recentlyUsedGroup = new DesignComponentGroup
            {
                Components = null,
                Description = "Here we should see list of recently used controls on the given page.",
                DisplayName = "Recently used",
                Expandable = true,
                Expanded = false,
                Name = "RecentlyUsed"
            };
            ComponentGroups.Add(recentlyUsedGroup);

            var group = new DesignComponentGroup
            {
                Name = "PageContent",
                DisplayName = "Page Content",
                Description = "Set of controls to construct page content",
                Expandable = true,
                Expanded = true,
                Components = new List<IContentComponent>()
            };
            group.Components.Add(new StaticHtmlCtrl());
            group.Components.Add(new EditableHtmlCtrl());
            group.Components.Add(new UpperNavigation());
            group.Components.Add(new JavaScript());
            group.Components.Add(new CSharp());
            group.Components.Add(new Hr());
            group.Components.Add(new Nbsp());
            group.Components.Add(new HyperLink(_configHelper));
            group.Components.Add(new YouTube(_configHelper));
            group.Components.Add(new Table(_configHelper));
            group.Components.Add(new CountryDropdown(_configHelper));
            group.Components.Add(new SocialLinks(_configHelper));
            group.Components.Add(new GoogleMap(_configHelper));
            group.Components.Add(new GoogleCaptcha(_configHelper));
            group.Components.Add(new Lookup(_configHelper));
            group.Components.Add(new Image(_configHelper));

            allComponents.AddRange(group.Components);
            ComponentGroups.Add(group);

            /*
            + <li>Static Html (текстовый блок)</li>
            + <li>Java Script</li>
            <li>Editable Image (изображение)</li>
            <li>Static Image (изображение)</li>                                                                
            <li>Module Action Link</li>
            <li>Module Action Body</li>
            <li>External Link</li>                                
            <li>Editable Video (видео проигрыватель)</li>
            <li>Static Video (видео проигрыватель)</li>
            + <li>C# Code</li>
            <li>Drop Down</li>
            <li>Country Drop Down</li>
            <li>Filter Down</li>
            <li>Sortable Table Column</li>
            <li>Google Map(гугл карты)</li>
            <li>Google reCaptcha</li>
            <li>Button (кнопки соцсетей)</li>
            +<li>Horizontal devider (разделитель)</li>
            <li>Social link button (кнопки соцсетей)</li>
            <li>Icon (Иконки (набор иконок, с возможность задавать цвет, размер))</li>
            <li>Table (таблицы)</li>
            <li>Carusel (Карусель) </li>
            <li>Banner (баннер) </li>
            + <li>Empty space (Пустое место) </li>
            <li>Row (Добавка ряда, а в нем возможность добавлять столбцы менять фон на изображение или задавать цвет)</li>
            Partial View 
            Action URL
            */

            var seoGroup = new DesignComponentGroup
            {
                Description = "SEO & Analytics helper page components",
                DisplayName = "SEO & Analytics",
                Expandable = true,
                Expanded = false,
                Name = "SEOAnalytics",
                Components = new List<IContentComponent>()
            };
            seoGroup.Components.Add(new GoogleAnalytics(_configHelper));
            seoGroup.Components.Add(new PageTitle(_configHelper));
            seoGroup.Components.Add(new PageDescription(_configHelper));
            seoGroup.Components.Add(new PageKeywords(_configHelper));
            seoGroup.Components.Add(new PageAuthor(_configHelper));
            ComponentGroups.Add(seoGroup);

            /*             
            <li>Page Title</li>
            <li>Page Description</li>
            <li>Page Keywords</li>
            <li>Page Author</li>
            <li>Google Analytics</li>       
             */

            /*ComponentGroups.Add(new DesignComponentGroup
            {
                Components = null,
                Description = "Blogs helper components",
                DisplayName = "Blogs",
                Expandable = true,
                Expanded = false,
                Name = "Blogs"
            });
            
            <li>Blog Page</li>
            <li>Blog Filter</li>
            <li>Blog Subscription</li>
            <li>Blog Unsubscription</li>
            <li>New Blog</li>
            <li>Recent Posts</li> 
            */
            group = new DesignComponentGroup
            {
                Components = new List<Common.IContentComponent>(),
                Description = "Here we should see list controls created by user",
                DisplayName = "Custom Controls",
                Expandable = true,
                Expanded = false,
                Name = "CustomControls"
            };
            if(_externalComponents != null && _externalComponents.Any())
            {
                group.Components.AddRange(_externalComponents);
                allComponents.AddRange(group.Components);
            }            
            ComponentGroups.Add(group);

            //Here we need to add items from ContentControlType table with further drop down to choose particular items from ContentControl
            /*
            ComponentGroups.Add(new DesignComponentGroup
            {
                Components = null,
                Description = "Once implemented - it will show list of controls for inter-module communication",
                DisplayName = "Module Integration",
                Expandable = true,
                Expanded = false,
                Name = "ModuleIntegration"
            });
            */

            //Adding recently used
            if(currentNode != null && currentNode.PageSettings != null && currentNode.PageSettings.RecentlyUsedControls != null && currentNode.PageSettings.RecentlyUsedControls.Any())
            {
                foreach(var ctrl in currentNode.PageSettings.RecentlyUsedControls)
                {
                    var ctrlObj = allComponents.SingleOrDefault(a => a.Name == ctrl);
                    if(ctrlObj != null)
                    {
                        if (recentlyUsedGroup.Components == null)
                            recentlyUsedGroup.Components = new List<IContentComponent>();
                        recentlyUsedGroup.Components.Add(ctrlObj);
                    }
                }
            }

        }
        /// <summary>
        /// Gets the component groups.
        /// </summary>
        /// <value>The component groups.</value>
        public List<DesignComponentGroup> ComponentGroups { get; }
    }
}
