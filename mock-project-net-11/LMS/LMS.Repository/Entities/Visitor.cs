using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Entities
{
    public class Visitor:BaseEntity
    {
        #region Properties
        public int CourseId { get; set; }
        public int UserId { get; set; }//person who watch this course
        #endregion

        #region Relationship
        public AppUser User { get; set; }
        public Course Course { get; set; }
        #endregion


    }
}
