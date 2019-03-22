using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
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
        public TermCourse(string courseid,string teacherid)
        {
            this.teacherid=teacherid;
            this.courseid=courseid;
            this.id=DateTime.Now.Year+courseid+teacherid+(new Random()).Next(20).ToString();
        }
    }
}
