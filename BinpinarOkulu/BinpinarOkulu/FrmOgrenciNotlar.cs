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
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        } // Global alan and sql connection
        SqlConnection sqlbaglanti = new SqlConnection(@"Data Source=DEVRAN-PC\SQLEXPRESS;Initial Catalog=BinpinarOkulu;Integrated Security=True");

        //bir tane numara degiskeni tanımlayalım 
        public string numara;
        // Not Formu notları getirdik 
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT DersName, Exam1,Exam2,Exam3,Proje,Average,Durum FROM Tbl_Notlar \r\nINNER JOIN Tbl_Dersler ON Tbl_Notlar.DersID = Tbl_Dersler.DersID WHERE StudentID = @p1", sqlbaglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            // Formun sol ust koseye ogrencı numara yani ID tasısın 
            // this.Text = numara.ToString();
            SqlDataAdapter dtAdapter = new SqlDataAdapter(komut);
            DataTable dtTable = new DataTable();
            dtAdapter.Fill(dtTable);
            dataGridView1.DataSource = dtTable;




        }
    }
}
