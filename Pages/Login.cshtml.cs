using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Absence.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credentials { get; set; }
        
        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
             

            // Verify Credential
            if(Credentials.UserName == "admin" && Credentials.Password == "password")
            {

                //Creating Security Context
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@admin.com"),
                    new Claim("Department", "Admin")

                };
                
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                HttpContext.Session.SetInt32("Login", 1);
                HttpContext.Session.SetString("username", Credentials.UserName);
                //ViewData["Logstatus"] = "logout";

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                
                
                return RedirectToPage("/Index");
            }
            else
            {
                
            }

            return Page();
            
        }
        
        public class Credential
        {
            [Required]
            [Display(Name = "User Name")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
    }
}
