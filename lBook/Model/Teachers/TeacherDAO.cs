using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lBook.Model
{
    class TeacherDAO : IDisposable
    {
        public List<Teacher> Teachers { get; set; }
        private static TeacherDAO instance;
        private TeacherDAO()
        {
            Teachers = new List<Teacher>();
        }

        public static TeacherDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TeacherDAO();
                }

                return instance;
            }
        }
        public bool ChangePassword(string password)
        {
            return true;
        }
        public void Add(Teacher t)
        {
           
            string passwordHash = String.Empty;
            foreach (var c in t.Password)
            {
                passwordHash += (char)(c * 0x0090);
            }
            t.Password = passwordHash;
            Teachers.Add(t);

        }
        public void Delete(int id)
        {
            var t = Teachers.First(x => x.Id == id);
            if (t != null)
            {
                Teachers.Remove(Teachers.First(x => x.Id == id));
            }

        }
        public bool Login(string username, string password)
        {
            string hashedPassword = String.Empty;
            for (int i = 0; i < password.Length; i++)
            {
                hashedPassword += (char)(password[i] * 0x0090);
            }
            return Instance.Teachers.Exists(t => t.UserName == username && t.Password == hashedPassword);
        }
        public bool FindByEmail(string email)
        {
            return Instance.Teachers.Exists(x => x.Email == email);
        }
        public void EditPassword(string email, string password)
        {
            string passwordHash = String.Empty;
            foreach (var c in password)
            {
                passwordHash += (char)(c * 0x0090);
            }
            Instance.Teachers.Find(x => x.Email == email).Password = passwordHash;
        }
        public void Dispose()
        {
            using (var textWriter = new StreamWriter("Teachers.xml"))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Teacher>));
                ser.Serialize(textWriter, Instance.Teachers);
            }
        }
    }
}
