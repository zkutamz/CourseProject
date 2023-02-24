namespace LMS.Repository.Context
{
    public class DatabaseSettingsOptions
    {
        public const string DatabaseSetting = "Setting:DatabaseSettings";

        public int MaxPoolSize { get; set; }
        public int MinPoolSize { get; set; }
        public string Database { get; set; }
        public string Server { get; set; }
    }
}
