using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChochoNest.Models
{
    public class TransaksiModel
    {
        public int IdTransaksi { get; set; }
        public DateTime TanggalTransaksi { get; set; }
        public int TotalBayar { get; set; }
        public int IdUser { get; set; }
        public int IdMetodePembayaran { get; set; }
        public string MetodePembayaranString { get; set; }

        public List<DetailTransaksi> ListDetail { get; set; } = new List<DetailTransaksi>();
    }

    public class DetailTransaksi
    {
        public int IdDetailTransaksi { get; set; }
        public int IdTransaksi { get; set; }
        public int IdProduk { get; set; }
        public int JumlahBeli { get; set; }
        public int Subtotal { get; set; }
    }
}
