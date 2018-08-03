using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lBook.Model
{
    public class Student : Person
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        private static int _nextId;
        public List<Exam> Exams { get; set; }
        public List<string> Subjects { get; set; }
        public Student()
        {
            Id = _nextId++;
        }
    }
}
