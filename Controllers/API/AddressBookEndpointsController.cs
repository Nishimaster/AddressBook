using AddressBook.Models.AddressBook;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace AddressBook.Controllers.API
{
    public class AddressBookEndpointsController : ControllerBase
    {
        private readonly IAddressBookRepository _addressRepository;

        public AddressBookEndpointsController(IAddressBookRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_addressRepository.AllAddresses());
        }

        [HttpPost]
        public IActionResult SearchAddresses([FromBody] string searchQuery)
        {
            IEnumerable<AddressBookEntry> addresses = new List<AddressBookEntry>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                addresses = _addressRepository.SearchAddresses(searchQuery);
            }

            return new JsonResult(addresses);
        }

        [HttpDelete]
        public IActionResult DeleteAddress([FromBody] AddressBookEntry entry)
        {
            try
            {
                _addressRepository.DeleteAddressBookEntry(entry);
                return Ok();
            }
            catch {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody]AddressBookEntry entry)
        {
            try
            {
                _addressRepository.AddAddressBookEntry(entry);
                return Ok();
            }
            catch
            {
                return BadRequest("Request should be a JSON object consisting of first_name, last_name, phone_number and email.");
            }
        }

        [HttpPut]
        public IActionResult UpdateAddress([FromBody] AddressBookEntry[] entry)
        {
            try
            {
                _addressRepository.UpdateAddressBookEntry(entry[0], entry[1]);
                return Ok();
            }
            catch
            {
                return BadRequest("Request should be an array of 2 JSON objects, each consisting of first_name, last_name, phone_number and email. " +
                    "The first one is the Original, the 2nd is the updated version.");
            }
        }
    }
}
