using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Course
    {
        private string course_ID;
        private string course_name;
        private double course_point;

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
        public Course(string id, string name, double point)
        {
            this.course_ID = id;
            this.course_name = name;
            this.course_point = point;
        }
    }
}
