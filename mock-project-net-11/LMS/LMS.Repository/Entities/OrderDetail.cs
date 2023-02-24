using System;

namespace LMS.Repository.Entities
{
    public class OrderDetail : BaseEntity
    {
        public decimal Price { get; set; }
        public int CourseId { get; set; }
        public int OrderHeaderId { get; set; }

        #region Navigational Properties
        /// <summary>
        /// relationship 1:N OrderHeader
        /// </summary>
        public OrderHeader OrderHeader { get; set; }

        /// <summary>
        /// relationship 1:N Course
        /// </summary>
        public Course Course { set; get; }
        #endregion
    }
}