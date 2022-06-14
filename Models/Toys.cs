using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Toys
    {
        public int Id { get; set; }


        public string Name { get; set; }



        public string? Description { get; set; }


        public int AgeRestriction { get; set; }


       
        public int CompanyId { get; set; }


        public decimal Price { get; set; }
        
        public virtual Company Company { get; set; }

    }
}
