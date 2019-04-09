using Models;
using SchoolMangerBLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMangerUI
{
    public class StudentUI
    {
        public static void ShowMenu()
        {
            Console.WriteLine(@"╔═══════════════════════════╗
║                 学生操作菜单                         ║
║             ====================                     ║
║     1——课程选修           2——课程退选            ║
║     3——成绩查询           4——个人信息            ║
║               5--修改密码                       ║
║     0——退出               help——显示本菜单       ║
╚═══════════════════════════╝");
        }
        public static void show()
        {
            ShowMenu();
            while (true)
            {
                Console.Write("请选择你要进行的操作(0-5):");
                string ans = Console.ReadLine().Trim();
                switch (ans.ToLower())
                {
                    case "0": BaseBLL.saveAll(); return;
                    case "1": AddCourse(); break;
                    case "2": RetirCourse(); break;
                    case "3": LookupCorse(); break;
                    case "4": ShowMe(); break;
                    case "5":changePasswd(); break;
                    case "help": ShowMenu(); break;
                    default: Console.WriteLine("*******无效输入 请仔细检查"); break;
                }
            }
        }

        private static void changePasswd()
        {
            Console.WriteLine("\n******* 重置用户密码 *********\n");
            Console.Write("请输入旧密码");
            string old=Console.ReadLine().Trim();
            Console.Write("请输入新密码");
            string newpw = Console.ReadLine().Trim();
            Console.Write("请再次输入新密码");
            string compw = Console.ReadLine().Trim();
            string err ;
            if (BaseBLL.ChangePasswd(old,newpw,compw,out err))
            {
                Console.WriteLine(">>>>密码修改成功");
            }
            else
            {
                Console.WriteLine(">>>>修改失败 错误信息 {0}", err);
            }
            Console.WriteLine("********************");
        }

        private static void ShowMe()
        {
            Console.WriteLine("****** 个人信息展示 *******");
            Console.WriteLine("本模块正在开发中");
            Console.WriteLine("**************************");
        }

        private static void LookupCorse()
        {
            Console.WriteLine("\n******** 成绩查询 ********\n");
            Console.WriteLine("       课程ID       课程名称       课程成绩");
            Console.WriteLine("     --------   ----------   -------------");
            Dictionary<Course, double> dataset = StudentBLL.getCourseAndMark();
            foreach (var row in dataset)
            {
                Console.WriteLine("       {0}       {1}       {2}", row.Key.CourseID, row.Key.CourseName, row.Value == -1 ? "在修" : row.Value.ToString());
            }
            Console.WriteLine("\t共得到 {0} 个查询结果", dataset.Count);
            Console.WriteLine("\n*******************\n");
        }

        private static void RetirCourse()
        {
            Console.WriteLine("\n********** 课程退选 ********\n");
            string tcourse_id = string.Empty;
            while (string.IsNullOrEmpty(tcourse_id))
            {
                Console.Write("请输入要推选的课程ID(按回车查询课程信息):");
                tcourse_id = Console.ReadLine().Trim().ToUpper();
                if (string.IsNullOrEmpty(tcourse_id)) myTermCourse();
            }
            string err;
            Console.WriteLine("确认要删除 {0}课程吗？(Y/N)", tcourse_id);
            if (Console.ReadLine().Trim().ToLower() != "y")
            {
                Console.WriteLine("操作已取消");
                return;
            }
            if (StudentBLL.delTCourse(tcourse_id,out err))
            {
                Console.WriteLine(">>>>退选成功");
            }else
            {
                Console.WriteLine(">>>错误信息：{0}", err);
            }
        }

        private static void AddCourse()
        {
            Console.WriteLine("\n********** 课程选修 ********\n");
            string tcourse_id = string.Empty;
            while (string.IsNullOrEmpty(tcourse_id))
            {
                Console.Write("请输入要选修的课程ID(按回车查询课程信息):");
                tcourse_id = Console.ReadLine().Trim().ToUpper();
                if (string.IsNullOrEmpty(tcourse_id)) AdminUI.lookupTermCourse();
            }
            string err;
            if (StudentBLL.AddCourse(tcourse_id,out err))
            {
                Console.WriteLine(">>>选课成功 ，期待你的表演");
            }
            else
            {
                Console.WriteLine(">>>错误提示：{0}", err);
            }
            Console.WriteLine("**********************\n");
        }

        private static void myTermCourse()
        {
            Console.WriteLine("\n********** 查询已选学期课程记录 ********\n");
            Console.WriteLine("     学期课程ID         课程名称         任课教师");
            Console.WriteLine("   --------------   -------------   -------------");
            List<ArrayList> lists = StudentBLL.getCourseInfo();
            foreach(var set in lists)
            {
                Console.WriteLine("        {0}                {1}                 {2}", set[0], set[1], set[2]);
            }
            Console.WriteLine("\n\t共得到 {0} 个查询结果", lists.Count);
            Console.WriteLine("*****************************\n");
        }
    }
}
