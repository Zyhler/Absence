using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Absence.Models;
//using Absence.MockData;


namespace Absence.Services
{
    public class ItemService : IItemService
    {

        private List<Item> items;
        private JsonFileItemService JsonFileItemService { get; set; }

        public ItemService(JsonFileItemService jsonFileItemService)
        {
            JsonFileItemService = jsonFileItemService;
            //items = MockItems.GetMockItems();
            items = JsonFileItemService.GetJsonItems().ToList();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
            JsonFileItemService.SaveJsonItems(items);
        }

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(int id)
        {
            foreach (Item item in items)
            {
                if (item.Id == id) return item;
            }
            return null;
        }

        public Item DeleteItem(int itemId)
        {
            Item itemToBeDeleted = null;
            foreach (Item i in items)
            {
                if (i.Id == itemId)
                {
                    itemToBeDeleted = i;
                    break;
                }

            }

            if (itemToBeDeleted != null)
            {
                items.Remove(itemToBeDeleted);
                JsonFileItemService.SaveJsonItems(items);
            }

            return itemToBeDeleted;
        }


        public void UpdateItem(Item item)
        {
            if (item != null)
            {
                foreach (Item i in items)
                {
                    if (i.Id == item.Id)
                    {
                        i.Name = item.Name;
                        i.Price = item.Price;
                    }
                }
                JsonFileItemService.SaveJsonItems(items);
            }
        }

        public IEnumerable<Item> NameSearch(string str)
        {
            List<Item> nameSearch = new List<Item>();
            foreach (Item item in items)
            {
                if (item.Name.ToLower().Contains(str.ToLower()))
                {
                    nameSearch.Add(item);
                }
            }

            return nameSearch;
        }

        public IEnumerable<Item> PriceFilter(int maxPrice, int minPrice = 0)
        {
            List<Item> filterList = new List<Item>();
            foreach (Item item in items)
            {
                if (item.Price>=minPrice && item.Price<=maxPrice)
                {
                    filterList.Add(item);
                }
            }

            return filterList;
        }

    }
}
