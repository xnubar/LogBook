using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lBook.Model
{
    /// <summary>
    /// /Abstract class for Admin, Student, and Teacher
    /// </summary>
    #region PERSON
    [XmlInclude(typeof(Teacher))]
    [XmlInclude(typeof(Student))]
    [Serializable]
    [XmlRoot(ElementName = "PersonData", Namespace = "person")]
    public abstract class Person
    {
        public string this[string columnName] => throw new NotImplementedException();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DateBirth { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public string Image { get; set; }
    
    }
   
    #endregion
}
