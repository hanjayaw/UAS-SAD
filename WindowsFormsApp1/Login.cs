﻿using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lbpin_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void BTlogin_Click(object sender, EventArgs e)
        {
            var m = new BelajarDoang();
            m.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var m = new StockBarang();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = new Form1();
            x.Show();
        }
    }
}
