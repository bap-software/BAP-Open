using System.Collections.Generic;

using BAP.DAL.Entities;

namespace BAP.Web.Models
{
    public class HomeData
    {
        public string ContactSubject { get; set; }
        public List<OrganizationService> Services { get; set; }
    }
}