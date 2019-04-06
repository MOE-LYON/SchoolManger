using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Admin:User
    {
        public static int currid;
        public Admin( string name, string password,string ID=null):base(name, password)
        {
            if (ID == null)
            {
                this.id = GetNewID();
            }
            else id = ID;
            this.role = Role.admin;
        }
        public override string GetNewID()
        {
            return string.Format("A{0:D2}", currid++);
        }
    }
}
