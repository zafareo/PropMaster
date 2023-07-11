using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class EmailMessageModel
    {
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [MaxLength(150)]
        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public override string ToString()
        {
            return $"Name:{Name}\nEmail:{Email}\nSubject:{Subject}\nMessage:{Message}";
        }
    }
}
