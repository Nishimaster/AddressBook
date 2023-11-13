using System.Diagnostics;

namespace AddressBook.Models.AddressBook
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private readonly IAddressBookJSONContext _addressBookJSONContext;

        public AddressBookRepository(IAddressBookJSONContext addressBookJSONContext)
        {
            _addressBookJSONContext = addressBookJSONContext;
        }

        public void AddAddressBookEntry(AddressBookEntry entry)
        {
            _addressBookJSONContext.addresses.Add(entry);
            _addressBookJSONContext.WriteToFile();
        }

        public IEnumerable<AddressBookEntry> AllAddresses()
        {
            return _addressBookJSONContext.addresses;
        }

        public void DeleteAddressBookEntry(AddressBookEntry entry)
        {
            //i'm sure there's a better way of doing this - I'd rather use unique ID's for each address data
            //to avoid having to check on every value, but i'm opting to use the example JSON provided
            
            var item = _addressBookJSONContext.addresses.First(
            x => 
                (x.first_name == entry.first_name) && 
                (x.last_name==entry.last_name) &&
                (x.email == entry.email) &&
                (x.phone_number == entry.phone_number));
            _addressBookJSONContext.addresses.Remove(item);
            _addressBookJSONContext.WriteToFile();
        }

        public IEnumerable<AddressBookEntry> SearchAddresses(string searchQuery)
        {
            //which things to compare to the search query will vary based on specifications - doing all for now
            return _addressBookJSONContext.addresses.Where(x =>
            ((x.first_name ?? "").ToLower().Contains(searchQuery.ToLower())) ||
            ((x.last_name ?? "").ToLower().Contains(searchQuery.ToLower())) ||
            ((x.phone_number ?? "").ToLower().Contains(searchQuery.ToLower())) ||
            ((x.email ?? "").ToLower().Contains(searchQuery.ToLower()))
            );
        }

        public void UpdateAddressBookEntry(AddressBookEntry original, AddressBookEntry newAddress)
        {
            //i'm sure there's a better way of doing this - I'd rather use unique ID's for each address data
            //to avoid having to check on every value, but i'm opting to use the example JSON provided
            var toUpDateItem = _addressBookJSONContext.addresses.First(
                x =>
                (x.first_name == original.first_name) &&
                (x.last_name == original.last_name) &&
                (x.email == original.email) &&
                (x.phone_number == original.phone_number));

            toUpDateItem.first_name = newAddress.first_name;
            toUpDateItem.last_name = newAddress.last_name; ;
            toUpDateItem.phone_number = newAddress.phone_number;
            toUpDateItem.email = newAddress.email;

            _addressBookJSONContext.WriteToFile();
        }
    }
}
