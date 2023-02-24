using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Entities
{
    public class PrivacySetting
    {
        #region Properties
        public int UserId { get; set; }
        public bool ShowYourProfileOnSearchEngines { get; set; }
        public bool ShowCoursesYouAreTakingOnYourProfilePage { get; set; }
        #endregion

        #region RelationProperties
        public AppUser User { get; set; }
        #endregion
    }
}
