using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Absence.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public double TotalPrice { get; set; }

        public List<Models.Item> Items { get; set; }

        public Order()
        {

        }
        public Order(int id,int userid, string name, double totalprice,List<Models.Item> items)
        {
            Id = id;
            Name = name;
            UserID = userid;
            TotalPrice = totalprice;
            Items = items;
        }


    }
}
