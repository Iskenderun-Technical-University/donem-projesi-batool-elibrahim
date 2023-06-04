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
    public partial class newClinet : Form
    {
        public newClinet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=DESKTOP-AFLO8AK\SQLEXPRESS01;Initial Catalog=data_pro;Integrated Security=True";
            // إنشاء اتصال بقاعدة البيانات
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // البيانات التي تريد إضافتها
                string value1 = "firstName";
                string value2 = "LastName";
                string value3 = "Adress";
                string value4 = "phone";
                string value5 = "Email";

                // استعلام SQL لإدخال البيانات
                string query = "INSERT INTO Clinets(firstName,LastName,Adress,phone,Email) VALUES (@firstName,@LastName,@Adress,@phone,@Email)";

                // إعداد الاستعلام
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@firstName", t1.Text);
                    cmd.Parameters.AddWithValue("@LastName", t2.Text);
                    cmd.Parameters.AddWithValue("@Adress", t3.Text);
                    cmd.Parameters.AddWithValue("@phone", t4.Text);
                    cmd.Parameters.AddWithValue("@Email", t5.Text);

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

               
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void t1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
