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
    public partial class Reminder : Form
    {
        //MySqlConnection sqlConnection;
        //MySqlCommand sqlCommand;
        //MySqlDataAdapter sqlAdapter;
        //string sqlQuery = "";
        //string connectString = "server=localhost;uid=root;pwd=root;database=ud_sinar_mas;";

        public Reminder()
        {
            InitializeComponent();
        }

        private void Reminder_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=localhost;uid=root;pwd=;database=ud_sinar_mas";
                string sqlini = "SELECT tanggal_penjualan 'Tanggal' , nama_customer 'Pembeli', alamat 'Alamat' , no_telepon 'Nomor Telepon', transaksi_penjualan.penjualan_id, 'Edit' as `Ubah` FROM transaksi_penjualan, penjualan_barang_supplier, customer, barang WHERE transaksi_penjualan.customer_id = customer.customer_id AND penjualan_barang_supplier.penjualan_id = transaksi_penjualan.penjualan_id AND MONTH(tanggal_penjualan) = MONTH(CURRENT_DATE) and DAY(tanggal_penjualan) >= DAY(CURRENT_DATE) GROUP BY nama_customer ORDER BY tanggal_penjualan";
                string sqldepan = "SELECT tanggal_penjualan 'Tanggal' , nama_customer 'Pembeli', alamat 'Alamat' , no_telepon 'Nomor Telepon', transaksi_penjualan.penjualan_id, 'Edit' as `Ubah` FROM transaksi_penjualan, penjualan_barang_supplier, customer, barang WHERE transaksi_penjualan.customer_id = customer.customer_id AND penjualan_barang_supplier.penjualan_id = transaksi_penjualan.penjualan_id and MONTH(tanggal_penjualan) = MONTH(CURRENT_DATE) + 1 GROUP BY nama_customer ORDER BY tanggal_penjualan LIMIT 3";
                MySqlConnection connection = new MySqlConnection(connectionString);
                SqlFunction sql = new SqlFunction(connectionString);
                DataTable data1 = sql.selectQuery(sqlini);
                DataTable data2 = sql.selectQuery(sqldepan);
                dgvbulanini.DataSource = data1;
                dgvbulandepan.DataSource = data2;
                dgvbulanini.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvbulandepan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvbulanini.Columns["penjualan_id"].Visible = false;
                dgvbulandepan.Columns["penjualan_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvbulanini_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 5)
            {
                DetailReminder edit = new DetailReminder();
                edit.tbid.Text = this.dgvbulanini.CurrentRow.Cells[4].Value.ToString();
                edit.ShowDialog();
            }
        }

        private void dgvbulandepan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 5)
            {
                DetailReminder edit = new DetailReminder();
                edit.tbid.Text = this.dgvbulandepan.CurrentRow.Cells[4].Value.ToString();
                edit.ShowDialog();
            }
        }
    }
}
