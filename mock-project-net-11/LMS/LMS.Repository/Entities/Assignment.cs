using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    public class Assignment : BaseEntity
    {
        #region Properties

        public string Title { get; set; }
        public string Content { get; set; }
        public int TotalTime { get; set; }
        public int TotalNumber { get; set; }
        public int MinimumPassNumber { get; set; }
        public int UploadAttachmentLimit { get; set; }
        public int SectionId { get; set; }

#nullable enable

        public int? MaximumAttachmentSizeLimit { get; set; }

#nullable disable

        #endregion

        #region Navigational properties

        public Section Section { get; set; }
        public List<AssignmentSubmissions> AssignmentSubmissions { get; set; }
        public List<Attachment> Attachments { get; set; }

        #endregion
    }
}
