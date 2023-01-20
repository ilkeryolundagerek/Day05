using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class PersonListItemDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int DepartmantId { get; set; }
        public string DepartmentName { get; set; }
    }

    public class PersonDetailDTO
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
        public DepartmentDTO DepartmentDTO { get; set; }
    }
}
