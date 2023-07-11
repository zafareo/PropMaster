namespace HomeHub.Models
{
    public class OwnerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public List<PropertyViewModel> Properties { get; set; }
    }
}
