using BAP.DAL.Entities;
using BAP.eCommerce.DAL.Entities;
using System;
using System.Collections.Generic;

namespace BAP.Web.Areas.eCommerce.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SKU { get; set; }

        public string PublicStatus { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public int AvailableItems { get; set; }

        public bool TrackInventory { get; set; }

        public bool NeedsShipping { get; set; }

        public Currency Currency { get; set; }

        public decimal Price { get; set; }

        public decimal ListPrice { get; set; }

        public string PID { get; set; }

        public string ImagePath { get; set; }

        public string CustomDetailsUrl { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public string WeightMeasure { get; set; }

        public string SizeMeasure { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public IList<Attachment> Attachments { get; set; }

        public IList<ProductOption> Options { get; set; }

        public IList<RelatedProduct> RelatedProducts { get; set; }

        public int Sales { get; set; }

        public decimal Discount => ListPrice > 0 ? Price - ListPrice : 0;

        public decimal RealPrice => Price - Discount;

        public bool IsOutOfStock => TrackInventory && AvailableItems == 0;

        public ProductModel(Product product)
        {
            if (product != null)
            {
                Id = product.Id;
                Name = product.Name;
                ShortDescription = product.ShortDescription;
                Description = product.Description;
                Currency = product.Currency;
                Price = product.Price;
                ListPrice = product.ListPrice;
                PID = product.GetPublicId();
                ImagePath = product.ImagePath;
                CustomDetailsUrl = product.CustomDetailsUrl;
                LastModifiedDate = product.LastModifiedDate;
                SKU = product.SKU;
                PublicStatus = product.PublicStatus;
                AvailableItems = product.AvailableItems;
                TrackInventory = product.TrackInventory;
                NeedsShipping = product.NeedsShipping;
                Width = product.Width;
                Depth = product.Depth;
                Height = product.Height;
                Weight = product.Weight;
                WeightMeasure = product.WeightMeasure;
                SizeMeasure = product.SizeMeasure;
                ProductCategory = product.ProductCategory;
                Manufacturer = product.Manufacturer;
                Attachments = product.Attachments;
                Options = product.Options;
                RelatedProducts = product.RelatedProducts;
            }
        }
    }
}