namespace LMS.API.Options
{
    public class SwaggerSecurityRequirementOptions
    {
        public const string SwaggerSecurityRequirement = "Configurations:SecurityRequirement";

        public string Id { get; set; }
        public string Scheme { get; set; }
        public string Name { get; set; }
    }
}
