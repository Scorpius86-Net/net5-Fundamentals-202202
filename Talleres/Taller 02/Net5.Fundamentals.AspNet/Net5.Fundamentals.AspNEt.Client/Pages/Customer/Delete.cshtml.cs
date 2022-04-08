using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Net5.Fundamentals.AspNet.Client.Pages.Customer
{
    using Net5.Fundamentals.AspNet.Data.Entities;
    using Net5.Fundamentals.AspNet.Data.Repositories;

    public class DeleteModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;
        [BindProperty]
        public Customer Customer { get; set; }

        public DeleteModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = _customerRepository.Get(id.Value);

            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if(Customer != null)
            {
                _customerRepository.Remove(id.Value);
            }
            
            return RedirectToPage("./Index");
        }
    }
}
