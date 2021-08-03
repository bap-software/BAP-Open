// ***********************************************************************
// Assembly         : BAP.eCommerce.Resources
// Author           : Victor Mamray
// Created          : 07-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-24-2020
// ***********************************************************************
// <copyright file="ResObject.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Globalization;

namespace BAP.eCommerce.Resources
{
    /// <summary>
    /// A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResObject : BAP.Resources.Resources
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResObject"/> class.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public ResObject() : base()
        {
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
            return ReadResourceManagerStringByType(name, culture, typeof(ResObject), defaultValue);
        }


        
        /// <summary>
        /// Looks up a localized string similar to Show if empty, click next to upload.
        /// </summary>
        /// <value>The UI text no orders yet.</value>
        public static string FieldLabel_Manufacturer_ShowIfEmpty
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Manufacturer_ShowIfEmpty", resourceCulture, "Show if empty?");
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Json verified, click next to upload.
        /// </summary>
        /// <value>The UI text no orders yet.</value>
        public static string UIText_NoOrdersYet
        {
            get
            {
                return ResourceManagerGetString("UIText_NoOrdersYet", resourceCulture, "You have no orders yet.");
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Result.
        /// </summary>
        /// <value>The field label product initial term.</value>
        public static string FieldLabel_Product_InitialTerm
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_InitialTerm", resourceCulture, "Initial Term");
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Result.
        /// </summary>
        /// <value>The field label product free trial term.</value>
        public static string FieldLabel_Product_FreeTrialTerm
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_FreeTrialTerm", resourceCulture, "Free Trial Term");
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Result.
        /// </summary>
        /// <value>The field label product renewal term.</value>
        public static string FieldLabel_Product_RenewalTerm
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_RenewalTerm", resourceCulture, "Renewal Term");
            }
        }

        /// <summary>
        /// Looks up a localized string similar to rating.
        /// </summary>
        /// <value>The field label product renewal term.</value>
        public static string FieldLabel_Common_Rating
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Common_Rating", resourceCulture, "Rating");
            }
        }        

        /// <summary>
        /// Looks up a localized string similar to Json verified, click next to upload.
        /// </summary>
        /// <value>The data wizard alert.</value>
        /// ABOVE NOT IN SEEDING YET ============================================================================================================================
        public static string DataWizard_Alert
        {
            get
            {
                return ResourceManagerGetString("DataWizard_Alert", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Upload JSON File.
        /// </summary>
        /// <value>The data wizard header one.</value>
        public static string DataWizard_Header_One
        {
            get
            {
                return ResourceManagerGetString("DataWizard_Header_One", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Result.
        /// </summary>
        /// <value>The data wizard header two.</value>
        public static string DataWizard_Header_Two
        {
            get
            {
                return ResourceManagerGetString("DataWizard_Header_Two", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to {0} categories successfully uploaded to database..
        /// </summary>
        /// <value>The data wizard controller category successfull upload.</value>
        public static string DataWizardController_Category_Successfull_Upload
        {
            get
            {
                return ResourceManagerGetString("DataWizardController_Category_Successfull_Upload", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Json deserialization error.
        /// </summary>
        /// <value>The data wizard controller json deserialization error.</value>
        public static string DataWizardController_Json_Deserialization_error
        {
            get
            {
                return ResourceManagerGetString("DataWizardController_Json_Deserialization_error", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to {0} products successfully uploaded to database..
        /// </summary>
        /// <value>The data wizard controller product successfull upload.</value>
        public static string DataWizardController_Product_Successfull_Upload
        {
            get
            {
                return ResourceManagerGetString("DataWizardController_Product_Successfull_Upload", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Json validation error.
        /// </summary>
        /// <value>The data wizard controller validation error.</value>
        public static string DataWizardController_Validation_Error
        {
            get
            {
                return ResourceManagerGetString("DataWizardController_Validation_Error", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sales order confirmation.
        /// </summary>
        /// <value>The email text order confiration subject.</value>
        public static string EmailText_OrderConfirationSubject
        {
            get
            {
                return ResourceManagerGetString("EmailText_OrderConfirationSubject", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Order details.
        /// </summary>
        /// <value>The email text order details subject.</value>
        public static string EmailText_OrderDetailsSubject
        {
            get
            {
                return ResourceManagerGetString("EmailText_OrderDetailsSubject", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to About your order.
        /// </summary>
        /// <value>The email text order subject.</value>
        public static string EmailText_OrderSubject
        {
            get
            {
                return ResourceManagerGetString("EmailText_OrderSubject", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address.
        /// </summary>
        /// <value>The entity label address.</value>
        public static string EntityLabel_Address
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Address", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customer.
        /// </summary>
        /// <value>The entity label customer.</value>
        public static string EntityLabel_Customer
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Customer", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customer Order.
        /// </summary>
        /// <value>The entity label customer order.</value>
        public static string EntityLabel_CustomerOrder
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_CustomerOrder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Discount Coupon.
        /// </summary>
        /// <value>The entity label discount coupon.</value>
        public static string EntityLabel_DiscountCoupon
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_DiscountCoupon", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Manufacturer.
        /// </summary>
        /// <value>The entity label manufacturer.</value>
        public static string EntityLabel_Manufacturer
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Manufacturer", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment Option.
        /// </summary>
        /// <value>The entity label payment option.</value>
        public static string EntityLabel_PaymentOption
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_PaymentOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product.
        /// </summary>
        /// <value>The entity label product.</value>
        public static string EntityLabel_Product
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Product", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product Catalog.
        /// </summary>
        /// <value>The entity label product catalog.</value>
        public static string EntityLabel_ProductCatalog
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_ProductCatalog", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product Category.
        /// </summary>
        /// <value>The entity label product category.</value>
        public static string EntityLabel_ProductCategory
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_ProductCategory", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product Option.
        /// </summary>
        /// <value>The entity label product option.</value>
        public static string EntityLabel_ProductOption
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_ProductOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Option Items.
        /// </summary>
        /// <value>The entity label product option item.</value>
        public static string EntityLabel_ProductOptionItem
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_ProductOptionItem", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Carrier.
        /// </summary>
        /// <value>The entity label shipping carrier.</value>
        public static string EntityLabel_ShippingCarrier
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_ShippingCarrier", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Option.
        /// </summary>
        /// <value>The entity label shipping option.</value>
        public static string EntityLabel_ShippingOption
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_ShippingOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shopping Cart.
        /// </summary>
        /// <value>The entity label shopping cart.</value>
        public static string EntityLabel_ShoppingCart
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_ShoppingCart", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Store.
        /// </summary>
        /// <value>The entity label store.</value>
        public static string EntityLabel_Store
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Store", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Supplier.
        /// </summary>
        /// <value>The entity label supplier.</value>
        public static string EntityLabel_Supplier
        {
            get
            {
                return ResourceManagerGetString("EntityLabel_Supplier", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attribute.
        /// </summary>
        /// <value>The enum value product option type attribute.</value>
        public static string EnumValue_ProductOptionType_Attribute
        {
            get
            {
                return ResourceManagerGetString("EnumValue_ProductOptionType_Attribute", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Not set.
        /// </summary>
        /// <value>The enum value product option type not set.</value>
        public static string EnumValue_ProductOptionType_NotSet
        {
            get
            {
                return ResourceManagerGetString("EnumValue_ProductOptionType_NotSet", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product.
        /// </summary>
        /// <value>The enum value product option type product.</value>
        public static string EnumValue_ProductOptionType_Product
        {
            get
            {
                return ResourceManagerGetString("EnumValue_ProductOptionType_Product", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Text.
        /// </summary>
        /// <value>The enum value product option type text.</value>
        public static string EnumValue_ProductOptionType_Text
        {
            get
            {
                return ResourceManagerGetString("EnumValue_ProductOptionType_Text", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Checkboxes Horizontally.
        /// </summary>
        /// <value>The enum value product option user control checkbox horizontal.</value>
        public static string EnumValue_ProductOptionUserControl_CheckboxHorizontal
        {
            get
            {
                return ResourceManagerGetString("EnumValue_ProductOptionUserControl_CheckboxHorizontal", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Checkboxes Vertically.
        /// </summary>
        /// <value>The enum value product option user control checkbox vertical.</value>
        public static string EnumValue_ProductOptionUserControl_CheckboxVertical
        {
            get
            {
                return ResourceManagerGetString("EnumValue_ProductOptionUserControl_CheckboxVertical", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Dropdown List.
        /// </summary>
        /// <value>The enum value product option user control drop down list.</value>
        public static string EnumValue_ProductOptionUserControl_DropDownList
        {
            get
            {
                return ResourceManagerGetString("EnumValue_ProductOptionUserControl_DropDownList", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Not set.
        /// </summary>
        /// <value>The enum value product option user control not set.</value>
        public static string EnumValue_ProductOptionUserControl_NotSet
        {
            get
            {
                return ResourceManagerGetString("EnumValue_ProductOptionUserControl_NotSet", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Radio Horizontally.
        /// </summary>
        /// <value>The enum value product option user control radio horizontal.</value>
        public static string EnumValue_ProductOptionUserControl_RadioHorizontal
        {
            get
            {
                return ResourceManagerGetString("EnumValue_ProductOptionUserControl_RadioHorizontal", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Radio Vertically.
        /// </summary>
        /// <value>The enum value product option user control radio vertical.</value>
        public static string EnumValue_ProductOptionUserControl_RadioVertical
        {
            get
            {
                return ResourceManagerGetString("EnumValue_ProductOptionUserControl_RadioVertical", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Text.
        /// </summary>
        /// <value>The enum value product option user control text.</value>
        public static string EnumValue_ProductOptionUserControl_Text
        {
            get
            {
                return ResourceManagerGetString("EnumValue_ProductOptionUserControl_Text", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Text Area.
        /// </summary>
        /// <value>The enum value product option user control text area.</value>
        public static string EnumValue_ProductOptionUserControl_TextArea
        {
            get
            {
                return ResourceManagerGetString("EnumValue_ProductOptionUserControl_TextArea", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Illegal attempt to add product to the cart.
        /// </summary>
        /// <value>The error text illegal add to cart.</value>
        public static string ErrorText_IllegalAddToCart
        {
            get
            {
                return ResourceManagerGetString("ErrorText_IllegalAddToCart", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Invalid parent product category used - it will cause circular dependency..
        /// </summary>
        /// <value>The error text invalid parent product category.</value>
        public static string ErrorText_InvalidParentProductCategory
        {
            get
            {
                return ResourceManagerGetString("ErrorText_InvalidParentProductCategory", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Chosen user control is not acceptable for Text type of product option.
        /// </summary>
        /// <value>The error text nota acceptable uc for product option text.</value>
        public static string ErrorText_NotaAcceptableUCForProductOptionText
        {
            get
            {
                return ResourceManagerGetString("ErrorText_NotaAcceptableUCForProductOptionText", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Chosen user control is not acceptable for Product or Attribute type of product option..
        /// </summary>
        /// <value>The error text not acceptable uc for product option attribute or product.</value>
        public static string ErrorText_NotAcceptableUCForProductOptionAttrOrProduct
        {
            get
            {
                return ResourceManagerGetString("ErrorText_NotAcceptableUCForProductOptionAttrOrProduct", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment could not be applied on the order, contact Support for more details.
        /// </summary>
        /// <value>The error text payment cannot be applied on order.</value>
        public static string ErrorText_PaymentCannotBeAppliedOnOrder
        {
            get
            {
                return ResourceManagerGetString("ErrorText_PaymentCannotBeAppliedOnOrder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cannot add product {0}, it is already present as option item..
        /// </summary>
        /// <value>The error text product already option item.</value>
        public static string ErrorText_ProductAlreadyOptionItem
        {
            get
            {
                return ResourceManagerGetString("ErrorText_ProductAlreadyOptionItem", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cannot add product {0}, it is already present as related product..
        /// </summary>
        /// <value>The error text product already related product.</value>
        public static string ErrorText_ProductAlreadyRelatedProduct
        {
            get
            {
                return ResourceManagerGetString("ErrorText_ProductAlreadyRelatedProduct", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Only two levels of product categories are allowed for a moment..
        /// </summary>
        /// <value>The error text product category2 level only.</value>
        public static string ErrorText_ProductCategory2LevelOnly
        {
            get
            {
                return ResourceManagerGetString("ErrorText_ProductCategory2LevelOnly", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cannot update item with product {0}, it is already used by another item..
        /// </summary>
        /// <value>The error text product item already present.</value>
        public static string ErrorText_ProductItemAlreadyPresent
        {
            get
            {
                return ResourceManagerGetString("ErrorText_ProductItemAlreadyPresent", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cannot update item with product {0}, it is already among products option is assigned to..
        /// </summary>
        /// <value>The error text product item already product.</value>
        public static string ErrorText_ProductItemAlreadyProduct
        {
            get
            {
                return ResourceManagerGetString("ErrorText_ProductItemAlreadyProduct", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Account Settings.
        /// </summary>
        /// <value>The field label account settings.</value>
        public static string FieldLabel_AccountSettings
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_AccountSettings", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address Line 1.
        /// </summary>
        /// <value>The field label address address line1.</value>
        public static string FieldLabel_Address_AddressLine1
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_AddressLine1", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Address Line 2.
        /// </summary>
        /// <value>The field label address address line2.</value>
        public static string FieldLabel_Address_AddressLine2
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_AddressLine2", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cell No..
        /// </summary>
        /// <value>The field label address cell number.</value>
        public static string FieldLabel_Address_CellNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_CellNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to City.
        /// </summary>
        /// <value>The field label address city.</value>
        public static string FieldLabel_Address_City
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_City", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Company Name.
        /// </summary>
        /// <value>The name of the field label address company.</value>
        public static string FieldLabel_Address_CompanyName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_CompanyName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Email.
        /// </summary>
        /// <value>The field label address contact email.</value>
        public static string FieldLabel_Address_ContactEmail
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_ContactEmail", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Country.
        /// </summary>
        /// <value>The field label address country.</value>
        public static string FieldLabel_Address_Country
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_Country", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to County.
        /// </summary>
        /// <value>The field label address county.</value>
        public static string FieldLabel_Address_County
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_County", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to County/Region.
        /// </summary>
        /// <value>The field label address county region.</value>
        public static string FieldLabel_Address_County_Region
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_County_Region", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label address create date.</value>
        public static string FieldLabel_Address_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label address created by user.</value>
        public static string FieldLabel_Address_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label address description.</value>
        public static string FieldLabel_Address_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Fax.
        /// </summary>
        /// <value>The field label address fax number.</value>
        public static string FieldLabel_Address_FaxNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_FaxNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to First Name.
        /// </summary>
        /// <value>The first name of the field label address.</value>
        public static string FieldLabel_Address_FirstName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_FirstName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Full Name.
        /// </summary>
        /// <value>The full name of the field label address.</value>
        public static string FieldLabel_Address_FullName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_FullName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label address last modified by user.</value>
        public static string FieldLabel_Address_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label address last modified date.</value>
        public static string FieldLabel_Address_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Name.
        /// </summary>
        /// <value>The last name of the field label address.</value>
        public static string FieldLabel_Address_LastName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_LastName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Middle Name.
        /// </summary>
        /// <value>The name of the field label address middle.</value>
        public static string FieldLabel_Address_MiddleName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_MiddleName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label address.</value>
        public static string FieldLabel_Address_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Phone Ext..
        /// </summary>
        /// <value>The field label address phone extension.</value>
        public static string FieldLabel_Address_PhoneExtension
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_PhoneExtension", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Phone No..
        /// </summary>
        /// <value>The field label address phone number.</value>
        public static string FieldLabel_Address_PhoneNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_PhoneNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Postcode.
        /// </summary>
        /// <value>The field label address postcode.</value>
        public static string FieldLabel_Address_Postcode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_Postcode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to State.
        /// </summary>
        /// <value>The state of the field label address.</value>
        public static string FieldLabel_Address_State
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_State", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to State (US only).
        /// </summary>
        /// <value>The field label address state us only.</value>
        public static string FieldLabel_Address_State_US_Only
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_State_US_Only", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Town/City.
        /// </summary>
        /// <value>The field label address town city.</value>
        public static string FieldLabel_Address_Town_City
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_Town_City", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Zip.
        /// </summary>
        /// <value>The field label address zip.</value>
        public static string FieldLabel_Address_Zip
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Address_Zip", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to All you need in one place. All with a few simple clicks..
        /// </summary>
        /// <value>The field label all you need in one place.</value>
        public static string FieldLabel_AllYouNeedInOnePlace
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_AllYouNeedInOnePlace", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attachments.
        /// </summary>
        /// <value>The field label attachments.</value>
        public static string FieldLabel_Attachments
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Attachments", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Back to Orders.
        /// </summary>
        /// <value>The field label back to orders.</value>
        public static string FieldLabel_BackToOrders
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_BackToOrders", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cancel items.
        /// </summary>
        /// <value>The field label cancel items.</value>
        public static string FieldLabel_CancelItems
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CancelItems", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Change preferable payment method.
        /// </summary>
        /// <value>The field label change preferable payment method.</value>
        public static string FieldLabel_ChangePreferablePaymentMethod
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ChangePreferablePaymentMethod", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Change shipping or billing info for an order.
        /// </summary>
        /// <value>The field label change shipping or billing information for order.</value>
        public static string FieldLabel_ChangeShippingOrBillingInfoForOrder
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ChangeShippingOrBillingInfoForOrder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Change your default shipping or billing info.
        /// </summary>
        /// <value>The field label change your default shipping or billing information.</value>
        public static string FieldLabel_ChangeYourDefaultShippingOrBillingInfo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ChangeYourDefaultShippingOrBillingInfo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Check the status of an order.
        /// </summary>
        /// <value>The field label check status of order.</value>
        public static string FieldLabel_CheckStatusOfOrder
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CheckStatusOfOrder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Check the status of a rebate.
        /// </summary>
        /// <value>The field label check status of rebate.</value>
        public static string FieldLabel_CheckStatusOfRebate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CheckStatusOfRebate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Check the balance of a gift card.
        /// </summary>
        /// <value>The field label check the balance of gift card.</value>
        public static string FieldLabel_CheckTheBalanceOfGiftCard
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CheckTheBalanceOfGiftCard", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Copy link to clipboard.
        /// </summary>
        /// <value>The field label copy link to clipboard.</value>
        public static string FieldLabel_CopyLinkToClipboard
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CopyLinkToClipboard", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Billing address.
        /// </summary>
        /// <value>The field label customer billing address.</value>
        public static string FieldLabel_Customer_BillingAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_BillingAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Billing Address Id.
        /// </summary>
        /// <value>The field label customer billing address identifier.</value>
        public static string FieldLabel_Customer_BillingAddressId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_BillingAddressId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Cell Phone.
        /// </summary>
        /// <value>The field label customer cell number.</value>
        public static string FieldLabel_Customer_CellNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_CellNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Company address.
        /// </summary>
        /// <value>The field label customer company address.</value>
        public static string FieldLabel_Customer_CompanyAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_CompanyAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Company Address Id.
        /// </summary>
        /// <value>The field label customer company address identifier.</value>
        public static string FieldLabel_Customer_CompanyAddressId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_CompanyAddressId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Company Name.
        /// </summary>
        /// <value>The name of the field label customer company.</value>
        public static string FieldLabel_Customer_CompanyName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_CompanyName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label customer create date.</value>
        public static string FieldLabel_Customer_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label customer created by user.</value>
        public static string FieldLabel_Customer_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Custom Data.
        /// </summary>
        /// <value>The field label customer custom data.</value>
        public static string FieldLabel_Customer_CustomData
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_CustomData", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment Methods.
        /// </summary>
        /// <value>The field label customer customer payments.</value>
        public static string FieldLabel_Customer_CustomerPayments
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_CustomerPayments", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label customer description.</value>
        public static string FieldLabel_Customer_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Email.
        /// </summary>
        /// <value>The field label customer email.</value>
        public static string FieldLabel_Customer_Email
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_Email", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Fax.
        /// </summary>
        /// <value>The field label customer fax number.</value>
        public static string FieldLabel_Customer_FaxNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_FaxNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to First Name.
        /// </summary>
        /// <value>The first name of the field label customer.</value>
        public static string FieldLabel_Customer_FirstName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_FirstName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label customer last modified by user.</value>
        public static string FieldLabel_Customer_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label customer last modified date.</value>
        public static string FieldLabel_Customer_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Name.
        /// </summary>
        /// <value>The last name of the field label customer.</value>
        public static string FieldLabel_Customer_LastName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_LastName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Login User.
        /// </summary>
        /// <value>The field label customer login user.</value>
        public static string FieldLabel_Customer_LoginUser
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_LoginUser", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Login User Id.
        /// </summary>
        /// <value>The field label customer login user identifier.</value>
        public static string FieldLabel_Customer_LoginUserId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_LoginUserId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Middle Name.
        /// </summary>
        /// <value>The name of the field label customer middle.</value>
        public static string FieldLabel_Customer_MiddleName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_MiddleName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label customer.</value>
        public static string FieldLabel_Customer_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Phone Ext..
        /// </summary>
        /// <value>The field label customer phone extension.</value>
        public static string FieldLabel_Customer_PhoneExtension
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_PhoneExtension", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Phone.
        /// </summary>
        /// <value>The field label customer phone number.</value>
        public static string FieldLabel_Customer_PhoneNumber
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_PhoneNumber", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Preferred Currency.
        /// </summary>
        /// <value>The field label customer preffered currency.</value>
        public static string FieldLabel_Customer_PrefferedCurrency
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_PrefferedCurrency", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Preferred Currency Id.
        /// </summary>
        /// <value>The field label customer preffered currency identifier.</value>
        public static string FieldLabel_Customer_PrefferedCurrencyId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_PrefferedCurrencyId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Preferred Shipping Option.
        /// </summary>
        /// <value>The field label customer preffered shipping option.</value>
        public static string FieldLabel_Customer_PrefferedShippingOption
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_PrefferedShippingOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Preferred Shipping Option Id.
        /// </summary>
        /// <value>The field label customer preffered shipping option identifier.</value>
        public static string FieldLabel_Customer_PrefferedShippingOptionId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_PrefferedShippingOptionId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Registered days ago.
        /// </summary>
        /// <value>The field label customer registered days ago.</value>
        public static string FieldLabel_Customer_RegisteredDaysAgo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_RegisteredDaysAgo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping address.
        /// </summary>
        /// <value>The field label customer shipping address.</value>
        public static string FieldLabel_Customer_ShippingAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_ShippingAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Address Id.
        /// </summary>
        /// <value>The field label customer shipping address identifier.</value>
        public static string FieldLabel_Customer_ShippingAddressId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_ShippingAddressId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label customer short description.</value>
        public static string FieldLabel_Customer_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Customer_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Billing Address.
        /// </summary>
        /// <value>The field label customer order billing address.</value>
        public static string FieldLabel_CustomerOrder_BillingAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_BillingAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Billing Address Id.
        /// </summary>
        /// <value>The field label customer order billing address identifier.</value>
        public static string FieldLabel_CustomerOrder_BillingAddressId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_BillingAddressId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Coupon.
        /// </summary>
        /// <value>The field label customer order coupon.</value>
        public static string FieldLabel_CustomerOrder_Coupon
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_Coupon", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label customer order create date.</value>
        public static string FieldLabel_CustomerOrder_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label customer order created by user.</value>
        public static string FieldLabel_CustomerOrder_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Currency.
        /// </summary>
        /// <value>The field label customer order currency.</value>
        public static string FieldLabel_CustomerOrder_Currency
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_Currency", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Currency Id.
        /// </summary>
        /// <value>The field label customer order currency identifier.</value>
        public static string FieldLabel_CustomerOrder_CurrencyId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_CurrencyId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Custom Data.
        /// </summary>
        /// <value>The field label customer order custom data.</value>
        public static string FieldLabel_CustomerOrder_CustomData
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_CustomData", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customer.
        /// </summary>
        /// <value>The field label customer order customer.</value>
        public static string FieldLabel_CustomerOrder_Customer
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_Customer", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customer Id.
        /// </summary>
        /// <value>The field label customer order customer identifier.</value>
        public static string FieldLabel_CustomerOrder_CustomerId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_CustomerId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customer Payment.
        /// </summary>
        /// <value>The field label customer order customer payment.</value>
        public static string FieldLabel_CustomerOrder_CustomerPayment
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_CustomerPayment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customer Payment Id.
        /// </summary>
        /// <value>The field label customer order customer payment identifier.</value>
        public static string FieldLabel_CustomerOrder_CustomerPaymentId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_CustomerPaymentId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label customer order description.</value>
        public static string FieldLabel_CustomerOrder_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Discount Coupon.
        /// </summary>
        /// <value>The field label customer order discount coupon.</value>
        public static string FieldLabel_CustomerOrder_DiscountCoupon
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_DiscountCoupon", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Discount Coupon Id.
        /// </summary>
        /// <value>The field label customer order discount coupon identifier.</value>
        public static string FieldLabel_CustomerOrder_DiscountCouponId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_DiscountCouponId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Discounts.
        /// </summary>
        /// <value>The field label customer order discounts total.</value>
        public static string FieldLabel_CustomerOrder_DiscountsTotal
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_DiscountsTotal", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Order Items.
        /// </summary>
        /// <value>The field label customer order items.</value>
        public static string FieldLabel_CustomerOrder_Items
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_Items", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label customer order last modified by user.</value>
        public static string FieldLabel_CustomerOrder_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label customer order last modified date.</value>
        public static string FieldLabel_CustomerOrder_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label customer order.</value>
        public static string FieldLabel_CustomerOrder_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Notes.
        /// </summary>
        /// <value>The field label customer order notes.</value>
        public static string FieldLabel_CustomerOrder_Notes
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_Notes", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Delivered At.
        /// </summary>
        /// <value>The field label customer order order delivered at.</value>
        public static string FieldLabel_CustomerOrder_OrderDeliveredAt
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_OrderDeliveredAt", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment Option.
        /// </summary>
        /// <value>The field label customer order payment option.</value>
        public static string FieldLabel_CustomerOrder_PaymentOption
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_PaymentOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment Option Id.
        /// </summary>
        /// <value>The field label customer order payment option identifier.</value>
        public static string FieldLabel_CustomerOrder_PaymentOptionId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_PaymentOptionId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Order#.
        /// </summary>
        /// <value>The field label customer order public identifier.</value>
        public static string FieldLabel_CustomerOrder_PublicId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_PublicId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipment Declined?.
        /// </summary>
        /// <value>The field label customer order shipment declined.</value>
        public static string FieldLabel_CustomerOrder_ShipmentDeclined
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_ShipmentDeclined", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipment Declined At.
        /// </summary>
        /// <value>The field label customer order shipment declined at.</value>
        public static string FieldLabel_CustomerOrder_ShipmentDeclinedAt
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_ShipmentDeclinedAt", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipment Started.
        /// </summary>
        /// <value>The field label customer order shipment initiated at.</value>
        public static string FieldLabel_CustomerOrder_ShipmentInitiatedAt
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_ShipmentInitiatedAt", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Address.
        /// </summary>
        /// <value>The field label customer order shipping address.</value>
        public static string FieldLabel_CustomerOrder_ShippingAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_ShippingAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Address Id.
        /// </summary>
        /// <value>The field label customer order shipping address identifier.</value>
        public static string FieldLabel_CustomerOrder_ShippingAddressId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_ShippingAddressId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Shipping.
        /// </summary>
        /// <value>The field label customer order shipping cost.</value>
        public static string FieldLabel_CustomerOrder_ShippingCost
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_ShippingCost", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Option.
        /// </summary>
        /// <value>The field label customer order shipping option.</value>
        public static string FieldLabel_CustomerOrder_ShippingOption
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_ShippingOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Option Id.
        /// </summary>
        /// <value>The field label customer order shipping option identifier.</value>
        public static string FieldLabel_CustomerOrder_ShippingOptionId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_ShippingOptionId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipment Ref. #.
        /// </summary>
        /// <value>The field label customer order shipping reference identifier.</value>
        public static string FieldLabel_CustomerOrder_ShippingReferenceId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_ShippingReferenceId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label customer order short description.</value>
        public static string FieldLabel_CustomerOrder_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subtotal.
        /// </summary>
        /// <value>The field label customer order subtotal.</value>
        public static string FieldLabel_CustomerOrder_Subtotal
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_Subtotal", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Tax.
        /// </summary>
        /// <value>The field label customer order tax total.</value>
        public static string FieldLabel_CustomerOrder_TaxTotal
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_TaxTotal", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total.
        /// </summary>
        /// <value>The field label customer order total.</value>
        public static string FieldLabel_CustomerOrder_Total
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_Total", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to User.
        /// </summary>
        /// <value>The field label customer order user.</value>
        public static string FieldLabel_CustomerOrder_User
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_User", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to User Id.
        /// </summary>
        /// <value>The field label customer order user identifier.</value>
        public static string FieldLabel_CustomerOrder_UserId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrder_UserId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customer Order Invoice.
        /// </summary>
        /// <value>The field label customer order invoice.</value>
        public static string FieldLabel_CustomerOrderInvoice
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderInvoice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attempt No.
        /// </summary>
        /// <value>The field label customer order payment attempt no.</value>
        public static string FieldLabel_CustomerOrderPayment_AttemptNo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_AttemptNo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label customer order payment create date.</value>
        public static string FieldLabel_CustomerOrderPayment_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label customer order payment created by user.</value>
        public static string FieldLabel_CustomerOrderPayment_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Currency.
        /// </summary>
        /// <value>The field label customer order payment currency.</value>
        public static string FieldLabel_CustomerOrderPayment_Currency
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_Currency", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customer Order.
        /// </summary>
        /// <value>The field label customer order payment customer order.</value>
        public static string FieldLabel_CustomerOrderPayment_CustomerOrder
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_CustomerOrder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Csutomer Payment.
        /// </summary>
        /// <value>The field label customer order payment customer payment.</value>
        public static string FieldLabel_CustomerOrderPayment_CustomerPayment
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_CustomerPayment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Error Code.
        /// </summary>
        /// <value>The field label customer order payment error code.</value>
        public static string FieldLabel_CustomerOrderPayment_ErrorCode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_ErrorCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Error Details.
        /// </summary>
        /// <value>The field label customer order payment error description.</value>
        public static string FieldLabel_CustomerOrderPayment_ErrorDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_ErrorDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Finished At.
        /// </summary>
        /// <value>The field label customer order payment finished.</value>
        public static string FieldLabel_CustomerOrderPayment_Finished
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_Finished", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Invoice File Name.
        /// </summary>
        /// <value>The name of the field label customer order payment invoice file.</value>
        public static string FieldLabel_CustomerOrderPayment_InvoiceFileName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_InvoiceFileName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Error?.
        /// </summary>
        /// <value>The field label customer order payment is error.</value>
        public static string FieldLabel_CustomerOrderPayment_IsError
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_IsError", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label customer order payment last modified by user.</value>
        public static string FieldLabel_CustomerOrderPayment_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label customer order payment last modified date.</value>
        public static string FieldLabel_CustomerOrderPayment_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment Intention.
        /// </summary>
        /// <value>The field label customer order payment payment intent.</value>
        public static string FieldLabel_CustomerOrderPayment_PaymentIntent
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_PaymentIntent", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Notes.
        /// </summary>
        /// <value>The field label customer order payment payment notes.</value>
        public static string FieldLabel_CustomerOrderPayment_PaymentNotes
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_PaymentNotes", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment Option.
        /// </summary>
        /// <value>The field label customer order payment payment option.</value>
        public static string FieldLabel_CustomerOrderPayment_PaymentOption
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_PaymentOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment Status.
        /// </summary>
        /// <value>The field label customer order payment payment status.</value>
        public static string FieldLabel_CustomerOrderPayment_PaymentStatus
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_PaymentStatus", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Ref. Id.
        /// </summary>
        /// <value>The field label customer order payment reference identifier.</value>
        public static string FieldLabel_CustomerOrderPayment_ReferenceId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_ReferenceId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Started At.
        /// </summary>
        /// <value>The field label customer order payment started.</value>
        public static string FieldLabel_CustomerOrderPayment_Started
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_Started", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Paid.
        /// </summary>
        /// <value>The field label customer order payment total.</value>
        public static string FieldLabel_CustomerOrderPayment_Total
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerOrderPayment_Total", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Account Ref. Id.
        /// </summary>
        /// <value>The field label customer payment account reference identifier.</value>
        public static string FieldLabel_CustomerPayment_AccountReferenceId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerPayment_AccountReferenceId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label customer payment create date.</value>
        public static string FieldLabel_CustomerPayment_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerPayment_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label customer payment created by user.</value>
        public static string FieldLabel_CustomerPayment_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerPayment_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customer.
        /// </summary>
        /// <value>The field label customer payment customer.</value>
        public static string FieldLabel_CustomerPayment_Customer
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerPayment_Customer", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customer Id.
        /// </summary>
        /// <value>The field label customer payment customer identifier.</value>
        public static string FieldLabel_CustomerPayment_CustomerId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerPayment_CustomerId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label customer payment description.</value>
        public static string FieldLabel_CustomerPayment_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerPayment_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label customer payment description.</value>
        public static string FieldLabel_ProductCategory_ShowIfEmpty
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductCategory_ShowIfEmpty", resourceCulture);
            }
        }
        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label customer payment last modified by user.</value>
        public static string FieldLabel_CustomerPayment_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerPayment_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label customer payment last modified date.</value>
        public static string FieldLabel_CustomerPayment_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerPayment_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Used At.
        /// </summary>
        /// <value>The field label customer payment last used.</value>
        public static string FieldLabel_CustomerPayment_LastUsed
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerPayment_LastUsed", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label customer payment.</value>
        public static string FieldLabel_CustomerPayment_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerPayment_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment Option.
        /// </summary>
        /// <value>The field label customer payment payment option.</value>
        public static string FieldLabel_CustomerPayment_PaymentOption
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerPayment_PaymentOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment Option Id.
        /// </summary>
        /// <value>The field label customer payment payment option identifier.</value>
        public static string FieldLabel_CustomerPayment_PaymentOptionId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerPayment_PaymentOptionId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label customer payment short description.</value>
        public static string FieldLabel_CustomerPayment_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_CustomerPayment_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Date.
        /// </summary>
        /// <value>The field label date.</value>
        public static string FieldLabel_Date
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Date", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Allow to apply discounts with lower priority?.
        /// </summary>
        /// <value>The field label discount coupon allow lower priority.</value>
        public static string FieldLabel_DiscountCoupon_AllowLowerPriority
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_AllowLowerPriority", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Amount.
        /// </summary>
        /// <value>The field label discount coupon amount.</value>
        public static string FieldLabel_DiscountCoupon_Amount
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_Amount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Discount conditions.
        /// </summary>
        /// <value>The field label discount coupon apply criteria.</value>
        public static string FieldLabel_DiscountCoupon_ApplyCriteria
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_ApplyCriteria", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Buy X amount.
        /// </summary>
        /// <value>The field label discount coupon buy x amount.</value>
        public static string FieldLabel_DiscountCoupon_BuyXAmount
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_BuyXAmount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Code.
        /// </summary>
        /// <value>The field label discount coupon code.</value>
        public static string FieldLabel_DiscountCoupon_Code
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_Code", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label discount coupon create date.</value>
        public static string FieldLabel_DiscountCoupon_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label discount coupon created by user.</value>
        public static string FieldLabel_DiscountCoupon_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label discount coupon description.</value>
        public static string FieldLabel_DiscountCoupon_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Discount Type.
        /// </summary>
        /// <value>The type of the field label discount coupon discount.</value>
        public static string FieldLabel_DiscountCoupon_DiscountType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_DiscountType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled?.
        /// </summary>
        /// <value>The field label discount coupon enabled.</value>
        public static string FieldLabel_DiscountCoupon_Enabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_Enabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Extra Codes List.
        /// </summary>
        /// <value>The field label discount coupon extra codes.</value>
        public static string FieldLabel_DiscountCoupon_ExtraCodes
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_ExtraCodes", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Extra Codes Text.
        /// </summary>
        /// <value>The field label discount coupon extra codes text.</value>
        public static string FieldLabel_DiscountCoupon_ExtraCodesText
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_ExtraCodesText", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Get Y amount.
        /// </summary>
        /// <value>The field label discount coupon get y amount.</value>
        public static string FieldLabel_DiscountCoupon_GetYAmount
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_GetYAmount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Is default.
        /// </summary>
        /// <value>The field label discount coupon is default.</value>
        public static string FieldLabel_DiscountCoupon_IsDefault
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_IsDefault", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Percent?.
        /// </summary>
        /// <value>The field label discount coupon is percent.</value>
        public static string FieldLabel_DiscountCoupon_IsPercent
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_IsPercent", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label discount coupon last modified by user.</value>
        public static string FieldLabel_DiscountCoupon_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label discount coupon last modified date.</value>
        public static string FieldLabel_DiscountCoupon_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label discount coupon.</value>
        public static string FieldLabel_DiscountCoupon_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Priority.
        /// </summary>
        /// <value>The field label discount coupon priority.</value>
        public static string FieldLabel_DiscountCoupon_Priority
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_Priority", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Products Applied.
        /// </summary>
        /// <value>The field label discount coupon products appied.</value>
        public static string FieldLabel_DiscountCoupon_ProductsAppied
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_ProductsAppied", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label discount coupon short description.</value>
        public static string FieldLabel_DiscountCoupon_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Stores.
        /// </summary>
        /// <value>The field label discount coupon stores.</value>
        public static string FieldLabel_DiscountCoupon_Stores
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_Stores", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Valid From.
        /// </summary>
        /// <value>The field label discount coupon valid from.</value>
        public static string FieldLabel_DiscountCoupon_ValidFrom
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_ValidFrom", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Valid To.
        /// </summary>
        /// <value>The field label discount coupon valid to.</value>
        public static string FieldLabel_DiscountCoupon_ValidTo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_DiscountCoupon_ValidTo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Download.
        /// </summary>
        /// <value>The field label download.</value>
        public static string FieldLabel_Download
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Download", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Edit Details.
        /// </summary>
        /// <value>The field label edit details.</value>
        public static string FieldLabel_EditDetails
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EditDetails", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Edit gift messaging or engraving.
        /// </summary>
        /// <value>The field label edit gift messaging or engraving.</value>
        public static string FieldLabel_EditGiftMessagingOrEngraving
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_EditGiftMessagingOrEngraving", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File details.
        /// </summary>
        /// <value>The field label file details.</value>
        public static string FieldLabel_FileDetails
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_FileDetails", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File Information.
        /// </summary>
        /// <value>The field label file information.</value>
        public static string FieldLabel_FileInformation
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_FileInformation", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Custom Config. (JSON).
        /// </summary>
        /// <value>The field label general custom configuration json.</value>
        public static string FieldLabel_General_CustomConfigJson
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_General_CustomConfigJson", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attachments.
        /// </summary>
        /// <value>The field label generic attachments.</value>
        public static string FieldLabel_Generic_Attachments
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Generic_Attachments", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Goods Total.
        /// </summary>
        /// <value>The field label goods total.</value>
        public static string FieldLabel_GoodsTotal
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_GoodsTotal", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Invoice.
        /// </summary>
        /// <value>The field label invoice.</value>
        public static string FieldLabel_Invoice
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Invoice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Invoices.
        /// </summary>
        /// <value>The field label invoices.</value>
        public static string FieldLabel_Invoices
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Invoices", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Manage email subscriptions.
        /// </summary>
        /// <value>The field label manage email subscriptions.</value>
        public static string FieldLabel_ManageEmailSubscriptions
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ManageEmailSubscriptions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label manufacturer create date.</value>
        public static string FieldLabel_Manufacturer_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Manufacturer_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label manufacturer created by user.</value>
        public static string FieldLabel_Manufacturer_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Manufacturer_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label manufacturer description.</value>
        public static string FieldLabel_Manufacturer_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Manufacturer_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to File.
        /// </summary>
        /// <value>The field label manufacturer file.</value>
        public static string FieldLabel_Manufacturer_File
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Manufacturer_File", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label manufacturer last modified by user.</value>
        public static string FieldLabel_Manufacturer_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Manufacturer_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label manufacturer last modified date.</value>
        public static string FieldLabel_Manufacturer_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Manufacturer_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Logo image.
        /// </summary>
        /// <value>The field label manufacturer logo image.</value>
        public static string FieldLabel_Manufacturer_LogoImage
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Manufacturer_LogoImage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label manufacturer.</value>
        public static string FieldLabel_Manufacturer_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Manufacturer_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label manufacturer short description.</value>
        public static string FieldLabel_Manufacturer_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Manufacturer_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Slogan.
        /// </summary>
        /// <value>The field label manufacturer slogan.</value>
        public static string FieldLabel_Manufacturer_Slogan
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Manufacturer_Slogan", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Maximum 80 characters allowed.
        /// </summary>
        /// <value>The field label manufacturer slogan maximum characters.</value>
        public static string FieldLabel_Manufacturer_Slogan_MaxCharacters
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Manufacturer_Slogan_MaxCharacters", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Modify an order, track a shipment, and update your account info..
        /// </summary>
        /// <value>The field label modify order and update account.</value>
        public static string FieldLabel_ModifyOrderAndUpdateAccount
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ModifyOrderAndUpdateAccount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to N/A.
        /// </summary>
        /// <value>The field label na.</value>
        public static string FieldLabel_NA
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_NA", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Count.
        /// </summary>
        /// <value>The field label order item count.</value>
        public static string FieldLabel_OrderItem_Count
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_Count", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label order item create date.</value>
        public static string FieldLabel_OrderItem_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label order item created by user.</value>
        public static string FieldLabel_OrderItem_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Custom Data.
        /// </summary>
        /// <value>The field label order item custom data.</value>
        public static string FieldLabel_OrderItem_CustomData
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_CustomData", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customer Order.
        /// </summary>
        /// <value>The field label order item customer order.</value>
        public static string FieldLabel_OrderItem_CustomerOrder
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_CustomerOrder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customer Order Id.
        /// </summary>
        /// <value>The field label order item customer order identifier.</value>
        public static string FieldLabel_OrderItem_CustomerOrderId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_CustomerOrderId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label order item description.</value>
        public static string FieldLabel_OrderItem_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Discount Coupon.
        /// </summary>
        /// <value>The field label order item discount coupon.</value>
        public static string FieldLabel_OrderItem_DiscountCoupon
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_DiscountCoupon", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Discount Coupon Id.
        /// </summary>
        /// <value>The field label order item discount coupon identifier.</value>
        public static string FieldLabel_OrderItem_DiscountCouponId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_DiscountCouponId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Download URL.
        /// </summary>
        /// <value>The field label order item download URL.</value>
        public static string FieldLabel_OrderItem_DownloadUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_DownloadUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label order item last modified by user.</value>
        public static string FieldLabel_OrderItem_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label order item last modified date.</value>
        public static string FieldLabel_OrderItem_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label order item.</value>
        public static string FieldLabel_OrderItem_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Online URL.
        /// </summary>
        /// <value>The field label order item online product URL.</value>
        public static string FieldLabel_OrderItem_OnlineProductUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_OnlineProductUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Options.
        /// </summary>
        /// <value>The field label order item options data.</value>
        public static string FieldLabel_OrderItem_OptionsData
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_OptionsData", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Price.
        /// </summary>
        /// <value>The field label order item price.</value>
        public static string FieldLabel_OrderItem_Price
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_Price", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product.
        /// </summary>
        /// <value>The field label order item product.</value>
        public static string FieldLabel_OrderItem_Product
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_Product", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product Id.
        /// </summary>
        /// <value>The field label order item product identifier.</value>
        public static string FieldLabel_OrderItem_ProductId
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_ProductId", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label order item short description.</value>
        public static string FieldLabel_OrderItem_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subtotal.
        /// </summary>
        /// <value>The field label order item subtotal.</value>
        public static string FieldLabel_OrderItem_Subtotal
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_Subtotal", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Discounts.
        /// </summary>
        /// <value>The field label order item total discounts.</value>
        public static string FieldLabel_OrderItem_TotalDiscounts
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_TotalDiscounts", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Tax.
        /// </summary>
        /// <value>The field label order item total tax.</value>
        public static string FieldLabel_OrderItem_TotalTax
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderItem_TotalTax", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Order No..
        /// </summary>
        /// <value>The field label order no.</value>
        public static string FieldLabel_OrderNo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_OrderNo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Orders.
        /// </summary>
        /// <value>The field label orders.</value>
        public static string FieldLabel_Orders
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Orders", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Pay.
        /// </summary>
        /// <value>The field label pay.</value>
        public static string FieldLabel_Pay
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Pay", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Pay for Your Order.
        /// </summary>
        /// <value>The field label pay for your order.</value>
        public static string FieldLabel_PayForYourOrder
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PayForYourOrder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Assembly.
        /// </summary>
        /// <value>The name of the field label payment option asssembly.</value>
        public static string FieldLabel_PaymentOption_AsssemblyName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentOption_AsssemblyName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Class.
        /// </summary>
        /// <value>The name of the field label payment option class.</value>
        public static string FieldLabel_PaymentOption_ClassName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentOption_ClassName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label payment option create date.</value>
        public static string FieldLabel_PaymentOption_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentOption_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label payment option created by user.</value>
        public static string FieldLabel_PaymentOption_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentOption_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label payment option description.</value>
        public static string FieldLabel_PaymentOption_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentOption_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled?.
        /// </summary>
        /// <value>The field label payment option enabled.</value>
        public static string FieldLabel_PaymentOption_Enabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentOption_Enabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label payment option last modified by user.</value>
        public static string FieldLabel_PaymentOption_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentOption_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label payment option last modified date.</value>
        public static string FieldLabel_PaymentOption_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentOption_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label payment option.</value>
        public static string FieldLabel_PaymentOption_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentOption_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Container CSS.
        /// </summary>
        /// <value>The field label payment option payment container CSS.</value>
        public static string FieldLabel_PaymentOption_PaymentContainerCss
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentOption_PaymentContainerCss", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Assosiated Shipping Options.
        /// </summary>
        /// <value>The field label payment option shipping options.</value>
        public static string FieldLabel_PaymentOption_ShippingOptions
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentOption_ShippingOptions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label payment option short description.</value>
        public static string FieldLabel_PaymentOption_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentOption_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Stores.
        /// </summary>
        /// <value>The field label payment option stores.</value>
        public static string FieldLabel_PaymentOption_Stores
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentOption_Stores", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payments &amp; Financing.
        /// </summary>
        /// <value>The field label payments and financing.</value>
        public static string FieldLabel_PaymentsAndFinancing
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PaymentsAndFinancing", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Pre-sign for a delivery.
        /// </summary>
        /// <value>The field label pre sign for delivery.</value>
        public static string FieldLabel_PreSignForDelivery
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PreSignForDelivery", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Preview.
        /// </summary>
        /// <value>The field label preview.</value>
        public static string FieldLabel_Preview
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Preview", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Price inc. VAT.
        /// </summary>
        /// <value>The field label price inc vat.</value>
        public static string FieldLabel_PriceIncVat
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PriceIncVat", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Print an invoice.
        /// </summary>
        /// <value>The field label print invoice.</value>
        public static string FieldLabel_PrintInvoice
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_PrintInvoice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Allow to Renew?.
        /// </summary>
        /// <value>The field label product allow to renew.</value>
        public static string FieldLabel_Product_AllowToRenew
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_AllowToRenew", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Attachments.
        /// </summary>
        /// <value>The field label product attachments.</value>
        public static string FieldLabel_Product_Attachments
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Attachments", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Available Items.
        /// </summary>
        /// <value>The field label product available items.</value>
        public static string FieldLabel_Product_AvailableItems
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_AvailableItems", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product URL.
        /// </summary>
        /// <value>The field label product base online URL.</value>
        public static string FieldLabel_Product_BaseOnlineUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_BaseOnlineUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label product create date.</value>
        public static string FieldLabel_Product_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label product created by user.</value>
        public static string FieldLabel_Product_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Custom Data.
        /// </summary>
        /// <value>The field label product custom data.</value>
        public static string FieldLabel_Product_CustomData
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_CustomData", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Custom Details Url.
        /// </summary>
        /// <value>The field label product custom details URL.</value>
        public static string FieldLabel_Product_CustomDetailsUrl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_CustomDetailsUrl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Depth.
        /// </summary>
        /// <value>The field label product depth.</value>
        public static string FieldLabel_Product_Depth
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Depth", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label product description.</value>
        public static string FieldLabel_Product_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Discount.
        /// </summary>
        /// <value>The field label product discount.</value>
        public static string FieldLabel_Product_Discount
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Discount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Discounts.
        /// </summary>
        /// <value>The field label product discounts.</value>
        public static string FieldLabel_Product_Discounts
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Discounts", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled?.
        /// </summary>
        /// <value>The field label product enabled.</value>
        public static string FieldLabel_Product_Enabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Enabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Grid.
        /// </summary>
        /// <value>The field label product grid.</value>
        public static string FieldLabel_Product_Grid
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Grid", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Height.
        /// </summary>
        /// <value>The height of the field label product.</value>
        public static string FieldLabel_Product_Height
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Height", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Image.
        /// </summary>
        /// <value>The field label product image path.</value>
        public static string FieldLabel_Product_ImagePath
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_ImagePath", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to In Store From.
        /// </summary>
        /// <value>The field label product in store from.</value>
        public static string FieldLabel_Product_InStoreFrom
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_InStoreFrom", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Internal Status.
        /// </summary>
        /// <value>The field label product internal status.</value>
        public static string FieldLabel_Product_InternalStatus
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_InternalStatus", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to For download?.
        /// </summary>
        /// <value>The field label product is downloadable.</value>
        public static string FieldLabel_Product_IsDownloadable
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_IsDownloadable", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Featured?.
        /// </summary>
        /// <value>The field label product is featured.</value>
        public static string FieldLabel_Product_IsFeatured
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_IsFeatured", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Online?.
        /// </summary>
        /// <value>The field label product is online.</value>
        public static string FieldLabel_Product_IsOnline
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_IsOnline", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Trial?.
        /// </summary>
        /// <value>The field label product is trial.</value>
        public static string FieldLabel_Product_IsTrial
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_IsTrial", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label product last modified by user.</value>
        public static string FieldLabel_Product_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label product last modified date.</value>
        public static string FieldLabel_Product_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to List.
        /// </summary>
        /// <value>The field label product list.</value>
        public static string FieldLabel_Product_List
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_List", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to List Price.
        /// </summary>
        /// <value>The field label product list price.</value>
        public static string FieldLabel_Product_ListPrice
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_ListPrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Manufacturer.
        /// </summary>
        /// <value>The field label product manufacturer.</value>
        public static string FieldLabel_Product_Manufacturer
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Manufacturer", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Max. Downloads.
        /// </summary>
        /// <value>The field label product maximum downloads.</value>
        public static string FieldLabel_Product_MaxDownloads
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_MaxDownloads", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Max. Price.
        /// </summary>
        /// <value>The field label product maximum price.</value>
        public static string FieldLabel_Product_MaxPrice
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_MaxPrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Min. Price.
        /// </summary>
        /// <value>The field label product minimum price.</value>
        public static string FieldLabel_Product_MinPrice
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_MinPrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to MSRP.
        /// </summary>
        /// <value>The field label product MSRP price.</value>
        public static string FieldLabel_Product_MsrpPrice
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_MsrpPrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label product.</value>
        public static string FieldLabel_Product_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping?.
        /// </summary>
        /// <value>The field label product needs shipping.</value>
        public static string FieldLabel_Product_NeedsShipping
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_NeedsShipping", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to New Arrival.
        /// </summary>
        /// <value>The field label product new arrival.</value>
        public static string FieldLabel_Product_NewArrival
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_NewArrival", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Newest.
        /// </summary>
        /// <value>The field label product newest.</value>
        public static string FieldLabel_Product_Newest
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Newest", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Options Available.
        /// </summary>
        /// <value>The field label product options.</value>
        public static string FieldLabel_Product_Options
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Options", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Parent Product.
        /// </summary>
        /// <value>The field label product parent product.</value>
        public static string FieldLabel_Product_ParentProduct
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_ParentProduct", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Popular.
        /// </summary>
        /// <value>The field label product popular.</value>
        public static string FieldLabel_Product_Popular
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Popular", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Price.
        /// </summary>
        /// <value>The field label product price.</value>
        public static string FieldLabel_Product_Price
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Price", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Price low to high.
        /// </summary>
        /// <value>The field label product price asc.</value>
        public static string FieldLabel_Product_PriceAsc
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_PriceAsc", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Price high to low.
        /// </summary>
        /// <value>The field label product price desc.</value>
        public static string FieldLabel_Product_PriceDesc
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_PriceDesc", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Category.
        /// </summary>
        /// <value>The field label product product category.</value>
        public static string FieldLabel_Product_ProductCategory
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_ProductCategory", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product name.
        /// </summary>
        /// <value>The name of the field label product product.</value>
        public static string FieldLabel_Product_ProductName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_ProductName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product Type.
        /// </summary>
        /// <value>The type of the field label product product.</value>
        public static string FieldLabel_Product_ProductType
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_ProductType", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Status.
        /// </summary>
        /// <value>The field label product public status.</value>
        public static string FieldLabel_Product_PublicStatus
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_PublicStatus", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Publish From Date.
        /// </summary>
        /// <value>The field label product publish from.</value>
        public static string FieldLabel_Product_PublishFrom
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_PublishFrom", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Publish To Date.
        /// </summary>
        /// <value>The field label product publish to.</value>
        public static string FieldLabel_Product_PublishTo
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_PublishTo", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Quick View.
        /// </summary>
        /// <value>The field label product quick view.</value>
        public static string FieldLabel_Product_QuickView
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_QuickView", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Recommended.
        /// </summary>
        /// <value>The field label product recommended.</value>
        public static string FieldLabel_Product_Recommended
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Recommended", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Related Products.
        /// </summary>
        /// <value>The field label product related products.</value>
        public static string FieldLabel_Product_RelatedProducts
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_RelatedProducts", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Reorder At Date.
        /// </summary>
        /// <value>The field label product reorder at.</value>
        public static string FieldLabel_Product_ReorderAt
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_ReorderAt", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label product short description.</value>
        public static string FieldLabel_Product_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Size Measure.
        /// </summary>
        /// <value>The field label product size measure.</value>
        public static string FieldLabel_Product_SizeMeasure
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_SizeMeasure", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to SKU.
        /// </summary>
        /// <value>The field label product sku.</value>
        public static string FieldLabel_Product_SKU
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_SKU", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Source Price.
        /// </summary>
        /// <value>The field label product source price.</value>
        public static string FieldLabel_Product_SourcePrice
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_SourcePrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Supplier.
        /// </summary>
        /// <value>The field label product supplier.</value>
        public static string FieldLabel_Product_Supplier
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Supplier", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Track Inventory?.
        /// </summary>
        /// <value>The field label product track inventory.</value>
        public static string FieldLabel_Product_TrackInventory
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_TrackInventory", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Unique ID.
        /// </summary>
        /// <value>The field label product uid.</value>
        public static string FieldLabel_Product_UID
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_UID", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Weight.
        /// </summary>
        /// <value>The field label product weight.</value>
        public static string FieldLabel_Product_Weight
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Weight", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Weight Measure.
        /// </summary>
        /// <value>The field label product weight measure.</value>
        public static string FieldLabel_Product_WeightMeasure
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_WeightMeasure", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Width.
        /// </summary>
        /// <value>The width of the field label product.</value>
        public static string FieldLabel_Product_Width
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Product_Width", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label product category create date.</value>
        public static string FieldLabel_ProductCategory_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductCategory_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label product category created by user.</value>
        public static string FieldLabel_ProductCategory_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductCategory_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label product category description.</value>
        public static string FieldLabel_ProductCategory_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductCategory_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label product category last modified by user.</value>
        public static string FieldLabel_ProductCategory_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductCategory_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label product category last modified date.</value>
        public static string FieldLabel_ProductCategory_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductCategory_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label product category.</value>
        public static string FieldLabel_ProductCategory_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductCategory_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Order #.
        /// </summary>
        /// <value>The field label product category order.</value>
        public static string FieldLabel_ProductCategory_Order
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductCategory_Order", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Parent Category.
        /// </summary>
        /// <value>The field label product category parent category.</value>
        public static string FieldLabel_ProductCategory_ParentCategory
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductCategory_ParentCategory", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label product category short description.</value>
        public static string FieldLabel_ProductCategory_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductCategory_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Stores.
        /// </summary>
        /// <value>The field label product category stores.</value>
        public static string FieldLabel_ProductCategory_Stores
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductCategory_Stores", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label product option create date.</value>
        public static string FieldLabel_ProductOption_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOption_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label product option created by user.</value>
        public static string FieldLabel_ProductOption_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOption_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label product option description.</value>
        public static string FieldLabel_ProductOption_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOption_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled?.
        /// </summary>
        /// <value>The field label product option enabled.</value>
        public static string FieldLabel_ProductOption_Enabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOption_Enabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label product option last modified by user.</value>
        public static string FieldLabel_ProductOption_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOption_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label product option last modified date.</value>
        public static string FieldLabel_ProductOption_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOption_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label product option.</value>
        public static string FieldLabel_ProductOption_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOption_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Products.
        /// </summary>
        /// <value>The field label product option products.</value>
        public static string FieldLabel_ProductOption_Products
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOption_Products", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label product option short description.</value>
        public static string FieldLabel_ProductOption_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOption_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Type.
        /// </summary>
        /// <value>The type of the field label product option.</value>
        public static string FieldLabel_ProductOption_Type
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOption_Type", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to User Control.
        /// </summary>
        /// <value>The field label product option user control.</value>
        public static string FieldLabel_ProductOption_UserControl
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOption_UserControl", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label product option item create date.</value>
        public static string FieldLabel_ProductOptionItem_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOptionItem_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label product option item created by user.</value>
        public static string FieldLabel_ProductOptionItem_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOptionItem_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label product option item description.</value>
        public static string FieldLabel_ProductOptionItem_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOptionItem_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label product option item last modified by user.</value>
        public static string FieldLabel_ProductOptionItem_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOptionItem_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label product option item last modified date.</value>
        public static string FieldLabel_ProductOptionItem_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOptionItem_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label product option item.</value>
        public static string FieldLabel_ProductOptionItem_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOptionItem_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Option.
        /// </summary>
        /// <value>The field label product option item option.</value>
        public static string FieldLabel_ProductOptionItem_Option
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOptionItem_Option", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Price+.
        /// </summary>
        /// <value>The field label product option item price added.</value>
        public static string FieldLabel_ProductOptionItem_PriceAdded
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOptionItem_PriceAdded", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product.
        /// </summary>
        /// <value>The field label product option item product.</value>
        public static string FieldLabel_ProductOptionItem_Product
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOptionItem_Product", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label product option item short description.</value>
        public static string FieldLabel_ProductOptionItem_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ProductOptionItem_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Qty.
        /// </summary>
        /// <value>The field label qty.</value>
        public static string FieldLabel_Qty
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Qty", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Recent Orders.
        /// </summary>
        /// <value>The field label recent orders.</value>
        public static string FieldLabel_RecentOrders
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_RecentOrders", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label related product create date.</value>
        public static string FieldLabel_RelatedProduct_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_RelatedProduct_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label related product created by user.</value>
        public static string FieldLabel_RelatedProduct_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_RelatedProduct_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label related product last modified by user.</value>
        public static string FieldLabel_RelatedProduct_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_RelatedProduct_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label related product last modified date.</value>
        public static string FieldLabel_RelatedProduct_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_RelatedProduct_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Return items.
        /// </summary>
        /// <value>The field label return items.</value>
        public static string FieldLabel_ReturnItems
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ReturnItems", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Send to customer.
        /// </summary>
        /// <value>The field label send to customer.</value>
        public static string FieldLabel_SendToCustomer
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_SendToCustomer", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label shipping carrier create date.</value>
        public static string FieldLabel_ShippingCarrier_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingCarrier_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label shipping carrier created by user.</value>
        public static string FieldLabel_ShippingCarrier_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingCarrier_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label shipping carrier description.</value>
        public static string FieldLabel_ShippingCarrier_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingCarrier_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled?.
        /// </summary>
        /// <value>The field label shipping carrier enabled.</value>
        public static string FieldLabel_ShippingCarrier_Enabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingCarrier_Enabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label shipping carrier last modified by user.</value>
        public static string FieldLabel_ShippingCarrier_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingCarrier_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label shipping carrier last modified date.</value>
        public static string FieldLabel_ShippingCarrier_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingCarrier_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label shipping carrier.</value>
        public static string FieldLabel_ShippingCarrier_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingCarrier_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Option Code.
        /// </summary>
        /// <value>The field label shipping carrier option code.</value>
        public static string FieldLabel_ShippingCarrier_OptionCode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingCarrier_OptionCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Options.
        /// </summary>
        /// <value>The field label shipping carrier shipping options.</value>
        public static string FieldLabel_ShippingCarrier_ShippingOptions
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingCarrier_ShippingOptions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Provider Assembly.
        /// </summary>
        /// <value>The field label shipping carrier shipping provider assembly.</value>
        public static string FieldLabel_ShippingCarrier_ShippingProviderAssembly
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingCarrier_ShippingProviderAssembly", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Provider Class.
        /// </summary>
        /// <value>The field label shipping carrier shipping provider class.</value>
        public static string FieldLabel_ShippingCarrier_ShippingProviderClass
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingCarrier_ShippingProviderClass", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label shipping carrier short description.</value>
        public static string FieldLabel_ShippingCarrier_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingCarrier_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Teaser Image.
        /// </summary>
        /// <value>The field label shipping carrier teaser image.</value>
        public static string FieldLabel_ShippingCarrier_TeaserImage
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingCarrier_TeaserImage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment Options.
        /// </summary>
        /// <value>The field label shipping option allowed payment option.</value>
        public static string FieldLabel_ShippingOption_AllowedPaymentOption
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_AllowedPaymentOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label shipping option create date.</value>
        public static string FieldLabel_ShippingOption_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label shipping option created by user.</value>
        public static string FieldLabel_ShippingOption_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label shipping option description.</value>
        public static string FieldLabel_ShippingOption_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Enabled?.
        /// </summary>
        /// <value>The field label shipping option enabled.</value>
        public static string FieldLabel_ShippingOption_Enabled
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_Enabled", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label shipping option last modified by user.</value>
        public static string FieldLabel_ShippingOption_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label shipping option last modified date.</value>
        public static string FieldLabel_ShippingOption_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Max. Shipping Price.
        /// </summary>
        /// <value>The field label shipping option maximum price.</value>
        public static string FieldLabel_ShippingOption_MaxPrice
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_MaxPrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label shipping option.</value>
        public static string FieldLabel_ShippingOption_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Option Code.
        /// </summary>
        /// <value>The field label shipping option option code.</value>
        public static string FieldLabel_ShippingOption_OptionCode
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_OptionCode", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Carrier.
        /// </summary>
        /// <value>The field label shipping option shipping carrier.</value>
        public static string FieldLabel_ShippingOption_ShippingCarrier
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_ShippingCarrier", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label shipping option short description.</value>
        public static string FieldLabel_ShippingOption_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Stores.
        /// </summary>
        /// <value>The field label shipping option stores.</value>
        public static string FieldLabel_ShippingOption_Stores
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_Stores", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Tease Image.
        /// </summary>
        /// <value>The field label shipping option teaser image.</value>
        public static string FieldLabel_ShippingOption_TeaserImage
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOption_TeaserImage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Carrier.
        /// </summary>
        /// <value>The field label shipping options carrier.</value>
        public static string FieldLabel_ShippingOptions_Carrier
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOptions_Carrier", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Information.
        /// </summary>
        /// <value>The field label shipping options information.</value>
        public static string FieldLabel_ShippingOptions_Information
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOptions_Information", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Method.
        /// </summary>
        /// <value>The field label shipping options method.</value>
        public static string FieldLabel_ShippingOptions_Method
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOptions_Method", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Price.
        /// </summary>
        /// <value>The field label shipping options price.</value>
        public static string FieldLabel_ShippingOptions_Price
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShippingOptions_Price", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shopping Basket.
        /// </summary>
        /// <value>The field label shopping basket.</value>
        public static string FieldLabel_ShoppingBasket
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingBasket", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Additional Information.
        /// </summary>
        /// <value>The field label shopping cart additional information.</value>
        public static string FieldLabel_ShoppingCart_AdditionalInformation
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_AdditionalInformation", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to apply coupon.
        /// </summary>
        /// <value>The field label shopping cart apply coupon.</value>
        public static string FieldLabel_ShoppingCart_ApplyCoupon
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ApplyCoupon", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Back.
        /// </summary>
        /// <value>The field label shopping cart back.</value>
        public static string FieldLabel_ShoppingCart_Back
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_Back", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Billing Address.
        /// </summary>
        /// <value>The field label shopping cart billing address.</value>
        public static string FieldLabel_ShoppingCart_BillingAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_BillingAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Billing information.
        /// </summary>
        /// <value>The field label shopping cart billing information.</value>
        public static string FieldLabel_ShoppingCart_BillingInformation
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_BillingInformation", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Checkout.
        /// </summary>
        /// <value>The field label shopping cart checkout.</value>
        public static string FieldLabel_ShoppingCart_Checkout
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_Checkout", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose your Delivery method.
        /// </summary>
        /// <value>The field label shopping cart choose delivery method.</value>
        public static string FieldLabel_ShoppingCart_ChooseDeliveryMethod
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ChooseDeliveryMethod", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose a payment method.
        /// </summary>
        /// <value>The field label shopping cart choose payment method.</value>
        public static string FieldLabel_ShoppingCart_ChoosePaymentMethod
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ChoosePaymentMethod", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Confirm.
        /// </summary>
        /// <value>The field label shopping cart confirm.</value>
        public static string FieldLabel_ShoppingCart_Confirm
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_Confirm", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Continue.
        /// </summary>
        /// <value>The field label shopping cart continue.</value>
        public static string FieldLabel_ShoppingCart_Continue
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_Continue", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Checkout as Unregistered.
        /// </summary>
        /// <value>The field label shopping cart continue as unregistered.</value>
        public static string FieldLabel_ShoppingCart_ContinueAsUnregistered
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ContinueAsUnregistered", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Continue Shopping.
        /// </summary>
        /// <value>The field label shopping cart continue shopping.</value>
        public static string FieldLabel_ShoppingCart_ContinueShopping
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ContinueShopping", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Coupon.
        /// </summary>
        /// <value>The field label shopping cart coupon.</value>
        public static string FieldLabel_ShoppingCart_Coupon
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_Coupon", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label shopping cart create date.</value>
        public static string FieldLabel_ShoppingCart_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Creayed By.
        /// </summary>
        /// <value>The name of the field label shopping cart created by user.</value>
        public static string FieldLabel_ShoppingCart_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Currency.
        /// </summary>
        /// <value>The field label shopping cart currency.</value>
        public static string FieldLabel_ShoppingCart_Currency
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_Currency", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Custom Data.
        /// </summary>
        /// <value>The field label shopping cart custom data.</value>
        public static string FieldLabel_ShoppingCart_CustomData
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_CustomData", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Delivery estimates below include item preparation and shipping time.
        /// </summary>
        /// <value>The field label shopping cart delivery estimates below include.</value>
        public static string FieldLabel_ShoppingCart_DeliveryEstimatesBelowInclude
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_DeliveryEstimatesBelowInclude", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Discount Coupon.
        /// </summary>
        /// <value>The field label shopping cart dscount coupon.</value>
        public static string FieldLabel_ShoppingCart_DscountCoupon
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_DscountCoupon", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to I agree to the .
        /// </summary>
        /// <value>The field label shopping cart i agree to the.</value>
        public static string FieldLabel_ShoppingCart_IAgreeToThe
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_IAgreeToThe", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label shopping cart last modified by user.</value>
        public static string FieldLabel_ShoppingCart_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label shopping cart last modified date.</value>
        public static string FieldLabel_ShoppingCart_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Notes.
        /// </summary>
        /// <value>The field label shopping cart notes.</value>
        public static string FieldLabel_ShoppingCart_Notes
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_Notes", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to 1 to max order.
        /// </summary>
        /// <value>The field label shopping cart one to maximum order.</value>
        public static string FieldLabel_ShoppingCart_OneToMaxOrder
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_OneToMaxOrder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Order Details.
        /// </summary>
        /// <value>The field label shopping cart order details.</value>
        public static string FieldLabel_ShoppingCart_OrderDetails
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_OrderDetails", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Order Review.
        /// </summary>
        /// <value>The field label shopping cart order review.</value>
        public static string FieldLabel_ShoppingCart_OrderReview
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_OrderReview", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment By.
        /// </summary>
        /// <value>The field label shopping cart payment by.</value>
        public static string FieldLabel_ShoppingCart_PaymentBy
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_PaymentBy", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment Method.
        /// </summary>
        /// <value>The field label shopping cart payment method.</value>
        public static string FieldLabel_ShoppingCart_PaymentMethod
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_PaymentMethod", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment Option.
        /// </summary>
        /// <value>The field label shopping cart payment option.</value>
        public static string FieldLabel_ShoppingCart_PaymentOption
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_PaymentOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Address.
        /// </summary>
        /// <value>The field label shopping cart shipping address.</value>
        public static string FieldLabel_ShoppingCart_ShippingAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ShippingAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Same as billing Information.
        /// </summary>
        /// <value>The field label shopping cart shipping as billing.</value>
        public static string FieldLabel_ShoppingCart_ShippingAsBilling
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ShippingAsBilling", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Cost.
        /// </summary>
        /// <value>The field label shopping cart shipping cost.</value>
        public static string FieldLabel_ShoppingCart_ShippingCost
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ShippingCost", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping information.
        /// </summary>
        /// <value>The field label shopping cart shipping information.</value>
        public static string FieldLabel_ShoppingCart_ShippingInformation
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ShippingInformation", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Method.
        /// </summary>
        /// <value>The field label shopping cart shipping method.</value>
        public static string FieldLabel_ShoppingCart_ShippingMethod
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ShippingMethod", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Option.
        /// </summary>
        /// <value>The field label shopping cart shipping option.</value>
        public static string FieldLabel_ShoppingCart_ShippingOption
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ShippingOption", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping &amp; Payment.
        /// </summary>
        /// <value>The field label shopping cart shipping payment.</value>
        public static string FieldLabel_ShoppingCart_ShippingPayment
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ShippingPayment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping Policy.
        /// </summary>
        /// <value>The field label shopping cart shipping policy.</value>
        public static string FieldLabel_ShoppingCart_ShippingPolicy
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ShippingPolicy", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Products.
        /// </summary>
        /// <value>The field label shopping cart shopping cart products.</value>
        public static string FieldLabel_ShoppingCart_ShoppingCartProducts
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_ShoppingCartProducts", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Signature may be required for delivery.
        /// </summary>
        /// <value>The field label shopping cart signature may be required for delivery.</value>
        public static string FieldLabel_ShoppingCart_SignatureMayBeRequiredForDelivery
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_SignatureMayBeRequiredForDelivery", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subtotal.
        /// </summary>
        /// <value>The field label shopping cart subtotal.</value>
        public static string FieldLabel_ShoppingCart_Subtotal
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_Subtotal", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Tax.
        /// </summary>
        /// <value>The field label shopping cart tax total.</value>
        public static string FieldLabel_ShoppingCart_TaxTotal
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_TaxTotal", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Terms and Conditions.
        /// </summary>
        /// <value>The field label shopping cart terms and conditions.</value>
        public static string FieldLabel_ShoppingCart_TermsAndConditions
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_TermsAndConditions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total.
        /// </summary>
        /// <value>The field label shopping cart total.</value>
        public static string FieldLabel_ShoppingCart_Total
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_Total", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Discounts.
        /// </summary>
        /// <value>The field label shopping cart total discounts.</value>
        public static string FieldLabel_ShoppingCart_TotalDiscounts
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_TotalDiscounts", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total weight.
        /// </summary>
        /// <value>The field label shopping cart total weight.</value>
        public static string FieldLabel_ShoppingCart_TotalWeight
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_TotalWeight", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to update cart.
        /// </summary>
        /// <value>The field label shopping cart update coupon.</value>
        public static string FieldLabel_ShoppingCart_UpdateCoupon
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_UpdateCoupon", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to User.
        /// </summary>
        /// <value>The field label shopping cart user.</value>
        public static string FieldLabel_ShoppingCart_User
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_User", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to We do not ship directly to APO/FPO addresses..
        /// </summary>
        /// <value>The field label shopping cart we do not ship directly.</value>
        public static string FieldLabel_ShoppingCart_WeDoNotShipDirectly
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_WeDoNotShipDirectly", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to We do not ship to P.O. boxes.
        /// </summary>
        /// <value>The field label shopping cart we do not ship to po boxes.</value>
        public static string FieldLabel_ShoppingCart_WeDoNotShipToPOBoxes
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCart_WeDoNotShipToPOBoxes", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Discount Coupon.
        /// </summary>
        /// <value>The field label shopping cart discount coupon discount coupon.</value>
        public static string FieldLabel_ShoppingCartDiscountCoupon_DiscountCoupon
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartDiscountCoupon_DiscountCoupon", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Count.
        /// </summary>
        /// <value>The field label shopping cart product count.</value>
        public static string FieldLabel_ShoppingCartProduct_Count
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_Count", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Coupon.
        /// </summary>
        /// <value>The field label shopping cart product coupon.</value>
        public static string FieldLabel_ShoppingCartProduct_Coupon
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_Coupon", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label shopping cart product create date.</value>
        public static string FieldLabel_ShoppingCartProduct_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label shopping cart product created by user.</value>
        public static string FieldLabel_ShoppingCartProduct_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Custom Data.
        /// </summary>
        /// <value>The field label shopping cart product custom data.</value>
        public static string FieldLabel_ShoppingCartProduct_CustomData
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_CustomData", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label shopping cart product last modified by user.</value>
        public static string FieldLabel_ShoppingCartProduct_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label shopping cart product last modified date.</value>
        public static string FieldLabel_ShoppingCartProduct_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Options Price.
        /// </summary>
        /// <value>The field label shopping cart product options added price.</value>
        public static string FieldLabel_ShoppingCartProduct_OptionsAddedPrice
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_OptionsAddedPrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Options.
        /// </summary>
        /// <value>The field label shopping cart product options data.</value>
        public static string FieldLabel_ShoppingCartProduct_OptionsData
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_OptionsData", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Price.
        /// </summary>
        /// <value>The field label shopping cart product price.</value>
        public static string FieldLabel_ShoppingCartProduct_Price
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_Price", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product.
        /// </summary>
        /// <value>The field label shopping cart product product.</value>
        public static string FieldLabel_ShoppingCartProduct_Product
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_Product", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shopping Cart.
        /// </summary>
        /// <value>The field label shopping cart product shopping cart.</value>
        public static string FieldLabel_ShoppingCartProduct_ShoppingCart
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_ShoppingCart", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Subtotal.
        /// </summary>
        /// <value>The field label shopping cart product subtotal.</value>
        public static string FieldLabel_ShoppingCartProduct_Subtotal
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_Subtotal", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Discounts.
        /// </summary>
        /// <value>The field label shopping cart product total discount.</value>
        public static string FieldLabel_ShoppingCartProduct_TotalDiscount
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ShoppingCartProduct_TotalDiscount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Specialists.
        /// </summary>
        /// <value>The field label specialists.</value>
        public static string FieldLabel_Specialists
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Specialists", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Admin user.
        /// </summary>
        /// <value>The field label store admin user.</value>
        public static string FieldLabel_Store_AdminUser
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_AdminUser", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Billing address.
        /// </summary>
        /// <value>The field label store billing address.</value>
        public static string FieldLabel_Store_BillingAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_BillingAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Discount coupons.
        /// </summary>
        /// <value>The field label store discount coupons.</value>
        public static string FieldLabel_Store_DiscountCoupons
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_DiscountCoupons", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Invoice Template.
        /// </summary>
        /// <value>The field label store invoice template.</value>
        public static string FieldLabel_Store_InvoiceTemplate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_InvoiceTemplate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Is unregistered allowed.
        /// </summary>
        /// <value>The field label store is unregistered checkout allowed.</value>
        public static string FieldLabel_Store_IsUnregisteredCheckoutAllowed
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_IsUnregisteredCheckoutAllowed", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Organization.
        /// </summary>
        /// <value>The field label store organization.</value>
        public static string FieldLabel_Store_Organization
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_Organization", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment options.
        /// </summary>
        /// <value>The field label store payment options.</value>
        public static string FieldLabel_Store_PaymentOptions
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_PaymentOptions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product categories.
        /// </summary>
        /// <value>The field label store product categories.</value>
        public static string FieldLabel_Store_ProductCategories
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_ProductCategories", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Quick shopping cart?.
        /// </summary>
        /// <value>The field label store quick shopping cart.</value>
        public static string FieldLabel_Store_QuickShoppingCart
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_QuickShoppingCart", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping address.
        /// </summary>
        /// <value>The field label store shipping address.</value>
        public static string FieldLabel_Store_ShippingAddress
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_ShippingAddress", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping options.
        /// </summary>
        /// <value>The field label store shipping options.</value>
        public static string FieldLabel_Store_ShippingOptions
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_ShippingOptions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Store discount coupons.
        /// </summary>
        /// <value>The field label store store discount coupons.</value>
        public static string FieldLabel_Store_StoreDiscountCoupons
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_StoreDiscountCoupons", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment options.
        /// </summary>
        /// <value>The field label store store payment options.</value>
        public static string FieldLabel_Store_StorePaymentOptions
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_StorePaymentOptions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Store product categories.
        /// </summary>
        /// <value>The field label store store product categories.</value>
        public static string FieldLabel_Store_StoreProductCategories
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_StoreProductCategories", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shipping options.
        /// </summary>
        /// <value>The field label store store shipping options.</value>
        public static string FieldLabel_Store_StoreShippingOptions
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Store_StoreShippingOptions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created At.
        /// </summary>
        /// <value>The field label supplier create date.</value>
        public static string FieldLabel_Supplier_CreateDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Supplier_CreateDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Created By.
        /// </summary>
        /// <value>The name of the field label supplier created by user.</value>
        public static string FieldLabel_Supplier_CreatedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Supplier_CreatedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Description.
        /// </summary>
        /// <value>The field label supplier description.</value>
        public static string FieldLabel_Supplier_Description
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Supplier_Description", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified By.
        /// </summary>
        /// <value>The name of the field label supplier last modified by user.</value>
        public static string FieldLabel_Supplier_LastModifiedByUserName
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Supplier_LastModifiedByUserName", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Last Modified At.
        /// </summary>
        /// <value>The field label supplier last modified date.</value>
        public static string FieldLabel_Supplier_LastModifiedDate
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Supplier_LastModifiedDate", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Name.
        /// </summary>
        /// <value>The name of the field label supplier.</value>
        public static string FieldLabel_Supplier_Name
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Supplier_Name", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Short Description.
        /// </summary>
        /// <value>The field label supplier short description.</value>
        public static string FieldLabel_Supplier_ShortDescription
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_Supplier_ShortDescription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Total Inc. Vat.
        /// </summary>
        /// <value>The field label total inc vat.</value>
        public static string FieldLabel_TotalIncVat
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_TotalIncVat", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Track a shipment.
        /// </summary>
        /// <value>The field label track shipment.</value>
        public static string FieldLabel_TrackShipment
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_TrackShipment", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Update your email address and password.
        /// </summary>
        /// <value>The field label update your email address and password.</value>
        public static string FieldLabel_UpdateYourEmailAddressAndPassword
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_UpdateYourEmailAddressAndPassword", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View.
        /// </summary>
        /// <value>The field label view.</value>
        public static string FieldLabel_View
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_View", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View All Orders.
        /// </summary>
        /// <value>The field label view all orders.</value>
        public static string FieldLabel_ViewAllOrders
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ViewAllOrders", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View order history.
        /// </summary>
        /// <value>The field label view order history.</value>
        public static string FieldLabel_ViewOrderHistory
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ViewOrderHistory", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View your previous activity.
        /// </summary>
        /// <value>The field label view your previous activity.</value>
        public static string FieldLabel_ViewYourPreviousActivity
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_ViewYourPreviousActivity", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Your Account.
        /// </summary>
        /// <value>The field label your account.</value>
        public static string FieldLabel_YourAccount
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_YourAccount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Your Details.
        /// </summary>
        /// <value>The field label your details.</value>
        public static string FieldLabel_YourDetails
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_YourDetails", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Your invoice.
        /// </summary>
        /// <value>The field label your invoice.</value>
        public static string FieldLabel_YourInvoice
        {
            get
            {
                return ResourceManagerGetString("FieldLabel_YourInvoice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to About us.
        /// </summary>
        /// <value>The UI text about us.</value>
        public static string UIText_AboutUs
        {
            get
            {
                return ResourceManagerGetString("UIText_AboutUs", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Administration.
        /// </summary>
        /// <value>The UI text administration.</value>
        public static string UIText_Administration
        {
            get
            {
                return ResourceManagerGetString("UIText_Administration", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to All Products.
        /// </summary>
        /// <value>The UI text all products.</value>
        public static string UIText_AllProducts
        {
            get
            {
                return ResourceManagerGetString("UIText_AllProducts", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to All rights reserved.
        /// </summary>
        /// <value>The UI text all right reserved.</value>
        public static string UIText_AllRightReserved
        {
            get
            {
                return ResourceManagerGetString("UIText_AllRightReserved", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Checkout.
        /// </summary>
        /// <value>The UI text checkout.</value>
        public static string UIText_Checkout
        {
            get
            {
                return ResourceManagerGetString("UIText_Checkout", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Contact us.
        /// </summary>
        /// <value>The UI text contact us.</value>
        public static string UIText_ContactUs
        {
            get
            {
                return ResourceManagerGetString("UIText_ContactUs", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Copy example to Clipboard.
        /// </summary>
        /// <value>The UI text copy example to clipboard.</value>
        public static string UIText_CopyExampleToClipboard
        {
            get
            {
                return ResourceManagerGetString("UIText_CopyExampleToClipboard", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Copyright.
        /// </summary>
        /// <value>The UI text copyright.</value>
        public static string UIText_Copyright
        {
            get
            {
                return ResourceManagerGetString("UIText_Copyright", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Your coupon '{0}' has been applied..
        /// </summary>
        /// <value>The UI text coupon applied.</value>
        public static string UIText_CouponApplied
        {
            get
            {
                return ResourceManagerGetString("UIText_CouponApplied", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to You coupon '{0}' could not be applied..
        /// </summary>
        /// <value>The UI text coupon not applied.</value>
        public static string UIText_CouponNotApplied
        {
            get
            {
                return ResourceManagerGetString("UIText_CouponNotApplied", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Discount coupon has been removed from the shopping cart..
        /// </summary>
        /// <value>The UI text coupon removed.</value>
        public static string UIText_CouponRemoved
        {
            get
            {
                return ResourceManagerGetString("UIText_CouponRemoved", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Customer Care.
        /// </summary>
        /// <value>The UI text customer care.</value>
        public static string UIText_CustomerCare
        {
            get
            {
                return ResourceManagerGetString("UIText_CustomerCare", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to There are some validation errors around eneterd data, please review current and other tabs..
        /// </summary>
        /// <value>The UI text customer validation error text.</value>
        public static string UIText_CustomerValidationErrorText
        {
            get
            {
                return ResourceManagerGetString("UIText_CustomerValidationErrorText", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product Category Bulk Upload.
        /// </summary>
        /// <value>The UI text data wizard text.</value>
        public static string UIText_DataWizardText
        {
            get
            {
                return ResourceManagerGetString("UIText_DataWizardText", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Default sorting.
        /// </summary>
        /// <value>The UI text default sorting.</value>
        public static string UIText_DefaultSorting
        {
            get
            {
                return ResourceManagerGetString("UIText_DefaultSorting", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Example copied..
        /// </summary>
        /// <value>The UI text example copied.</value>
        public static string UIText_ExampleCopied
        {
            get
            {
                return ResourceManagerGetString("UIText_ExampleCopied", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Exclusive Promotions.
        /// </summary>
        /// <value>The UI text exclusive promotions.</value>
        public static string UIText_ExclusivePromotions
        {
            get
            {
                return ResourceManagerGetString("UIText_ExclusivePromotions", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Filter by Price.
        /// </summary>
        /// <value>The UI text filter by price.</value>
        public static string UIText_FilterByPrice
        {
            get
            {
                return ResourceManagerGetString("UIText_FilterByPrice", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to List of Products.
        /// </summary>
        /// <value>The UI text list of products.</value>
        public static string UIText_ListOfProducts
        {
            get
            {
                return ResourceManagerGetString("UIText_ListOfProducts", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shop.
        /// </summary>
        /// <value>The UI text menu shop.</value>
        public static string UIText_Menu_Shop
        {
            get
            {
                return ResourceManagerGetString("UIText_Menu_Shop", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Order Tracker.
        /// </summary>
        /// <value>The UI text order tracker.</value>
        public static string UIText_OrderTracker
        {
            get
            {
                return ResourceManagerGetString("UIText_OrderTracker", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Add subscription.
        /// </summary>
        /// <value>The UI text organization add subscription.</value>
        public static string UIText_Organization_AddSubscription
        {
            get
            {
                return ResourceManagerGetString("UIText_Organization_AddSubscription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Add user.
        /// </summary>
        /// <value>The UI text organization add user.</value>
        public static string UIText_Organization_AddUser
        {
            get
            {
                return ResourceManagerGetString("UIText_Organization_AddUser", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose subscription.
        /// </summary>
        /// <value>The UI text organization choose subscription.</value>
        public static string UIText_Organization_ChooseSubscription
        {
            get
            {
                return ResourceManagerGetString("UIText_Organization_ChooseSubscription", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Choose user.
        /// </summary>
        /// <value>The UI text organization choose user.</value>
        public static string UIText_Organization_ChooseUser
        {
            get
            {
                return ResourceManagerGetString("UIText_Organization_ChooseUser", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No subscriptions selected.
        /// </summary>
        /// <value>The UI text organization no subscriptions selected.</value>
        public static string UIText_Organization_NoSubscriptionsSelected
        {
            get
            {
                return ResourceManagerGetString("UIText_Organization_NoSubscriptionsSelected", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to No users selected.
        /// </summary>
        /// <value>The UI text organization no users selected.</value>
        public static string UIText_Organization_NoUsersSelected
        {
            get
            {
                return ResourceManagerGetString("UIText_Organization_NoUsersSelected", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Out of Stock.
        /// </summary>
        /// <value>The UI text out of stock.</value>
        public static string UIText_OutOfStock
        {
            get
            {
                return ResourceManagerGetString("UIText_OutOfStock", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Paid.
        /// </summary>
        /// <value>The UI text paid.</value>
        public static string UIText_Paid
        {
            get
            {
                return ResourceManagerGetString("UIText_Paid", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Pay for your Order.
        /// </summary>
        /// <value>The UI text pay for order.</value>
        public static string UIText_PayForOrder
        {
            get
            {
                return ResourceManagerGetString("UIText_PayForOrder", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Payment method.
        /// </summary>
        /// <value>The UI text payment method.</value>
        public static string UIText_PaymentMethod
        {
            get
            {
                return ResourceManagerGetString("UIText_PaymentMethod", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to % off.
        /// </summary>
        /// <value>The UI text percent off.</value>
        public static string UIText_PercentOff
        {
            get
            {
                return ResourceManagerGetString("UIText_PercentOff", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Privacy policy.
        /// </summary>
        /// <value>The UI text privacy policy.</value>
        public static string UIText_PrivacyPolicy
        {
            get
            {
                return ResourceManagerGetString("UIText_PrivacyPolicy", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Categories.
        /// </summary>
        /// <value>The UI text product categories.</value>
        public static string UIText_Product_Categories
        {
            get
            {
                return ResourceManagerGetString("UIText_Product_Categories", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Filter.
        /// </summary>
        /// <value>The UI text product filter.</value>
        public static string UIText_Product_Filter
        {
            get
            {
                return ResourceManagerGetString("UIText_Product_Filter", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Filter By.
        /// </summary>
        /// <value>The UI text product filter by.</value>
        public static string UIText_Product_FilterBy
        {
            get
            {
                return ResourceManagerGetString("UIText_Product_FilterBy", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Keywords.
        /// </summary>
        /// <value>The UI text product keywords.</value>
        public static string UIText_Product_Keywords
        {
            get
            {
                return ResourceManagerGetString("UIText_Product_Keywords", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Manufactures.
        /// </summary>
        /// <value>The UI text product manufactures.</value>
        public static string UIText_Product_Manufactures
        {
            get
            {
                return ResourceManagerGetString("UIText_Product_Manufactures", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Search Results for "{0}".
        /// </summary>
        /// <value>The UI text product search results for.</value>
        public static string UIText_Product_SearchResultsFor
        {
            get
            {
                return ResourceManagerGetString("UIText_Product_SearchResultsFor", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to to.
        /// </summary>
        /// <value>The UI text product to.</value>
        public static string UIText_Product_To
        {
            get
            {
                return ResourceManagerGetString("UIText_Product_To", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to We found {0} Items for "{1}".
        /// </summary>
        /// <value>The UI text product we found items for.</value>
        public static string UIText_Product_WeFoundItemsFor
        {
            get
            {
                return ResourceManagerGetString("UIText_Product_WeFoundItemsFor", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to The product has been added to Wishlist..
        /// </summary>
        /// <value>The UI text product added to whish list.</value>
        public static string UIText_ProductAddedToWhishList
        {
            get
            {
                return ResourceManagerGetString("UIText_ProductAddedToWhishList", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Options added:.
        /// </summary>
        /// <value>The UI text product options in cart.</value>
        public static string UIText_ProductOptionsInCart
        {
            get
            {
                return ResourceManagerGetString("UIText_ProductOptionsInCart", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Product upload wizard.
        /// </summary>
        /// <value>The UI text product upload wizard text.</value>
        public static string UIText_ProductUploadWizardText
        {
            get
            {
                return ResourceManagerGetString("UIText_ProductUploadWizardText", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Rows per page.
        /// </summary>
        /// <value>The UI text rows per page.</value>
        public static string UIText_RowsPerPage
        {
            get
            {
                return ResourceManagerGetString("UIText_RowsPerPage", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sales and refund.
        /// </summary>
        /// <value>The UI text sales adn refund.</value>
        public static string UIText_SalesAdnRefund
        {
            get
            {
                return ResourceManagerGetString("UIText_SalesAdnRefund", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Note: If no payment option selected - all payment options are applied to this shipping option..
        /// </summary>
        /// <value>The UI text shipping payment warning.</value>
        public static string UIText_ShippingPayment_Warning
        {
            get
            {
                return ResourceManagerGetString("UIText_ShippingPayment_Warning", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shop By Brand.
        /// </summary>
        /// <value>The UI text shop by brand.</value>
        public static string UIText_ShopByBrand
        {
            get
            {
                return ResourceManagerGetString("UIText_ShopByBrand", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shop by Catgeries.
        /// </summary>
        /// <value>The UI text shop by categories.</value>
        public static string UIText_ShopByCategories
        {
            get
            {
                return ResourceManagerGetString("UIText_ShopByCategories", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shop By Popular Products.
        /// </summary>
        /// <value>The UI text shop by popular products.</value>
        public static string UIText_ShopByPopularProducts
        {
            get
            {
                return ResourceManagerGetString("UIText_ShopByPopularProducts", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Shopping Bag ({0}).
        /// </summary>
        /// <value>The UI text shopping bag count.</value>
        public static string UIText_ShoppingBagCount
        {
            get
            {
                return ResourceManagerGetString("UIText_ShoppingBagCount", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Show All.
        /// </summary>
        /// <value>The UI text show all.</value>
        public static string UIText_ShowAll
        {
            get
            {
                return ResourceManagerGetString("UIText_ShowAll", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Sitemap.
        /// </summary>
        /// <value>The UI text sitemap.</value>
        public static string UIText_Sitemap
        {
            get
            {
                return ResourceManagerGetString("UIText_Sitemap", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Terms of use.
        /// </summary>
        /// <value>The UI text terms of use.</value>
        public static string UIText_TermsOfUse
        {
            get
            {
                return ResourceManagerGetString("UIText_TermsOfUse", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Trending Products.
        /// </summary>
        /// <value>The UI text trending products.</value>
        public static string UIText_TrendingProducts
        {
            get
            {
                return ResourceManagerGetString("UIText_TrendingProducts", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Prending Products Promotion.
        /// </summary>
        /// <value>The UI text trending products promotion.</value>
        public static string UIText_TrendingProductsPromotion
        {
            get
            {
                return ResourceManagerGetString("UIText_TrendingProductsPromotion", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View All Orders.
        /// </summary>
        /// <value>The UI text view all orders.</value>
        public static string UIText_ViewAllOrders
        {
            get
            {
                return ResourceManagerGetString("UIText_ViewAllOrders", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View Cart.
        /// </summary>
        /// <value>The UI text view cart.</value>
        public static string UIText_ViewCart
        {
            get
            {
                return ResourceManagerGetString("UIText_ViewCart", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to View More.
        /// </summary>
        /// <value>The UI text view more.</value>
        public static string UIText_ViewMore
        {
            get
            {
                return ResourceManagerGetString("UIText_ViewMore", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Wishlist.
        /// </summary>
        /// <value>The UI text wishlist.</value>
        public static string UIText_Wishlist
        {
            get
            {
                return ResourceManagerGetString("UIText_Wishlist", resourceCulture);
            }
        }

        /// <summary>
        /// Looks up a localized string similar to Your shopping cart is empty.
        /// </summary>
        /// <value>The UI text your cart empty.</value>
        public static string UIText_YourCartEmpty
        {
            get
            {
                return ResourceManagerGetString("UIText_YourCartEmpty", resourceCulture);
            }
        }
    }    
}
