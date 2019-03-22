using System;
using System.Collections.Generic;
using Models;

namespace SchoolMangerDAL
{
	/// <summary>
	/// TermCourseDAL ��ժҪ˵����
	/// </summary>
	[Serializable]
	public class TermCourseDAL
	{
		private List<TermCourse> termCourses;

		public TermCourseDAL()
		{
			this.termCourses = new List<TermCourse>();
		}

		/// <summary>
		/// ����ѧ���¿γ�
		/// </summary>
		/// <param name="newTermCourse"></param>
		/// <returns></returns>
		public bool AddNewTermCourse(TermCourse newTermCourse)
		{
			for(int i = 0;i<termCourses.Count;i++)
			{
				if(newTermCourse.ID == ((TermCourse)termCourses[i]).ID)
					return false;
			}
			termCourses.Add(newTermCourse);
			return true;
		}


		/// <summary>
		/// ����ѧ�ڿ���γ̵�IDȡ���ÿγ�
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public bool RemoveTermCourse(string ID)
		{
			for(int i=0;i<termCourses.Count;i++)
			{
				if(ID == ((TermCourse)termCourses[i]).ID)
				{
					termCourses.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// ����ѧ�ڿ���γ̵�ID��������γ�
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public TermCourse RetrieveTermCourse(string ID)
		{
			for(int i=0;i<termCourses.Count;i++)
			{
				if(ID == termCourses[i].ID)
				{
					return termCourses[i];
				}
			}
			return null;
		}
        
		/// <summary>
		/// ����ѧ�ڿ�������пγ�
		/// </summary>
		/// <returns></returns>
		public TermCourse[] RetrieveAll()
		{
			return termCourses.ToArray();
		}
	
		/// <summary>
		/// ���ݽ�ʦID�����ο���Ϣ
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public TermCourse[] TeachCourses (string teacher_ID)
		{
            List<TermCourse> teachCourses = new List<TermCourse>();
			for(int i=0;i<termCourses.Count;i++)
			{
				if(teacher_ID == termCourses[i].TeacherID)
				{
					teachCourses.Add(termCourses[i]);
				}
			}
			return teachCourses.ToArray();
		}

		
	}
}