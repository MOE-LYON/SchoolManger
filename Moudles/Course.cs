using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Course
    {
        private string course_ID;
        private string course_name;
        private double course_point;
        private string cpno;
        public double Point
        {
            get { return course_point; }
        }
        public string CourseID
        {
            get
            {
                return course_ID;
            }
        }
        public string CourseName
        {
            get { return course_name; }
        }

        public string Cpno { get { return cpno; } set { cpno = value; } }

        public Course(string id, string name, double point,string cpno=null)
        {
            this.course_ID = id;
            this.course_name = name;
            this.course_point = point;
            this.cpno = cpno;
        }
    }
}
