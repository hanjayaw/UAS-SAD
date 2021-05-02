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
    public partial class Kontak : Form
    {
        public Kontak()
        {
            InitializeComponent();
        }

        private void Kontak_Load(object sender, EventArgs e)
        {
            try
            {
                //if
                string connectionString = "server=localhost;uid=root;pwd=root;database=ud_sinar_mas";
                string sql = "SELECT nama_customer 'Nama' , alamat 'Alamat' , no_telepon 'Nomor Telepon' FROM customer";
                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                connection.Open();
                dataAdapter.Fill(ds);
                connection.Close();
                dgvkontak.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tambah_Click(object sender, EventArgs e)
        {

        }

    }
}
