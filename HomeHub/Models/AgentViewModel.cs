namespace HomeHub.Models
{
    public class AgentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public List<PropertyViewModel> Properties { get; set; }
    }
}