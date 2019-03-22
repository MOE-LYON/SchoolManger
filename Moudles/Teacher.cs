using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Teacher:User
    {
        private static int cuurid;
        public Teacher(string name, string password, string id=null):base(name,password)
        {
            if (id == null)
            {

            }
            else this.id = id;
            this.role = Role.teacher;
        }

        public override string GetNewID()
        {
            return string.Format("T{0}{1:D3}",DateTime.Now.Year, cuurid);
        }
    }
}
