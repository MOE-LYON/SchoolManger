using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace SchoolMangerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            User user= LoginUI.login();
            switch(user.getRole())
            {
                case Role.admin: AdminUI.show(); break;
                case Role.student: StudentUI.show(); break;
                case Role.teacher: TeacherUI.show(); break;
            }
            Console.Write("程序正常关闭 请按任意键退出");
            Console.ReadLine();
        }
    }
}
