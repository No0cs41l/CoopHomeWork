using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coop.Models
{
    public class Assortment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
        public IList<AssortimentProduct> AssortimentProducts { get; set; }
    }
}
