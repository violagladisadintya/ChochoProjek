using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChochoNest.Models
{
    public class Produk
    {
        private int _idProduk;
        private string _namaProduk;
        private int _harga;
        private int _stok;
        //private byte[] _gambarProduk;

        public int IdProduk
        {
            get { return _idProduk; }
            set { _idProduk = value; }
        }

        public string NamaProduk
        {
            get { return _namaProduk; }
            set { _namaProduk = value; }
        }

        public int Harga
        {
            get { return _harga; }
            set { _harga = value; }
        }

        public int Stok
        {
            get { return _stok; }
            set { _stok = value; }
        }
        public byte[] gambarProduk { get; set; }
    }
}
