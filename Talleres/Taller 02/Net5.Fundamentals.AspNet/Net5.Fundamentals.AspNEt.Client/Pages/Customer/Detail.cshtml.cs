using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Net5.Fundamentals.AspNet.Data.Repositories;

namespace Net5.Fundamentals.AspNet.Client.Pages.Customer
{
    using Net5.Fundamentals.AspNet.Data.Entities;
    public class DetailModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;
        public Customer Customer { get; set; }

        public DetailModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer customer = _customerRepository.Get(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
