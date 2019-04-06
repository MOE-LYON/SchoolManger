using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMangerDAL;
using Models;
using System.Collections;

namespace SchoolMangerBLL
{
    public class AdminBLL:BaseBLL
    {
        public static bool addTeacher(string name)
        {
            Models.User user = new Teacher(name, "123");
            if (teachers.Add(user))
            {
                return true;
            }
            else return false;
        }

        public static bool delTeacher(string id)
        {
            if (teachers.Remove(id))
            {
                return true;
            }
            else return false;
        }

        public static User[] lookupteachers(string ans)
        {
            List<User> userlist = new List<User>();
            User[]  users = teachers.RetrieveAll();
            foreach (User user in users)
            {
                if (user.ID.IndexOf(ans) != -1) userlist.Add(user);
            }
            return userlist.ToArray();
        }

        public static bool addStudent(string name)
        {
            Models.User user = new Student(name, "123");
            if (students.Add(user))
            {
                return true;
            }
            else return false;
        }

        public static bool delStudent(string id)
        {
            if (students.Remove(id))
            {
                return true;
            }
            else return false;
        }

        public static User[] lookupstudens(string ans)
        {
            List<User> userlist = new List<User>();
            User[] users = students.RetrieveAll();
            foreach (User user in users)
            {
                if (user.ID.IndexOf(ans) != -1) userlist.Add(user);
            }
            return userlist.ToArray();
        }

        public static bool addCourse(string course_id, string course_name, string course_point)
        {
            Course newcourse = new Course(course_id, course_name, double.Parse(course_point));
            if (courses.AddNewCourse(newcourse))
            {
                return true;
            }
            else return false;
        }

        public static Course[] lookupcourses(string ans)
        {
            List<Course> courselist = new List<Course>();
            Course[] res = courses.RetrieveAll();
            foreach (Course course in res)
            {
                if (course.CourseID.IndexOf(ans) != -1) courselist.Add(course);
            }
            return courselist.ToArray();
        }

        public static bool delCourse(string id)
        {
            return courses.RemoveCourse(id);
        }

        public static bool addTermCourse(string course_id, string teacher_id, out string err)
        {
            err = string.Empty;
            if (lookupcourses(course_id).Length!=1)
            {
                err = "不存在课程ID为 " + course_id + " 的课程";
                return false;
            }
            else if (lookupteachers(teacher_id).Length!=1)
            {
                err = "不存在教师ID为 " + teacher_id + " 的教师";
                return false;
            }
            TermCourse termCourse = new TermCourse(course_id, teacher_id);
            if (termCourses.AddNewTermCourse(termCourse))
            {
                return true;
            }
            else
            {
                err = "未知错误 请稍后再试";
                return false;
            }
        }

        public static List<ArrayList> lookupTermCourses(string ans)
        {
            List<ArrayList> arrayLists = new List<ArrayList>();

            TermCourse[] res = termCourses.RetrieveAll();
            foreach (var tcourse in res)
            {
                if (tcourse.ID.IndexOf(ans) != -1)
                {
                    var temp = new ArrayList();
                    temp.Add(tcourse.ID);
                    temp.Add(courses.RetrieveCourse(tcourse.CourseID).CourseName);
                    temp.Add(teachers.Retrieve(tcourse.TeacherID).Name);
                    arrayLists.Add(temp);
                }
            }
            return arrayLists;
        }

        public static bool delTermCourse(string id)
        {
            return termCourses.RemoveTermCourse(id);
        }
    }
}
