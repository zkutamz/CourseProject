using LMS.Model.Request.SearchDTOs.Enums;
using LMS.Repository.Enums;

namespace LMS.Model.Request.SearchDTOs
{
    public class SearchRequest
    {
        public string SearchString { get; set; }
        public string Topic { get; set; }
        public SearchPrice? Price { get; set; }
        public SearchRating? Rating { get; set; }
        public SearchDuration? VideoDuration { get; set; }
        public SearchFeature? Features { get; set; }
        public Level? Level { get; set; }
        public OrderBy? OrderBy { get; set; }
    }
}
