using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lBook.Model.Admin
{
    class Admin:Person
    {
        public int Id { get; set; }
        private static int _nextId;
        public Admin()
        {
            Id = _nextId++;
        }
    }
}
