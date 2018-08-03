using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lBook.Model.Admin
{
    class AdminService
    {
        private static AdminService instance;
        public static AdminService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdminService();
                }
                return instance;
            }
        }
        public bool Login(string username, string password)
        {
            if (username.Length <= 0 || password.Length <= 0)
            {
                throw new Exception("USERNAME AND PASSWORD MUST BE FILLED");

            }
            return AdminDAO.Instance.Login(username, password);
        }
    }
}
