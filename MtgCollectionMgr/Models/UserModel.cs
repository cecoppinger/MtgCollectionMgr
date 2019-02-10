using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtgCollectionMgr.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }

        public IList<CardCollectionModel> CardCollection { get; set; }

        public UserModel() { }
        public UserModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
