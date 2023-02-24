using LMS.Model.Response.AppUserDTOs;
using System;
using System.Collections.Generic;

namespace LMS.Model.Response.DiscussionDTOs
{
    public class DiscussionDTO
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int LikeCount { get; set; }

        public int DisLikeCount { get; set; }
        public DateTime UpdatedAt { get; set; }       
#nullable enable
        public int? ParentId { get; set; }
#nullable disable
        public AppUserDTO User { get; set; }
        public IList<DiscussionDTO> ChildDiscussions { get; set; }
    }
}
