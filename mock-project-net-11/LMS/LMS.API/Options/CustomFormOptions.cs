namespace LMS.API.Options
{
    public class CustomFormOptions
    {
        public const string CustomForm = "Configurations";

        public string MultipartBodyLengthLimit { get; set; }
        public string MaxRequestBodySize { get; set; }
    }
}
