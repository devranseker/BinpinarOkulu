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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ogrenci pictureBox1'ına tıkladıgın zaman ogrenci notlar tablosuna gitsin
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgrenciNotlar frmogrnclr = new FrmOgrenciNotlar();
            frmogrnclr.numara = textBox1.Text;
            frmogrnclr.Show();


        }

        // ogretmen pictureBox1'ına tıkladıgın zaman ogrenci notlar tablosuna gitsin
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmen frmogrt = new FrmOgretmen();
            frmogrt.Show();
            this.Hide();
            
            
        }
    }
}
