using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.MVC.Models
{
    public class PersonFormViewModel : BaseViewModel
    {
        public PersonFormViewModel(IPersonService service, string title, PageType type = PageType.People, PersonDetailDTO person = null) : base(title, type)
        {
            Person = person;
            _service = service;
            SubTitle = title + " page subtitle.";
        }
        private IPersonService _service;
        public PersonDetailDTO? Person { get; set; }
        public SelectList Departments { get => new SelectList(_service.GetDepartments(), "Id", "Name", Person.DepartmentId); }
    }
}
