using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class TermCourse
    {
        private string id;
        private string teacherid;
        private string courseid;
        private List<string> students;
        public string ID
        {
            get
            {
                return id;
            }
        }
        public string TeacherID
        {
            get
            {
                return teacherid;
            }
        }
        public string CourseID
        {
            get { return courseid; }
        }
        public void addStu(string sid)
        {
            students.Add(sid);
        }

        public bool removeStu(string sid)
        {
            return students.Remove(sid);
        }
        public string[] getAllStu()
        {
            return students.ToArray();
        }
        public TermCourse(string courseid,string teacherid)
        {
            this.teacherid=teacherid;
            this.courseid=courseid;
            this.id=courseid+ teacherid + DateTime.Now.Year + (new Random()).Next(20).ToString();
            this.students = new List<string>();
        }
    }
}
