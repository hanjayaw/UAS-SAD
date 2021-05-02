﻿using System;
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
    public partial class UbahKontakSupplier : Form
    {
        public UbahKontakSupplier()
        {
            InitializeComponent();
        }

        private void btsimpan_Click(object sender, EventArgs e)
        {
            {
                if (tbnama.Text == "" || tbalamat.Text == "" || tbnotelp.Text == "")
                {
                    MessageBox.Show("Data tidak boleh kosong");
                }
                else
                {
                    string connectionString = "server=localhost;uid=root;pwd=;database=ud_sinar_mas";
                    MySqlConnection conn = new MySqlConnection(connectionString);
                    string sql = "UPDATE supplier SET nama_supplier = '" + tbnama.Text + "', alamat = '" + tbalamat.Text + "', no_telepon = '" + tbnotelp.Text + "' WHERE supplier_id = '" + tbid.Text + "' ";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kontak berhasil diupdate");
                    conn.Close();
                    this.Close();
                }
            }
        }

        private void btbatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;uid=root;pwd=;database=ud_sinar_mas";
            MySqlConnection conn = new MySqlConnection(connectionString);
            string sql = "DELETE FROM supplier WHERE supplier_id = '" + tbid.Text + "' ";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kontak berhasil dihapus");
            conn.Close();
            this.Close();
        }

        private void tbnotelp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
