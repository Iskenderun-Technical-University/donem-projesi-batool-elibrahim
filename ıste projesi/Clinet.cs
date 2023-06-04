using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ıste_projesi
{
    public partial class Clinet : Form
    {
        public Clinet()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-AFLO8AK\SQLEXPRESS01;Initial Catalog=data_pro;Integrated Security=True");

        void GetData()
        {
            cn.Open();
            DataTable Dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(" select *from Clinets", cn);
            adapter.Fill(Dt);
            guna2DataGridView1.DataSource = Dt;
            cn.Close();
        }
        private void Clinet_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            newClinet clinet = new newClinet();
            clinet.ShowDialog(); 
        }
    }
}
