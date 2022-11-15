namespace ContactPro.Models
{
    public class MailSettings
    {
        //this class mimics out mail settings info made in secrets
        public string? Email { get; set; }

        public string? MailPassword { get; set; }

        public string? DisplayName { get; set; }

        public string? MailHost { get; set; }

        public int MailPort { get; set; }
    }
}
