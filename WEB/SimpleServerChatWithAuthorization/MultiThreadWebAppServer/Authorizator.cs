using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    public class Authorizator
    {
        public static List<User> UserLogons { get; set; } = new List<User>();
        private AuthorizationLogger  _authorizationLogger = new AuthorizationLogger();
        public Authorizator()
        {
            var usersData =  _authorizationLogger.ReadFile();
            foreach (var user in usersData)
            {
                var data = user.Split('%');
                UserLogons.Add(new User(data[0], data[1]));
            } 
        }

        public bool CheckAuthorization(User user)
        {
            int index = GetIndexUser(user);
            if(index == -1 || UserLogons[index].Password != user.Password)
                return false;
         
            return !UserLogons[index].IsConnect;
        }

        public bool Registration(User user)
        {
            int index = GetIndexUser(user);
            if (index == -1)
            {
                UserLogons.Add(user);
                _authorizationLogger.SaveData(user.ToString());
                return true;
            }
            else
                return false;
        }

        public int GetIndexUser(User user)
        {
            return UserLogons.FindIndex(0, UserLogons.Count, u => user.Equals(u));
        }

        public void SetUserConnectStatus(User user)
        {
            if (user == null)
                return;
            int index = GetIndexUser(user);
            
            if(index != -1)
                UserLogons[index].IsConnect = user.IsConnect;
        }
    }
}
