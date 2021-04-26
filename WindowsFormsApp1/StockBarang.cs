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
    public partial class StockBarang : Form
    {
        public StockBarang()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            UbahProduk up = new UbahProduk();
            up.ubahnamaproduk.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            up.ubahnamasupplier.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            up.numericupdownharga.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            up.numericUpDownsisastock.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            up.ShowDialog();
        }

        private void StockBarang_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;user=root;password=;database=uas pak yos";
            string sql = "SELECT nama_supplier, nama_barang, jumlah_barang, harga_jual, harga_beli FROM `barang`, `barang_supplier`, supplier WHERE barang.barang_id = barang_supplier.barang_id AND barang_supplier.supplier_id = supplier.supplier_id";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlDataAdapter dataadapter = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Authors_table");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Authors_table";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var z = new Reminder();
            z.Show();
        }
    }
}
