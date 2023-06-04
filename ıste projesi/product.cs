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
    public partial class product : Form
    {
        public product()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-AFLO8AK\SQLEXPRESS01;Initial Catalog=data_pro;Integrated Security=True");

         private void GetData()
        {

         
            SqlDataAdapter adapter = new SqlDataAdapter(" select *from product", cn);
            DataSet ds = new DataSet();
            cn.Open();
            adapter.Fill(ds, "product");
            guna2DataGridView1.DataSource = ds.Tables["product"];
            cn.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            
            string connectionString = @"Data Source=DESKTOP-AFLO8AK\SQLEXPRESS01;Initial Catalog=data_pro;Integrated Security=True";
            // إنشاء اتصال بقاعدة البيانات
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // البيانات التي تريد إضافتها
                string value1 = "ProductName";
                string value2 = "Brand";
                string value3 = "Description";
                string value4 = "Price";
                string value5 = "QuantityAvailable";
               
                // استعلام SQL لإدخال البيانات
                string query = "INSERT INTO product(ProductName,Brand,Description,Price,QuantityAvailable) VALUES (@ProductName,@Brand,@Description,@Price,@QuantityAvailable)";

                // إعداد الاستعلام
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductName", t1.Text);
                    cmd.Parameters.AddWithValue("@Brand", t2.Text);
                    cmd.Parameters.AddWithValue("@Description", t3.Text);
                    cmd.Parameters.AddWithValue("@Price", t4.Text);
                    cmd.Parameters.AddWithValue("@QuantityAvailable", t5.Text);

                    // تنفيذ الاستعلام
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // التحقق من عدد الصفوف المتأثرة
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("تمت إضافة البيانات بنجاح!");
                        t1.Clear();
                        t2.Clear();
                        t3.Clear();
                        t4.Clear();
                        t5.Clear();
                     
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

        private void product_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AFLO8AK\SQLEXPRESS01;Initial Catalog=data_pro;Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("Delete client  where id=@id", con);

           // cmd.Parameters.AddWithValue("@id", t0.Text);





            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sucessfully Deleted ");

        }
    }
    
}
