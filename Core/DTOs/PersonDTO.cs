using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class PersonListItemDTO
    {
        [Display(Name = "Business ID", Prompt = "Business ID")]
        public int Id { get; set; }

        [Display(Name = "Firstname", Prompt = "Firstname")]
        public string Firstname { get; set; }

        [Display(Name = "Middlename", Prompt = "Middlename")]
        public string Middlename { get; set; }

        [Display(Name = "Lastname", Prompt = "Lastname")]
        public string Lastname { get; set; }

        [Display(Name = "E-Mail Address", Prompt = "E-Mail Address")]
        public string Email { get; set; }

        [Display(Name = "Department ID", Prompt = "Department ID")]
        public int DepartmentId { get; set; }

        [Display(Name = "Department Name", Prompt = "Department Name")]
        public string DepartmentName { get; set; }
    }

    public class PersonDetailDTO
    {
        [Display(Name = "Business ID", Prompt = "Business ID"), Required]
        public int Id { get; set; }

        [Display(Name = "Firstname", Prompt = "Firstname"), Required]
        public string Firstname { get; set; }

        [Display(Name = "Middlename", Prompt = "Middlename"), Required]
        public string Middlename { get; set; }

        [Display(Name = "Lastname", Prompt = "Lastname"), Required]
        public string Lastname { get; set; }

        [Display(Name = "E-Mail Address", Prompt = "E-Mail Address"), EmailAddress, Required]
        public string Email { get; set; }

        [Display(Name = "Department ID", Prompt = "Department ID")]
        public int DepartmentId { get; set; }

        [Display(Name = "Department Name", Prompt = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Department Description", Prompt = "Department Description"), DataType(DataType.MultilineText)]
        public string DepartmentDescription { get; set; }

        [Display(Name = "Phone Number", Prompt = "Phone Number"), DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Address", Prompt = "Address"), DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "City", Prompt = "City")]
        public string City { get; set; }

        [Display(Name = "Person Type", Prompt = "Person Type")]
        public string PersonType { get; set; }
    }
}
