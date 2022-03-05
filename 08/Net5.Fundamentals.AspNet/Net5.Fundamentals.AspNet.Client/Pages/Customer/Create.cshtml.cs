using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Net5.Fundamentals.AspNet.Data.Repositories;

namespace Net5.Fundamentals.AspNet.Client.Pages.Customer
{
    public class CreateModel : PageModel
    {
        private readonly CustomerRepository _customerRepository;
        [BindProperty]
        public Data.Entities.Customer Customer { get; set; }
        public CreateModel(CustomerRepository customerRepository)
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
