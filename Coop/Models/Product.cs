using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string EANCode { get; set; }

        //public virtual ICollection<Assortment> Assortments { get; set; }
        public IList<AssortimentProduct> AssortimentProducts { get; set; }
    }


}
