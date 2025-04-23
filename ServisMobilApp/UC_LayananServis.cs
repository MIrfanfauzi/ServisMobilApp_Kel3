using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ServisMobilApp
{
    public partial class UC_LayananServis : UserControl
    {
        private string connectionString = "Data Source=LAPTOP-N8SLA3LN\\IRFANFAUZI;Initial Catalog=ServisMobil;Integrated Security=True";

        public UC_LayananServis()
        {
            InitializeComponent();
            LoadLayanan();

            // Event handler tombol
            btnTambah.Click += btnTambah_Click;
            btnEdit.Click += btnUbah_Click;
            btnHapus.Click += btnHapus_Click;
            dgvLayanan.CellClick += dgvLayanan_CellClick;
        }

        private void LoadLayanan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID_Layanan, NamaLayanan, Deskripsi, Harga FROM LayananServis";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLayanan.DataSource = dt;
                    KosongkanForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data layanan: " + ex.Message);
                }
            }
        }

        private void KosongkanForm()
        {
            lblID.Text = "";
            txtNamaLayanan.Clear();
            txtDeskripsi.Clear();
            txtHarga.Clear();
            txtNamaLayanan.Focus();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaLayanan.Text) || string.IsNullOrWhiteSpace(txtHarga.Text))
            {
                MessageBox.Show("Nama layanan dan harga harus diisi!");
                return;
            }

            if (!decimal.TryParse(txtHarga.Text, out decimal harga) || harga < 0)
            {
                MessageBox.Show("Masukkan harga yang valid!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO LayananServis (NamaLayanan, Deskripsi, Harga)
                                     VALUES (@NamaLayanan, @Deskripsi, @Harga)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NamaLayanan", txtNamaLayanan.Text.Trim());
                    cmd.Parameters.AddWithValue("@Deskripsi", txtDeskripsi.Text.Trim());
                    cmd.Parameters.AddWithValue("@Harga", harga);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Layanan berhasil ditambahkan!");
                    LoadLayanan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menambah layanan: " + ex.Message);
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblID.Text))
            {
                MessageBox.Show("Pilih layanan yang ingin diubah!");
                return;
            }

            if (!decimal.TryParse(txtHarga.Text, out decimal harga) || harga < 0)
            {
                MessageBox.Show("Masukkan harga yang valid!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE LayananServis
                                     SET NamaLayanan = @NamaLayanan, Deskripsi = @Deskripsi, Harga = @Harga
                                     WHERE ID_Layanan = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", lblID.Text);
                    cmd.Parameters.AddWithValue("@NamaLayanan", txtNamaLayanan.Text.Trim());
                    cmd.Parameters.AddWithValue("@Deskripsi", txtDeskripsi.Text.Trim());
                    cmd.Parameters.AddWithValue("@Harga", harga);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Layanan berhasil diperbarui!");
                    LoadLayanan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengubah layanan: " + ex.Message);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblID.Text))
            {
                MessageBox.Show("Pilih layanan yang ingin dihapus!");
                return;
            }

            var confirm = MessageBox.Show("Yakin ingin menghapus layanan ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM LayananServis WHERE ID_Layanan = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", lblID.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Layanan berhasil dihapus!");
                        LoadLayanan();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus layanan: " + ex.Message);
                    }
                }
            }
        }

        private void dgvLayanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLayanan.Rows[e.RowIndex];
                lblID.Text = row.Cells["ID_Layanan"].Value.ToString();
                txtNamaLayanan.Text = row.Cells["NamaLayanan"].Value.ToString();
                txtDeskripsi.Text = row.Cells["Deskripsi"].Value.ToString();
                txtHarga.Text = row.Cells["Harga"].Value.ToString();
            }
        }
    }
}
