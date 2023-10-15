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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

            private void BtnClpislemler_Click(object sender, EventArgs e)
        {     
            FrmKulup frmclp = new FrmKulup();
            frmclp.Show();
        }

        // Ders İşlemleri Butonu 
        private void BtnDersislemleri_Click(object sender, EventArgs e)
        {
            FrmDersler frdrslr = new FrmDersler();
            frdrslr.Show();

        }

        // Ogrenci islemleri Butonu 
        private void BtnOgrenciIslemleri_Click(object sender, EventArgs e)
        {
            FrmOgrenci frmOgrenci = new FrmOgrenci();
            frmOgrenci.Show();

        }

        //Sınav Notları 
        private void BtnSınavNotları_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar frmsnvnot = new FrmSinavNotlar();
            frmsnvnot.Show();

        }

       
    }
}
