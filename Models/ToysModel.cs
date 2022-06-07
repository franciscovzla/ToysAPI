using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class ToysModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Name { get; set; }


        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string? Description { get; set; } 

       
        [Range(0, 100, ErrorMessage = "The {0} value cannot exceed the range. ")]
        public int AgeRestriction { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Company { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "The {0} value cannot exceed the range. ")]
        public decimal Price { get; set; }
    }
}
