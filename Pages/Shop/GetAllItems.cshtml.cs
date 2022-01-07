using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Absence.Models;
using Absence.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Absence.Pages
{
    public class GetAllItemsModel : PageModel
    {
        private ItemService itemService;
        public List<Models.Item> Items { get; private set; }
        [BindProperty] public string SearchString { get; set; }
        [BindProperty] public int MaxPrice { get; set; }
        [BindProperty] public int MinPrice { get; set; }

        public GetAllItemsModel(ItemService itemService) //Dependency Injection
        {
            this.itemService = itemService;
        }

        public IActionResult OnGet()
        {
            //if (MyAuthCookie == false)
            //{
            //    return RedirectToPage("Index");
            //}
            Items = itemService.GetItems().ToList();
            return Page();
        }

        public IActionResult OnPostNameSearch()
        {
            Items = itemService.NameSearch(SearchString).ToList();
            return Page();
        }

        public IActionResult OnPostPriceFilter(int maxPrice, int minPrice = 0)
        {
            Items = itemService.PriceFilter(maxPrice, minPrice).ToList();
            return Page();
        }
    }
}
