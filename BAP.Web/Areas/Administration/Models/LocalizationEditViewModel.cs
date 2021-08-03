using BAP.Common;
using BAP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAP.Web.Areas.Administration.Models
{
    public class LocalizationEditViewModel
    {
        public string Name { get; set; }
        public string Object { get; set; }
        public string ObjectId { get; set; }
        public string ResourceSet { get; set; }
        public string FileName { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }

        public List<LocalizationEditItemViewModel> Items { get; set; } = new List<LocalizationEditItemViewModel>();

        public LocalizationEditViewModel() { }

        public LocalizationEditViewModel(List<Localization> localizations, CultureHelper cultureHelper)
        {
            Name = JoinAndDistinctItems(localizations.Select(x => x.Name));
            Object = JoinAndDistinctItems(localizations.Select(x => x.Object));
            ObjectId = JoinAndDistinctItems(localizations.Select(x => x.ObjectId));
            CreateDate = JoinAndDistinctItems(localizations.Select(x => x.CreateDate.ToString()));
            CreatedBy = JoinAndDistinctItems(localizations.Select(x => x.CreatedBy));
            FileName = JoinAndDistinctItems(localizations.Select(x => x.FileName));
            ResourceSet = JoinAndDistinctItems(localizations.Select(x => x.ResourceSet));
            LastModifiedBy = JoinAndDistinctItems(localizations.Select(x => x.LastModifiedBy));
            LastModifiedDate = JoinAndDistinctItems(localizations.Select(x => x.LastModifiedDate.ToString()));

            // use this culture if CultureCode is NULL in localization object
            var defaultCulture = cultureHelper.GetDefaultCulture();

            Items = localizations.Select(x =>
            {
                var cultureCode = string.IsNullOrEmpty(x.CultureCode) ? defaultCulture : x.CultureCode;

                return new LocalizationEditItemViewModel
                {
                    Value = x.Value,
                    LocalizationId = x.Id,
                    CountryCode = cultureHelper.GetCountryCode(cultureCode),
                    LanguageName = cultureHelper.GetLanguageName(cultureCode),
                    CultureCode = cultureCode
                };
            }).ToList();
        }

        private string JoinAndDistinctItems<T>(IEnumerable<T> items)
        {
            return string.Join(", ", items.Distinct());
        }
    }

    [Bind(Include = "LocalizationId,Value,CountryCode,LanguageName,CultureCode")]
    public class LocalizationEditItemViewModel
    {
        public int LocalizationId { get; set; }
        public string Value { get; set; }
        public string CountryCode { get; set; }
        public string LanguageName { get; set; }
        public string CultureCode { get; set; }
    }
}