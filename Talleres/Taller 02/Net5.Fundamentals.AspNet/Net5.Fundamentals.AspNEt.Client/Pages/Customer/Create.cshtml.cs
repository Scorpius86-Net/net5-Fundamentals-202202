using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net5.Fundamentals.AspNet.Client.Pages.Customer
{
    using Net5.Fundamentals.AspNet.Data.Entities;
    using Net5.Fundamentals.AspNet.Data.Repositories;

    public class CreateModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;
        [BindProperty]
        public Customer Customer { get; set; }

        public CreateModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Customer = _customerRepository.Insert(Customer);

            return RedirectToPage("./Index");
        }
    }
}
