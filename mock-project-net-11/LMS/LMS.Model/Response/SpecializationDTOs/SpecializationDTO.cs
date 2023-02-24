using System;

namespace LMS.Model.Response.SpecializationDTOs
{
    public class SpecializationDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        
    }
}