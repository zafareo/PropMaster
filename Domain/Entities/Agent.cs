using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("agent")]
    public class Agent : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("contact_number")]
        public string ContactNumber { get; set; }

        [Column("profile_picture")]
        public string ProfilePicture { get; set; }

        [Column("properties_id")]
        public List<Property> Properties { get; set; } // Many-to-many relationship with Property
    }
}
