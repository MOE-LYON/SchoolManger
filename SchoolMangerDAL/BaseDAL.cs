using System;
using System.Collections.Generic;
using Models;
namespace SchoolMangerDAL
{
	/// <summary>
	/// BaseDAL 的摘要说明。
	/// </summary>
	[Serializable]
	public class BaseDAL
	{
		private List<User> Users;

		public BaseDAL()
		{
            this.Users = new List<User>();
		}

		/// <summary>
		/// 增加
		/// </summary>
		/// <param name="User"></param>
		/// <returns></returns>
		public bool Add(User User)
		{
			for(int i=0;i<Users.Count; ++i)
			{
				if(User.ID ==Users[i].ID)
				{
					return false;
				}
			}
			Users.Add(User);
			return true;
		}

		/// <summary>
		/// 根据ID删除
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public bool Remove(string ID)
		{
			for(int i=0;i<Users.Count; ++i)
			{
				if(ID == Users[i].ID)
				{
					Users.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 根据ID查询
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public User Retrieve(string ID)
		{
			for(int i=0;i<Users.Count; ++i)
			{
                if (ID == Users[i].ID)
				{
					return Users[i];
				}
			}
			return null;
		}
        public bool ChangPW(User p,string newPw)
        {
            User theUser = Retrieve(p.ID);
            if (theUser != null)
            {
                theUser.Password = newPw;
                return true;
            }
            return false;

        }
        public bool ChangPW(string pid, string newPw)
        {
            User theUser = Retrieve(pid);
            if (theUser != null)
            {
                theUser.Password = newPw;
                return true;
            }
            return false;

        }
		public User[] RetrieveAll()
		{
			return Users.ToArray();
		}
	

	}
}
