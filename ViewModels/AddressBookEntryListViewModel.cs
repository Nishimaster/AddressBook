using AddressBook.Models.AddressBook;

namespace AddressBook.ViewModels
{
    public class AddressBookEntryListViewModel
    {
        public IEnumerable<AddressBookEntry> AddressBookEntries { get; }

        public AddressBookEntryListViewModel(IEnumerable<AddressBookEntry> addresses)
        {
            AddressBookEntries = addresses;
        }
    }
}
