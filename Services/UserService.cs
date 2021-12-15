using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Absence.Models;
//using Absence.MockData;


namespace Absence.Services
{
    public class UserService : IUserService
    {

        private List<User> users;
        private JsonFileUserService JsonFileUserService { get; set; }

        public UserService(JsonFileUserService jsonFileUserService)
        {
            JsonFileUserService = jsonFileUserService;
            //users = Mockusers.GetMockusers();
            users = JsonFileUserService.GetJsonUsers().ToList();
        }

        public void AddUser(User user)
        {
            users.Add(user);
            JsonFileUserService.SaveJsonUsers(users);
        }

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User GetUser(int id)
        {
            foreach (User oneUser in users)
            {
                if (oneUser.Id == id) return oneUser;
            }
            return null;
        }

        //public user Deleteuser(int userId)
        //{
        //    user userToBeDeleted = null;
        //    foreach (user i in users)
        //    {
        //        if (i.Id == userId)
        //        {
        //            userToBeDeleted = i;
        //            break;
        //        }

        //    }

        //    if (userToBeDeleted != null)
        //    {
        //        users.Remove(userToBeDeleted);
        //        JsonFileuserService.SaveJsonusers(users);
        //    }

        //    return userToBeDeleted;
        //}


        public void Updateuser(User user)
        {
            if (user != null)
            {
                foreach (User i in users)
                {
                    if (i.Id == user.Id)
                    {
                        //i.Name = user.Name;
                        //i.Price = user.Price;
                    }
                }
                JsonFileUserService.SaveJsonUsers(users);
            }
        }

        //public IEnumerable<User> NameSearch(string str)
        //{
        //    List<user> nameSearch = new List<user>();
        //    foreach (user user in users)
        //    {
        //        if (user.Name.ToLower().Contains(str.ToLower()))
        //        {
        //            nameSearch.Add(user);
        //        }
        //    }

        //    return nameSearch;
        //}

       

    }
}
