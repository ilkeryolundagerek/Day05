using Core.DTOs;
using Core.Services;
using Services.HR;
using UtilitiesCore;

namespace UI.MVC.Models
{
    public class PeopleIndexViewModel : BaseViewModel
    {
        public Pagination<PersonListItemDTO> People { get; set; }
        public PeopleIndexViewModel(IPersonService service, int current_page = 1, int page_size = 10) : base("People List", PageType.People)
        {
            People = new Pagination<PersonListItemDTO>(page_size, current_page, service.GetPeople());
            SubTitle = "Get people list with pagination.";
        }
    }
}
