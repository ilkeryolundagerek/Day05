namespace Core.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PersonListItemDTO> People { get; set; }
        public DepartmentDTO()
        {
            People = new HashSet<PersonListItemDTO>();
        }
    }
}
