using lBook.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lBook
{
    public class Password
    {
        public static bool PasswordChecker(string password)
        {
            if (password.Length >= 6 && password.IsValidPassword())
            {

                return true;
            }
            return false;
        }
        public static string RandomConfirmationPassword()
        {
            string symbols = "ABCDEFGHIJKLMNOPQRSTWXYZabcdefghijklmnopqrstwxyz12345";
            string RandomConfirmationPassword = String.Empty;
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                RandomConfirmationPassword += symbols[rand.Next(0, symbols.Length)];
            }
            return RandomConfirmationPassword;
        }
        public static string RecoverPassword(string email)
        {
            string PasswordForRecovering = String.Empty;
            if (String.IsNullOrEmpty(email))
            {
                throw new Exception("YOU MUST ENTER YOUR EMAIL");
            }
            using (StreamWriter fs = new StreamWriter("RecoverPassword.txt"))
            {
                PasswordForRecovering = RandomConfirmationPassword();
                fs.WriteLine(PasswordForRecovering);
            }
            return PasswordForRecovering;
        }
        public static Role EditPasswordByEmail(string email)
        {
            if (TeacherDAO.Instance.Teachers.Exists(x=>x.Email==email))
            {
                return Role.Teacher;
            }
            return Role.Student;
        }

    }
}
