namespace ContactPro.Models
{
    public class MailSettings
    {
        //this class mimics out mail settings info made in secrets
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? DisplayName { get; set; }

        public string? Host { get; set; }

        public int Port { get; set; }
    }
}
