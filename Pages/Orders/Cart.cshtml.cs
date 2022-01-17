using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Absence.Models;
using Absence.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Absence.Pages
{
    public class CartModel : PageModel
    {
        public int NoOfItems;
        public static List<Order> OrderList = new List<Order>();

        public Order(int id, int noOfItems)
        {
            id = OrderList.Count + 1;
            noOfItems = NoOfItems;
        }
        public List<Models.Item> cart { get; set; }
        public double Total { get; set; }

        public void OnGet()
        {

        }
    }
}
