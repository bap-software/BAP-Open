using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;

using Newtonsoft.Json;

using BAP.DAL;
using BAP.Log;
using BAP.Common;
using BAP.Lookups;
using BAP.FileSystem;
using BAP.UI.Controllers;

using BAP.eCommerce.BL;
using BAP.eCommerce.Resources;
using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.DataWizards.Models;
using BAP.eCommerce.DataWizards.Services.AbstractTypes;
using BAP.eCommerce.DataWizards.Services.ConcreteTypes;
using System.Collections.Generic;

namespace BAP.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator,ContentManager")]
    public class DataWizardsController : BaseController<ProductCategory>
    {

        private readonly IProductBL _productbl;
        private readonly IProductCategoryBL _pbl;
        private readonly IFileVerifyService _fileVerifyService;
        private readonly IJsonValidationService _jsonValidationService;
        private readonly ICategoryMapService _mapService;
        private readonly IUploadFileService _uploadFileService;
        private readonly IReadFromFileService _readFileService;
        private readonly IProductMapService _productMapService;

        public DataWizardsController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context, IFileProcessor fileProcessor) :
            base(logger, configHelper, lookupEngine, context, new AuthorizationHelper<ProductCategory>(configHelper, context), null, fileProcessor, new ProductCategoryBL(configHelper, context, logger))
        {
            _productbl = (IProductBL)_bl;
            _pbl = (IProductCategoryBL)_bl;
            _fileVerifyService = new FileVerifyService();
            _jsonValidationService = new JsonValidationService();
            _mapService = new CategoryMapService();
            _uploadFileService = new UploadFileService();
            _readFileService = new ReadFromFileService();
            _productMapService = new ProductMapService();
        }
        // GET: Administration/DataWizards/ProductCategoryDataWizard
        public ActionResult ProductCategoryDataWizard()
        {
            return View("DataWizard");
        }
        // GET: Administration/DataWizards/ProductDataWizard
        public ActionResult ProductDataWizard()
        {
            return View("ProductUploadWizard");
        }

        [HttpPost]
        public JsonResult VerifyJson(HttpPostedFileBase file, string modelType)
        {
            var jsonResult = DataWizardResponseModel.GetInstance();
            string jsonData = "";

            try
            {
                // Verify that the user selected a file
                if (_fileVerifyService.FileIsNotNullAndEmpty(file))
                {
                    if (modelType == "Category")
                    {
                        _uploadFileService.UploadFile(file, _fileProcessor);
                        var bapFile = _uploadFileService.GetFile(file.FileName, _fileProcessor);
                        if (bapFile?.FileStream != null)
                        {
                            jsonData = _readFileService.ReadFile(bapFile);
                        }
                    }
                    if (modelType == "Product")
                    {
                        _uploadFileService.UploadFile(file, _fileProcessor, true);
                        var bapFile = _uploadFileService.GetFile(file.FileName, _fileProcessor, true);
                        if (bapFile?.FileStream != null)
                        {
                            jsonData = _readFileService.ReadFile(bapFile);
                        }
                    }

                }
                bool? validationResult = false;
                // Verify if file is correct 
                if (modelType == "Product")
                {
                    validationResult = _jsonValidationService.FileIsJson(jsonData)
                                             ?.IsJsonSchemeCorrect<ProductUploadModel>(jsonData)
                                             ?.IsJsonCorrectModel<ProductUploadModel>(jsonData);
                }
                if (modelType == "Category")
                {
                    validationResult = _jsonValidationService.FileIsJson(jsonData)
                                           ?.IsJsonSchemeCorrect<DataWizardProductCategory>(jsonData)
                                           ?.IsJsonCorrectModel<DataWizardProductCategory>(jsonData);
                }
                // return validation response
                if (validationResult != null && validationResult != false)
                {
                    if (modelType == "Category")
                    {
                        var source = JsonConvert.DeserializeObject<DataWizardProductCategory>(jsonData);
                        if (source != null)
                        {
                            var dataToAdd = _mapService.GetSeparatedCategories(source).ToArray();
                            jsonResult.IsSuccess = true;
                            jsonResult.Message = ResObject.DataWizard_Alert;

                            Session["jsonData"] = dataToAdd;
                        }
                        else
                        {
                            jsonResult.IsSuccess = false;
                            jsonResult.Message = ResObject.DataWizardController_Json_Deserialization_error;
                        }
                    }
                    if (modelType == "Product")
                    {
                        var source = JsonConvert.DeserializeObject<List<ProductUploadModel>>(jsonData);
                        if (source != null)
                        {
                            List<Product> dataToAdd = new List<Product>();
                            foreach (var item in source)
                            {
                                var category = _pbl.GetAllProductCategories().FirstOrDefault(o => o.Name == item.Category);
                                dataToAdd.Add(_productMapService.CastToProduct(item, category, _fileProcessor));
                            }
                            jsonResult.IsSuccess = true;
                            jsonResult.Message = ResObject.DataWizard_Alert;

                            Session["jsonData"] = dataToAdd;

                        }
                    }
                }
                else
                {
                    jsonResult.IsSuccess = false;
                    jsonResult.Message = ResObject.DataWizardController_Validation_Error;
                }
            }
            catch (Exception exc)
            {
                jsonResult.EventId = _logger.LogException("DataWizardsController", "VerifyJson", exc);
                jsonResult.IsSuccess = false;
                jsonResult.Message = exc.Message;
            }

            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SaveData(string model)
        {
            var jsonResult = DataWizardResponseModel.GetInstance();
            jsonResult.IsSuccess = true;

            try
            {
                if (model == "Product")
                {
                    var dataToAdd = (List<Product>)Session["jsonData"];
                    // save to DB
                    _productbl.AddProduct(_uploadFileService, _fileProcessor, dataToAdd.ToArray());
                    jsonResult.Message = string.Format(ResObject.DataWizardController_Product_Successfull_Upload, dataToAdd.Count);
                }
                else if (model == "Category")
                {
                    var dataToAdd = (ProductCategory[])Session["jsonData"];

                    _pbl.AddProductCategory(dataToAdd);
                    jsonResult.Message = string.Format(ResObject.DataWizardController_Category_Successfull_Upload, dataToAdd.Length);
                }
                else
                    throw new Exception("Incorrect model string");

            }
            catch (Exception exc)
            {
                jsonResult.EventId = _logger.LogException("DataWizardsController", "AddData", exc);
                jsonResult.IsSuccess = false;
                jsonResult.Message = exc.Message;
            }

            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

    }
}