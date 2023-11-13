using AddressBook.Models;
using AddressBook.Models.AddressBook;
using AddressBook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAddressBookRepository _addressRepository;

        public HomeController(IAddressBookRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public IActionResult Index()
        {
            var addresses = _addressRepository.AllAddresses();
            AddressBookEntryListViewModel viewModel = new AddressBookEntryListViewModel(addresses);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(string? searchQuery)
        {
            IEnumerable<AddressBookEntry> addresses;
            if (searchQuery != null)
            {
                addresses = _addressRepository.SearchAddresses(searchQuery);
            }
            else
            {
                addresses = _addressRepository.AllAddresses();
            }

            AddressBookEntryListViewModel viewModel = new AddressBookEntryListViewModel(addresses);
            return View(viewModel);
        }

        //not a fan of having all these parameters, but i'm avoiding using an ID because it wasn't in the example JSON 
        public RedirectToActionResult RemoveAddress(string fname, string lname, string phone, string email)
        {
            _addressRepository.DeleteAddressBookEntry(new AddressBookEntry() { first_name = fname, last_name = lname, email = email, phone_number = phone });
            return RedirectToAction("Index");
        }

        public RedirectToActionResult AddAddress(string fname, string lname, string phone, string email)
        {
            _addressRepository.AddAddressBookEntry(new AddressBookEntry() { first_name = fname, last_name = lname, email = email, phone_number = phone });
            return RedirectToAction("Index");
        }

        //this one is especially clunky without use of an ID
        public RedirectToActionResult UpdateAddress(string fname, string lname, string phone, string email, string ofname, string olname, string ophone, string oemail)
        {
            _addressRepository.UpdateAddressBookEntry(
                new AddressBookEntry() { first_name = ofname, last_name = olname, email = oemail, phone_number = ophone }, //original
                new AddressBookEntry() { first_name = fname, last_name = lname, email = email, phone_number = phone }); //new
            return RedirectToAction("Index");
        }
    }
}