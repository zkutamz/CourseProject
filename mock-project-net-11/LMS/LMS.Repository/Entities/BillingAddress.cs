namespace LMS.Repository.Entities
{
    public class BillingAddress
    {
        #region Properties

        public int UserId { get; set; }
        
#nullable enable
        public string? FirstName { get; set; }
#nullable disable
#nullable enable
        public string? LastName { get; set; }
#nullable disable
#nullable enable
        public string? AcademyName { get; set; }
#nullable disable
#nullable enable
        public string? Country { get; set; }
#nullable disable
#nullable enable
        public string? AddressLine1 { get; set; }
#nullable disable
#nullable enable
        public string? AddressLine2 { get; set; }
#nullable disable
#nullable enable
        public string? City { get; set; }
#nullable disable
#nullable enable
        public string? Province { get; set; }
#nullable disable
#nullable enable
        public int? PostalCode { get; set; }
#nullable disable
#nullable enable
        public string? PhoneNumber { get; set; }
#nullable disable
#nullable enable
        public string? EmailPaypal { get; set; }
#nullable disable
        #endregion

        #region Navigatinal Properties
        public int WithdrawalMethodId { get; set; }
        public WithdrawalMethod WithdrawalMethod { get; set; }
        public AppUser User { get; set; }
        #endregion

    }
}
