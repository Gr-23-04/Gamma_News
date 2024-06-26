﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamma_News.Models.ViewModels
{
    public class Article
    {
        public Article()
        {
            Categories = new List<SelectListItem>();
        }

        //articles information
        public int Id { get; set; }
        public string Headline { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public string FileName { get; set; }

        public string ImageLink { get; set; }

        public string Preview
        {
            get
            {
                return Content.Length > 100 ? Content.Substring(0, 100) : Content;
            }

        }
        // public virtual ICollection<Uri> ListTest { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }


        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        [NotMapped]
        public List<SelectListItem> Categories { get; set; }
        public virtual Category Category { get; set; }

    }
}
