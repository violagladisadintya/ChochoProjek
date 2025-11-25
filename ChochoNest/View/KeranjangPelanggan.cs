//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using ChochoNest.Models;

//namespace ChochoNest.View
//{
//    // Class untuk item keranjang
//    public class ItemKeranjang
//    {
//        public int IdProduk { get; set; }
//        public string NamaProduk { get; set; }
//        public decimal Harga { get; set; }
//        public int Jumlah { get; set; }
//        public decimal Subtotal => Harga * Jumlah;
//    }

//    // Static class untuk menyimpan keranjang
//    public static class Keranjang
//    {
//        private static List<ItemKeranjang> items = new List<ItemKeranjang>();

//        public static void TambahItem(Produk produk, int jumlah = 1)
//        {
//            var existing = items.FirstOrDefault(x => x.IdProduk == produk.IdProduk);

//            if (existing != null)
//            {
//                existing.Jumlah += jumlah;
//            }
//            else
//            {
//                items.Add(new ItemKeranjang
//                {
//                    IdProduk = produk.IdProduk,
//                    NamaProduk = produk.NamaProduk,
//                    Harga = produk.Harga,
//                    Jumlah = jumlah
//                });
//            }
//        }

//        public static void HapusItem(int idProduk)
//        {
//            items.RemoveAll(x => x.IdProduk == idProduk);
//        }

//        public static void UpdateJumlah(int idProduk, int jumlahBaru)
//        {
//            var item = items.FirstOrDefault(x => x.IdProduk == idProduk);
//            if (item != null)
//            {
//                item.Jumlah = jumlahBaru;
//            }
//        }

//        public static void Kosongkan()
//        {
//            items.Clear();
//        }

//        public static List<ItemKeranjang> GetItems()
//        {
//            return items.ToList();
//        }

//        public static ItemKeranjang GetItemById(int idProduk)
//        {
//            return items.FirstOrDefault(x => x.IdProduk == idProduk);
//        }

//        public static bool IsItemExists(int idProduk)
//        {
//            return items.Any(x => x.IdProduk == idProduk);
//        }

//        public static int JumlahItem => items.Sum(x => x.Jumlah);

//        public static decimal TotalHarga => items.Sum(x => x.Subtotal);
//    }

//    public partial class KeranjangPelanggan : Form
//    {
//        private DataGridView dgvKeranjang;
//        private Label lblTotal;
//        private Label lblJumlahItem;
//        private Button btnTambah;
//        private Button btnEdit;
//        private Button btnHapus;
//        private Button btnKosongkan;
//        private Button btnCheckout;
//        private readonly ProdukContext _produkController = new ProdukContext();

//        public KeranjangPelanggan()
//        {
//            InitializeComponent();
//        }

//        private void KeranjangPelanggan_Load(object sender, EventArgs e)
//        {
//            InitializeCustomControls();
//            LoadKeranjang();
//        }

//        private void InitializeCustomControls()
//        {
//            Panel headerPanel = new Panel
//            {
//                Dock = DockStyle.Top
//            };

//            Label lblHeader = new Label
//            {
//                Text = "KERANJANG BELANJA",
//                Dock = DockStyle.Fill
//            };

//            lblJumlahItem = new Label
//            {
//                Text = "0 Item",
//                Dock = DockStyle.Right,
//                AutoSize = true
//            };

//            headerPanel.Controls.Add(lblHeader);
//            headerPanel.Controls.Add(lblJumlahItem);

//            Panel toolbarPanel = new Panel
//            {
//                Dock = DockStyle.Top
//            };

//            btnTambah = new Button
//            {
//                Text = "Tambah Item"
//            };
//            btnTambah.Click += BtnTambah_Click;

//            btnEdit = new Button
//            {
//                Text = "Edit Item"
//            };
//            btnEdit.Click += BtnEdit_Click;

//            btnHapus = new Button
//            {
//                Text = "Hapus Item"
//            };
//            btnHapus.Click += BtnHapus_Click;

//            btnKosongkan = new Button
//            {
//                Text = "Kosongkan"
//            };
//            btnKosongkan.Click += BtnKosongkan_Click;

//            toolbarPanel.Controls.Add(btnTambah);
//            toolbarPanel.Controls.Add(btnEdit);
//            toolbarPanel.Controls.Add(btnHapus);
//            toolbarPanel.Controls.Add(btnKosongkan);

//            dgvKeranjang = new DataGridView
//            {
//                Dock = DockStyle.Fill,
//                AllowUserToAddRows = false,
//                AllowUserToDeleteRows = false,
//                ReadOnly = true,
//                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
//                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
//                RowHeadersVisible = false,
//                MultiSelect = false
//            };

//            dgvKeranjang.Columns.Add(new DataGridViewTextBoxColumn
//            {
//                Name = "IdProduk",
//                HeaderText = "ID Produk"
//            });

//            dgvKeranjang.Columns.Add(new DataGridViewTextBoxColumn
//            {
//                Name = "NamaProduk",
//                HeaderText = "Nama Produk"
//            });

//            dgvKeranjang.Columns.Add(new DataGridViewTextBoxColumn
//            {
//                Name = "Harga",
//                HeaderText = "Harga",
//                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
//            });

//            dgvKeranjang.Columns.Add(new DataGridViewTextBoxColumn
//            {
//                Name = "Jumlah",
//                HeaderText = "Jumlah"
//            });

//            dgvKeranjang.Columns.Add(new DataGridViewTextBoxColumn
//            {
//                Name = "Subtotal",
//                HeaderText = "Subtotal",
//                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
//            });

//            dgvKeranjang.CellDoubleClick += (s, e) => BtnEdit_Click(s, e);

//            Panel footerPanel = new Panel
//            {
//                Dock = DockStyle.Bottom
//            };

//            lblTotal = new Label
//            {
//                Text = "Total: Rp 0",
//                AutoSize = true
//            };

//            btnCheckout = new Button
//            {
//                Text = "Checkout"
//            };
//            btnCheckout.Click += BtnCheckout_Click;

//            footerPanel.Controls.Add(lblTotal);
//            footerPanel.Controls.Add(btnCheckout);

//            this.Controls.Add(dgvKeranjang);
//            this.Controls.Add(toolbarPanel);
//            this.Controls.Add(headerPanel);
//            this.Controls.Add(footerPanel);
//        }

//        private void LoadKeranjang()
//        {
//            dgvKeranjang.Rows.Clear();

//            var items = Keranjang.GetItems();

//            foreach (var item in items)
//            {
//                dgvKeranjang.Rows.Add(
//                    item.IdProduk,
//                    item.NamaProduk,
//                    item.Harga,
//                    item.Jumlah,
//                    item.Subtotal
//                );
//            }

//            UpdateTotal();
//        }

//        private void UpdateTotal()
//        {
//            lblTotal.Text = $"Total: Rp {Keranjang.TotalHarga:N0}";
//            lblJumlahItem.Text = $"{Keranjang.JumlahItem} Item";
//        }

//        private void BtnTambah_Click(object sender, EventArgs e)
//        {
//            FormTambahKeranjang form = new FormTambahKeranjang();
//            if (form.ShowDialog() == DialogResult.OK)
//            {
//                LoadKeranjang();
//            }
//        }

//        private void BtnEdit_Click(object sender, EventArgs e)
//        {
//            if (dgvKeranjang.SelectedRows.Count == 0)
//            {
//                MessageBox.Show("Pilih item yang akan diedit!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            int idProduk = Convert.ToInt32(dgvKeranjang.SelectedRows[0].Cells["IdProduk"].Value);
//            var item = Keranjang.GetItemById(idProduk);

//            if (item != null)
//            {
//                FormTambahKeranjang form = new FormTambahKeranjang(item);
//                if (form.ShowDialog() == DialogResult.OK)
//                {
//                    LoadKeranjang();
//                }
//            }
//        }

//        private void BtnHapus_Click(object sender, EventArgs e)
//        {
//            if (dgvKeranjang.SelectedRows.Count == 0)
//            {
//                MessageBox.Show("Pilih item yang akan dihapus!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            int idProduk = Convert.ToInt32(dgvKeranjang.SelectedRows[0].Cells["IdProduk"].Value);
//            string namaProduk = dgvKeranjang.SelectedRows[0].Cells["NamaProduk"].Value.ToString();

//            var result = MessageBox.Show(
//                $"Hapus {namaProduk} dari keranjang?",
//                "Konfirmasi",
//                MessageBoxButtons.YesNo,
//                MessageBoxIcon.Question
//            );

//            if (result == DialogResult.Yes)
//            {
//                Keranjang.HapusItem(idProduk);
//                LoadKeranjang();
//                MessageBox.Show("Item berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }

//        private void BtnKosongkan_Click(object sender, EventArgs e)
//        {
//            if (Keranjang.JumlahItem == 0)
//            {
//                MessageBox.Show("Keranjang sudah kosong!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            var result = MessageBox.Show(
//                "Kosongkan semua item dari keranjang?",
//                "Konfirmasi",
//                MessageBoxButtons.YesNo,
//                MessageBoxIcon.Question
//            );

//            if (result == DialogResult.Yes)
//            {
//                Keranjang.Kosongkan();
//                LoadKeranjang();
//                MessageBox.Show("Keranjang berhasil dikosongkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }

//        private void BtnCheckout_Click(object sender, EventArgs e)
//        {
//            if (Keranjang.JumlahItem == 0)
//            {
//                MessageBox.Show("Keranjang masih kosong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            Form inputForm = new Form
//            {
//                Text = "Checkout",
//                StartPosition = FormStartPosition.CenterParent,
//                FormBorderStyle = FormBorderStyle.FixedDialog,
//                MaximizeBox = false,
//                MinimizeBox = false
//            };

//            Label lblInfo = new Label
//            {
//                Text = $"Total: Rp {Keranjang.TotalHarga:N0}\nJumlah Item: {Keranjang.JumlahItem}",
//                AutoSize = true
//            };

//            Label lblIdUser = new Label
//            {
//                Text = "ID User:",
//                AutoSize = true
//            };

//            NumericUpDown numIdUser = new NumericUpDown
//            {
//                Minimum = 1,
//                Maximum = 99999,
//                Value = 1
//            };

//            Label lblMetode = new Label
//            {
//                Text = "Metode Bayar:",
//                AutoSize = true
//            };

//            ComboBox cmbMetode = new ComboBox
//            {
//                DropDownStyle = ComboBoxStyle.DropDownList
//            };
//            cmbMetode.Items.AddRange(new object[] { "Cash", "Transfer", "E-Wallet", "Debit/Credit" });
//            cmbMetode.SelectedIndex = 0;

//            Label lblIdMetode = new Label
//            {
//                Text = "ID Metode:",
//                AutoSize = true
//            };

//            NumericUpDown numIdMetode = new NumericUpDown
//            {
//                Minimum = 1,
//                Maximum = 99999,
//                Value = 1
//            };

//            Button btnBayar = new Button
//            {
//                Text = "Bayar"
//            };

//            btnBayar.Click += (s, ev) =>
//            {
//                int idUser = (int)numIdUser.Value;
//                int idMetodePembayaran = (int)numIdMetode.Value;
//                string metodePembayaran = cmbMetode.SelectedItem.ToString();

//                var items = Keranjang.GetItems();
//                int idTransaksi = DataTransaksi.TambahTransaksi(idUser, idMetodePembayaran, metodePembayaran, items);

//                var transaksi = DataTransaksi.GetTransaksiById(idTransaksi);

//                MessageBox.Show(
//                    $"Pembayaran Berhasil!\n\n" +
//                    $"ID Transaksi: {transaksi.IdTransaksi}\n" +
//                    $"Tanggal: {transaksi.TanggalTransaksi:dd/MM/yyyy HH:mm}\n" +
//                    $"Metode: {transaksi.MetodePembayaranString}\n" +
//                    $"Total: Rp {transaksi.TotalBayar:N0}\n\n" +
//                    $"Terima kasih telah berbelanja!",
//                    "Sukses",
//                    MessageBoxButtons.OK,
//                    MessageBoxIcon.Information
//                );

//                Keranjang.Kosongkan();
//                LoadKeranjang();
//                inputForm.Close();
//                this.Close();
//            };

//            inputForm.Controls.Add(lblInfo);
//            inputForm.Controls.Add(lblIdUser);
//            inputForm.Controls.Add(numIdUser);
//            inputForm.Controls.Add(lblMetode);
//            inputForm.Controls.Add(cmbMetode);
//            inputForm.Controls.Add(lblIdMetode);
//            inputForm.Controls.Add(numIdMetode);
//            inputForm.Controls.Add(btnBayar);
//            inputForm.AcceptButton = btnBayar;

//            inputForm.ShowDialog();
//        }
//    }

//    // Form untuk Tambah/Edit Item Keranjang
//    public partial class FormTambahKeranjang : Form
//    {
//        private readonly ProdukContext _produkController = new ProdukContext();
//        private ComboBox cmbProduk;
//        private NumericUpDown numJumlah;
//        private Label lblHarga;
//        private Label lblSubtotal;
//        private Label lblStok;
//        private Button btnSimpan;
//        private Button btnBatal;
//        private Produk selectedProduk;
//        private ItemKeranjang itemEdit;
//        private bool isEditMode = false;

//        public FormTambahKeranjang(ItemKeranjang itemToEdit = null)
//        {
//            InitializeComponent();
//            itemEdit = itemToEdit;
//            isEditMode = itemToEdit != null;
//        }

//        private void FormTambahKeranjang_Load(object sender, EventArgs e)
//        {
//            InitializeCustomControls();
//            LoadProduk();

//            if (isEditMode)
//            {
//                LoadDataEdit();
//            }
//        }

//        private void InitializeCustomControls()
//        {
//            this.Text = isEditMode ? "Edit Item Keranjang" : "Tambah ke Keranjang";

//            Label lblProduk = new Label
//            {
//                Text = "Pilih Produk:",
//                AutoSize = true
//            };

//            cmbProduk = new ComboBox
//            {
//                DropDownStyle = ComboBoxStyle.DropDownList,
//                DisplayMember = "NamaProduk",
//                ValueMember = "IdProduk",
//                Enabled = !isEditMode
//            };
//            cmbProduk.SelectedIndexChanged += CmbProduk_SelectedIndexChanged;

//            lblStok = new Label
//            {
//                Text = "Stok: -",
//                AutoSize = true
//            };

//            lblHarga = new Label
//            {
//                Text = "Harga: Rp 0",
//                AutoSize = true
//            };

//            Label lblJumlahText = new Label
//            {
//                Text = "Jumlah:",
//                AutoSize = true
//            };

//            numJumlah = new NumericUpDown
//            {
//                Minimum = 1,
//                Maximum = 999,
//                Value = 1
//            };
//            numJumlah.ValueChanged += NumJumlah_ValueChanged;

//            lblSubtotal = new Label
//            {
//                Text = "Subtotal: Rp 0",
//                AutoSize = true
//            };

//            btnSimpan = new Button
//            {
//                Text = isEditMode ? "Update" : "Tambah",
//                DialogResult = DialogResult.OK
//            };
//            btnSimpan.Click += BtnSimpan_Click;

//            btnBatal = new Button
//            {
//                Text = "Batal",
//                DialogResult = DialogResult.Cancel
//            };

//            this.Controls.Add(lblProduk);
//            this.Controls.Add(cmbProduk);
//            this.Controls.Add(lblStok);
//            this.Controls.Add(lblHarga);
//            this.Controls.Add(lblJumlahText);
//            this.Controls.Add(numJumlah);
//            this.Controls.Add(lblSubtotal);
//            this.Controls.Add(btnSimpan);
//            this.Controls.Add(btnBatal);

//            this.AcceptButton = btnSimpan;
//            this.CancelButton = btnBatal;
//        }

//        private void LoadProduk()
//        {
//            var listProduk = _produkController.GetProdukFromDatabase();
//            var produkTersedia = listProduk.Where(p => p.Stok > 0).ToList();

//            cmbProduk.DataSource = produkTersedia;
//        }

//        private void LoadDataEdit()
//        {
//            var produk = _produkController.GetProdukFromDatabase()
//                .FirstOrDefault(p => p.IdProduk == itemEdit.IdProduk);

//            if (produk != null)
//            {
//                cmbProduk.SelectedValue = produk.IdProduk;
//                numJumlah.Value = itemEdit.Jumlah;
//            }
//        }

//        private void CmbProduk_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (cmbProduk.SelectedItem is Produk produk)
//            {
//                selectedProduk = produk;
//                lblStok.Text = $"Stok: {produk.Stok}";
//                lblHarga.Text = $"Harga: Rp {produk.Harga:N0}";
//                numJumlah.Maximum = produk.Stok;
//                UpdateSubtotal();
//            }
//        }

//        private void NumJumlah_ValueChanged(object sender, EventArgs e)
//        {
//            UpdateSubtotal();
//        }

//        private void UpdateSubtotal()
//        {
//            if (selectedProduk != null)
//            {
//                decimal subtotal = selectedProduk.Harga * numJumlah.Value;
//                lblSubtotal.Text = $"Subtotal: Rp {subtotal:N0}";
//            }
//        }

//        private void BtnSimpan_Click(object sender, EventArgs e)
//        {
//            if (selectedProduk == null)
//            {
//                MessageBox.Show("Pilih produk terlebih dahulu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                this.DialogResult = DialogResult.None;
//                return;
//            }

//            int jumlah = (int)numJumlah.Value;

//            if (isEditMode)
//            {
//                Keranjang.UpdateJumlah(itemEdit.IdProduk, jumlah);
//                MessageBox.Show("Item berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            else
//            {
//                if (Keranjang.IsItemExists(selectedProduk.IdProduk))
//                {
//                    var result = MessageBox.Show(
//                        "Produk sudah ada di keranjang. Tambah jumlahnya?",
//                        "Konfirmasi",
//                        MessageBoxButtons.YesNo,
//                        MessageBoxIcon.Question
//                    );

//                    if (result == DialogResult.Yes)
//                    {
//                        Keranjang.TambahItem(selectedProduk, jumlah);
//                        MessageBox.Show("Jumlah item berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    }
//                    else
//                    {
//                        this.DialogResult = DialogResult.None;
//                        return;
//                    }
//                }
//                else
//                {
//                    Keranjang.TambahItem(selectedProduk, jumlah);
//                    MessageBox.Show($"{jumlah}x {selectedProduk.NamaProduk} ditambahkan ke keranjang!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//            }
//        }
//    }
//}
