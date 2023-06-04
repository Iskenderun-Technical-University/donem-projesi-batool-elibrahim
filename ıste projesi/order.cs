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
    public partial class order : Form
    {
        public order()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-AFLO8AK\SQLEXPRESS01;Initial Catalog=data_pro;Integrated Security=True");

        private void GetData()
        {


            SqlDataAdapter adapter = new SqlDataAdapter(" select *from Ordertb", cn);
            DataSet ds = new DataSet();
            cn.Open();
            adapter.Fill(ds, "Ordertb");
            guna2DataGridView1.DataSource = ds.Tables["Ordertb"];
            cn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-AFLO8AK\SQLEXPRESS01;Initial Catalog=data_pro;Integrated Security=True";
            // إنشاء اتصال بقاعدة البيانات
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // البيانات التي تريد إضافتها
                string value1 = "CustomerID";
                string value2 = "OrderDate";
                string value3 = "OrderStatus";


                // استعلام SQL لإدخال البيانات
                string query = "INSERT INTO Ordertb(CustomerID,OrderDate,OrderStatus) VALUES (@CustomerID,@OrderDate,@OrderStatus)";

                // إعداد الاستعلام
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", t1.Text);
                    cmd.Parameters.AddWithValue("@OrderDate", t2.Text);
                    cmd.Parameters.AddWithValue("@OrderStatus", t3.Text);


                    // تنفيذ الاستعلام
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // التحقق من عدد الصفوف المتأثرة
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("تمت إضافة البيانات بنجاح!");
                        t1.Clear();
                        t2.Clear();
                        t3.Clear();
                        t3.Clear();


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

        private void order_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=DESKTOP-AFLO8AK\SQLEXPRESS01;Initial Catalog=data_pro;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Ordertb SET OrderStatus = @OrderStatus WHERE OrderID = @OrderID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", "OrderID");
                        command.Parameters.AddWithValue("@OrderStatus", "OrderStatus");


                        int rowsAffected = command.ExecuteNonQuery();

                        Console.WriteLine("تم تحديث البيانات بنجاح. تأثرت " + rowsAffected + " صفوف.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("حدث خطأ أثناء تحديث البيانات: " + ex.Message);
                GetData();
            }
          
            Console.ReadLine();
        }

    
        

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            t1.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            t2.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            t3.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
