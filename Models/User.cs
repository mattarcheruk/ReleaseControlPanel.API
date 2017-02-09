namespace ReleaseControlPanel.API.Models
{
    public class User
    {
        public string CiBuildApiToken { get; set; }
        public string CiBuildUserName { get; set; }
        public string CiQaApiToken { get; set; }
        public string CiQaUserName { get; set; }
        public string CiStagingApiToken { get; set; }
        public string CiStagingUserName { get; set; }
        public string FullName { get; set; }
        public string JiraPassword { get; set; }
        public string JiraUserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string UserName { get; set; }
        public string UserSecret { get; set; }
    }
}