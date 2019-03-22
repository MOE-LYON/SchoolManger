using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student:User
    {
        private static int cuurid;
        //private List<Course> courses;
        private Dictionary<Course, int> courseandmark;
        public Student(string name, string password, string id=null):base(name,password)
        {
            if (id == null)
            {

            }
            else this.id = id;
            this.role = Role.student;
        }

        public override string GetNewID()
        {
            return string.Format("S{0}{1:D6}",DateTime.Now.Year, cuurid);
        }

        public void AddCourse(Course cou)
        {
            this.courseandmark.Add(cou, -1);
        }
        public Course[] GetAllCourses()
        {
            return this.courseandmark.Keys.ToArray();
        }

        public bool UpdateCourse(int grade, Course course)
        {
            //if (grade>=0&&grade<=100) 这个BLL应该会处理 不能抢风头
            //{
            //以防万一出现异常
                try
                {
                    courseandmark[course] = grade;
                    return true;
                }
                catch (Exception) { }
            //}
            return false;
        }
    }
}
