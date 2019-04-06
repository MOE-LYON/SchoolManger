using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using SchoolMangerBLL;
namespace SchoolMangerUI
{
    public class LoginUI
    {
        internal static User login()
        {
            Console.WriteLine(@"
╔════════════════════════════╗
║╔══════════════════════════╗║
║║              简易教务管理系统 V0.1                 ║║
║║                                                    ║║
║╚══════════════════════════╝║
╚════════════════════════════╝
");
            Console.WriteLine("Powered By lt\n");
            Console.WriteLine("*********  用户登录 *********");
            while (BaseBLL.User == null)
            {
                string account = string.Empty;
                while (string.IsNullOrEmpty(account))
                {
                    Console.Write("请输入ID:");
                    account = Console.ReadLine();
                }
                string passwd = string.Empty;
                while (string.IsNullOrEmpty(passwd))
                {
                    Console.Write("请输入密码：");
                    passwd = Console.ReadLine();
                }
                string err;
                if (LoginBLL.login(account.Trim(), passwd.Trim(), out err))
                {
                    Console.WriteLine("\n欢迎 {0}: {1}登入系统 当前时间：{2}", BaseBLL.User.getRole(), BaseBLL.User.Name, DateTime.Now);
                }
                else
                {
                    Console.WriteLine(err); 
                }
            }
            return BaseBLL.User;
        }
    }
}
