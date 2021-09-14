using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogHub.Data.Models
{
    public class HubUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }


        public ICollection<Article> ArticleList { get; set; }
    }
}
