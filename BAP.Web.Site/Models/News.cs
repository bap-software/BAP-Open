using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace BAP.Web.Models
{
    [Table("News")]
    public class News
    {
        [Display(Name = "News Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [StringLength(50)]
        public string Title { get; set; }

        [Display(Name = "Subtitle")]
        [StringLength(80)]
        public string Subtitle { get; set; }

        [Display(Name = "Text Html")]
        [StringLength(2000)]
        public string TextHtml { get; set; }

        [Display(Name = "Image Path")]
        [StringLength(255)]
        public string ImagePath { get; set; }

        [Display(Name = "Upload Image")]
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "News Created At")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "News Published At")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Published?")]
        public Boolean Published { get; set; }
    }
}