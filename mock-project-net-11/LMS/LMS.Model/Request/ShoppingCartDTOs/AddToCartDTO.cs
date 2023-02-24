using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Request.ShoppingCartDTOs
{
    public class AddToCartDTO
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
