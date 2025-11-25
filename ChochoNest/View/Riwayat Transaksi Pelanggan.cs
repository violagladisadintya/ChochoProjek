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
    // Static class untuk menyimpan transaksi (sementara di memory)
    public static class DataTransaksi
    {
        private static List<TransaksiModel> transaksiList = new List<TransaksiModel>();
        private static int lastId = 0;

        public static int TambahTransaksi(int idUser, int idMetodePembayaran, string metodePembayaran, List<ItemKeranjang> items)
        {
            lastId++;

            var transaksi = new TransaksiModel
            {
                IdTransaksi = lastId,
                TanggalTransaksi = DateTime.Now,
                TotalBayar = (int)items.Sum(x => x.Subtotal),
                IdUser = idUser,
                IdMetodePembayaran = idMetodePembayaran,
                MetodePembayaranString = metodePembayaran,
                ListDetail = new List<DetailTransaksi>()
            };

            int detailId = 1;
            foreach (var item in items)
            {
                transaksi.ListDetail.Add(new DetailTransaksi
                {
                    IdDetailTransaksi = detailId++,
                    IdTransaksi = lastId,
                    IdProduk = item.IdProduk,
                    JumlahBeli = item.Jumlah,
                    Subtotal = (int)item.Subtotal
                });
            }

            transaksiList.Add(transaksi);
            return lastId;
        }

        public static List<TransaksiModel> GetAllTransaksi()
        {
            return transaksiList.OrderByDescending(x => x.TanggalTransaksi).ToList();
        }

        public static TransaksiModel GetTransaksiById(int id)
        {
            return transaksiList.FirstOrDefault(x => x.IdTransaksi == id);
        }

        public static List<TransaksiModel> GetTransaksiByUser(int idUser)
        {
            return transaksiList.Where(x => x.IdUser == idUser)
                                .OrderByDescending(x => x.TanggalTransaksi)
                                .ToList();
        }
    }

    public partial class Riwayat_Transaksi_Pelanggan : Form
    {
        private DataGridView dgvTransaksi;
        private DataGridView dgvDetail;
        private Label lblTotalTransaksi;
        private Label lblTotalPendapatan;
        private DateTimePicker dtpDari;
        private DateTimePicker dtpSampai;
        private Button btnFilter;
        private Button btnRefresh;
        private ComboBox cmbMetodePembayaran;
        private readonly ProdukContext _produkController = new ProdukContext();
        private int? filterIdUser = null; // null = semua user
        private Panel panelMain;

        public Riwayat_Transaksi_Pelanggan(int? idUser = null)
        {
            InitializeComponent();
            filterIdUser = idUser;
        }

        private void Riwayat_Transaksi_Pelanggan_Load(object sender, EventArgs e)
        {
            InitializeCustomControls();
            LoadTransaksi();
        }

        private void InitializeCustomControls()
        {
            // Set form properties
            this.Text = "Riwayat Transaksi - ChochoNest";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.WhiteSmoke;

            // Main Panel
            panelMain = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            // Panel Header
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.SaddleBrown,
                Padding = new Padding(20)
            };

            Label lblHeader = new Label
            {
                Text = "📊 RIWAYAT TRANSAKSI",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 10),
                AutoSize = true
            };

            // Panel Filter
            Panel filterPanel = new Panel
            {
                Location = new Point(20, 45),
                Size = new Size(1140, 45),
                BackColor = Color.Transparent
            };

            Label lblDari = new Label
            {
                Text = "Dari:",
                ForeColor = Color.White,
                Location = new Point(0, 12),
                AutoSize = true
            };

            dtpDari = new DateTimePicker
            {
                Location = new Point(50, 8),
                Size = new Size(150, 25),
                Format = DateTimePickerFormat.Short
            };
            dtpDari.Value = DateTime.Now.AddMonths(-1);

            Label lblSampai = new Label
            {
                Text = "Sampai:",
                ForeColor = Color.White,
                Location = new Point(220, 12),
                AutoSize = true
            };

            dtpSampai = new DateTimePicker
            {
                Location = new Point(290, 8),
                Size = new Size(150, 25),
                Format = DateTimePickerFormat.Short
            };

            Label lblMetode = new Label
            {
                Text = "Metode:",
                ForeColor = Color.White,
                Location = new Point(460, 12),
                AutoSize = true
            };

            cmbMetodePembayaran = new ComboBox
            {
                Location = new Point(530, 8),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbMetodePembayaran.Items.AddRange(new object[] { "Semua", "Cash", "Transfer", "E-Wallet", "Debit/Credit" });
            cmbMetodePembayaran.SelectedIndex = 0;

            btnFilter = new Button
            {
                Text = "Filter",
                Location = new Point(700, 8),
                Size = new Size(80, 30),
                BackColor = Color.White,
                ForeColor = Color.SaddleBrown,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.Click += BtnFilter_Click;

            btnRefresh = new Button
            {
                Text = "Refresh",
                Location = new Point(790, 8),
                Size = new Size(80, 30),
                BackColor = Color.White,
                ForeColor = Color.SaddleBrown,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += (s, ev) => LoadTransaksi();

            filterPanel.Controls.Add(lblDari);
            filterPanel.Controls.Add(dtpDari);
            filterPanel.Controls.Add(lblSampai);
            filterPanel.Controls.Add(dtpSampai);
            filterPanel.Controls.Add(lblMetode);
            filterPanel.Controls.Add(cmbMetodePembayaran);
            filterPanel.Controls.Add(btnFilter);
            filterPanel.Controls.Add(btnRefresh);

            headerPanel.Controls.Add(lblHeader);
            headerPanel.Controls.Add(filterPanel);

            // Panel Info
            Panel infoPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(20, 10, 20, 10)
            };

            lblTotalTransaksi = new Label
            {
                Text = "Total Transaksi: 0",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.SaddleBrown,
                Location = new Point(20, 20),
                AutoSize = true
            };

            lblTotalPendapatan = new Label
            {
                Text = "Total Pendapatan: Rp 0",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Green,
                Location = new Point(400, 20),
                AutoSize = true
            };

            infoPanel.Controls.Add(lblTotalTransaksi);
            infoPanel.Controls.Add(lblTotalPendapatan);

            // Split Container untuk 2 grid
            SplitContainer splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 600,
                BackColor = Color.Gray
            };

            // Panel kiri - Daftar Transaksi
            Panel leftPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            Label lblTransaksi = new Label
            {
                Text = "Daftar Transaksi",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = Color.LightGray,
                Padding = new Padding(10, 5, 0, 0)
            };

            dgvTransaksi = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                Font = new Font("Segoe UI", 9)
            };

            dgvTransaksi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdTransaksi",
                HeaderText = "ID Transaksi",
                FillWeight = 15
            });

            dgvTransaksi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tanggal",
                HeaderText = "Tanggal",
                FillWeight = 25
            });

            dgvTransaksi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdUser",
                HeaderText = "ID User",
                FillWeight = 15
            });

            dgvTransaksi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MetodePembayaran",
                HeaderText = "Metode",
                FillWeight = 20
            });

            dgvTransaksi.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Total Bayar",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                FillWeight = 25
            });

            dgvTransaksi.SelectionChanged += DgvTransaksi_SelectionChanged;

            leftPanel.Controls.Add(dgvTransaksi);
            leftPanel.Controls.Add(lblTransaksi);

            // Panel kanan - Detail Transaksi
            Panel rightPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            Label lblDetail = new Label
            {
                Text = "Detail Transaksi",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = Color.LightGray,
                Padding = new Padding(10, 5, 0, 0)
            };

            dgvDetail = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                Font = new Font("Segoe UI", 9)
            };

            dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdProduk",
                HeaderText = "ID Produk",
                FillWeight = 15
            });

            dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NamaProduk",
                HeaderText = "Nama Produk",
                FillWeight = 40
            });

            dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "JumlahBeli",
                HeaderText = "Jumlah",
                FillWeight = 15
            });

            dgvDetail.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                HeaderText = "Subtotal",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                FillWeight = 30
            });

            rightPanel.Controls.Add(dgvDetail);
            rightPanel.Controls.Add(lblDetail);

            splitContainer.Panel1.Controls.Add(leftPanel);
            splitContainer.Panel2.Controls.Add(rightPanel);

            panelMain.Controls.Add(splitContainer);
            panelMain.Controls.Add(infoPanel);
            panelMain.Controls.Add(headerPanel);

            // Add main panel to form
            this.Controls.Add(panelMain);
        }

        private void LoadTransaksi()
        {
            dgvTransaksi.Rows.Clear();
            dgvDetail.Rows.Clear();

            var allTransaksi = filterIdUser.HasValue
                ? DataTransaksi.GetTransaksiByUser(filterIdUser.Value)
                : DataTransaksi.GetAllTransaksi();

            // Filter berdasarkan tanggal
            var filteredTransaksi = allTransaksi.Where(x =>
                x.TanggalTransaksi.Date >= dtpDari.Value.Date &&
                x.TanggalTransaksi.Date <= dtpSampai.Value.Date
            ).ToList();

            // Filter berdasarkan metode pembayaran
            if (cmbMetodePembayaran.SelectedItem?.ToString() != "Semua")
            {
                filteredTransaksi = filteredTransaksi.Where(x =>
                    x.MetodePembayaranString == cmbMetodePembayaran.SelectedItem?.ToString()
                ).ToList();
            }

            foreach (var transaksi in filteredTransaksi)
            {
                dgvTransaksi.Rows.Add(
                    transaksi.IdTransaksi,
                    transaksi.TanggalTransaksi.ToString("dd/MM/yyyy HH:mm"),
                    transaksi.IdUser,
                    transaksi.MetodePembayaranString,
                    transaksi.TotalBayar
                );
            }

            // Update info
            lblTotalTransaksi.Text = $"Total Transaksi: {filteredTransaksi.Count}";
            lblTotalPendapatan.Text = $"Total Pendapatan: Rp {filteredTransaksi.Sum(x => x.TotalBayar):N0}";
        }

        private void DgvTransaksi_SelectionChanged(object sender, EventArgs e)
        {
            dgvDetail.Rows.Clear();

            if (dgvTransaksi.SelectedRows.Count > 0)
            {
                int idTransaksi = Convert.ToInt32(dgvTransaksi.SelectedRows[0].Cells["IdTransaksi"].Value);
                var transaksi = DataTransaksi.GetTransaksiById(idTransaksi);

                if (transaksi != null && transaksi.ListDetail != null)
                {
                    // Ambil semua produk untuk menampilkan nama
                    var allProduk = _produkController.GetProdukFromDatabase();

                    foreach (var detail in transaksi.ListDetail)
                    {
                        var produk = allProduk.FirstOrDefault(p => p.IdProduk == detail.IdProduk);
                        string namaProduk = produk?.NamaProduk ?? "Produk Tidak Ditemukan";

                        dgvDetail.Rows.Add(
                            detail.IdProduk,
                            namaProduk,
                            detail.JumlahBeli,
                            detail.Subtotal
                        );
                    }
                }
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            LoadTransaksi();
        }
    }
}