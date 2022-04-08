using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Net5.Fundamentals.AspNet.Data.Repositories;
using System.Collections.Generic;

namespace Net5.Fundamentals.AspNet.Client.Pages.Customer
{
    using Net5.Fundamentals.AspNet.Data.Entities;

    public class IndexModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;
        public List<Customer> Customers { get; set; }

        public IndexModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void OnGet()
        {
            Customers = _customerRepository.List();
        }
    }
}
