using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Net5.Fundamentals.AspNet.Data.Repositories;

namespace Net5.Fundamentals.AspNet.Client.Pages.Customer
{
    public class DeleteModel : PageModel
    {
        private readonly CustomerRepository _customerRepository;
        [BindProperty]
        public Data.Entities.Customer Customer { get; set; }
        public DeleteModel(CustomerRepository customerRepository)
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

            if (Customer != null)
            {
                _customerRepository.Remove(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
