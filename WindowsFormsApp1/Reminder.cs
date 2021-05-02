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
                string sqlini = "SELECT tanggal_penjualan 'Tanggal' , nama_customer 'Pembeli', alamat 'Alamat' , no_telepon 'Nomor Telepon'  FROM transaksi_penjualan, penjualan_barang_supplier, customer, barang WHERE transaksi_penjualan.customer_id = customer.customer_id AND penjualan_barang_supplier.penjualan_id = transaksi_penjualan.penjualan_id AND MONTH(tanggal_penjualan) = MONTH(CURRENT_DATE) and DAY(tanggal_penjualan) >= DAY(CURRENT_DATE) GROUP BY nama_customer ORDER BY tanggal_penjualan";
                string sqldepan = "SELECT tanggal_penjualan 'Tanggal' , nama_customer 'Pembeli', alamat 'Alamat' , no_telepon 'Nomor Telepon'  FROM transaksi_penjualan, penjualan_barang_supplier, customer, barang WHERE transaksi_penjualan.customer_id = customer.customer_id AND penjualan_barang_supplier.penjualan_id = transaksi_penjualan.penjualan_id and MONTH(tanggal_penjualan) = MONTH(CURRENT_DATE) + 1 GROUP BY nama_customer ORDER BY tanggal_penjualan LIMIT 3";
                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlCommand sqlCommand1 = new MySqlCommand(sqlini, connection);
                MySqlCommand sqlCommand2 = new MySqlCommand(sqldepan, connection);
                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();
                connection.Open();
                MySqlDataAdapter dataAdapter1 = new MySqlDataAdapter(sqlini, connection);
                MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqldepan, connection);
                dataAdapter1.SelectCommand = sqlCommand1;
                dataAdapter2.SelectCommand = sqlCommand2;
                dataAdapter1.Fill(ds1);
                dataAdapter2.Fill(ds2);
                connection.Close();
                dgvbulanini.DataSource = ds1;
                dgvbulandepan.DataSource = ds2;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
