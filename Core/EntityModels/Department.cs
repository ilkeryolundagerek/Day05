namespace Core.EntityModels
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Person> People { get; set; }
        public Department()
        {
            People = new HashSet<Person>();
        }
    }
}
