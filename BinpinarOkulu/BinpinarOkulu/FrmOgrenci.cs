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
using System.Data.SqlClient;





namespace BinpinarOkulu
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        // X butonu
        private void BtnXX_Click(object sender, EventArgs e)
        {
            this.Hide();  // bu formu sakla

        }
        SqlConnection sqlbaglanti = new SqlConnection(@"Data Source=DEVRAN-PC\SQLEXPRESS;Initial Catalog=BinpinarOkulu;Integrated Security=True");

        // Global alana  OgrenciListesi yazalım ki istediğimiz zaman kullanalım 
        DataSet1TableAdapters.DataTable1TableAdapter dtSetTblAdpter = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtSetTblAdpter.OgrenciListesi();
            sqlbaglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Clups", sqlbaglanti);
            SqlDataAdapter dtAdapter = new SqlDataAdapter(komut);
            DataTable dtTbl = new DataTable();
            dtAdapter.Fill(dtTbl);
            // DisplayMember ==  Ekrana gelecek ad => KULÜPAD
            // ValueMember == arkaplanda  => KULÜPID

            CmbOgrnciClup.DisplayMember = "ClupName";
            CmbOgrnciClup.ValueMember = "ClupID";
            CmbOgrnciClup.DataSource = dtTbl;
            sqlbaglanti.Close();


        }
        // Ekle Butonu
        string gender = " ";
        private void BtnAdd_Click(object sender, EventArgs e)
        {
           
            dtSetTblAdpter.OgreniEkle(TxtOgrnciName.Text, TxtOgrnciSurname.Text, byte.Parse(CmbOgrnciClup.SelectedValue.ToString()), gender);
            MessageBox.Show("Öğrenci Ekleme İşlemi Yapıldı.");

        }

        // Listeleme Butonu 
        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtSetTblAdpter.OgrenciListesi();
        }

        // Clup cmbsi
        private void CmbOgrnciClup_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtOgrnciID.Text = CmbOgrnciClup.SelectedValue.ToString();

        }

        /// <summary>
        /// ///////////////    silme islemi calısmıyor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // Silme Butonu 
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            dtSetTblAdpter.OgrenciSil(int.Parse(TxtOgrnciID.Text));
            MessageBox.Show("Öğrenci Silme İşlemi Yapıldı.");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            dtSetTblAdpter.OgrenciGuncelle(TxtOgrnciName.Text,TxtOgrnciSurname.Text, byte.Parse(CmbOgrnciClup.SelectedValue.ToString()),gender, byte.Parse(TxtOgrnciID.Text));
            MessageBox.Show("Öğrenci Güncelleme İşlemi Yapıldı.");
        }

        // dataGridView1 CellClick herhangi bir hucreye tıkladıgımızda 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
              TxtOgrnciID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
              TxtOgrnciName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
              TxtOgrnciSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
              CmbOgrnciClup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            // Gender Cinsiyet icin
            // string cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); // Cinsiyet verisini alın
            RadioButtonErkek.Enabled = true; // Erkek RadioButton'ı tıklanabilir hale gelir
            RadioButtonKadin.Enabled = true; // Kadın RadioButton'ı tıklanabilir hale gelir


            if (gender == "Erkek")                                                                          
            {
                // "Erkek" ise Erkek RadioButton'ını işaretle
                RadioButtonErkek.Checked = true;
            }
            else if (gender == "Kız")
            {
                // "Kadın" ise Kadın RadioButton'ını işaretle
                RadioButtonKadin.Checked = true;
            }


        }

        private void RadioButtonKadin_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonKadin.Checked == true)
            {
                gender = "Kız";
            }
        }

        private void RadioButtonErkek_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonErkek.Checked == true)
            {
                gender = "Erkek";
            }
        }

        // Ara Butonu 
        private void BtnAra_Click(object sender, EventArgs e)
        {
          dataGridView1.DataSource = dtSetTblAdpter.OgrenciGetir(TxtAra.Text);

        }
    }
}
