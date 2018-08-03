using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lBook.Model
{
   // [AddINotifyPropertyChangedInterface]
    public class Teacher : Person
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string SubjectName { get; set; }
        private static int _nextId;
        public Teacher()
        {
            Id = _nextId++;
        }
    }
}
