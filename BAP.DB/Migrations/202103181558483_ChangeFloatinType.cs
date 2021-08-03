namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFloatinType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerOrderPayment", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.CustomerOrder", "Subtotal", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.CustomerOrder", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.CustomerOrder", "DiscountsTotal", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.CustomerOrder", "ShippingCost", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.CustomerOrder", "TaxTotal", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.ShippingOption", "MaxPrice", c => c.Decimal(precision: 18, scale: 4));
            AlterColumn("dbo.DiscountCoupon", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "SourcePrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "ListPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "MsrpPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "MinPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "MaxPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "Width", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "Depth", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "Height", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Product", "PrepaymentAmount", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.ProductOptionItem", "PriceAdded", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.OrderItem", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.OrderItem", "Subtotal", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.OrderItem", "TotalTax", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.OrderItem", "TotalDiscounts", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.ShoppingCartProduct", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.ShoppingCartProduct", "Subtotal", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.ShoppingCartProduct", "TotalDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.ShoppingCartProduct", "OptionsAddedPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.ShoppingCart", "Subtotal", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.ShoppingCart", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.ShoppingCart", "ShippingCost", c => c.Decimal(precision: 18, scale: 4));
            AlterColumn("dbo.ShoppingCart", "TotalDiscounts", c => c.Decimal(precision: 18, scale: 4));
            AlterColumn("dbo.ShoppingCart", "TaxTotal", c => c.Decimal(precision: 18, scale: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShoppingCart", "TaxTotal", c => c.Single());
            AlterColumn("dbo.ShoppingCart", "TotalDiscounts", c => c.Single());
            AlterColumn("dbo.ShoppingCart", "ShippingCost", c => c.Single());
            AlterColumn("dbo.ShoppingCart", "Total", c => c.Single(nullable: false));
            AlterColumn("dbo.ShoppingCart", "Subtotal", c => c.Single(nullable: false));
            AlterColumn("dbo.ShoppingCartProduct", "OptionsAddedPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.ShoppingCartProduct", "TotalDiscount", c => c.Single(nullable: false));
            AlterColumn("dbo.ShoppingCartProduct", "Subtotal", c => c.Single(nullable: false));
            AlterColumn("dbo.ShoppingCartProduct", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderItem", "TotalDiscounts", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderItem", "TotalTax", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderItem", "Subtotal", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderItem", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.ProductOptionItem", "PriceAdded", c => c.Single(nullable: false));
            AlterColumn("dbo.Product", "PrepaymentAmount", c => c.Single(nullable: false));
            AlterColumn("dbo.Product", "Height", c => c.Single(nullable: false));
            AlterColumn("dbo.Product", "Depth", c => c.Single(nullable: false));
            AlterColumn("dbo.Product", "Width", c => c.Single(nullable: false));
            AlterColumn("dbo.Product", "Weight", c => c.Single(nullable: false));
            AlterColumn("dbo.Product", "MaxPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.Product", "MinPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.Product", "MsrpPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.Product", "ListPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.Product", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Product", "SourcePrice", c => c.Single(nullable: false));
            AlterColumn("dbo.DiscountCoupon", "Amount", c => c.Single(nullable: false));
            AlterColumn("dbo.ShippingOption", "MaxPrice", c => c.Single());
            AlterColumn("dbo.CustomerOrder", "TaxTotal", c => c.Single(nullable: false));
            AlterColumn("dbo.CustomerOrder", "ShippingCost", c => c.Single(nullable: false));
            AlterColumn("dbo.CustomerOrder", "DiscountsTotal", c => c.Single(nullable: false));
            AlterColumn("dbo.CustomerOrder", "Total", c => c.Single(nullable: false));
            AlterColumn("dbo.CustomerOrder", "Subtotal", c => c.Single(nullable: false));
            AlterColumn("dbo.CustomerOrderPayment", "Total", c => c.Single(nullable: false));
        }
    }
}
