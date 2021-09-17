using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogHub.ViewModels
{
    public class EditArticleViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "This Area Is Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This Area Is Required")]
        public string Content { get; set; }

        [Display(Name = "Article Picture")]
        public IFormFile ArticlePicture { get; set; }

        public string ArticlePictureName { get; set; }
    }
}
