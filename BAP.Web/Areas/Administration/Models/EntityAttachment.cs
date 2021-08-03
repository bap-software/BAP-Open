using BAP.DAL.Entities;
using System.Collections.Generic;

namespace BAP.Web.Areas.Administration.Models
{
    public class EntityAttachment
    {
        public string Object { get; set; }
        public int ObjectId { get; set; }
        public IList<Attachment> Attachments { get; set; }
        public bool IsReadOnly { get; set; }
    }
}