namespace ContactPro.Models.ViewModels
{
    public class EmailCategoryViewModel
    {
        //holds all memebers of the category
        public List<Contact>? Contacts { get; set; }
        public EmailData? EmailData { get; set; }
    }
}
