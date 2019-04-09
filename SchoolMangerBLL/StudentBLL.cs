using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using SchoolMangerDAL;
namespace SchoolMangerBLL
{
    public class StudentBLL : BaseBLL
    {
        public static bool AddCourse(string tcourse_id, out string err)
        {
            Student stu = (Student)user;
            err = string.Empty;
            if (termCourses.RetrieveTermCourse(tcourse_id)==null)
            {
                err = "未开设学期课程ID为 " + tcourse_id + " 的课程";
                return false;
            }else if (HasChoosed(tcourse_id))
            {
                err = " 已经选修了该课程 --";
                return false;
            }
            else if (!CheekCp(tcourse_id))
            {
                err = "未选修指定先修课 导致无法选课";
                return false;
            }
            stu.AddTermCourse(tcourse_id);
            termCourses.RetrieveTermCourse(tcourse_id).addStu(User.ID);
            return true;
           
        }

        private static bool CheekCp(string tid)
        {
            string cid = termCourses.RetrieveTermCourse(tid).CourseID;
            string pno = courses.RetrieveCourse(cid).Cpno;
            if (pno == null) return true;
            Student stu = (Student)user;
            foreach (var teamcourse in stu.GetAllTermCourses())
            {
                try
                {
                    if (pno == termCourses.RetrieveTermCourse(teamcourse).CourseID)
                    {
                        return true;
                    }
                }
                catch (Exception) { }
            }
            return false;
        }

        public static bool HasChoosed(string tid)
        {
            Student stu = (Student)user;
            string cid = termCourses.RetrieveTermCourse(tid).CourseID;
            foreach(var teamcourse in stu.GetAllTermCourses())
            {
                try { 
                    if (cid==termCourses.RetrieveTermCourse(teamcourse).CourseID)
                    {
                        return true;
                    }
                }
                catch (Exception) { }
            }
            return false;
        }

        public static Dictionary<Course, double> getCourseAndMark()
        {
            Student stu = (Student)User;
            Dictionary<Course, double> pairs = new Dictionary<Course, double>();
            var data = stu.getTcAndMark();
            foreach(var row in data)
            {
                try
                {
                    string cid = termCourses.RetrieveTermCourse(row.Key).CourseID;
                    Course course = courses.RetrieveCourse(cid);
                    pairs.Add(course, row.Value);
                }
                catch(Exception) { }
            }

            return pairs;
        }

        public static bool delTCourse(string tcourse_id, out string err)
        {
            Student stu = (Student)User;
            if (stu.deleteTCourse(tcourse_id, out err))
            {
                TermCourse t = termCourses.RetrieveTermCourse(tcourse_id);
                if (t != null) t.removeStu(User.ID);
                return true;
            }
            else return false;
        }

        public static List<ArrayList> getCourseInfo()
        {
            List<ArrayList> array = new List<ArrayList>();
            Student stu = (Student)User;
            string[] tids=stu.GetAllTermCourses();
            foreach (var tid in tids)
            {
                ArrayList list = new ArrayList();
                list.Add(tid);
                TermCourse tc = termCourses.RetrieveTermCourse(tid);
                list.Add(courses.RetrieveCourse(tc.CourseID).CourseName);
                list.Add(teachers.Retrieve(tc.TeacherID).Name);
                array.Add(list);
            }

            return array;
        }
    }

   
}
