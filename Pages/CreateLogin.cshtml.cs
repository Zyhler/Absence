using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace Absence.Pages
{
    public class CreateLoginModel : PageModel
    {

        public void OnGet()
        {
        }

        public class User
        {
            public int Id { get; set; }
            public string Mail { get; set; }
            public string FirstName { get; set; }
            public string SurName { get; set; }
            public string Address { get; set; }
            public int Zip { get; set; }
            public string Phone { get; set; }
            public bool AuthLvL { get; set; }
            public int NrOrders { get; set; }
            public int NrDelivs { get; set; }

        }

        public interface IUserService
        {
            List<User> ReadAll();
        }

        public class UserService : IUserService
        {
            public List<User> ReadAll()
            {
                List<User> users = new List<User>
                {
                    new User{Id = 1 , Mail = "Admin@Absence.com", FirstName = "Adminton", SurName = "King", Address = "Admin Ave. 13", Zip = 4200, Phone = "99999999", AuthLvL = true, NrOrders = 0, NrDelivs = 0}
                };
                return users;
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IUserService, UserService>();

        }

    }

}
