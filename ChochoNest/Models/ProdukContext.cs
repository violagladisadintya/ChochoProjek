using ChochoNest.Database;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChochoNest.Models
{
    public class ProdukContext
    {
        private readonly DbContext _dbContext;
        public event EventHandler? ProdukDiubah;

        public ProdukContext()
        {
            _dbContext = new DbContext();
        }

        protected virtual void OnProdukDiubah(EventArgs e)
        {
            ProdukDiubah?.Invoke(this, e);
        }

        // --- 1. AMBIL DATA (READ) ---
        public List<Produk> GetProdukFromDatabase()
        {
            var listProduk = new List<Produk>();
            string query = "SELECT id_produk, nama_produk, harga, stok, gambar_produk FROM produk ORDER BY id_produk ASC";

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produk p = new Produk();
                            p.IdProduk = Convert.ToInt32(reader["id_produk"]);
                            p.NamaProduk = reader["nama_produk"].ToString();
                            p.Harga = Convert.ToInt32(reader["harga"]);
                            p.Stok = Convert.ToInt32(reader["stok"]);

                            if (reader["gambar_produk"] != DBNull.Value)
                                p.gambarProduk = (byte[])reader["gambar_produk"];

                            listProduk.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal ambil data: " + ex.Message); }
            return listProduk;
        }

        // --- 2. TAMBAH PRODUK (Pindah dari AuthController ke sini) ---
        public void TambahProduk(Produk produk)
        {
            string query = "INSERT INTO produk (nama_produk, harga, stok, gambar_produk) VALUES (@nama, @harga, @stok, @gambar)";
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", produk.NamaProduk);
                        cmd.Parameters.AddWithValue("@harga", produk.Harga);
                        cmd.Parameters.AddWithValue("@stok", produk.Stok);

                        if (produk.gambarProduk != null)
                            cmd.Parameters.AddWithValue("@gambar", produk.gambarProduk);
                        else
                            cmd.Parameters.AddWithValue("@gambar", DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
                OnProdukDiubah(EventArgs.Empty);
            }
            catch (Exception ex) { MessageBox.Show("Gagal tambah produk: " + ex.Message); }
        }

        // --- 3. EDIT PRODUK ---
        public void EditProduk(Produk produk)
        {
            string query = "UPDATE produk SET nama_produk=@nama, harga=@harga, stok=@stok, gambar_produk=@gambar WHERE id_produk=@id";
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", produk.IdProduk);
                        cmd.Parameters.AddWithValue("@nama", produk.NamaProduk);
                        cmd.Parameters.AddWithValue("@harga", produk.Harga);
                        cmd.Parameters.AddWithValue("@stok", produk.Stok);

                        if (produk.gambarProduk != null)
                            cmd.Parameters.AddWithValue("@gambar", produk.gambarProduk);
                        else
                            cmd.Parameters.AddWithValue("@gambar", DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
                OnProdukDiubah(EventArgs.Empty);
            }
            catch (Exception ex) { MessageBox.Show("Gagal edit produk: " + ex.Message); }
        }

        // --- 4. HAPUS PRODUK ---
        public void HapusProduk(int id)
        {
            string query = "DELETE FROM produk WHERE id_produk = @id";
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                OnProdukDiubah(EventArgs.Empty);
            }
            catch (Exception ex) { MessageBox.Show("Gagal hapus produk: " + ex.Message); }
        }

        // --- 5. UPDATE STOK (Manual/Admin) ---
        public void UpdateStok(int idProduk, int stok)
        {
            string query = "UPDATE produk SET stok = @stok WHERE id_produk = @id";
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idProduk);
                        cmd.Parameters.AddWithValue("@stok", stok);
                        cmd.ExecuteNonQuery();
                    }
                }
                OnProdukDiubah(EventArgs.Empty);
            }
            catch (Exception ex) { MessageBox.Show("Gagal update stok: " + ex.Message); }
        }

        // --- 6. TRANSAKSI (Kurangi Stok saat Beli) ---
        public void TransaksiProduk(int idProduk, int jumlahTerjual)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();
                    string query = "UPDATE produk SET stok = stok - @jumlah WHERE id_produk = @id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idProduk);
                        cmd.Parameters.AddWithValue("@jumlah", jumlahTerjual);
                        cmd.ExecuteNonQuery();
                    }
                }
                OnProdukDiubah(EventArgs.Empty);
            }
            catch (Exception ex) { MessageBox.Show("Gagal transaksi stok: " + ex.Message); }
        }

        // --- 7. SIMPAN TRANSAKSI (History/Riwayat) ---
        public void SimpanTransaksi(TransaksiModel transaksiBaru)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_dbContext.connStr))
            {
                conn.Open();
                using (NpgsqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert Header
                        string queryHeader = "INSERT INTO transaksi (tanggal_transaksi, total_bayar, id_user, id_metode_pembayaran) VALUES (@tgl, @total, @idUser, @idMetode) RETURNING id_transaksi";
                        int idTransaksiBaru;

                        using (NpgsqlCommand cmd = new NpgsqlCommand(queryHeader, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@tgl", DateTime.Now);
                            cmd.Parameters.AddWithValue("@total", transaksiBaru.TotalBayar);
                            cmd.Parameters.AddWithValue("@idUser", transaksiBaru.IdUser);
                            cmd.Parameters.AddWithValue("@idMetode", transaksiBaru.IdMetodePembayaran);
                            idTransaksiBaru = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2. Insert Detail & Update Stok
                        foreach (var detail in transaksiBaru.ListDetail)
                        {
                            string queryDetail = "INSERT INTO detail_transaksi (id_transaksi, id_produk, jumlah_beli, subtotal) VALUES (@idTrans, @idProd, @qty, @sub)";
                            using (NpgsqlCommand cmdDetail = new NpgsqlCommand(queryDetail, conn, tran))
                            {
                                cmdDetail.Parameters.AddWithValue("@idTrans", idTransaksiBaru);
                                cmdDetail.Parameters.AddWithValue("@idProd", detail.IdProduk);
                                cmdDetail.Parameters.AddWithValue("@qty", detail.JumlahBeli);
                                cmdDetail.Parameters.AddWithValue("@sub", detail.Subtotal);
                                cmdDetail.ExecuteNonQuery();
                            }

                            string queryStok = "UPDATE produk SET stok = stok - @qty WHERE id_produk = @idProd";
                            using (NpgsqlCommand cmdStok = new NpgsqlCommand(queryStok, conn, tran))
                            {
                                cmdStok.Parameters.AddWithValue("@qty", detail.JumlahBeli);
                                cmdStok.Parameters.AddWithValue("@idProd", detail.IdProduk);
                                cmdStok.ExecuteNonQuery();
                            }
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception("Gagal simpan transaksi: " + ex.Message);
                    }
                }
            }
        }
        public List<TransaksiModel> GetRiwayatTransaksi()
        {
            List<TransaksiModel> listRiwayat = new List<TransaksiModel>();
            string query = "SELECT id_transaksi, tanggal_transaksi, total_bayar, metode_pembayaran.nama_metode_pembayaran FROM transaksi LEFT JOIN metode_pembayaran ON transaksi.id_metode_pembayaran = metode_pembayaran.id_metode_pembayaran ORDER BY tanggal_transaksi DESC";

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(_dbContext.connStr))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TransaksiModel t = new TransaksiModel();
                            t.IdTransaksi = Convert.ToInt32(reader["id_transaksi"]);
                            t.TanggalTransaksi = Convert.ToDateTime(reader["tanggal_transaksi"]);
                            t.TotalBayar = Convert.ToInt32(reader["total_bayar"]);

                            if (reader["nama_metode_pembayaran"] != DBNull.Value)
                                t.MetodePembayaranString = reader["nama_metode_pembayaran"].ToString(); // Buat properti baru di model Transaksi buat nampung string nama metode
                            else
                                t.MetodePembayaranString = "-";

                            listRiwayat.Add(t);
                        }
                    }
                }
            }
            catch { }
            return listRiwayat;
        }
    }
}
