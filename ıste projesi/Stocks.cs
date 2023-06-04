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
    public partial class Stocks : Form
    {
        public Stocks()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-AFLO8AK\SQLEXPRESS01;Initial Catalog=data_pro;Integrated Security=True");

        private void GetData()
        {

          
            SqlDataAdapter adapter = new SqlDataAdapter(" select *from stocks", cn);
            DataSet ds = new DataSet();
            cn.Open();
            adapter.Fill(ds, "stocks");
            dataGridView1.DataSource = ds.Tables["stocks"];
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void order1_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void Stocks_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-AFLO8AK\SQLEXPRESS01;Initial Catalog=data_pro;Integrated Security=True";
            // إنشاء اتصال بقاعدة البيانات
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // البيانات التي تريد إضافتها
                string value1 = "ProductID";
                string value2 = "Quantity";


                // استعلام SQL لإدخال البيانات
                string query = "INSERT INTO stocks(ProductID,Quantity) VALUES (@ProductID,@Quantity)";

                // إعداد الاستعلام
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductID", t1.Text);
                    cmd.Parameters.AddWithValue("@Quantity", t2.Text);


                    // تنفيذ الاستعلام
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // التحقق من عدد الصفوف المتأثرة
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("تمت إضافة البيانات بنجاح!");
                        t1.Clear();
                        t2.Clear();


                    }
                    else
                    {
                        MessageBox.Show("لم يتم إضافة البيانات.");
                    }
                }

                connection.Close();

                GetData();
            }
        }

        private void t2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
