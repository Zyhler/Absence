using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Absence.Models
{
    public class User
    {
       

        public int Id { get; set; }
        public string Mail { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        
        public string Password { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public string Phone { get; set; }
        public bool AuthLvL { get; set; }
        public int NrOrders { get; set; }
        public int NrDelivs { get; set; }

        //public List<Order> OrderList { get; set; }
        //public List<Delivery> DeliveryList { get; set; }


        public User()
        {

        }
        public User(int id, string mail, string firstName, string surName,string password, string address, int zip, string phone, bool authLvL, int nrOrders, int nrDelivs)
        {
                    Id = id;
                    //OrderList = orderList;
                    //DeliveryList = deliverylist;
                    Mail = mail;
                    FirstName = firstName;
                    SurName = surName;
                    Password = password;
                    Address = address;
                    Zip = zip;
                    Phone = phone;
                    AuthLvL = authLvL;
                    NrOrders = nrOrders;
                    NrDelivs = nrDelivs;
            }



    }
    
    //public interface IUserService
    //{
    //    List<User> ReadAll();
    //}

    //public class UserService : IUserService
    //{
    //    public List<User> ReadAll()
    //    {
    //        List<User> users = new List<User>
    //            {
    //                new User{Id = 1 , Mail = "Admin@Absence.com", FirstName = "Adminton", SurName = "King", Address = "Admin Ave. 13", Zip = 4200, Phone = "99999999", AuthLvL = true, NrOrders = 0, NrDelivs = 0}
    //            };
    //        return users;
    //    }
    //}
    

   
}
