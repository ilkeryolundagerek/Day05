namespace UI.MVC.Models
{
    public enum PageType { General, Home, About, Contact, People, Departments }
    public class BaseViewModel
    {
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        public PageType Type { get; set; }

        public BaseViewModel(string title, PageType type = PageType.General)
        {
            Title = title;
            Type = type;
        }
    }
}
