using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Absence.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Absence.Pages.Item
{
    [Authorize(Policy = "MustBeAdmin")]
    public class DeleteItemModel : PageModel
    {
        private ItemService itemService;

        [BindProperty]
        public Models.Item Item { get; set; }

        public DeleteItemModel(ItemService itemService)
        {
            this.itemService = itemService;
        }
        public IActionResult OnGet(int id)
        {
            Item = itemService.GetItem(id);
            if (Item == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }

        public IActionResult OnPost()
        {
            Models.Item deletedItem = itemService.DeleteItem(Item.Id);
            if (deletedItem == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu
            return RedirectToPage("GetAllItems");
        }
    }
}
