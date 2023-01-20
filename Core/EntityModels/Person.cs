using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityModels
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PersonType { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Item> Items { get; set; }

        public Person()
        {
            Items = new HashSet<Item>();
        }
    }
}
