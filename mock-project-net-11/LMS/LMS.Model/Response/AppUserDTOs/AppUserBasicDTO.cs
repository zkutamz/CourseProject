namespace LMS.Model.Response.AppUserDTOs
{
    public class AppUserBasicDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => FirstName + " " + LastName; }
        public string Intro { get; set; }
    }
}
