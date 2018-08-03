using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lBook.Model
{
    class TeacherService
    {
        private static TeacherService instance;
        public static TeacherService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TeacherService();
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
            return TeacherDAO.Instance.Login(username, password);
        }
    }
}
