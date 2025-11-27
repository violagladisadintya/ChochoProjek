using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChochoNest.Models
{
    internal class Keranjang
    {
        public int Id { get; set; }
        public int ProdukId { get; set; } = 0;
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal PriceTotal { get; set; }
            public int QuantityTotal { get; set; }
            
    }
}
