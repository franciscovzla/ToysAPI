using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class ToysModel
    {
        //TODO: If we already have a configuration file, lets try to move the Keys and Constraints there to leave a clean class here
        //1.- Conventions (Inferred Keys, Relationships, etc.)
        //2.- Data Annotations // Attributes on each property
        //3.- Fluent API // On entity configuration type, you can add even more logic than Data Annotations

        //[Key]
        public int? Id { get; set; }

        //[Required]
        //[StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Name { get; set; }

        
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string? Description { get; set; } 

       
        [Range(0, 100, ErrorMessage = "The {0} value cannot exceed the range. ")]
        public int AgeRestriction { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        //TODO: This is not in the code Challenge but for practical purposes lets create a FK to a COmpanyTable to practice that part.
        public string Company { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "The {0} value cannot exceed the range. ")]
        public decimal Price { get; set; }


        //Navigation Properties
        //[ForeignKey("FK_Toys_Companies")]
        //public List<Company> Companies;
    }
}
