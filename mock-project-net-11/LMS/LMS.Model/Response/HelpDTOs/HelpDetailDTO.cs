using LMS.Model.Response.FAQs;
using LMS.Model.Response.HelpTopicDTOs;
using System.Collections.Generic;

namespace LMS.Model.Response.HelpDTOs
{
    public class HelpDetailDTO
    {
        public int Id { get; set; }
        public string UserContent { get; set; }
        public IList<FAQDTO> FAQs { get; set; }
        public IList<HelpTopicDTO> HelpTopics { get; set; }
    }
}
