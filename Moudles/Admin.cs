using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Admin:User
    {
        private static int currid;
        public Admin(string ID, string name, string password):base(name,password)
        {
            this.id = ID;
            this.role = Role.admin;
        }
        public override string GetNewID()
        {
            return string.Format("A{0:D2}", currid);
        }
    }
}
