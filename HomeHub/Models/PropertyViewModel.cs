namespace HomeHub.Models
{
    public class PropertyViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public bool IsRent { get; set; }
        public Guid OwnerId { get; set; }
        public List<AgentViewModel> Agents { get; set; }
    }
}
