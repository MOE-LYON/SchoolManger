using SchoolMangerBLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace SchoolMangerUI
{
    public class TeacherUI
    {
        public static void ShowMenu()
        {
            Console.WriteLine(@"╔═══════════════════════════╗
║                 教师操作菜单                         ║
║             ====================                     ║
║     1——课程成绩登记       2——所授课程查询        ║
║     3——个人信息                                    ║
║     0——退出               help——显示本菜单       ║
╚═══════════════════════════╝");
        }
        public static void show()
        {
            while (true)
            {
                ShowMenu();
                Console.Write("请选择你要进行的操作(0-3):");
                string ans = Console.ReadLine().Trim();
                switch (ans.ToLower())
                {
                    case "0": BaseBLL.saveAll(); return;
                    case "1": updateMark(); break;
                    case "2": findAllCourse(); break;
                    case "3": ShowMe(); break;
                    case "help": ShowMenu(); break;
                    default: Console.WriteLine("*******无效输入 请仔细检查"); break;
                }
            }
        }

        private static void findAllCourse()
        {
            Console.WriteLine(" ****** 所授课程查询 *******");
            Console.WriteLine("     \t 学期课程ID      \t课程名称      \t 已选课人数");
            Console.WriteLine("   --------------\t----------- \t =-------------");
            List<ArrayList> lists = TeacherBLL.getCourseInfo();
            foreach (var row in lists)
            {
                Console.WriteLine("    \t {0}       \t{1}     \t{2}", row[0], row[1], row[2]);
            }
            Console.WriteLine("共找到{0}条记录", lists.Count);
            Console.WriteLine("**************************");
        }

        private static void updateMark()
        {
            Console.WriteLine("\n****** 个人信息展示 *******\n");
            string ans = string.Empty;
            while (string.IsNullOrEmpty(ans))
            {
                Console.Write("请输入要登记成绩的学期课程ID (按回车键显示所授课程信息):");
                ans = Console.ReadLine().Trim().ToUpper();
                if (string.IsNullOrEmpty(ans)) findAllCourse();
            }

            if (!TeacherBLL.hasCourse(ans))
            {
                Console.WriteLine("本学期没有授课这门课程 请检查输入");
                return;
            }
            string choice = string.Empty;
            Console.Write("输入所有选修此课程的学生的成绩(y/n/q)?");
            choice = Console.ReadLine();
            switch (choice.ToLower())
            {
                case "y": updateAllOneStu(ans); break;
                case "n": updateOneStu(ans); break;
                default: break;
            }
            Console.WriteLine("******************");
        }

        private static void updateOneStu(string tcid)
        {
            
            string sid = string.Empty;
            while(string.IsNullOrEmpty(sid))
            {
                Console.Write("请输入要登记成绩的学生学号:");
                sid = Console.ReadLine().Trim().ToUpper();
            }
            string mark = string.Empty;
            while(string.IsNullOrEmpty(mark))
            {
                Console.Write("{0} 的成绩 :", sid);
                mark = Console.ReadLine();
            }
            string err;
            if (TeacherBLL.UpdateOneStu(tcid,sid,mark, out err))
            {
                Console.WriteLine(">>>>登记成绩成功");
            }
            else
            {
                Console.WriteLine(">>>>错误提示 {0}", err);
            }
        }

        private static void updateAllOneStu(string tcid)
        {
            Student[] stus = TeacherBLL.getAllUCStu(tcid);
            if (stus.Length == 0)
            {
                Console.WriteLine("没有需要录入成绩的学生了");
                return;
            }
            foreach(Student stu in stus)
            {
                Console.Write("{0}的成绩:", stu.ID);
                string score = Console.ReadLine().Trim();
                string err;
                if (TeacherBLL.UpdateOneStu(tcid,stu.ID,score,out err))
                {
                    Console.WriteLine(">>>>成功录入学生成绩！");
                }
                else
                {
                    Console.WriteLine(">>>>错误提示：{0}", err);
                }
            }
        }

        private static void ShowMe()
        {
            Console.WriteLine("\n****** 个人信息展示 *******\n");
            Console.WriteLine("本模块正在开发中");
            Console.WriteLine("**************************");
        }
    }
}
