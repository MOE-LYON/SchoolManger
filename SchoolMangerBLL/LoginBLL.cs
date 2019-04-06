using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMangerDAL;
using SchoolMangerBLL;
using Models;
namespace SchoolMangerBLL
{
    public class LoginBLL:BaseBLL
    {
        public static bool login(string user_id, string user_passwd, out string err)
        {
            err = string.Empty;
            user_id = user_id.ToUpper();
            switch(user_id[0])
            {
                case 'S': user = students.Retrieve(user_id); break;
                case 'T': user = teachers.Retrieve(user_id); break;
                case 'A': user = admins.Retrieve(user_id); break;
                default: err = "账号id错误请重新尝试"; return false;
            }
            if(user==null)
            {
                err = "账户不存在";
                return false;
            }
            if (user.CheckPasswd(user_passwd))
            {
                return true;
            }
            else
            {
                err = "密码错误请仔细检查";
                user = null;
                return false;
            }
        }
    }
}
