using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Absence.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace Absence.Pages
{
    public class CreateLoginModel : PageModel
    {
        
        private UserService userService;
        private List<Models.User> users;

        [BindProperty]
        public Models.User User { get; set; }

        public CreateLoginModel(UserService iS)
        {
            userService = iS;
            users = userService.GetUsers().ToList();
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

            User.Id = users.Count + 1;
            userService.AddUser(User);
            
            return RedirectToPage("index");
        }

    }
    //public void OnGet()
    //    {

    //    }

        

}


