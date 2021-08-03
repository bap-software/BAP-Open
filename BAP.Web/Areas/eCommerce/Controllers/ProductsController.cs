using System;
using System.Net;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using Newtonsoft.Json;
using PagedList;

using BAP.Common;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;
using BAP.Email;
using BAP.FileSystem;
using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.BL;
using BAP.eCommerce.Common.Exceptions;
using BAP.eCommerce.Resources;
using BAP.ContentManagement;
using BAP.eCommerce.UI.Controllers;
using BAP.BL;
using BAP.Web.Areas.eCommerce.Models;
using MvcSiteMapProvider.Web.Html.Models;

namespace BAP.Web.Areas.eCommerce.Controllers
{
    //Every controller is created with restricted access be default. Any public action has to be created explicitly.
    [Authorize(Roles = "Administrator,User")]
    public class ProductsController : BaseeCommerceController<Product>, IContentExtendable
    {
        private readonly IProductBL _pbl;
        private readonly IProductCategoryBL _pcbl;
        private readonly IManufacturerBL _mbl;
        private readonly IOrderItemBL _oibl;
        private readonly IContentNodeBL _cnbl;

        public ProductsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IFileProcessor fileProc, IAuthorizationContext context, IMailer mailer, IFileProcessor fileProcessor) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<Product>(configHelper, context), mailer, fileProcessor, new eCommerceBusinessLayer(lookupEngine, fileProc, configHelper, context, logger))
        {
            _pbl = (eCommerceBusinessLayer)_bl;
            _pcbl = (eCommerceBusinessLayer)_bl;
            _mbl = (eCommerceBusinessLayer)_bl;
            _oibl = (eCommerceBusinessLayer)_bl;
            _cnbl = (eCommerceBusinessLayer)_bl;

            ViewBag.QuickAddToCart = false;
            if(_eContext != null && _eContext.DefaultStore != null)
            {
                ViewBag.QuickAddToCart = _eContext.DefaultStore.QuickShoppingCart;
            }
                       
            ViewBag.CurrencySymbol = "$";
            if (_eContext != null && _eContext.CurrentCurrency != null)
            {
                ViewBag.CurrencySymbol = _eContext.CurrentCurrency.Symbol;                
            }
        }
        
        [AllowAnonymous]
        public override ActionResult Content(string view = "", object[] parameters = null)
        {
            ViewBag.Parameters = parameters;
            return base.Content(view);
        }

        // GET: Products
        [AllowAnonymous]
        public ActionResult Index(string sortOrder, string currentFilter, string manufacturer, int? page, int? pageSize, string category = "", bool? listView = false, string view = "")
        {
            int pageNumber = page ?? 1;
            int rowsPerPage = GetRealPageSize(pageSize);

            InitIndexViewData(sortOrder, currentFilter);
            ViewBag.IsListView = listView ?? false;
            var customSortOrder = string.Empty;
            if (!string.IsNullOrWhiteSpace(sortOrder) && (sortOrder.Contains("Sales") || sortOrder.Contains("Discount") || sortOrder.Contains("Price")))
            {
                customSortOrder = sortOrder;
                sortOrder = string.Empty;
            }

            ProductCategory productCategory = null;
            if (!string.IsNullOrWhiteSpace(category))
                productCategory = _pcbl.GetProductCategoryByPublicId(category);

            var allProducts = _pbl.GetAllProducts();
            var categoriesWithCounts = new List<KeyValuePair<ProductCategory, int>>();
            var categories = _pcbl.GetAllProductCategories().Where(c => allProducts.Any(p => p.ProductCategoryId == c.Id) || c.ShowIfEmpty);
            foreach (var ctgr in categories)
            {
                var count = allProducts.Where(a => a.ProductCategoryId == ctgr.Id).Count();
                categoriesWithCounts.Add(new KeyValuePair<ProductCategory, int>(ctgr, count));
            }
            ViewBag.Categories = categories;
            ViewBag.CategoriesWithCount = categoriesWithCounts;

            var manufacturesWithCounts = new List<KeyValuePair<Manufacturer, int>>();
            var manufactures = _mbl.GetAllManufacturers().Where(m => allProducts.Any(p => p.ManufacturerId == m.Id) || m.ShowIfEmpty);
            foreach (var mnf in manufactures)
            {
                var count = allProducts.Where(a => a.ManufacturerId == mnf.Id).Count();
                manufacturesWithCounts.Add(new KeyValuePair<Manufacturer, int>(mnf, count));
            }
            ViewBag.ManufacturesWithCounts = manufacturesWithCounts;

            if (!string.IsNullOrWhiteSpace(manufacturer))
            {
                currentFilter = GetManufacturerFilter(manufacturer);
                ViewBag.FilterBy = manufacturer;
            }
            else if (productCategory != null)
                ViewBag.FilterBy = productCategory.Name;
            else if (!string.IsNullOrWhiteSpace(currentFilter))
            {
                var filters = JsonConvert.DeserializeObject<List<SearchStruct>>(currentFilter);
                var fullText = filters.FirstOrDefault(f => f.field == "fulltext");
                if (fullText != null)
                    ViewBag.FilterBy = fullText.value;
            }
            else
                ViewBag.FilterBy = string.Empty;

            var categoryId = productCategory != null ? productCategory.Id : 0;
            var products = _pbl.SearchProducts(currentFilter, sortOrder, pageNumber, rowsPerPage, categoryId);

            var productModels = new List<ProductModel>();
            var orderItems = _oibl.GetAllOrderItems();
            foreach (var product in products)
            {
                var productModel = new ProductModel(product)
                {
                    Sales = orderItems.Where(o => o.ProductId == product.Id).Sum(o => o.Count)
                };
                productModels.Add(productModel);
            }

            if (!string.IsNullOrWhiteSpace(customSortOrder))
            {
                string field = string.Empty;
                string dir = string.Empty;
                var exts = customSortOrder.Split("-".ToCharArray());
                if (exts.Length > 1)
                {
                    var sortData = (Dictionary<string, string>)ViewBag.SortData;
                    field = exts[0];
                    dir = exts[1];
                    switch (field)
                    {
                        case "Sales":
                            if (dir == "asc")
                            {
                                productModels = productModels.OrderBy(p => p.Sales).ToList();
                                sortData.Add("Sales", "desc");
                            }
                            else
                            {
                                productModels = productModels.OrderByDescending(p => p.Sales).ToList();
                                sortData.Add("Sales", "asc");
                            }
                            break;
                        case "Discount":
                            if (dir == "asc")
                            {
                                productModels = productModels.OrderBy(p => p.Discount).ToList();
                                sortData.Add("Discount", "desc");
                            }
                            else
                            {
                                productModels = productModels.OrderByDescending(p => p.Discount).ToList();
                                sortData.Add("Discount", "asc");
                            }
                            break;
                        case "Price":
                            if (dir == "asc")
                            {
                                productModels = productModels.OrderBy(p => p.RealPrice).ToList();
                                sortData.Add("Discount", "desc");
                            }
                            else
                            {
                                productModels = productModels.OrderByDescending(p => p.RealPrice).ToList();
                                sortData.Add("Discount", "asc");
                            }
                            break;
                    }
                    ViewBag.SortData = sortData;
                }
            }

            var model = new PagedList<ProductModel>(productModels, pageNumber, rowsPerPage);
            return string.IsNullOrEmpty(view) ? View(model) : View(view, model);
        }

        [AllowAnonymous]
        public ActionResult ProductBanners(string view = "")
        {
            if (string.IsNullOrEmpty(view))
                return View();
            else
                return View(view);
        }

        [AllowAnonymous]
        public ActionResult ProductsMenu(string view, SiteMapNodeModelList adminMenus)
        {
            var allProducts = _pbl.GetAllProducts();
            var productsMenu = new ProductsMenuModel
            {
                Categories = _pcbl.GetAllProductCategories().Where(c => c.ParentCategory == null && (allProducts.Any(p => p.ProductCategoryId == c.Id) || c.ShowIfEmpty)).ToList(),
                Manufacturers = _mbl.GetAllManufacturers().Where(m => allProducts.Any(p => p.ManufacturerId == m.Id) || m.ShowIfEmpty).ToList()
            };
            var orderItems = _oibl.GetAllOrderItems();
            foreach (var product in _pbl.GetAllProducts())
            {
                var productModel = new ProductModel(product)
                {
                    Sales = orderItems.Where(o => o.ProductId == product.Id).Sum(o => o.Count)
                };
                productsMenu.Products.Add(productModel);
            }
            ViewBag.eShopAdminMenus = adminMenus;
            productsMenu.Products = productsMenu.Products.OrderByDescending(p => p.Sales).ToList();
            if (string.IsNullOrEmpty(view))
                return View(productsMenu);
            else
                return View(view, productsMenu);
        }

        private List<FeaturedProductModel> GetFeaturedProducts()
        {
            var featuredProducts = _pbl.GetFeaturedProducts();
            return featuredProducts.Take(5).Select(o =>
            {
                return new FeaturedProductModel()
                {
                    Currency = o.Currency,
                    Id = o.Id,
                    ImagePath = o.ImagePath,
                    Name = o.Name,
                    Price = o.Price,
                    Promotion = o.ShortDescription,
                    PublicDate = o.InStoreFrom != DateTime.MinValue ? o.InStoreFrom : DateTime.Now,
                    PublicId = o.GetPublicId()
                };
            }).ToList();
        }
        [AllowAnonymous]
        public ActionResult FeaturedProductsSlider(string view = "")
        {
            var products = GetFeaturedProducts();
            return view.IsNullOrEmpty() ? View(products) : View(view, products);
        }

        [AllowAnonymous]        
        public JsonResult FeaturedProductsJson()
        {
            return Json(GetFeaturedProducts(), JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult LatestProductsForFooter(string view = "")
        {
            var latestProducts = ((eCommerceBusinessLayer)_pbl).SearchProducts(null, "LastModifiedDate-DESC").Take(4);
            var products = latestProducts.Select(o =>
               {
                   return new LatestProductModel()
                   {
                       Id = o.Id,
                       Name = o.Name,
                       Price = o.Price,
                       ImagePath = o.ImagePath,
                       PublicId = o.GetPublicId()
                   };
               }).ToList();
            return view.IsNullOrEmpty() ? View(products) : View(view, products);
        }

        [AllowAnonymous]
        public ActionResult TrendingProducts(string view = "")
        {
            var allProducts = _pbl.GetAllProducts();
            ///
            var products = allProducts
                .Where(o => o.InternalStatus == "trending")
                .Select(o =>
                     new TrendingProductModel()
                     {
                         Id = o.Id,
                         Name = o.Name,
                         RegularPrice = o.Price,
                         SalesPrice = o.ListPrice,
                         ImagePath = o.ImagePath,
                         ShortDescription = o.ShortDescription,
                         Description = o.Description,
                         PublicId = o.GetPublicId()
                     }).ToList();

            return view.IsNullOrEmpty() ? View(products) : View(view, products);
        }

        [AllowAnonymous]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProductsByCategories(string view = "")
        {
            var allProducts = _pbl.GetAllProducts();

            //Get Category and manufacturers data from _eContext
            var categories = ((IProductCategoryBL)_pbl).GetAllProductCategories();//_eContext.ProductCategories;
            var manufacturers = _eContext.Manufacturers;

            //Initialize and populating Lookups
            //
            //key = ProductCategoryId  value = ProductId
            allProducts = allProducts.Where(p => categories.Any(c => c.Id == p.ProductCategoryId)).ToList();
            Lookup<int?, int> lookupCategories = (Lookup<int?, int>)allProducts.ToLookup(key => key.ProductCategoryId, value => value.Id);

            //key = ProductId  value = ManufacturerId
            Lookup<int, int?> lookupManufacturers = (Lookup<int, int?>)allProducts.ToLookup(key => key.Id, value => value.ManufacturerId);

            //Create List for <Category , Manufacturer> pair
            List<KeyValuePair<int?, int?>> kvpList = new List<KeyValuePair<int?, int?>>();

            //Create Pair for kvpList<CategoryId,ManufacturerId>
            foreach (IGrouping<int?, int> category in lookupCategories)
            {
                foreach (var item in category)
                {
                    foreach (IGrouping<int, int?> manufacturer in lookupManufacturers.Where(z => z.Key == item))
                    {
                        foreach (int? manufacturerId in manufacturer)
                            kvpList.Add(new KeyValuePair<int?, int?>(category.Key, manufacturerId));
                    }
                }
            }

            Lookup<int?, int?> categoriesManufacturers = (Lookup<int?, int?>)kvpList.ToLookup(key => key.Key, value => value.Value);

            //Create List of CategoryModel productCategories:
            //
            //Public Properties:
            //      int? Category
            //      List<ManufacturerModel> Manufacturers
            List<CategoryModel> productCategories = new List<CategoryModel>();

            //Populate List<CatagoryModel> productCategories
            foreach (IGrouping<int?, int?> packageGroup in categoriesManufacturers)
            {
                var check = categories.Where(o => o.Id == packageGroup.Key).First();
                if (check.ParentCategoryId != null)
                    continue;
                //Local var for adding to list 
                var productCategory = new CategoryModel
                {
                    CategoryId = packageGroup.Key
                };
                var pc = categories.Where(o => o.Id == productCategory.CategoryId).FirstOrDefault();
                if (pc != null)
                {
                    productCategory.Name = pc.Name;
                    productCategory.Description = pc.Description;
                    productCategory.PCID = pc.GetPublicId();
                }

                //Create List of ManufacturerModel productManufacturers:
                //
                //Public Properties:
                //      int? Manufacturer
                //      List<ProductByCategoryModel> ProductByCategory
                //
                List<ManufacturerModel> productManufacturers = new List<ManufacturerModel>();

                //Populate with data 
                foreach (var item in packageGroup)
                {
                    //Populating List<ManufacturerModel> Manufacturers
                    if (item != null)
                    {
                        var manufacturer = manufacturers.Where(j => j.Id == item && item != null).FirstOrDefault();
                        if (manufacturer != null)
                            productManufacturers.Add(new ManufacturerModel()
                            {
                                ManufacturerId = item,
                                Name = manufacturer.Name,
                                ProductByCategory = new List<ProductByCategoryModel>(allProducts
                                   .Where(prod => prod.ManufacturerId == item && prod.ProductCategoryId == packageGroup.Key)
                                   .Select(m =>
                                    new ProductByCategoryModel()
                                    {
                                        Id = m.Id,
                                        Name = m.Name,
                                        RegularPrice = m.Price,
                                        SalesPrice = m.ListPrice,
                                        ImagePath = m.ImagePath,
                                        ShortDescription = m.ShortDescription,
                                        Description = m.Description,
                                        PublicId = m.GetPublicId(),
                                        ManufacturerId = item,
                                        CategoryId = packageGroup.Key
                                    }).Take(7)).ToList()
                            });
                    }
                }
                productCategory.Manufacturers = productManufacturers
                                                .GroupBy(x => x.ManufacturerId)
                                                .Select(y => y.First()).ToList();
                if (productCategory.Manufacturers.Count == 0)
                    continue;
                productCategories.Add(productCategory);
            }
            return view.IsNullOrEmpty() ? View(productCategories) : View(view, productCategories);
        }

        // GET: Products/Details/5
        [AllowAnonymous]
        //[Route("products/{pid}/{view?}")]
        public ActionResult Details(string pid, string view = "")
        {
            Product product = null;

            if (!string.IsNullOrEmpty(pid))
            {
                product = _pbl.GetProductByPublicId(pid);
                foreach (var item in product.RelatedProducts)
                    item.SimilarProduct = _pbl.GetProductById(item.SimilarProductId);
                var categories = _pcbl.GetAllProductCategories();
                var links = new List<KeyValuePair<string, string>>();
                FillProductCategoryLinks(product.ProductCategory, categories, links);
                ViewBag.ProductCategoryLinks = links;
            }

            if (product == null)
                return HttpNotFound();

            ViewBag.ShippingOptions = ((IShippingOptionBL)_bl).GetShippingOptions(null);
            var productModel = new ProductModel(product);
            return view.IsNullOrEmpty() ? View(productModel) : View(view, productModel);
        }

        private void FillProductCategoryLinks(ProductCategory productCategory, IList<ProductCategory> categories, IList<KeyValuePair<string, string>> links)
        {
            if (productCategory == null)
                links.Add(new KeyValuePair<string, string>(Url.Action("Index", "Products"), ResObject.FieldLabel_ShoppingCart_ShoppingCartProducts));
            else
            {
                if (productCategory.ParentCategoryId > 0)
                    productCategory.ParentCategory = categories.FirstOrDefault(c => c.Id == productCategory.ParentCategoryId);
                FillProductCategoryLinks(productCategory.ParentCategory, categories, links);
                links.Add(new KeyValuePair<string, string>(Url.Action("Index", "Products", new { category = productCategory.GetPublicId() }), productCategory.Name));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(int productId, int count, string token, string view = "")
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ShoppingCartException(ResObject.ErrorText_IllegalAddToCart);
            }
            var shoppingCartBL = ((IShoppingCartBL)_bl);
            Product product = _pbl.GetProductById(productId);
            ShoppingCart shoppingcart = _eContext.CurrentShoppingCart;
            if (product == null || shoppingcart == null)
            {
                return HttpNotFound();
            }

            if (!IsPostTokenPresent(shoppingcart.Id, token))
            {
                AddPostToken(shoppingcart.Id, token);

                shoppingCartBL.AddProductToShoppingCart(shoppingcart, product, count);

                if (product.Options != null && product.Options.Count > 0)
                {
                    foreach (var optionCat in product.Options)
                    {
                        if (!Request.Form["Option" + optionCat.Id].IsNullOrEmpty())
                        {
                            var formVal = Request.Form["Option" + optionCat.Id];
                            if (optionCat.Type == ProductOptionType.Product)
                            {
                                var ids = formVal.Split(",".ToCharArray()).Select(a => Convert.ToInt32(a)).ToArray();
                                foreach (int id in ids)
                                {
                                    var optionItem = optionCat.ProductOptionItems.SingleOrDefault(a => a.Id == id);
                                    if (optionItem.RelatedProductId != null && optionItem.RelatedProductId.Value > 0)
                                    {
                                        var p = _pbl.GetSingleProductById(optionItem.RelatedProductId.Value);
                                        ((IShoppingCartBL)_bl).AddProductToShoppingCart(shoppingcart, p, count);
                                    }
                                }
                            }
                            else
                            {
                                ProductOptionItem optionItem = null;
                                switch (optionCat.Type)
                                {
                                    case ProductOptionType.Attribute:
                                        var ids = formVal.Split(",".ToCharArray()).Select(a => Convert.ToInt32(a)).ToArray();
                                        //expecting here IDs of option items
                                        foreach (var id in ids)
                                        {
                                            optionItem = optionCat.ProductOptionItems.SingleOrDefault(a => a.Id == id);
                                            shoppingCartBL.AddProductOption(shoppingcart, product, optionItem, null);
                                        }
                                        break;
                                    case ProductOptionType.Text:
                                        if (optionCat.ProductOptionItems.Any())
                                            optionItem = optionCat.ProductOptionItems.First();

                                        if (optionItem == null)
                                        {
                                            optionItem = new ProductOptionItem
                                            {
                                                Id = 0,
                                                Name = optionCat.Name,
                                                ShortDescription = optionCat.ShortDescription,
                                                Description = optionCat.Description
                                            };
                                        }
                                        shoppingCartBL.AddProductOption(shoppingcart, product, optionItem, formVal);
                                        break;
                                }
                            }
                        }
                    }
                }
            }


            return RedirectToAction("Details", "ShoppingCarts", routeValues: new { shoppingcart.Id, view });
        }

        [HttpPost]
        [AllowAnonymous]
        public void AddToWishlist(int? productId)
        {
            if (productId.HasValue && Session != null)
            {
                if (Session["Wishlist"] is List<int> wishlist && !wishlist.Any(x => x == productId.Value))
                    wishlist.Add(productId.Value);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public void RemoveFromWishlist(int? productId)
        {
            if (productId.HasValue && Session != null)
            {
                if (Session["Wishlist"] is List<int> wishlist && wishlist.Any(x => x == productId.Value))
                    wishlist.Remove(productId.Value);
            }
        }

        [AllowAnonymous]
        public ActionResult WishlistHeader(string view = "")
        {
            if (string.IsNullOrEmpty(view))
                return View();
            else
                return View(view);
        }

        [AllowAnonymous]
        public ActionResult WishlistItems(string view = "WishlistItems")
        {
            var model = new WishlistModel
            {
                Products = new List<Product>(),
                Currency = new DAL.Entities.Currency { Symbol = "$" }
            };

            if (Session != null)
            {
                var wishlist = Session["Wishlist"] as List<int>;
                foreach (int productId in wishlist)
                {
                    var product = _pbl.GetProductByPublicId(productId.ToString());
                    model.Products.Add(product);
                }
            }

            if (model.Products.Any())
            {
                return PartialView(view, model);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            }
        }

        [AllowAnonymous]
        public ActionResult WishlistCount(string view = "")
        {
            if (Session != null)
                ViewBag.WishlistCount = (Session["Wishlist"] as List<int>)?.Count;

            if (string.IsNullOrEmpty(view))
                return View();
            else
                return View(view);
        }
        
        private string GetManufacturerFilter(string manufacturer)
        {
            var filters = new List<SearchStruct>();
            var manufacturerFilter = new SearchStruct
            {
                field = "Manufacturer.Name",
                value = manufacturer
            };
            filters.Add(manufacturerFilter);
            return JsonConvert.SerializeObject(filters);
        }
    }
}
