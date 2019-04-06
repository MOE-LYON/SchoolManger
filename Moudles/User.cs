using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public enum Role
    {
        student=1,
        teacher=2,
        admin=3
    }
    [Serializable]
    public abstract class User
    {
        protected string id;
        protected Role role;
        protected string password;
        protected string name;
        public string ID
        {
            get { return id;}
        }

        public string Password
        {
            set { password=value; }
        }
        public string Name
        {
            get { return name; }
        }

        public abstract string GetNewID();
        public User(string name,string password)
        {
            this.name = name;
            this.password = password;
        }
        public bool CheckPasswd(string passwd)
        {
            return this.password == passwd;
        }
        public Role getRole()
        {
            return role;
        }
    }
}
