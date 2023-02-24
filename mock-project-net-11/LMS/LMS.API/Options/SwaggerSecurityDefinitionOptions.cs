namespace LMS.API.Options
{
    public class SwaggerSecurityDefinitionOptions
    {
        public const string SwaggerSecurityDefinition = "Configurations:SwaggerSecurityDefinition";

        public string SecurityDefinitionName { get; set; }
        public string Schema { get; set; }
        public string SecuritySchemaName { get; set; }
        public string Description { get; set; }
    }
}
