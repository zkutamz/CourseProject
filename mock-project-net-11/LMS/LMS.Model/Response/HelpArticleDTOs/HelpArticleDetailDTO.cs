using System;

namespace LMS.Model.Response.HelpArticleDTOs
{
    public class HelpArticleDetailDTO : HelpArticleDTO
    {
        public DateTime UpdatedAt { get; set; }
        public string Content { get; set; }
    }
}
