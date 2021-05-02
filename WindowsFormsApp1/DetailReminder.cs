using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class DetailReminder : Form
    {
        public DetailReminder()
        {
            InitializeComponent();
        }

        private void DetailReminder_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=localhost;uid=root;pwd=;database=ud_sinar_mas";
                string sqldetail = "SELECT customer.nama_customer 'Pembeli' , customer.alamat 'Alamat', customer.no_telepon 'Nomor Telepon', barang.nama_barang 'Barang' ,  penjualan_barang_supplier.jumlah_pemesanan 'Quantity', barang_supplier.harga_jual 'Harga' , penjualan_barang_supplier.sub_total 'Jumlah' FROM customer, barang, penjualan_barang_supplier, barang_supplier, transaksi_penjualan WHERE barang.barang_id = barang_supplier.barang_id AND penjualan_barang_supplier.barang_supplier_id = barang_supplier.barang_supplier_id AND customer.customer_id = transaksi_penjualan.customer_id and transaksi_penjualan.penjualan_id = penjualan_barang_supplier.penjualan_id AND transaksi_penjualan.penjualan_id = '" + tbid.Text + "'";
                string sqllabel = "SELECT nama_customer, tanggal_penjualan FROM customer, transaksi_penjualan WHERE transaksi_penjualan.customer_id = customer.customer_id AND penjualan_id = '" + tbid.Text + "'";
                MySqlConnection connection = new MySqlConnection(connectionString);
                SqlFunction sql = new SqlFunction(connectionString);
                DataTable label = sql.selectQuery(sqllabel);
                string nama = label.Rows[0]["nama_customer"].ToString();
                string tanggal = label.Rows[0]["tanggal_penjualan"].ToString();
                DateTime tanggalDateTime = DateTime.ParseExact(tanggal, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                string tanggalTransaksi = tanggalDateTime.ToString("yyyy-MM-dd");
                string kalimatakhir = String.Format("{0}, {1}", nama, tanggalTransaksi);
                DataTable data = sql.selectQuery(sqldetail);
                dgvdetail.DataSource = data;
                lebeldetail.Text = kalimatakhir;
                dgvdetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
