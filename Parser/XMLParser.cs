using Ionic.Zip;
using Parser.Properties;
using Parser.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser
{
    public partial class XMLParser : Form
    {
        Dosya dosya;
        Ayarlar ayarlar;
        ZipIslem zipIslem;

        enum Konumlar
        {
            taramaNoktasi,
            kayitNoktasi
        }

        public XMLParser()
        {
            InitializeComponent();
        }
        Dictionary<string, int> senaryoSayaci;
        Dictionary<string, List<string>> liste;
        bool ayiklandimi = false;
        private void XMLParser_Load(object sender, EventArgs e)
        {
            try
            {

                senaryoSayaci = new Dictionary<string, int>();
                txtKonuım.Text = Properties.Settings.Default.TaramaNoktasi.ToString();
                textBox1.Text = Properties.Settings.Default.KayitYolu.ToString();
                
                dosya = new Dosya();
                
                dosya.konum = Properties.Settings.Default.TaramaNoktasi.ToString();
                Dictionary<string, List<string>> liste = dosya.dosayListesi();
                Dictionary<string, List<string>> liste2 = liste;

                liste = new Dictionary<string, List<string>>();
                zipIslem = new ZipIslem();
            }
            catch (Exception a)
            {

                MessageBox.Show(a.ToString());
            }
        }
        private void konumuKaydet(string konum, Konumlar konumTipi)
        {
            if (konumTipi == Konumlar.taramaNoktasi)
            {
                
                Properties.Settings.Default.TaramaNoktasi = konum;
                Properties.Settings.Default.Save();
            }
            if (konumTipi == Konumlar.kayitNoktasi)
            {
                Properties.Settings.Default.KayitYolu = konum;
                Properties.Settings.Default.Save();
            }
        }

        private void DosyaYolu_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog();
                string konum = dialog.SelectedPath.ToString();
                this.konumuKaydet(konum, Konumlar.taramaNoktasi);
                txtKonuım.Text = Properties.Settings.Default.TaramaNoktasi.ToString();
                MessageBox.Show("Adres kayıt edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listeyeEkle(List<string> liste, TreeNode node)
        {

            foreach (var item in liste)
            {
                string[] tmp = item.Split('\\');
                TreeNode nd = new TreeNode(tmp[tmp.Length-1]);
                node.Nodes.Add(nd);
            }


        }
         

        
        private void btnKayıtYolu_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog();
                string konum = dialog.SelectedPath.ToString();
                this.konumuKaydet(konum,Konumlar.kayitNoktasi);
                txtKonuım.Text = Properties.Settings.Default.TaramaNoktasi.ToString();
                MessageBox.Show("Adres kayıt edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTara_Click(object sender, EventArgs e)
        {
            try
            {
                ayiklandimi = false;
                agacListe.Nodes.Clear();   
                dosya = new Dosya();

                dosya.konum = Properties.Settings.Default.TaramaNoktasi.ToString();

                liste = dosya.dosayListesi();

                foreach (var item2 in liste)
                {
                    TreeNode node = new TreeNode(item2.Key.ToString() + " (" + item2.Value.Count.ToString() + ")");
                    listeyeEkle(item2.Value, node);
                    agacListe.Nodes.Add(node);
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnAyikla_Click(object sender, EventArgs e)
        {
            try
            {
                if (liste == null)
                {
                    MessageBox.Show("Taranmış dosya listesi boş! \n Öncelikle tarama yapmalısınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.senaryoSayaci.Clear();
                int paketSayisi = Convert.ToInt32(Properties.Settings.Default.paketSayisi);
                string dizinid = "";
                string cikarmaYolu = "";
                string tmp = Properties.Settings.Default.KayitYolu + @"\tmp";
                string kayitYolu = Properties.Settings.Default.KayitYolu;
                if (Directory.Exists(tmp) == false)
                {
                    Directory.CreateDirectory(tmp);
                }
                

                progressBar1.Maximum = 0;
                foreach (var item in liste)
                {
                    progressBar1.Maximum += item.Value.Count;
                }
                foreach (var item in liste)
                {
                    
                        if (item.Key == "zip")
                        {
                            statusTxt.Text = "Zipler işleniyor ...";
                            foreach (var zipler in item.Value)
                            {
                            progressBar1.Value += 1;
                                foreach (var item2 in zipIslem.zipdenCikar(zipler.ToString(), tmp))
                                {
                                statusTxt.Text = item2.ToString();
                                    genelAmacli.xmlAyikla(
                                        ref this.senaryoSayaci,
                                        kayitYolu,
                                        tmp + @"\" + item2,
                                        cikarmaYolu,
                                        tmp + @"\" + item2,
                                        new Dosya(),
                                        paketSayisi                                        
                                    );
                                    File.Delete(tmp + @"\" + item2);
                                }
                            }
                        }
                        else
                        {
                            statusTxt.Text = "Zarflar işleniyor";
                            foreach (var item2 in item.Value)
                            {
                            statusTxt.Text = item2.ToString();
                            progressBar1.Value += 1;
                            genelAmacli.xmlAyikla(
                                        ref this.senaryoSayaci,
                                        kayitYolu,
                                        tmp + @"\" + item2,
                                        cikarmaYolu,
                                        item2,
                                        new Dosya(),
                                        paketSayisi
                                    );

                            }
                        }
                }
                Directory.Delete(tmp, true);


                #region zipleme
                List<string> ziplList = new List<string>();
                foreach (var item in senaryoSayaci)
                {
                    var i = item;
                    if (item.Key.IndexOf("_Sayac") == -1)
                    {
                        for (global::System.Int32 j = 1; j <= item.Value; j++)
                        {
                            var dizin = item.Key.ToString() + j.ToString();
                            ziplList.Add(dizin );
                        }
                    }
                }
                #endregion

                TreeNode node = new TreeNode("Yeni saklama dizinleri (" + ziplList.Count.ToString() + ")");
                listeyeEkle(ziplList, node);
                agacListe.Nodes.Add(node);

                ayiklandimi = true;
                statusTxt.Text = "Bitti";
                MessageBox.Show("İşlem tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception sas)
            {
                statusTxt.Text = sas.Message.ToString();
                MessageBox.Show(sas.Message.ToString());
            }
        }

        private void XMLParser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            ayarlar = new Ayarlar(Ayarlar.statu.ayarlarla);
            ayarlar.ShowDialog();
        }

        private void btnziple_Click(object sender, EventArgs e)
        {
            try
            {
                if (ayiklandimi == false)
                {
                    MessageBox.Show("Belgeler ayıklanmamış veya hazır değil!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string tmp = Properties.Settings.Default.KayitYolu + @"\tmp";
                string kayitYolu = Properties.Settings.Default.KayitYolu;
                #region zipleme
                List<string> ziplList = new List<string>();
                foreach (var item in senaryoSayaci)
                {
                    var i = item;
                    if (item.Key.IndexOf("_Sayac") == -1)
                    {
                        for (global::System.Int32 j = 1; j <= item.Value; j++)
                        {
                            var dizin = item.Key.ToString() + j.ToString();
                            ziplList.Add(dizin + ".zip");
                            zipIslem.dizinZiple(kayitYolu + @"\" + dizin, kayitYolu + @"\" + dizin + ".zip");
                            Directory.Delete(kayitYolu + @"\" + dizin, true);
                        }
                    }
                }
                #endregion
                TreeNode node = new TreeNode("Yeni saklama dosyaları (" + ziplList.Count.ToString() + ")");
                listeyeEkle(ziplList, node);
                agacListe.Nodes.Add(node);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
