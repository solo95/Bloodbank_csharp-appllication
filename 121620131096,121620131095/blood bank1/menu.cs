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
    public partial class menu : Form
    {
        SqlConnection con = new SqlConnection("Data Source=WILLIAM;Initial Catalog=kanbanka;Integrated Security=True");

        string path;
        public menu()
        {
            InitializeComponent();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            Login main = new Login();
            main.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KanVerici adminf = new KanVerici();
           adminf.Show();
            this.Hide();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hesap hp = new Hesap();
            hp.Show();

        }

        public void admin_Load(object sender, EventArgs e)
        {
            Login fm = new Login();
            SqlCommand cd = new SqlCommand("select foto from login where Kullanci_kodu='" + fm.getval() + "'", con);
            con.Open();
            SqlDataReader rd = cd.ExecuteReader();
            if (rd.Read())
            {
                try
                {
                                       
                        path = rd.GetString(0);
                    
                   
                }
                catch 
                {
                    path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10)) + "\\foto\\default.jpg"; 
                }
            }
            con.Close();
            pictureBox1.ImageLocation = @path;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Kan kn = new Kan();
            kn.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        
    }
}
