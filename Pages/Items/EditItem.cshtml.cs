using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Absence.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Absence.Pages.Shop
{
  [Authorize(Policy = "MustBeAdmin")]
    public class EditItemModel : PageModel
    {
        private ItemService itemService;
        
        [BindProperty]
        public Models.Item Item { get; set; }

        
        public IActionResult OnGet(int id)
        {
            Item = itemService.GetItem(id);
            if (Item == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }
        public EditItemModel(ItemService itemService)
        {
            this.itemService = itemService;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            itemService.UpdateItem(Item);
            return RedirectToPage("GetAllItems");
        }
    }
}
