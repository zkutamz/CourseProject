using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LMS.Model.Request.AssignmentDTOs
{
    public class AssignmentCreateDTO
    {
        #region Properties

        public string Title { get; set; }
        public string Content { get; set; }
        public int TotalTime { get; set; }
        public int TotalNumber { get; set; }
        public int MinimumPassNumber { get; set; }
        public int UploadAttachmentLimit { get; set; }
        public List<string> AssignmentUrls { get; set; }
#nullable enable

        public int? MaximumAttachmentSizeLimit { get; set; }
        public int? SectionId { get; set; }

#nullable disable

        #endregion
    }
}
