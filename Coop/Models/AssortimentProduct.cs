using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coop.Models
{
    public class AssortimentProduct
    {
        public int AssortmentId { get; set; }
        public Assortment Assortment { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}
