using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("owner")]
    public class Owner : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("contact_number")]
        public string ContactNumber { get; set; }

        [Column("properties")]
        public List<Property> Properties { get; set; } // One-to-many relationship with Property
    }
}
