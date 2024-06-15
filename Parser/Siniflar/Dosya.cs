using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Siniflar
{
    public class Dosya : IDosya
    {
        public string adi { get  ; set  ; }
        public double boyut { get  ; set  ; }
        public string tip { get  ; set  ; }
        public string konum { get  ; set  ; }
         

        public Dictionary<string, List<string>> dosayListesi()
        {
            if (konum == null)
            {
                throw new Exception("taranacak bir konum yok!");
            }
            #region nesneler
            List<string> xmller = new List<string>(Directory.EnumerateFiles(this.konum, "*.xml", SearchOption.AllDirectories));
            List<string> zipler = new List<string>(Directory.EnumerateFiles(this.konum, "*.zip", SearchOption.AllDirectories));
            #endregion
            Dictionary<string, List<string>> dosyaListesi = new Dictionary<string, List<string>>();
            dosyaListesi.Add("xml", xmller);
            dosyaListesi.Add("zip", zipler); 
            return dosyaListesi;
        }

        public void iciniTara()
        {
            //ilerleyen süreçler için
            if (konum == null)
            {
                throw new Exception("taranacak bir konum yok!");
            }

        }

        public void tara()
        {
            //ilerleyen süreçler için
            throw new NotImplementedException();
        }

        public string arasındakiniGetir(string baslangic, string bitis, string metin) {
            try
            {
                if (metin.IndexOf(baslangic) == -1)
                {
                    return "";
                }
                return metin.Substring(metin.IndexOf(baslangic) + baslangic.Length, (metin.IndexOf(bitis) - metin.IndexOf(baslangic) - bitis.Length));
                
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

    }
}
