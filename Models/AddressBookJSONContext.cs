using AddressBook.Models.AddressBook;
using AddressBook.Utils;

namespace AddressBook.Models
{
    public class AddressBookJSONContext : IAddressBookJSONContext
    {
        private ICollection<AddressBookEntry>? _addresses;
        public ICollection<AddressBookEntry> addresses {
            get {
                if (_addresses == null)
                { _addresses = JsonFileReader.Read<ICollection<AddressBookEntry>>("data/addressbook.json"); }
                return _addresses;
            }

            set {
                _addresses = value;
            }
        }

        public void WriteToFile()
        {
            JsonFileWriter.Write<ICollection<AddressBookEntry>>(_addresses, "data/addressbook.json");
        }
    }
}
