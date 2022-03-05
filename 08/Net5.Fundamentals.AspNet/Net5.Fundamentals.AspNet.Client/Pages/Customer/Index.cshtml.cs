using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Net5.Fundamentals.AspNet.Data.Helpers;
using Net5.Fundamentals.AspNet.Data.Repositories;
using System.Collections.Generic;

namespace Net5.Fundamentals.AspNet.Client.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly CustomerRepository _customerRepository;
        public List<Data.Entities.Customer> Customers { get; set; }

        public IndexModel(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void OnGet()
        {
            Customers = _customerRepository.List();
        }
    }
}
