using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Teacher:User
    {
        public static int cuurid;
        public Teacher(string name, string password, string id=null):base(name,password)
        {
            if (id == null)
            {
                this.id = GetNewID();
            }
            else this.id = id;
            this.role = Role.teacher;
        }

        public override string GetNewID()
        {
            return string.Format("T{0}{1:D3}",DateTime.Now.Year, cuurid++);
        }
    }
}
