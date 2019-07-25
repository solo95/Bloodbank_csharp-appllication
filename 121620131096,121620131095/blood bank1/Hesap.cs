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
    public partial class Hesap : Form
    {
        
        SqlConnection con = new SqlConnection("Data Source=WILLIAM;Initial Catalog=kanbanka;Integrated Security=True");
        KanVerici dn = new KanVerici();
       
        Login fm = new Login();
        
        
        string foto;
        public Hesap()
        {
            InitializeComponent();
            label14.Hide();
            dataGridView2.Hide();
            groupBox1.Show();
        }
        public int max()
        {
            int x = 0;
            SqlCommand a = new SqlCommand("select isnull(Max(kullanci_kodu),0)+1 from login", con);
            con.Open();
            SqlDataReader rdr = a.ExecuteReader();
            if (rdr.Read())
            {
                x = rdr.GetInt32(0);

            }
            con.Close();
            return x;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string query = "select count(*) from login where [TC_kimlik]='" + textBox11.Text + "'";
            bool exists = false;
            if (fm.Data(query).Rows[0][0].ToString() == "1")
            {
                exists = true;
            }
            
            if (button3.Text == "KAYDET")
            {
                if (textBox12.Text == textBox5.Text)
                {
                    if (textBox12.Text.Length >= 4)
                    {
                        dn.UpdateInsert("update login set sifre='" + textBox12.Text + "',adi='" + textBox2.Text + "',ikinci_adi='" + textBox3.Text + "',soyadi='" + textBox4.Text + "',cinsiyet='" + comboBox1.Text + "',telefon='" + textBox6.Text + "',E_posta='" + textBox7.Text + "',ulke='" + textBox8.Text + "',sehir='" + textBox9.Text + "',adres='" + textBox10.Text + "',TC_kimlik='" + textBox11.Text + "',kullanci_tipi='" + comboBox2.Text + "',foto='" + foto + "' where kullanci_kodu='" + textBox1.Text + "'");
                        MessageBox.Show("Başarılı");
                    }
                    else
                    {
                        MessageBox.Show("Şifre en az dort karakterli olması lazım");
                    }
                }
                else
                {
                    MessageBox.Show("şifre farklidir!");
                }
            }
            else if (button3.Text == "OLUŞTUR")
            {
                //
                if (exists == true)
                {
                    MessageBox.Show("Bu numara kullanamazsın. Numara sistemde kayıtlı!");
                        
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Adi Boş bırakamazsın!");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Soyadi Boş bırakamazsın!");
                }
                else if (textBox11.Text == "")
                {
                    MessageBox.Show("TC kimlik Numara Boş bırakamazsın!");
                }
                else if (textBox11.Text.Length!=11)
                {
                    MessageBox.Show("TC kimlik Numara Eksik Yada Fazla!");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("Telefon Numara Boş bırakamazsın!");
                }
                else if (textBox8.Text == "")
                {
                    MessageBox.Show("Ulke Girmeniz lazım!");
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("Şehir Boş bırakamazsın!");
                }
                else
                {
                    
                    if (textBox12.Text.Length < 4)
                    {
                        MessageBox.Show("Şifre en az dort karakterli olması lazım!");
                    }
                    else
                    {

                        if (textBox12.Text == textBox5.Text)
                           {
                               if (comboBox1.Text == "Erkek" || comboBox1.Text == "Kadın" || comboBox1.Text == "Başka")
                               {
                                   dn.UpdateInsert("insert into login (sifre,adi,ikinci_adi,soyadi,cinsiyet,telefon,E_posta,ulke,sehir,adres,TC_kimlik,kullanci_tipi,foto) values('" + textBox12.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + comboBox2.Text + "','" + foto + "')");
                                   MessageBox.Show("yeni Hesap Başarıyla oluşturdu! Hesap Numara " + textBox1.Text);
                                   textBox1.Text = max().ToString();
                                   textBox12.Clear();
                                   textBox5.Clear();
                                   textBox2.Clear();
                                   textBox3.Clear();
                                   textBox4.Clear();
                                   comboBox1.Text = "seç";
                                   textBox6.Clear();
                                   textBox7.Clear();
                                   textBox8.Clear();
                                   textBox9.Clear();
                                   textBox10.Clear();
                                   textBox11.Clear();

                               }
                               else
                               {
                                   MessageBox.Show("lUTFEN cinsiyet kotudan şeçin");
                               }
                           }
                        else
                           {
                                MessageBox.Show("şifre farklidir!");
                           }
                    }
                    
                }
            }
            
       }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text != textBox5.Text)
            {
                label14.Show();
            }
            else
            {
                label14.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button7.Hide();
            search.Hide();
            label24.Hide();
            LoadBoxes();
            textBox1.Text = fm.getval();
            button3.Text = "KAYDET";
            dataGridView2.Hide();
            groupBox1.Show();
            comboBox2.Enabled = false;
            textBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button7.Hide();
            search.Hide();
            label24.Hide();
            comboBox2.Enabled = true;
            button3.Text = "OLUŞTUR";
            dataGridView2.Hide();
            groupBox1.Show();
            textBox1.Enabled = false;
            textBox1.Text = max().ToString();
            textBox12.Clear();
            textBox5.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text="seç";
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            pictureBox1.ImageLocation = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10)) + "\\defaultfoto\\default.jpg";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu ad = new menu();
            ad.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Show();
            search.Show();
            button7.Hide();
            groupBox1.Hide();
            string query ="Select kullanci_kodu,adi,soyadi,telefon,E_posta,kullanci_tipi,TC_kimlik from login";
            try
            {
               dataGridView2.DataSource = fm.Data(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "images (*.jpg)|*.jpg";

            if (opd.ShowDialog() == DialogResult.OK)
            {

                string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10)) + "\\foto\\" + textBox1.Text + ".jpg";

                System.IO.File.Copy(opd.FileName, paths, true);
                pictureBox1.ImageLocation = paths;
                foto = paths;


            }
        }
        public string usertype()
        {
            

            String kul="";
            SqlCommand cmd = new SqlCommand("select kullanci_tipi from login where kullanci_kodu='" +fm.getval() + "'", con);
            con.Open();//
            SqlDataReader reader = cmd.ExecuteReader();//
            
            while (reader.Read())//
            {

                kul= reader.GetString(0);
                
            }
            con.Close();
            return kul;
        }
        public void LoadBoxes()
        { textBox1.Text = fm.getval();
            if (usertype() == "admin")
            {
                comboBox2.Text = "admin";
            }
            else
            {
                comboBox2.Text = "standart";
            }
        SqlCommand cmd = new SqlCommand("select * from login where kullanci_kodu='" + textBox1.Text + "'", con);
            con.Open();//
            SqlDataReader reader = cmd.ExecuteReader();//
            try
            {
                while (reader.Read())//
                {

                    textBox12.Text = reader.GetString(1);
                    textBox5.Text = textBox12.Text;
                    textBox2.Text = reader.GetString(2);
                    textBox3.Text = reader.GetString(3);
                    textBox4.Text = reader.GetString(4);
                    comboBox1.Text = reader.GetString(5);
                    textBox6.Text = reader.GetString(6);
                    textBox7.Text = reader.GetString(7);
                    textBox8.Text = reader.GetString(8);
                    textBox9.Text = reader.GetString(9);
                    textBox10.Text = reader.GetString(10);
                    textBox11.Text = reader.GetString(11);

                    pictureBox1.ImageLocation = reader.GetString(13);


                }
                con.Close();
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
             
        }
        private void Hesap_Load(object sender, EventArgs e)
        {
            button7.Hide();
            search.Hide();
            label24.Hide();
            LoadBoxes();
            if (usertype() == "admin")
            {
               
                button2.Show();
                button4.Show();
            }
            else
            {
                button4.Hide();
                button2.Hide();
                search.Hide();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
            button7.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {    
            string del = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("emin misiniz "+del+" numaralı kullanci sistemden silmek isteyorsunuz!", "sil", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dn.UpdateInsert("delete from login where [kullanci_kodu]='" + del + "'");
                MessageBox.Show(del +"numaralı kullanci sistemden sildi", "Başarılı!");
            }
           
             string query = "Select kullanci_kodu,adi,soyadi,telefon,E_posta,kullanci_tipi,TC_kimlik from login";
            try
                    {
                    dataGridView2.DataSource = fm.Data(query);
                      }
            catch (Exception ex)
                     {
                          MessageBox.Show(ex.Message);
                     }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String query = "Select * from login";
                if (search.Text != "")
                {
               
                     query = "Select * from login where [kullanci_kodu] like '" + search.Text + "'";
                }
                dataGridView2.DataSource = fm.Data(query);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            button7.Hide();
        }

       
    }
}
