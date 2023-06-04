using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ıste_projesi
{
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void guna2ContainerControl1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            product pro = new product();
            pro.ShowDialog();
               
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            Stocks st = new Stocks();
            st.ShowDialog();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            order st = new order();
            st.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            Clinet st = new Clinet();
            st.ShowDialog();
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
