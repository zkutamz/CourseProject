using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.CourseDTOs
{
    public class CourseTitlePriceDTO:CourseTitleDTO
    {
        public decimal Price { get; set; }
    }
}
