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
    public partial class Kan : Form
    {
        SqlConnection con = new SqlConnection("Data Source=WILLIAM;Initial Catalog=kanbanka;Integrated Security=True");
        SqlDataAdapter adaptar;
        KanVerici dn = new KanVerici();
        Login lg = new Login();
        public Kan()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void setStrings()
        {
            label1.Text = Numbers("A-");
            label2.Text = Numbers("A+");
            label3.Text = Numbers("B-");
            label4.Text = Numbers("B+");
            label5.Text = Numbers("AB-");
            label6.Text = Numbers("AB+");
            label7.Text = Numbers("O-");
            label8.Text = Numbers("O+");
            label20.Text = Numbers();
            label21.Text = Numbers1("sona ermiş");
        }
        public string Numbers()
        {
            string query = "select count(*) from kan where Durum='depoda'";
            return lg.Data(query).Rows[0][0].ToString();
        }
        public string Numbers(string kanGrubu)
        {

            string query ="select count(*) from kan where [Kan Grubu]='" + kanGrubu + "' and Durum ='depoda'";
            return lg.Data(query).Rows[0][0].ToString();
        }
        public string Numbers1(string durum)
        {
            string query ="select count(*) from kan where Durum ='" + durum + "'";
            return lg.Data(query).Rows[0][0].ToString();
        }
        public void loadData()
        {
            string query ="Select * from Kan";
            try
            {
                dataGridView2.DataSource = lg.Data(query);
                button3.Hide();
                button6.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            button3.Hide();
            button6.Hide();
            try
            {
                string query = "Select * from Kan where [Kan Kodu] like '" + search.Text + "%'  or [Verici Kodu] like '" + search.Text + "%'";
                dataGridView2.DataSource = lg.Data(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Hide();
            button6.Hide();
            try
            {
                string kan = "";
                switch (comboBox1.Text)
                {
                    case "O- Grubu":
                        kan = "O-";
                        break;
                    case "O+ Grubu":
                        kan = "O+";
                        break;
                    case "A- Grubu":
                        kan = "A-";
                        break;
                    case "A+ Grubu":
                        kan = "A+";
                        break;
                    case "B- Grubu":
                        kan = "B-";
                        break;
                    case "B+ Grubu":
                        kan = "B+";
                        break;
                    case "AB- Grubu":
                        kan = "AB-";
                        break;
                    case "AB+ Grubu":
                        kan = "AB+";
                        break;
                }
                string query ="Select * from Kan where [Kan Grubu]='" + kan + "'";
               dataGridView2.DataSource = lg.Data(query);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox2.Hide();
            search.Show();
            comboBox1.Show();
            ara.Show();
            dataGridView2.Show();
            loadData();
            UpdateDurum();
            setStrings();
           
        }
        public int max()
        {
            int x = 0;
            SqlCommand a = new SqlCommand("select isnull(Max([Kan Kodu]),0)+1 from kan", con);
            con.Open();
            SqlDataReader rdr = a.ExecuteReader();
            if (rdr.Read())
            {
                x = rdr.GetInt32(0);

            }
            con.Close();
            return x;
        }
        public void kanvermek(){
            textBox7.Text = max().ToString();
            button4.Text = "Tamam";
            groupBox2.Show();
            search.Hide();
            comboBox1.Hide();
            ara.Hide();
            dataGridView2.Hide();
            textBox5.Enabled = false;
            textBox9.Enabled = false;
            textBox2.Enabled = true;


            dateTimePicker1.Enabled = true;
            comboBox2.Text = "Depoya Giris";
            comboBox2.Enabled = false;
            dateTimePicker2.Enabled = false;
            textBox7.Enabled = false;
            button3.Hide();
            button6.Hide();


            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToString("M/d/yyyy");
            comboBox2.Text = "";

            textBox5.Text = "";
            textBox9.Text = "";
            dateTimePicker2.Text = "";
        }
        public void kanvermek(string x)
        {
            textBox7.Text = max().ToString();
            button4.Text = "Tamam";
            groupBox2.Show();
            search.Hide();
            comboBox1.Hide();
            ara.Hide();
            dataGridView2.Hide();
            textBox5.Enabled = false;
            textBox9.Enabled = false;
            textBox2.Enabled = true;


            dateTimePicker1.Enabled = true;
            comboBox2.Text = "Depoya Giris";
            comboBox2.Enabled = false;
            dateTimePicker2.Enabled = false;
            textBox7.Enabled = false;
            button3.Hide();
            button6.Hide();


            textBox1.Text = "";
            textBox2.Text = x;
            dateTimePicker1.Text = DateTime.Now.ToString("M/d/yyyy");
            comboBox2.Text = "";

            textBox5.Text = "";
            textBox9.Text = "";
            dateTimePicker2.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            kanvermek();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Text = "Yolla";
            groupBox2.Show();
            search.Hide();
            comboBox1.Hide();
            ara.Hide();
            dataGridView2.Hide();

            textBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox2.Text = "Gönderi";
            comboBox2.Enabled = false;
            textBox7.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (button4.Text == "Tamam")
            {
                
                if (textBox1.Text == "A-" || textBox1.Text == "A+" || textBox1.Text == "B-" || textBox1.Text == "B+" || textBox1.Text == "AB-" || textBox1.Text == "AB+" || textBox1.Text == "O-" || textBox1.Text == "O+")
                {
                    String qry = "update Verici set [Son Aktif]='"+DateTime.Now+"' where [Verici Kodu]='" + textBox2.Text + "'";
                    dn.UpdateInsert(qry);
                    dn.UpdateInsert("insert into kan([Kan Grubu],[Verici kodu],[Toplama Tarih],[Durum]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Text + "','depoda')");
                    MessageBox.Show("Başarılı!!! Kan Kodu " + textBox7.Text);
                    textBox7.Text = max().ToString();
                    textBox2.Clear(); 
                }
                else
                {
                    MessageBox.Show("verici kodu sistemde yok yada yanliş! Lutefen sistemde bakınız yada kayıt yapın","UYARI");
                }
            }
            else if (button4.Text == "Güncelleme")
            {
               
                    dn.UpdateInsert("update kan set [Kan Grubu]='" + textBox1.Text + "',[Verici kodu]='" + textBox2.Text + "', [Toplama Tarih]='" + dateTimePicker1.Text + "',Durum='" + comboBox2.Text + "' ,Alan='" + textBox5.Text + "',[Siparis Numara]='" + textBox9.Text + "',[Edinme tarih]='" + dateTimePicker2.Text + "' where [Kan Kodu]='" + textBox7.Text + "'");
                    MessageBox.Show("Kaydeti!");
            }
            else if (button4.Text == "Yolla")
            {
                dn.UpdateInsert("update kan set Durum ='çıkmış',Alan='" + textBox5.Text + "',[Siparis Numara]='" + textBox9.Text + "',[Edinme tarih]='" + dateTimePicker2.Text + "' where [Kan Kodu]='" + textBox7.Text + "'");
                    MessageBox.Show("Kaydeti!");
                
            groupBox2.Hide();
            search.Show();
            comboBox1.Show();
            ara.Show();
            dataGridView2.Show();
            loadData();
           
            }
            UpdateDurum();
            setStrings();

        }

        private void ara_Click(object sender, EventArgs e)
        {
            loadData();//şu fonksiyon datagridview dolduruyor
            search.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
            textBox9.Enabled = true;
            button4.Text = "Güncelleme";
            groupBox2.Show();
            search.Hide();
            comboBox1.Hide();
            ara.Hide();
            dataGridView2.Hide();

            textBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox2.Enabled = true;
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu adm = new menu();
            adm.Show();
            this.Hide();
        }
        
        public void UpdateDurum()//sona ermiş olan kan'n durumu değişiyor
        {   DateTime exdate = DateTime.Today.AddDays(-42);
            
        string query = "update kan set Durum='sona ermiş' where [Toplama Tarih]<='" + exdate + "'";
        string query1 = "update kan set Durum='depoda' where [Toplama Tarih]>'" + exdate + "' and Durum='sona ermiş'";    
            dn.UpdateInsert(query);//calls the update function in doner class with the query string 
            dn.UpdateInsert(query1);                        //to change the durum of all the blood in the stock with dates
                                       //that exceed the expiry date to "sona ermiş".
                          
        }
        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (dataGridView2.SelectedRows[0].Cells[4].Value.ToString() == "depoda")
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
            button3.Show();
            button6.Show();
            textBox7.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();

            textBox5.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
            textBox9.Text = dataGridView2.SelectedRows[0].Cells[6].Value.ToString();
            dateTimePicker2.Text = dataGridView2.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            button3.Hide();
            button6.Hide();
        }

        private void splitContainer1_MouseClick(object sender, MouseEventArgs e)
        {
            button3.Hide();
            button6.Hide();
        }

        private void update1_Click(object sender, EventArgs e)
        {



        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {//verici kodu kullanarak kan grubu alıyor
            SqlCommand cmd = new SqlCommand("SELECT [Kan Grubu] FROM Verici where [Verici Kodu]='" + textBox2.Text + "'", con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                textBox1.Text = rd.GetString(0);
                label22.Text = "";
            }
            else
            {
                textBox1.Clear();
                label22.Text = "Sistemde yok!";
                
            }
            con.Close();
        }

        private void Kan_Load(object sender, EventArgs e)
        {
          loadData();
            groupBox2.Hide();
            UpdateDurum();
            setStrings();
        }

       
    }
}
