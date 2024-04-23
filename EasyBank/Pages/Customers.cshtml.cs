using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyBank.Pages
{
    public class CustomersModel : PageModel
    {

        private readonly BankAppDataContext _dbContext;

        public CustomersModel(BankAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public class CustomersViewModel
        {
            public int Id { get; set; }
            public string Givenname { get; set; } = null!;

            public string Surname { get; set; } = null!;
        }

        public List<CustomersViewModel> Customers { get; set; }
    = new List<CustomersViewModel>();


        public void OnGet()
        {
            Customers = _dbContext.Customers.Select(c=> new CustomersViewModel
            {
                Id = c.CustomerId,
                Givenname = c.Givenname,
                Surname = c.Surname
            }).ToList();

        }
    }
}
