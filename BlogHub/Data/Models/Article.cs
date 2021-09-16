using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogHub.Data.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MinLength(100)]
        public string Content { get; set; }

        public string ArticlePicture { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        [Required]
        public HubUser Author { get; set; }

    }
}
