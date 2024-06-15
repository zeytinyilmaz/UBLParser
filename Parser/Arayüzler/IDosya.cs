using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    internal interface IDosya
    {
        string adi {  get; set; }
        double boyut { get; set; }
        string tip { get; set; }
        string konum { get; set; }
        void tara();
        void iciniTara();
        Dictionary<string, List<string>> dosayListesi();
    }
}
