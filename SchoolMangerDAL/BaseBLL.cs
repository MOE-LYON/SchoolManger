using System;
using Models;
using SchoolMangerDAL;

namespace SchoolMangerDAL
{
	/// <summary>
	/// BaseBLL 的摘要说明。
	/// </summary>
	public class BaseBLL
	{		
		protected static User user;
		protected static AdminDAL admins;
		protected static StudentDAL students;
		protected static TeacherDAL teachers;
		protected static CourseDAL courses;
		protected static TermCourseDAL termCourses;

		protected BaseBLL(){}
		static BaseBLL()
		{
			admins = DataFileAccess.GetAdmins();
			students = DataFileAccess.GetStudents();
			teachers = DataFileAccess.GetTeachers();
			courses = DataFileAccess.GetCourses();
			termCourses = DataFileAccess.GetTermCourses();
		}

		public static User User
		{
			get{return user;}
		}

		public static TermCourse RetrieveTermCourse(string termCourseId)
		{
			return termCourses.RetrieveTermCourse(termCourseId);
		}
	}
}
