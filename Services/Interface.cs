using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Absence.Models;

namespace Absence.Services
{
    interface IItemService
    {
        IEnumerable<Item> GetItems();
        void AddItem(Item item);

        IEnumerable<Item> NameSearch(string str);

        IEnumerable<Item> PriceFilter(int maxPrice, int minPrice = 0);
    }
    interface IUserService
    {
        IEnumerable<User> GetUsers();
        void AddUser(User user);
    }
}
