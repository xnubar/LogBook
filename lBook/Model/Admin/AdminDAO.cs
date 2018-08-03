using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lBook.Model.Admin
{
    class AdminDAO
    {
        public List<Admin> Admins { get; set; }
        private static AdminDAO instance;
        private AdminDAO()
        {
            Admins = new List<Admin>();
            Admin p = new Admin()
            {
                DateBirth = "10/10/10",
                Email = "admin@gmail.com",
                FirstName = "admin",
                Gender = Gender.Female,
                Image = "pack://application:,,,/Images/logBook.ico",
                LastName = "admin",
                Password = "admin123",
                Role = Role.Admin,
                UserName = "admin"
            };
            Add(p);

        }
        public bool Login(string username,string password)
        {
            string hashedPassword = String.Empty;
            for (int i = 0; i < password.Length; i++)
            {
                hashedPassword += (char)(password[i] * 0x0090);
            }
            return Instance.Admins.Exists(t => t.UserName == username && t.Password == hashedPassword);
        }
        public static AdminDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdminDAO();
                }
                return instance;
            }

        }
        public void Add(Admin p)
        {
            string passwordHash = String.Empty;
            foreach (var c in p.Password)
            {
                passwordHash += (char)(c * 0x0090);
            }
            p.Password = passwordHash;
            Admins.Add(p);
        }
    }
}
