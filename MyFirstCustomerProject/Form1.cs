using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MyFirstCustomerProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Server=MSI\\SQLEXPRESS;initial Catalog=MyDbCustomer;integrated Security=true");


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand command = new SqlCommand("Select * from TblDepartment", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Delete From TblDepartment Where DepartmentID=@p1", connection);
                command.Parameters.AddWithValue("@p1", textBox1.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Departman başarılı bir şekilde Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                connection.Close();
            }
            else
            {
                MessageBox.Show("Lütfen ID alanını boş geçmeyin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            if (rdbActive.Checked || rdbPassive.Checked)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into TblDepartment (DepartmentName,DepartmentStatus) Values (@p1,@p2)", connection);
                command.Parameters.AddWithValue("@p1", asd.Text);
                if (rdbActive.Checked)
                {
                    command.Parameters.AddWithValue("@p2", "True");
                }
                if (rdbPassive.Checked)
                {
                    command.Parameters.AddWithValue("@p2", "False");
                }
                command.ExecuteNonQuery();
                MessageBox.Show("Departman başarılı bir şekilde Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
            }
            else
            {
                MessageBox.Show("Lütfen Bir Durum Seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCategoryUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Update TblDepartment set DepartmentName=@p1 where DeparmentID=@p2", connection);
            command.Parameters.AddWithValue("@p1", textBox2.Text);
            command.Parameters.AddWithValue("@p2", textBox1.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Departman Başarılı bir şekilde güncellendi", "Bilgi", MessageBoxButtons.OK);
            connection.Close();

        }
    }
}
