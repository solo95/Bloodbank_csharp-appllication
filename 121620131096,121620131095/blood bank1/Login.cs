using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace blood_bank1
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=WILLIAM;Initial Catalog=kanbanka;Integrated Security=True");
        menu adminf = new menu();
        private static string id;
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
             string query ="select count(*) from login where kullanci_kodu='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'";
            
            if (Data(query).Rows[0][0].ToString() == "1")
            {//what i changed today

                id = textBox1.Text;
                adminf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("şifre ya da kullanci adi yanliş!");
            }
                    
        }

        public DataTable Data(string query)
        {
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }

        public string getval()
        {
             return id;         
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
