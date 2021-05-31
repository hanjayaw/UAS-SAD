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
    public partial class Login : Form
    {
        SqlFunction sqlFunc;
        public Login()
        {
            InitializeComponent();
        }

        private void lbpin_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;user=root;password=;database=ud_sinar_mas";
            sqlFunc = new SqlFunction(connectionString);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BTlogin_Click(object sender, EventArgs e)
        {
            //Button Login OnClick, TODO's:
            try
            {
                //Get User Level
                string sqlQuery = "SELECT user.user_level `Level` FROM ud_sinar_mas.user WHERE UPPER(user.nama) = UPPER('" + tbanama.Text + "') AND pin = " + tbpin.Text + "";
                DataTable authDt = sqlFunc.selectQuery(sqlQuery);

                //Check if name and password correct
                if (authDt.Rows.Count > 0)
                {
                    //Code User Level Ada
                    int userLevel = Convert.ToInt32(authDt.Rows[0]["Level"]);
                    if (userLevel == 0)
                    {
                        var x = new mdi();
                        this.Hide();
                        x.Show();
                    }
                    else
                    {
                        var y = new mdiuser();
                        this.Hide();
                        y.Show();
                    }
                }
                else
                {
                    //Code User Level Tidak Ada
                    MessageBox.Show("Username atau PIN Salah");
                    tbanama.Text = "";
                    tbpin.Text = "";

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Username atau PIN Salah");                               
            }



            //bool IsDuplicate = false;
            //for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //{
            //    if (tbanama.Text != dataGridView1.Rows[i].Cells[2].Value.ToString() && tbpin.Text != dataGridView1.Rows[i].Cells[3].Value.ToString())
            //    {
            //        MessageBox.Show("Paswword Salah");
            //        IsDuplicate = true;
            //    }
            //}
            //if (!IsDuplicate)
            //{
            //    string connectionString = "datasource=localhost;port=3306;user=root;password=;database=ud_sinar_mas";
            //    string sql = "INSERT INTO `barang_supplier`(`barang_id`, `supplier_id`, `harga_jual`, `jumlah_barang`) VALUES ('" + comboBox1.SelectedValue + "','" + comboBox2.SelectedValue + "','" + numericUpDown1.Value + "','" + numericUpDown2.Value + "') ";
            //    MySqlConnection connection = new MySqlConnection(connectionString);
            //    MySqlDataAdapter dataadapter = new MySqlDataAdapter(sql, connection);
            //    DataSet ds = new DataSet();
            //    connection.Open();
            //    dataadapter.Fill(ds, "Authors_table");
            //    connection.Close();
            //    this.Close();
        }
    }

}

 
