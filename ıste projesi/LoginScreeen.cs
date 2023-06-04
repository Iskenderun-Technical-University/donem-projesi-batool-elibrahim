using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ıste_projesi
{ 
    public partial class LoginScreeen : Form
    {
        public LoginScreeen()
        {
            InitializeComponent();
        }
        SqlConnection cn;
        SqlDataAdapter DA;
        DataSet ds;   
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            BackgroundImage.Clone();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-AFLO8AK\SQLEXPRESS01;Initial Catalog=data_pro;Integrated Security=True";

            try
            {

                SqlConnection cn = new SqlConnection(connectionString);

                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                string cmd = "SELECT * FROM  Login where username='" + guna2TextBox1.Text + "'and password= '" + guna2TextBox2.Text + "'";
                SqlCommand cd = new SqlCommand(cmd, cn);
                int r = Convert.ToInt32(cd.ExecuteScalar());
                if (r > 0)
                {
                    this.Hide();
                    HomeScreen hm = new HomeScreen();
                    hm.ShowDialog();
                    this.Close();

                }
                else
                    MessageBox.Show("The username or password is incorrect");
                if (cn.State == ConnectionState.Open)
                    cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}