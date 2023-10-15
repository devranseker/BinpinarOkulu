using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinpinarOkulu
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        // Dersler Formu 
        // Gloabal'e tasıdık cunku her kod blogunda dtsetDrsler kullanmam icin 
        DataSet1TableAdapters.Tbl_DerslerTableAdapter dtsetDrsler = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();

        private void FrmDersler_Load(object sender, EventArgs e)
        {
          
            dataGridView1.DataSource = dtsetDrsler.DersListesi();      // DersListesi(); methodunu unutma tabloyu dondurmek icin bu methoda atadık 

        }

        // listele butonu 
        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtsetDrsler.DersListesi();

        }

        // Ekle Butonu 
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            dtsetDrsler.DersEkle(TxtDersName.Text);
            MessageBox.Show("Ders Ekleme İşlemi Yapılmıştır.");

        }

        // X butonu 
        private void BtnXX_Click(object sender, EventArgs e)
        {  // X Butonuna tıkladıgım zaman gizliyor 
            this.Hide();

        }

        // Sil butonu 
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            dtsetDrsler.DersSil(byte.Parse (TxtDersID.Text));    // stringi yani metni byte cevirdik 

        }

        // Guncelleme Butonu 
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            dtsetDrsler.DersGuncelle(TxtDersName.Text, byte.Parse(TxtDersID.Text));
            MessageBox.Show("Güncelleme İşlemi Gerçekleştirildi.");

        }

        // dataGridView1'deki 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtDersID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDersName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }
    }
}
