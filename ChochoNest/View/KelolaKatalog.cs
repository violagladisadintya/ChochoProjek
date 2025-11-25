using ChochoNest.Models;
using ChochoNest.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ChochoNest.View
{
    public partial class KelolaKatalog : Form
    {
        private readonly ProdukContext _controller = new ProdukContext();

        public KelolaKatalog()
        {
            InitializeComponent();
            LoadProdukToPanel();
        }

        private void btn_TambahProduk_Click(object sender, EventArgs e)
        {
            TambahProduk tambahProduk = new TambahProduk(null);

            if (tambahProduk.ShowDialog() == DialogResult.OK)
            {
                LoadProdukToPanel();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProdukToPanel();
        }

        public void LoadProdukToPanel()
        {
            panelProduk.SuspendLayout();
            panelProduk.Controls.Clear();

            try
            {
                var listProduk = _controller.GetProdukFromDatabase();

                foreach (var item in listProduk)
                {
                    Panel kartu = CreateProdukCard(item);
                    panelProduk.Controls.Add(kartu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }

            panelProduk.ResumeLayout();
        }

        private Panel CreateProdukCard(Produk produk)
        {
            Panel card = new Panel
            {
                Size = new Size(220, 320),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            PictureBox pb = new PictureBox
            {
                Size = new Size(180, 140),
                Location = new Point(20, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle
            };

            if (produk.gambarProduk != null && produk.gambarProduk.Length > 0)
            {
                try
                {
                    using (var ms = new MemoryStream(produk.gambarProduk))
                    {
                        pb.Image = Image.FromStream(ms);
                    }
                }
                catch { pb.BackColor = Color.Red; }
            }

            Label lblNama = new Label
            {
                Text = produk.NamaProduk,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(10, 160),
                Size = new Size(200, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblHarga = new Label
            {
                Text = "Rp " + produk.Harga.ToString("N0"),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.DarkOrange,
                Location = new Point(10, 200),
                Size = new Size(200, 25),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblStok = new Label
            {
                Text = $"Stok: {produk.Stok}",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Location = new Point(10, 225),
                Size = new Size(200, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            if (produk.Stok <= 0)
            {
                lblStok.ForeColor = Color.Red;
                lblStok.Text = "HABIS";
            }

            Button btnEdit = new Button
            {
                Text = "Edit",
                Size = new Size(85, 30),
                Location = new Point(15, 260),
                BackColor = Color.SaddleBrown,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            Button btnHapus = new Button
            {
                Text = "Hapus",
                Size = new Size(85, 30),
                Location = new Point(110, 260),
                BackColor = Color.Maroon,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnEdit.Click += (s, e) =>
            {
                TambahProduk form = new TambahProduk(produk);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadProdukToPanel();
            };

            btnHapus.Click += (s, e) =>
            {
                if (MessageBox.Show($"Yakin hapus {produk.NamaProduk}?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _controller.HapusProduk(produk.IdProduk);
                    LoadProdukToPanel(); 
                }
            };

            card.Controls.Add(pb);
            card.Controls.Add(lblNama);
            card.Controls.Add(lblHarga);
            card.Controls.Add(lblStok);
            card.Controls.Add(btnEdit);
            card.Controls.Add(btnHapus);

            return card;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void KelolaKatalog_Load(object sender, EventArgs e)
        {

        }
    }
}