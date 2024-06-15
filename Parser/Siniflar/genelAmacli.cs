using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Siniflar
{
    public static class genelAmacli
    {
        public static string belgeSenaryo(string xml, string baslangic, string bitis)
        {

            return (xml.Substring(xml.IndexOf(baslangic) + baslangic.Length, (xml.IndexOf(bitis) - xml.IndexOf(baslangic) - bitis.Length + 1)));
        }

        public static void xmlAyikla(ref Dictionary<string, int> senaryoSayaci, string ayiklamaYolu, string zarfUbl, string tmp, object nesne, Dosya dosyaNesnesi, int paketSayisi) {
            string dizinId = "";
            string[] dosya = nesne.ToString().Split('\\');
            using (var streamReader = new StreamReader(nesne.ToString()))
            {
                var zarfSatirlar = streamReader.ReadToEnd(); 
                if (zarfSatirlar == "")
                {
                    return;
                }
                string xml = dosyaNesnesi.arasındakiniGetir("<ElementList>", "</ElementList>", zarfSatirlar.ToString());
                if (xml == "")
                {
                    if (zarfSatirlar.IndexOf("<cbc:ProfileID>") == -1)
                    {
                        return;
                    }
                    xml = zarfSatirlar;
                }
                string senaryo = genelAmacli.belgeSenaryo(xml, "<cbc:ProfileID>", "</cbc:ProfileID>");
                if (senaryo.IndexOf("EARSIV") != -1)
                {
                    senaryo = "eArsivFatura";
                }
                else if (senaryo.IndexOf("FATURA") != -1)
                {
                    senaryo = "eFatura";
                }
                else
                {
                    senaryo = "Irsaliye";
                }
                if (!senaryoSayaci.ContainsKey(senaryo))
                {
                    senaryoSayaci.Add(senaryo, 1);
                    senaryoSayaci.Add(senaryo + "_Sayac", 1);
                }
                else
                {
                    senaryoSayaci[senaryo + "_Sayac"] = senaryoSayaci[senaryo + "_Sayac"] + 1;
                }
                dizinId = "";
                if (senaryoSayaci[senaryo + "_Sayac"] == paketSayisi)
                {
                    senaryoSayaci[senaryo] = senaryoSayaci[senaryo] + 1;
                    senaryoSayaci[senaryo + "_Sayac"] = 0;
                }

                dizinId = senaryo + senaryoSayaci[senaryo].ToString();
                if (!Directory.Exists(ayiklamaYolu + @"\" + dizinId))
                {
                    Directory.CreateDirectory(ayiklamaYolu + @"\" + dizinId);
                }
                
                StreamWriter sw = new StreamWriter(ayiklamaYolu + @"\" + dizinId + @"\" + dosya[dosya.Length - 1]);
                sw.Write(xml);
                sw.Flush();
                sw.Close();
            } 
        }
    }
}
