using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlnv.Layers
{
    public class Paramater_Dept
    {
        public string MAPB;
        public string TENPB;
        public string MATRPHONG;
        public string TENTRPHONG;

        public Paramater_Dept(string MAPB,string TENPB,string MATRPHONG,string TENTRPHONG)
        {
            this.MAPB = MAPB;
            this.TENPB = TENPB;
            this.MATRPHONG = MATRPHONG;
            this.TENTRPHONG = TENTRPHONG;
        }
    }
}
