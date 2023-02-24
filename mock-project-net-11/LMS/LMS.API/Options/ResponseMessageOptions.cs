namespace LMS.API.Options
{
    public class ResponseMessageOptions
    {
        public const string ResponseMessages = "Constants:ResponseMessages";

        public string AddFailure { get; set; }
        public string AddRangeFailure { get; set; }
        public string DeleteFailure { get; set; }
        public string UpdateFailure { get; set; }
        public string AddSuccess { get; set; }
        public string UpdateSuccess { get; set; }
        public string DeleteSuccess { get; set; }
        public string LoginFailure { get; set; }
        public string IncorrectPassword { get; set; }
        public string RevokedToken { get; set; }
        public string EmailExist { get; set; }
        public string RegisterFailure { get; set; }
        public string AccessDenied { get; set; }
        public string NotMatch { get; set; }
        public string GetDataSuccess { get; set; }
        public string GetDataFailed { get; set; }
        public string CouponUse { get; set; }
        public string InDiscount { get; set; }
        public string ExistCartItem { get; set; }
        public string EndDate { get; set; }
        public string AddMediaWithoutCourse { get; set; }
        public string TitleMaxLengthInvalid { get; set; }
        public string ShortDescriptionMaxLengthInvalid { get; set; }
        public string AddPriceWithoutCourse { get; set; }
        public string ErrorOccurred { get; set; }
        public string InvalidParameters { get; set; }
        public string NotFound { get; set; }
        public string CertificateAlreadyExist { get; set; }
        public string InvalidId { get; set; }
    }
}
