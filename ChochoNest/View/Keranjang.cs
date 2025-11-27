using ChochoNest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChochoNest.View
{
    public partial class Keranjang : Form
    {
        private List<int> _listIdProduk;
        private readonly ProdukContext _produkController = new ProdukContext();
        public Keranjang(List<int> listIdProduk)
        {
            InitializeComponent();
            _listIdProduk = listIdProduk;


        }

        private void Keranjang_Load(object sender, EventArgs e)
        {
            LoadKeranjang();
        }
        private void LoadKeranjang()
        {
            if (_listIdProduk.Count == 0)
            {
                MessageBox.Show("Keranjang masih kosong.");
                return;
            }

            // Kelompokkan jika ada item yang sama
            var items = _listIdProduk
                .GroupBy(x => x)
                .Select(g => new { IdProduk = g.Key, Qty = g.Count() })
                .ToList();

            foreach (var item in items)
            {
                Produk p = _produkController.GetProdukById(item.IdProduk);

                if (p != null)
                {
                    AddProdukToUI(p, item.Qty);
                }
            }
        }

        private void AddProdukToUI(Produk p, int qty)
        {
            // Contoh tampilan sederhana
            Label lbl = new Label();
            lbl.Text = $"{p.NamaProduk}  x{qty}   | Rp {p.Harga:N0}";
            lbl.AutoSize = true;

            flowLayoutPanel1.Controls.Add(lbl); // pastikan kamu punya panel bernama ini
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

