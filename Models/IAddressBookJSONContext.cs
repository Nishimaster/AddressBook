using AddressBook.Models.AddressBook;

namespace AddressBook.Models
{
    public interface IAddressBookJSONContext
    {
        ICollection<AddressBookEntry> addresses { get; set; }
        void WriteToFile();
    }
}
