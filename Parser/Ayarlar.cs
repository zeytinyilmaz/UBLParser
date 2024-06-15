using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser
{
    public partial class Ayarlar : Form
    {
        private XMLParser parser;
        public enum statu
        {
            baslangicta,
            ayarlarla
        }

        private bool thisClose = false;

        public Ayarlar(statu statu)
        {
            InitializeComponent();
            thisClose = (statu == statu.ayarlarla) ? true : false;
        }

        public Ayarlar()
        {
            InitializeComponent();
        }

        private void btnTaranacakDizin_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                fb.ShowDialog();
                txtTaranacak.Text = fb.SelectedPath.ToString();
            }
        }

        private void btnkayitDizin_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                fb.ShowDialog();
                txtkayitYeri.Text = fb.SelectedPath.ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.paketSayisi = Convert.ToInt32(sayac.Value);
            Properties.Settings.Default.KayitYolu = txtkayitYeri.Text.ToString();
            Properties.Settings.Default.TaramaNoktasi = txtTaranacak.Text.ToString();
            Properties.Settings.Default.Save();
            if (thisClose)
            {
                this.Close();
            }
            else
            {
                parser = new XMLParser();
                this.Hide();
                parser.ShowDialog();
            }

        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            sayac.Value = Properties.Settings.Default.paketSayisi;
            txtkayitYeri.Text = Properties.Settings.Default.KayitYolu.ToString();
            txtTaranacak.Text = Properties.Settings.Default.TaramaNoktasi.ToString();
        }
    }
}
