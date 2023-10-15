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


namespace BinpinarOkulu
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        // Global alan and sqlconnection add
        SqlConnection sqlbaglanti = new SqlConnection(@"Data Source=DEVRAN-PC\SQLEXPRESS;Initial Catalog=BinpinarOkulu;Integrated Security=True");

         void listele()
        {
            SqlDataAdapter veribgl = new SqlDataAdapter("SELECT * FROM Tbl_Clups", sqlbaglanti);
            DataTable dtTable = new DataTable();
            veribgl.Fill(dtTable);
            dataGridView1.DataSource = dtTable;
        }

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            listele();

        }
        // Add butonu 
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            sqlbaglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into  Tbl_Clups (ClupName) VALUES (@p1) ", sqlbaglanti);
            komut.Parameters.AddWithValue("@p1", TxtClupName.Text);
            komut.ExecuteNonQuery();
            sqlbaglanti.Close();
            MessageBox.Show("Kulüp Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        // X Butonu yani Formdan cıksın 
        private void BtnXX_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        // Mouse ustune geldigi zaman 
        private void BtnXX_MouseHover(object sender, EventArgs e)
        {
            BtnXX.BackColor = Color.LightBlue;

        }

        // Mouse ustunden cekildigi zaman eski rengine gelsin 
        private void BtnXX_MouseLeave(object sender, EventArgs e)
        {
            BtnXX.BackColor = Color.Transparent;

        }

        // dataGridView1 CellClick herhangi bir hucreye tıkladıgımızda 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtClupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtClupName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }
        // Delete Butonu 
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            sqlbaglanti.Open();
            SqlCommand komut = new SqlCommand("Delete From Tbl_Clups where ClupID = @p1", sqlbaglanti);
            komut.Parameters.AddWithValue("@p1", TxtClupID.Text);
            komut.ExecuteNonQuery();
            sqlbaglanti.Close();
            MessageBox.Show("Kulüp Silme İşlemi Gerçekleştirildi.");
            listele();

        }

        // Update Butonu  where'siz olmaz dikkat 
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            sqlbaglanti.Open();
            SqlCommand komut = new SqlCommand("Update Tbl_Clups set ClupName = @p1 Where ClupID = @p2", sqlbaglanti);
            komut.Parameters.AddWithValue("@p1", TxtClupName.Text);
            komut.Parameters.AddWithValue("@p2", TxtClupID.Text);
            komut.ExecuteNonQuery();
            sqlbaglanti.Close();
            MessageBox.Show("Kulüp Güncelleme İşlemi Gerçekleştirildi.");
            listele();

        }

        private void BtnXX_Click_1(object sender, EventArgs e)
        {
            this.Hide();  // bu formu sakla
        }
    }
}
