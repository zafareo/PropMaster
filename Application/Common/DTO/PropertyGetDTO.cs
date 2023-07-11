using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Common.DTO
{
    public class PropertyGetDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Uri Location { get; set; }
        public string ImageUrl { get; set; }
        public bool IsRent { get; set; }
        public Guid OwnerId { get; set; }

        [JsonIgnore]
        public Owner Owner { get; set; }

        public List<Guid> AgentIds { get; set; }

        [JsonIgnore]
        public List<Agent> Agents { get; set; }
    }
}
