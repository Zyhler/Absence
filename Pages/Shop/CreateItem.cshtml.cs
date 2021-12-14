using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Absence.Models;
using Absence.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Absence.Pages
{
    public class CreateItemModel : PageModel
    {
        private ItemService itemService;
        private List<Models.Item> items;
       
        [BindProperty]
        public Models.Item Item { get; set; }

        public CreateItemModel(ItemService iS)
        {
            itemService = iS;
            items = itemService.GetItems().ToList();
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
            itemService.AddItem(Item);
            return RedirectToPage("GetAllItems");
        }

    }
}
