using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Absence.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Absence.Pages
{
    public class ShopModel : PageModel
    {
        
       //public string UpdateCheck = "Not Updated";
           private ItemService itemService;
           public List<Models.Item> Items { get; private set; }
           [BindProperty] public string SearchString { get; set; }
           [BindProperty] public int MaxPrice { get; set; }
           [BindProperty] public int MinPrice { get; set; }
        public ShopModel(ItemService itemService) //Dependency Injection
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
               //UpdateCheck = "updated";
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
