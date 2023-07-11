using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("property")]
    public class Property : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("location")]
        public Uri Location { get; set; }

        [Column("image_url")]
        public string ImageUrl { get; set; }

        [Column("is_rent")]
        public bool IsRent { get; set; }

        [ForeignKey("owner_id")]
        public Guid OwnerId { get; set; } // Foreign key to Owner

        [JsonIgnore]
        public Owner Owner { get; set; }
        public List<Agent> Agents { get; set; } // Many-to-many relationship with Agent
    }
}
