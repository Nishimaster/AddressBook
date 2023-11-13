using System.IO.Pipelines;

namespace AddressBook.Models.AddressBook
{
    public interface IAddressBookRepository
    {
        IEnumerable<AddressBookEntry> AllAddresses();
        IEnumerable<AddressBookEntry> SearchAddresses(string searchQuery);
        void AddAddressBookEntry(AddressBookEntry entry);
        void UpdateAddressBookEntry(AddressBookEntry original, AddressBookEntry newAddress);
        void DeleteAddressBookEntry(AddressBookEntry entry);
    }
}
