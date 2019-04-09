using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMangerBLL;
using Models;
using System.Collections;

namespace SchoolMangerUI
{
    public class AdminUI
    {
        public static void ShowMenu()
        {
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║               系统管理菜单              ║ ");
            Console.WriteLine("║             ====================       ║");
            Console.WriteLine("║     1——教师管理         2——学生管理      ║");
            Console.WriteLine("║     3——课程管理         4——学期课程管理  ║");
            Console.WriteLine("║              5--重置用户密码            ║");
            Console.WriteLine("║     0——退出             help——帮助      ║");
            Console.WriteLine("╚════════════════════════════════════════╝");


        }
        public static void ShowTeacherAdminMenu()
        {
            Console.WriteLine(@"╔═══════════════════════════════╗
║                       教师管理菜单                           ║
║                   ====================                       ║
║                1——新增         2——删除                   ║
║                3——修改         4——查询                   ║
║        0——返回至系统管理菜单   help——显示本菜单            ║
╚═══════════════════════════════╝");
        }
        public static void ShowStudentAdminMenu()
        {
            Console.WriteLine(@"╔═══════════════════════════════╗
║                       学生管理菜单                           ║
║                   ====================                       ║
║                1——新增         2——删除                   ║
║                3——修改         4——查询                   ║
║        0——返回至系统管理菜单   help——显示本菜单          ║
╚═══════════════════════════════╝");
        }
        public static void ShowCourseAdminMenu()
        {
            Console.WriteLine(@"╔═══════════════════════════════╗
║                       课程管理菜单                           ║
║                   ====================                       ║
║                1——新增         2——删除                   ║
║                3——修改         4——查询                   ║
║        0——返回至系统管理菜单   help——显示本菜单          ║
╚═══════════════════════════════╝");
        }
        public static void ShowTermCourseAdminMenu()
        {
            Console.WriteLine(@"╔═══════════════════════════════╗
║                       学期课程管理菜单                       ║
║                   ====================                       ║
║                1——新增         2——删除                   ║
║                3——修改         4——查询                   ║
║        0——返回至系统管理菜单   help——显示本菜单          ║
╚═══════════════════════════════╝");
        }
        public static void show()
        {
            while (true)
            {
                ShowMenu();
                Console.Write("请选择你要进行的操作(0-5):");
                string ans = Console.ReadLine().Trim();
                switch (ans.ToLower())
                {
                    case "0": BaseBLL.saveAll(); return;
                    case "1": TeacherAdmin(); break;
                    case "2": StudentAdmin(); break;
                    case "3": CourseAmdin(); break;
                    case "4": TermCourseAdmin(); break;
                    case "5": resetPasswd(); break;
                    case "help": Help(); break;
                    default: Console.WriteLine("*******无效输入 请仔细检查"); break;
                }
            }
        }
        private static void resetPasswd()
        {
            Console.WriteLine("\n******* 重置用户密码 *********");
            bool ans;
            do
            {
                ans = false;
                string id = string.Empty;
                while (string.IsNullOrEmpty(id))
                {
                    Console.Write("请输入要重置用户的ID");
                    id = Console.ReadLine().Trim().ToUpper();
                }
                User ts = AdminBLL.GeUser(id);
                if (ts == null)
                {
                    Console.WriteLine("用户不存在");
                }
                else
                {
                    string pwd = string.Empty;
                    Console.WriteLine("请输入新密码 否则密码默认为123");
                    pwd= Console.ReadLine().Trim();
                    AdminBLL.SetPasswd(ts,pwd);
                    
                }
                Console.WriteLine("是否继续？(y/n)");
                if (Console.ReadLine().Trim().ToLower() == "y") ans = true;
            } while (ans);
        }

        private static void TermCourseAdmin()
        {
            while (true)
            {
                ShowTermCourseAdminMenu();
                Console.Write("请选择你要进行的操作(0-4):");
                string ans = Console.ReadLine().Trim();
                switch (ans.ToLower())
                {
                    case "0": return;
                    case "1": addTermCourse(); break;
                    case "2": delTermCourse(); break;
                    case "3": updateTermCourse(); break;
                    case "4": lookupTermCourse(); break;
                    case "help": Help(); break;
                    default: Console.WriteLine("*******无效输入 请仔细检查*******"); break;
                }
            }
        }

        public static void lookupTermCourse()
        {
            Console.WriteLine("\n******* 查询学期课程记录 *********");
            Console.Write("请输入要查询的课程ID<否则显示所有学期课程信息 支持模糊匹配:");
            string ans = Console.ReadLine().Trim().ToUpper();
            List<ArrayList> res = AdminBLL.lookupTermCourses(ans);
            if (res.Count == 0)
            {
                Console.WriteLine("指定的课程不存在");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\t学期课程ID\t课程名称\t任课教师");
                Console.WriteLine("   ---- \t----- \t------");
                foreach (var tcourse in res)
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}", tcourse[0],tcourse[1],tcourse[2]);
                }
                Console.WriteLine("\n\t共找到{0}个查询结果", res.Count);
            }
            Console.WriteLine("******************************");
        }

        private static void updateTermCourse()
        {
            Console.WriteLine("\n******* 修改课程记录 *********");
            //Console.WriteLine("貌似没有改的意思...... ");
            Console.WriteLine("本功能暂未实现~~~~~");
            Console.WriteLine("*****************************");
        }

        private static void delTermCourse()
        {
            Console.WriteLine("\n***** 删除学期课程记录********\n");
            string id = string.Empty;
            while (string.IsNullOrEmpty(id))
            {
                Console.Write("\n请输入要删除的学期课程ID:");
                id = Console.ReadLine().Trim().ToUpper();
            }
            var res = AdminBLL.lookupTermCourses(id);
            if (res.Count == 0 || res[0][0].ToString() != id)
            {
                Console.WriteLine("错误提示：指定的学期课程不存在");
                return;
            }
            Console.WriteLine("确认要删除 {0} 吗？(Y/N)", res[0][0]);
            if (Console.ReadLine().Trim().ToLower() != "y")
            {
                Console.WriteLine("操作已取消");
                return;
            }
            if (AdminBLL.delTermCourse(id))
            {
                Console.WriteLine(">>>>成功删除课程");
            }
            else
            {
                Console.WriteLine(">>>错误提示：未知错误 无法删除");
            }
        }

        private static void addTermCourse()
        {
            Console.WriteLine("\n***** 新增课程记录********\n");
            string course_id = string.Empty;
            string teacher_id = string.Empty;
            while (string.IsNullOrEmpty(course_id))
            {
                Console.Write("请输入学期要开设课程的ID(按回合查询课程信息):");
                course_id = Console.ReadLine().Trim().ToUpper();
                if (string.IsNullOrEmpty(course_id)) lookupCourse();
            }
           
            while (string.IsNullOrEmpty(teacher_id))
            {
                Console.Write("请输入课程任课教师的ID(按回合查询课程信息):");
                teacher_id = Console.ReadLine().Trim().ToUpper();
                if (string.IsNullOrEmpty(teacher_id)) lookupTeacher();
            }
            string err;
            if (AdminBLL.addTermCourse(course_id,teacher_id, out err))
            {
                Console.WriteLine(">>>>成功添加新课程记录");

            }
            else Console.WriteLine(">>>错误提示"+err);
            Console.WriteLine("*******************");
        }

        private static void CourseAmdin()
        {
            while (true)
            {
                ShowCourseAdminMenu();
                Console.Write("请选择你要进行的操作(0-4):");
                string ans = Console.ReadLine().Trim();
                switch (ans.ToLower())
                {
                    case "0": return;
                    case "1": addCourse(); break;
                    case "2": delCourse(); break;
                    case "3": updateCourse(); break;
                    case "4": lookupCourse(); break;
                    case "help": Help(); break;
                    default: Console.WriteLine("*******无效输入 请仔细检查*******"); break;
                }
            }
        }

        private static void lookupCourse()
        {
            Console.WriteLine("\n******* 查询课程记录 *********");
            Console.Write("请输入要查询的课程ID<否则显示所有课程信息 支持模糊匹配:");
            string ans = Console.ReadLine().Trim().ToUpper();
            Course[] res = AdminBLL.lookupcourses(ans);
            if (res.Length == 0)
            {
                Console.WriteLine("指定的课程不存在");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\t课程ID\t课程名称\t先修课");
                foreach (Course course in res)
                {
                    Console.WriteLine("\t{0}\t{1}\t\t{2}", course.CourseID, course.CourseName,course.Cpno);
                }
                Console.WriteLine("\n\t共找到{0}个查询结果", res.Length);
            }
            Console.WriteLine("******************************");
        }

        private static void updateCourse()
        {
            Console.WriteLine("\n******* 修改课程记录 *********");
            Console.WriteLine("貌似没有改的意思...... ");
            Console.WriteLine("本功能暂未实现~~~~~");
            Console.WriteLine("*****************************");
        }

        private static void delCourse()
        {
            Console.WriteLine("\n***** 删除课程记录********\n");
            string id = string.Empty;
            while (string.IsNullOrEmpty(id))
            {
                Console.Write("\n请输入要删除的课程ID:");
                id = Console.ReadLine().Trim().ToUpper();
            }
            Course[] res = AdminBLL.lookupcourses(id);
            if (res.Length == 0 || res[0].CourseID != id)
            {
                Console.WriteLine("错误提示：指定的课程不存在");
                return;
            }
            Console.WriteLine("确认要删除 {0}:{1} 吗？(Y/N)", res[0].CourseID, res[0].CourseName);
            if (Console.ReadLine().Trim().ToLower() != "y")
            {
                Console.WriteLine("操作已取消");
                return;
            }
            if (AdminBLL.delCourse(id))
            {
                Console.WriteLine(">>>>成功删除课程");
            }
            else
            {
                Console.WriteLine(">>>错误提示：指定的教师不存在或者无法删除");
            }
        }

        private static void addCourse()
        {
            Console.WriteLine("\n***** 新增课程记录********\n");
            string course_name = string.Empty;
            string course_id = string.Empty;
            string course_point = string.Empty;
            while (string.IsNullOrEmpty(course_id))
            {
                Console.Write("请输入新课程的ID:");
                course_id = Console.ReadLine().Trim().ToUpper();
            }
            while (string.IsNullOrEmpty(course_name))
            {
                Console.Write("请输入新课程的名称:");
                course_name = Console.ReadLine().Trim();
            }
            while (string.IsNullOrEmpty(course_point))
            {
                Console.Write("请输入新课程的学分数:");
                course_point = Console.ReadLine().Trim();
            }
            string cpno = string.Empty;
            Console.WriteLine("请输入新课程的先修课 若无直接按回车");
            cpno = Console.ReadLine().Trim().ToUpper();
            if (AdminBLL.addCourse(course_id,course_name,course_point,cpno))
            {
                Console.WriteLine(">>>>成功添加新课程记录");

            }
            else Console.WriteLine("该课程ID已存在");
            Console.WriteLine("*******************");
        }

        private static void TeacherAdmin()
        {
            ShowTeacherAdminMenu();
            while (true)
            {
                Console.WriteLine();
                Console.Write("请选择你要进行的操作(0-4):");
                string ans = Console.ReadLine().Trim();
                switch (ans.ToLower())
                {
                    case "0": return;
                    case "1": addTeacher(); break;
                    case "2": delTeacher(); break;
                    case "3": updateTeacher(); break;
                    case "4": lookupTeacher(); break;
                    case "help": ShowTeacherAdminMenu(); ; break;
                    default: Console.WriteLine("*******无效输入 请仔细检查*******"); break;
                }
            }
        }

        private static void lookupTeacher()
        {
            Console.WriteLine("\n******* 查询教师记录 *********");
            Console.Write("请输入要查询的教师ID<否则显示所有教师信息 支持模糊匹配:");
            string ans = Console.ReadLine().Trim().ToUpper();
            User[] users = AdminBLL.lookupteachers(ans);
            if (users.Length==0)
            {
                Console.WriteLine("指定的老师不存在");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\t教师ID\t教师姓名");
                foreach( User user in users)
                {
                    Console.WriteLine("\t{0}\t{1}", user.ID, user.Name);
                }
                Console.WriteLine("\n\t共找到{0}个查询结果",users.Length);
            }
            Console.WriteLine("******************************");
        }

        private static void updateTeacher()
        {
            Console.WriteLine("\n******* 修改教师记录 *********");
            Console.WriteLine("除了密码外貌似没有改的意思...... ");
            Console.WriteLine("本功能暂未实现~~~~~");
            Console.WriteLine("*****************************");
        }

        private static void delTeacher()
        {
            Console.WriteLine("\n***** 删除教师记录********\n");
            string id= string.Empty;
            while (string.IsNullOrEmpty(id))
            {
                Console.Write("\n请输入要删除的教师ID:");
                id = Console.ReadLine().Trim().ToUpper();
            }
            User[] res = AdminBLL.lookupteachers(id);
            if (res.Length == 0 || res[0].ID != id)
            {
                Console.WriteLine("错误提示：指定的教师不存在");
                return;
            }
            Console.WriteLine("确认要删除 {0}教师吗？(Y/N)",res[0].ID);
            if (Console.ReadLine().Trim().ToLower() != "y")
            {
                Console.WriteLine("操作已取消");
                return;
            }
            if (AdminBLL.delTeacher(id))
            {
                Console.WriteLine(">>>>成功删除教师");
            }
            else
            {
                Console.WriteLine(">>>错误提示：指定的老师不存在或者无法删除");
            }
        }

        private static void addTeacher()
        {
            Console.WriteLine("\n***** 新增教师记录********\n");
            string name=string.Empty;
            while(string.IsNullOrEmpty(name))
            {
                Console.Write("请输入新教师的姓名:");
                name = Console.ReadLine().Trim();
            }
            if (AdminBLL.addTeacher(name))
            {
                Console.WriteLine(">>>>成功添加新教师记录");

            }
            else Console.WriteLine("未知错误，请稍后再试");
            Console.WriteLine("*******************");
        }
        private static void StudentAdmin()
        {
            while (true)
            {
                ShowStudentAdminMenu();
                Console.Write("请选择你要进行的操作(0-4):");
                string ans = Console.ReadLine().Trim();
                switch (ans.ToLower())
                {
                    case "0": return;
                    case "1": addStudent(); break;
                    case "2": delStudent(); break;
                    case "3": updateStudent(); break;
                    case "4": lookupStudent(); break;
                    case "help": Help(); break;
                    default: Console.WriteLine("*******无效输入 请仔细检查*******"); break;
                }
            }
        }

        private static void lookupStudent()
        {
            Console.WriteLine("\n******* 查询学生记录 *********");
            Console.Write("请输入要查询的学生ID<否则显示所有学生信息:");
            string ans = Console.ReadLine().Trim().ToUpper();
            User[] users = AdminBLL.lookupstudens(ans);
            
            if (users.Length == 0)
            {
                Console.WriteLine("指定的学生不存在");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\t学生ID\t学生姓名");
                Console.WriteLine("   -------     ----------");
                foreach (User user in users)
                {
                    Console.WriteLine("\t{0}\t{1}", user.ID, user.Name);
                }
                Console.WriteLine("\n\t共找到{0}个查询结果", users.Length);
            }
            Console.WriteLine("******************************");
        }

        private static void updateStudent()
        {
            Console.WriteLine("\n******* 修改教师记录 *********");
            Console.WriteLine("除了密码外貌似没有改的意思...... ");
            Console.WriteLine("本功能暂未实现~~~~~");
            Console.WriteLine("*****************************");
        }

        private static void delStudent()
        {
            Console.WriteLine("\n***** 删除学生记录********\n");
            string id = string.Empty;
            while (string.IsNullOrEmpty(id))
            {
                Console.Write("\n请输入要删除的学生ID:");
                id = Console.ReadLine().Trim().ToUpper();
            }
            User[] res = AdminBLL.lookupstudens(id);
            if (res.Length == 0 || res[0].ID != id)
            {
                Console.WriteLine("错误提示：指定的学生不存在");
                return;
            }
            Console.WriteLine("确认要删除 {0}学生吗？(Y/N)", res[0].ID);
            if (Console.ReadLine().Trim().ToLower() != "y")
            {
                Console.WriteLine("操作已取消");
                return;
            }
            if (AdminBLL.delStudent(id))
            {
                Console.WriteLine(">>>>成功删除学生");
            }
            else
            {
                Console.WriteLine(">>>错误提示：程序异常 无法删除");
            }
        }

        private static void addStudent()
        {
            Console.WriteLine("\n***** 新增学生记录********\n");
            string name = string.Empty;
            while (string.IsNullOrEmpty(name))
            {
                Console.Write("请输入新学生的姓名:");
                name = Console.ReadLine().Trim();
            }
            if (AdminBLL.addStudent(name))
            {
                Console.WriteLine(">>>>成功添加新学生记录");

            }
            else Console.WriteLine("未知错误，请稍后再试");
            Console.WriteLine("*******************");
        }
        private static void Help()
        {
            Console.WriteLine("就是字面意思 无需任何解释~~~");
        }
    }
}
