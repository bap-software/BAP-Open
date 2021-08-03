using BAP.eCommerce.BL.ProductCategoryNodes;
using BAP.eCommerce.DAL.Entities;
using PagedList;
using System.Collections.Generic;

namespace BAP.Web.Areas.Administration.Models
{
    public class BAPProductCategoryData
    {
        public ProductCategoryNode RootNode { get; set; }

        public ProductCategoryNode CurrentNode { get; set; }

        public string Search { get; set; }

        public IList<ProductCategoryNode> GetAllNodes(ProductCategoryNode node)
        {
            var nodes = new List<ProductCategoryNode>();
            foreach (var child in node.Children)
                nodes.AddRange(GetAllNodes(child));
            nodes.Add(node);            
            return nodes;
        }

        public IPagedList<Product> Products { get; set; }
    }
}