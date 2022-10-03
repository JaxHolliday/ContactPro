using ContactPro.Models;

namespace ContactPro.Services.Interfaces
{
    public interface IAddressBookService
    {
        public Task AddContactToCategoryAsync(int categoryId, int contactId);

        public Task<bool> IsContactInCategory(int categoryId, int contactId);

        public Task<IEnumerable<Category>> GetUserCategoriesAsync(string userId);

        public Task<ICollection<int>> GetContactCategoryIdsAsync(int contactId);

        public Task<ICollection<Category>> GetContactCategoriesAsync(int contactId);

        public Task RemoveContactFromCategoryAsync(int categoryId, int contactId);

        public IEnumerable<Contact> SearchForContacts(string searchString, string userId);
    }
}
