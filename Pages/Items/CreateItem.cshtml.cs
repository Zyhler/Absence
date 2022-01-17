using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Absence.Models;
using Absence.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Absence.Pages
{
    [Authorize(Policy = "MustBeAdmin")]
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
        public void AssignID()
        {
            //foreach (Models.Item oneItem in items)
            //{
            //    oneItem.Id = items.IndexOf(oneItem) + 1;
            //}
            Item.Id = items.Last().Id + 1;
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
            AssignID();
            itemService.AddItem(Item);
            return RedirectToPage("GetAllItems");
        }

    }
}
