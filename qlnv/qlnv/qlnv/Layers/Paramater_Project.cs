using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace qlnv.Layers
{
	public class Paramater_Project
	{
		public string MADA;
		public string TENDA;
		public string DEP;
		public string CHIPHI;
		public string NOWINWORKING;

		public Paramater_Project(string MADA,string TENDA,string DEP,string CHIPHI,string NOWINWORKING)
		{
			this.MADA = MADA;
			this.TENDA = TENDA;
			this.DEP = DEP;
			this.CHIPHI = CHIPHI;
			this.NOWINWORKING = NOWINWORKING; ;
		}
	}
}
