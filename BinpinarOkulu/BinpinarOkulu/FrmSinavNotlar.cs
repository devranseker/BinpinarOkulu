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



namespace BinpinarOkulu
{
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }
        // Global alan 
        DataSet1TableAdapters.Tbl_NotlarTableAdapter dtSetAdptr = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        SqlConnection sqlbaglanti = new SqlConnection(@"Data Source=DEVRAN-PC\SQLEXPRESS;Initial Catalog=BinpinarOkulu;Integrated Security=True");


        // AraButonu 
        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtSetAdptr.NotListesi(int.Parse(TxtOgrnciID.Text));

        }

        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
            // Cmb'ye Dersleri aktardık 
            sqlbaglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Dersler", sqlbaglanti);
            SqlDataAdapter dtAdapter = new SqlDataAdapter(komut);
            DataTable dtTbl = new DataTable();
            dtAdapter.Fill(dtTbl);
            // DisplayMember ==  Ekrana gelecek ad => KULÜPAD
            // ValueMember == arkaplanda  => KULÜPID

            CmbDers.DisplayMember = "DersName";
            CmbDers.ValueMember = "DersID";
            CmbDers.DataSource = dtTbl;
            sqlbaglanti.Close();
        }

        // dataGridView1_CellClick olayı 

        int notID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtOgrnciID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        
        // Hesapla Butonu 
        int Exam1, Exam2, Exam3, Proje;

        private void BtnXX_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        double Average;
        //  string Durum;  kullanmadım 
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            Exam1 = Convert.ToInt16(TxtSinav1.Text);
            Exam2 = Convert.ToInt16(TxtSinav2.Text);
            Exam3 = Convert.ToInt16(TxtSinav3.Text);
            Proje = Convert.ToInt16(TxtProje.Text);
            Average = (Exam1 + Exam2 + Exam3 + Proje) / 4;
            TxtOrtalama.Text = Average.ToString();
            if(Average >= 50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";

            }

        }
        // Guncelle Butonu 
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            // NULL deger olmaması lazım 
            dtSetAdptr.NotGuncelle(byte.Parse(CmbDers.SelectedValue.ToString()),int.Parse(TxtOgrnciID.Text), byte.Parse(TxtSinav1.Text), byte.Parse(TxtSinav2.Text), byte.Parse(TxtSinav3.Text), byte.Parse(TxtProje.Text), decimal .Parse(TxtOrtalama.Text), bool.Parse(TxtDurum.Text),notID);
            MessageBox.Show("Öğrenci bilgileri güncellendi.");

        }

    }
}
