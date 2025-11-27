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
    public partial class KatalogPelanggan : Form
    {
        public static List<int> Keranjang = new List<int>();

        private readonly ProdukContext _controller = new ProdukContext();
        private FlowLayoutPanel panelProduk;

        public KatalogPelanggan()
        {
            InitializeComponent();
            InitializePanelProduk();
            LoadProdukToPanel();
        }

        private void InitializePanelProduk()
        {
            panelProduk = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10),
                BackColor = Color.WhiteSmoke
            };
            panelProduk.BackgroundImage = this.BackgroundImage;
            panelProduk.BackgroundImageLayout = ImageLayout.Zoom;
            this.Controls.Add(panelProduk);
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
                    // Hanya tampilkan produk yang masih ada stoknya
                    if (item.Stok > 0)
                    {
                        Panel kartu = CreateProdukCard(item);
                        panelProduk.Controls.Add(kartu);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }

            panelProduk.ResumeLayout();
        }

        public void TambahKeKeranjang(int idProduk)
        {
            Keranjang.Add(idProduk);
            MessageBox.Show("Berhasil ditambahkan ke keranjang!",
                "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Panel CreateProdukCard(Produk produk)
        {
            Panel card = new Panel
            {
                Size = new Size(220, 320),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Cursor = Cursors.Hand
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
                Text = $"Tersedia: {produk.Stok}",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Green,
                Location = new Point(10, 225),
                Size = new Size(200, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button btnMasukkanKeranjang = new Button
            {
                Text = "Masukkan Ke Keranjang",
                Size = new Size(190, 35),
                Location = new Point(15, 260),
                BackColor = Color.SaddleBrown,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,

                // SIMPAN ID PRODUK KE TAG
                Tag = produk.IdProduk
            };


            btnMasukkanKeranjang.FlatAppearance.BorderSize = 0;

            // Hover effect untuk tombol beli
            btnMasukkanKeranjang.MouseEnter += (s, e) => btnMasukkanKeranjang.BackColor = Color.Chocolate;
            btnMasukkanKeranjang.MouseLeave += (s, e) => btnMasukkanKeranjang.BackColor = Color.SaddleBrown;

            btnMasukkanKeranjang.Click += (s, e) =>
            {
                int idProduk = (int)((Button)s).Tag;

                // Tambahkan ke keranjang
                TambahKeKeranjang(idProduk);
            };


            // Hover effect untuk card
            card.MouseEnter += (s, e) =>
            {
                card.BackColor = Color.FromArgb(250, 250, 250);
                card.BorderStyle = BorderStyle.Fixed3D;
            };

            card.MouseLeave += (s, e) =>
            {
                card.BackColor = Color.White;
                card.BorderStyle = BorderStyle.FixedSingle;
            };

            card.Controls.Add(pb);
            card.Controls.Add(lblNama);
            card.Controls.Add(lblHarga);
            card.Controls.Add(lblStok);
            card.Controls.Add(btnMasukkanKeranjang);

            return card;
        }

        private void KatalogPelanggan_Load(object sender, EventArgs e)
        {

        }

        private void KeranjangBTN_Click(object sender, EventArgs e)
        {
            Keranjang formKeranjang = new Keranjang(Keranjang);
            formKeranjang.ShowDialog();
        }
    }
}