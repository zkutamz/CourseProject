using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Entities
{
    public class WithdrawalMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<BillingAddress> BillingAddresses { get; set; }
    }
}
