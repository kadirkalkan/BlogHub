using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogHub.ViewModels
{
    public class ArticleListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedTime { get; set; }

        public string GetCreatedTime()
        {
            return CreatedTime.ToString("dd-MM-yyyy HH:mm");
        }

        public string GetContentSummary()
        {
            string summary = string.Empty;
            if (Content.Length >= 50)
                summary = string.Format("{0}...", Content.Substring(0, 50));
            else
                summary = Content;

            return summary;
        }

    }
}
