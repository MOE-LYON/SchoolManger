using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Student:User
    {
        public static int cuurid;
        //private List<Course> courses;
        private Dictionary<string, double> courseandmark;
        public Student(string name, string password, string id=null):base(name,password)
        {
            if (id == null)
            {
                this.id = GetNewID();
            }
            else this.id = id;
            this.role = Role.student;
            courseandmark = new Dictionary<string, double>();
        }

        public override string GetNewID()
        {
            return string.Format("S{0}{1:D6}",DateTime.Now.Year, cuurid++);
        }

        public void AddTermCourse(string tcou)
        {
            this.courseandmark.Add(tcou, -1);
        }
        public string[] GetAllTermCourses()
        {
            return this.courseandmark.Keys.ToArray();
        }
        
        public Dictionary<string, double> getTcAndMark()
        {
            return courseandmark;
        }

        public bool deleteTCourse(string tid,out string err)
        {
            err = string.Empty;
            try
            {
                if (courseandmark[tid]>=0)
                {
                    err = "该课已经有成绩无法退选";
                    return false;
                }
                if (courseandmark.Remove(tid))
                {
                    return true;
                }
                else return false;
            }
            catch (Exception) { err ="该课不存在"; return false; }
        }

        public double? gerMarkByTC(string tc)
        {
            double mark;
            if (courseandmark.TryGetValue(tc,out mark))
            {
                return mark;
            }
            return null;
        }
        public bool IsChoosed(string tcid)
        {
            return courseandmark.ContainsKey(tcid);
        }
        public bool UpdateCourse(double grade, string tcourse)
        {
            //if (grade>=0&&grade<=100) 这个BLL应该会处理 不能抢风头
            //{
            //以防万一出现异常
                try
                {
                    courseandmark[tcourse] = grade;
                    return true;
                }
                catch (Exception) { }
            //}
            return false;
        }
    }
}
