using LMS.Repository.Enums;
using System;

namespace LMS.Model.Response.FeedbackDTOs
{
    public class FeedbackDTO
    {
        #region Properties
        public int Id { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public FeedbackStatus Status { get; set; }
        #endregion
        #region Relationship Properties
        public int UserId { get; set; }
        #endregion
    }
}
