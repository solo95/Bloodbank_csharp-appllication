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
using System.IO;

namespace blood_bank1
{
    public partial class KanVerici : Form
    {   
        SqlConnection con = new SqlConnection("Data Source=WILLIAM;Initial Catalog=kanbanka;Integrated Security=True");
        SqlDataAdapter adaptar;
    Login lg = new Login();
        public KanVerici()
        {
          
            InitializeComponent();
            groupBox1.Hide();
            loadData();
            groupBox2.Hide();


        }
        
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            
           
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
         string query = "Select * from verici where [Kan Grubu]='"+kan+"'";
                dataGridView1.DataSource = lg.Data(query);
                groupBox2.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void closeString()
        {
            con.Close();
        }
        public void loadData()
        {
            string query ="Select * from verici";
            try
            {
               dataGridView1.DataSource = lg.Data(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateInsert(string comandString)
        {
            try
            {
                if (con.State ==   ConnectionState.Closed )
                {
                       con.Open();
                }
                
                adaptar = new SqlDataAdapter(comandString, con);
                adaptar.SelectCommand.ExecuteNonQuery();
                
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Show();
            ara.Show();
            dataGridView1.Show();
            groupBox1.Hide();
            groupBox2.Hide();
            search.Show();
            loadData();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public int max() {
            int x = 0;
            SqlCommand a = new SqlCommand("select isnull(Max([Verici Kodu]),0)+1 from verici", con);
            con.Open();
            SqlDataReader rdr = a.ExecuteReader();
            if (rdr.Read())
            {
                x = rdr.GetInt32(0);

            }
            con.Close();
            return x;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            textBox7.Text = max().ToString();
            textBox2.Text ="";
            textBox1.Text = "";
            comboBox2.Text = "kan grubu şeçiniz";
            textBox3.Text = "";
            dateTimePicker1.Text="";
            textBox5.Text = "";
            textBox9.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            adress.Text = "";
            comboBox1.Hide();
            ara.Hide();
            dataGridView1.Hide();
            groupBox1.Show();
            groupBox2.Hide(); 
            search.Hide();
            button4.Show();
            update1.Hide();
            label2.Hide();

        }

        private void sehir_Click(object sender, EventArgs e)
        {

        }

        private void doner_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kanbankaDataSet.Verici' table. You can move, or remove it, as needed.
            //this.vericiTableAdapter.Fill(this.kanbankaDataSet.Verici);

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string rdobutton="";
            if(radioButton1.Checked){
                rdobutton = "Kadın";
            }
            else if(radioButton2.Checked){
                    rdobutton= "Erkek";
            }
            else if(radioButton3.Checked){
                rdobutton = "Başka";
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("formun gerekli olan kotuda tamamen doldurun!");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("formun gerekli olan kotuda tamamen doldurun!");
            }
            else if (rdobutton == "")
            {
                MessageBox.Show("cinsiyet şeçin!");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("formun gerekli olan kotuda tamamen doldurun!");
            }
            else if (textBox3.Text.Length < 11)
            {
                MessageBox.Show("TC kimlik numara eksik numaralalar var");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("formun gerekli olan kotuda tamamen doldurun!");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("formun gerekli olan kotuda tamamen doldurun!");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("formun gerekli olan kotuda tamamen doldurun!");
            }
            else
            {
                UpdateInsert("insert into verici(Adi,Soyadi,Cinsiyet,[Kan Grubu],[TC kimlik],[Doğum tarih],[Telefon No],[E posta],ulke,sehir,Adres) values('" + textBox2.Text + "','" + textBox1.Text + "','" + rdobutton + "','" + comboBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + textBox5.Text + "','" + textBox9.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + adress.Text + "')");
                con.Close();
                MessageBox.Show("Kaydeti!");
            }

        }

        private void button6_Click(object sender, EventArgs e)//5.19.2016
        {
            Kan kn = new Kan();
            kn.Show();
            kn.kanvermek(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
           
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ara_Click(object sender, EventArgs e)
        {
            loadData();
             search.Text= "";
             groupBox2.Hide();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            try
            {

                String query ="Select * from verici where [TC kimlik] like '" + search.Text + "'  or [Verici Kodu] like '" + search.Text + "'";
              
                dataGridView1.DataSource = lg.Data(query);
                groupBox2.Hide();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            button4.Hide();
            update1.Show();
            groupBox1.Show();
             comboBox1.Hide();
            ara.Hide();
            dataGridView1.Hide();
            groupBox2.Hide();
            search.Hide();
            label2.Hide();

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            groupBox2.Hide();
            
        }

        private void splitContainer1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void splitContainer1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void splitContainer1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            groupBox2.Show();
           
        }

        private void update1_Click(object sender, EventArgs e)
        {
            string rdobutton = "";
            if (radioButton1.Checked)
            {
                rdobutton = "Kadın";
            }
            else if (radioButton2.Checked)
            {
                rdobutton = "Erkek";
            }
            else if (radioButton3.Checked)
            {
                rdobutton = "Başka";
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("formun gerekli olan kotuda tamamen doldurun!");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("formun gerekli olan kotuda tamamen doldurun!");
            }
            else if (rdobutton == "")
            {
                MessageBox.Show("cinsiyet şeçin!");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("formun gerekli olan kotuda tamamen doldurun!");
            }
            else if (textBox3.Text.Length<11)
            {
                MessageBox.Show("TC kimlik numara eksik numaralalar var");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("formun gerekli olan kotuda tamamen doldurun!");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("formun gerekli olan kotuda tamamen doldurun!");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("formun gerekli olan kotuda tamamen doldurun!");
            }
            else
            {
                UpdateInsert("update verici set Adi='" + textBox2.Text + "',Soyadi='" + textBox1.Text + "',Cinsiyet='" + rdobutton + "',[Kan Grubu]='" + comboBox2.Text + "',[TC kimlik]='" + textBox3.Text + "',[Doğum tarih]='" + dateTimePicker1.Text + "',[Telefon No]='" + textBox5.Text + "',[E posta]='" + textBox9.Text + "',ulke='" + textBox4.Text + "',sehir='" + textBox6.Text + "',Adres='" + adress.Text + "' where [Verici Kodu]='" + textBox7.Text + "'");

                MessageBox.Show("Başarılı!!");
            }
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //////datagridview set valuse..use a function
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string cinsiyetSelection = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            if (cinsiyetSelection=="Kadın")
            {
                radioButton1.Checked=true;
                
            }
            else if (cinsiyetSelection=="Erkek")
            {
                radioButton2.Checked=true;
                
            }
            else if (cinsiyetSelection=="Başka")
            {
                radioButton3.Checked=true;
            }
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            adress.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            




        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu adm = new menu();
            adm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter="images (*.jpg)|*.jpg";
            opd.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                if (opd.CheckFileExists)
                {

                }
            }
        }
    }
}
