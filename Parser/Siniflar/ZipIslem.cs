using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using Ionic.Zip;


namespace Parser.Siniflar
{
    public class ZipIslem 
    {
        public string konum {  get; set; }
        public string tmp { get; set; }

        public List<string> zipdenCikar(string zipYolu, string CiktiDizini)
        {
            try
            {

                List<string> liste = new List<string>();
                using (ZipFile zip = ZipFile.Read(zipYolu))
                {
                    foreach (ZipEntry entr in zip)
                    {
                        if (entr.FileName.EndsWith(".xml"))
                        {
                            entr.Extract(CiktiDizini, ExtractExistingFileAction.OverwriteSilently);
                            liste.Add(entr.FileName);
                        }
                    }
                }
                return liste;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void dizinZiple(string yolu, string CiktiDizini)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    if (File.Exists(CiktiDizini))
                    {
                        throw new Exception(CiktiDizini + " zaten mevcut!");
                    }
                    zip.AddDirectory(yolu);
                    zip.Save(CiktiDizini);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
         
    }
}
