using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    public class User: IEquatable<User>
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public bool IsConnect { get; set; }
        public User(string login, string password)
        {
            Login = login;
            Password = password;
            IsConnect = false;
        }
        public bool Equals(User other)
        {
            return Login == other.Login;
        }
        public override string ToString()
        {
            return $"{Login}%{Password}";
        }
    }
}
