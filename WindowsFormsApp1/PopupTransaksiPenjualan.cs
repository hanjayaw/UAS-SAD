using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PopupTransaksiPenjualan : Form
    {
        public string connString = "datasource=127.0.0.1;port=3306;username=root;password=;Convert Zero Datetime = True";
        private SqlFunction sqlFunc;
        public PopupTransaksiPenjualan()
        {
            InitializeComponent();
            
        }

        private void PopupTransaksiPenjualan_Load(object sender, EventArgs e)
        {
            sqlFunc = new SqlFunction(connString);
            //Fill AutoComplete Customer Name
            string sqlQuery = "SELECT cs.nama_customer `Nama Customer` FROM ud_sinar_mas.customer cs";
            DataTable customerDt = new DataTable();
            customerDt = sqlFunc.selectQuery(sqlQuery);

            AutoCompleteStringCollection customerCollectionString = new AutoCompleteStringCollection();
            for (int i = 0; i < customerDt.Rows.Count; i++)
            {
                customerCollectionString.Add(customerDt.Rows[i]["Nama Customer"].ToString());
            }

            //AutoSuggest
            //custTextbox.AutoCompleteMode = AutoCompleteMode.Suggest;
            //custTextbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //custTextbox.AutoCompleteCustomSource = customerCollectionString;
        }
        //pengirimanDateTimePicker.Value.ToString("yyyy-MM-dd")                

        private void langgananCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            //Langganan
            if (langgananCheckbox.Checked == true)
            {                               
                hargaBaruNumeric.Visible = true;
                hargaBaruText.Visible = true;
            }
            else
            {             
                hargaBaruText.Visible = false;
                hargaBaruNumeric.Visible = false;
            }
        }

        private void hutangCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (hutangCheckbox.Checked == true)
            {
                bayarNumeric.Visible = true;
                jatuhtempoDateTimePicker.Visible = true;
                bayarText.Visible = true;
                jatuhtempoText.Visible = true;
            }
            else
            {
                bayarNumeric.Visible = false;
                jatuhtempoDateTimePicker.Visible = false;
                bayarText.Visible = false;
                jatuhtempoText.Visible = false;
            }
        }

        private void pengirimanDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            jatuhtempoDateTimePicker.MinDate = pengirimanDateTimePicker.Value;
            jatuhtempoDateTimePicker.Value = pengirimanDateTimePicker.Value;
        }

        private void selesaiButton_Click(object sender, EventArgs e)
        {

        }

        
    }
}
