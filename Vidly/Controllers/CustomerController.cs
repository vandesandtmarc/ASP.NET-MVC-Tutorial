using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/ ! Action !

        //Action 
        // FIRST IS JUST /CUSTOMERS TO SHOW LIST OF CUSTOMERS
        // ON CLICK OF A CUSTOMER, GO TO NEW VIEW THAT JUST DISPLAYS THAT NAME , URL CHANGES FROM CUSTOMERS TO CUSTOMERS/DETAILS/ID (1,2 OR 3) ETC

        List<Customer> CustomerList = new List<Customer>();


        public void populateCustomers()
        {
            CustomerList = new List<Customer>
            {
                new Customer {Name = "John Smith", Id = 1},
                new Customer{ Name = "Mary Williams", Id = 2}
            };
        }

        [Route("customers")]
        public ActionResult AllCustomers()

        {
            if (CustomerList.Count < 1)
                populateCustomers();
            var viewmodel = new CustomerViewModel();
            viewmodel.Customers = CustomerList;

            return View(viewmodel);
        }

        [Route("Details/Customers/{id}")]
        public ActionResult SelectCustomer(int id)
        {
            if (CustomerList.Count < 1)
                populateCustomers();
            Customer customer = CustomerList.SingleOrDefault(p => p.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new SingleCustomer();
            viewmodel.name = customer.Name;
            return View(viewmodel);
        }

    }
}