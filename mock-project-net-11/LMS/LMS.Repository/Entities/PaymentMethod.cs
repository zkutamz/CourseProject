using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public string Name { get; set; }

        public List<OrderHeader> OrderHeaders { get; set; }
    }
}
