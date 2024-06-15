using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Properties.Settings.Default.paketSayisi == 0 || Properties.Settings.Default.TaramaNoktasi == "" || Properties.Settings.Default.KayitYolu == "")
            {
                MessageBox.Show("Kayıtlı bir ayar bulunmamaktadır. Ayar ekranına yönlendiriliyorsunuz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Run(new Ayarlar(Ayarlar.statu.baslangicta));
            }
            else
            {
                
                Application.Run(new XMLParser());
            }


            
        }
    }
}
