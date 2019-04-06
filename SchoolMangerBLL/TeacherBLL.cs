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
    public class TeacherBLL : BaseBLL
    {
        public static List<ArrayList> getCourseInfo()
        {
            List<ArrayList> res = new List<ArrayList>();
            var tcs = termCourses.RetrieveAll();
            foreach (var tc in tcs)
            {
                if (tc.TeacherID==User.ID)
                {
                    ArrayList array = new ArrayList();
                    array.Add(tc.ID);
                    array.Add(courses.RetrieveCourse(tc.CourseID).CourseName);
                    array.Add(tc.getAllStu().Length);
                    res.Add(array);
                }
            }
            return res;
        }

        public static bool hasCourse(string tcid)
        {
            var tcs = getCourseInfo();
            foreach(var tc in tcs)
            {
                if (tc[0].ToString() == tcid) return true;
            }
            return false;
        }

        public static bool UpdateOneStu(string tcid, string sid, string mark, out string err)
        {
            err = "未知错误";
            double score;
            try
            {
                score = double.Parse(mark);
            }
            catch(Exception)
            {
                err = "输入的成绩非法";
                return false;
            }
            if (score>100||score<0)
            {
                err = "输入的成绩非法";
                return false;
            }
            Student stu = (Student)students.Retrieve(sid);
            if (stu==null)
            {
                err = "无法找到该学生";
                return false;
            }
            if (!stu.IsChoosed(tcid))
            {
                err = "该学生并没有选这门课";
                return false;
            }
            if (stu.gerMarkByTC(tcid)>=0)
            {
                err = "该学生这个课程已经有成绩了 如需修改请联系管理员";
                return false;
            }
            return stu.UpdateCourse(score, tcid);
        }

        public static Student[] getAllUCStu(string tcid)
        {
            string[] stuarr = termCourses.RetrieveTermCourse(tcid).getAllStu();
            List<Student> stus = new List<Student>();
            foreach(string ss in stuarr)
            {
                Student s = (Student)students.Retrieve(ss);
                if (s.gerMarkByTC(tcid) != null && s.gerMarkByTC(tcid) < 0) stus.Add(s);
            }
            return stus.ToArray();
        }
    }
}
