namespace LMS.Service.Options
{
    public class JwtTokenOptions
    {
        public const string JwtToken = "Tokens";

        public string Key { get; set; }
        public string Issuer { get; set; }
        public int Expires { get; set; }
    }
}
