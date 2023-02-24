using LMS.Model.Response.HelpArticleDTOs;
using System;
using System.Collections.Generic;

namespace LMS.Model.Response.HelpTopicDTOs
{
    public class HelpTopicDetailDTO : HelpTopicDTO
    {
        public IList<HelpArticleDTO> HelpArticles { get; set; }
    }
}
