using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlnv.Layers
{
    public class Paramater_Emps
    {
        public string MANV;
        public string HOTEN;
        public DateTime NGAYSINH;
        public string SEX;
        public string PHONE;
        public string ADDRESS;
        public string SALARY;
        public string DEP;
        public string NOW;

        public Paramater_Emps(string MANV,string HOTEN,DateTime NGAYSINH,string SEX,string PHONE,string ADDRESS,string SALARY,string DEP,string NOW)
        {
            this.MANV = MANV;
            this.HOTEN = HOTEN;
            this.NGAYSINH = NGAYSINH;
            this.SEX = SEX;
            this.PHONE = PHONE;
            this.ADDRESS = ADDRESS;
            this.SALARY = SALARY;
            this.DEP = DEP;
            this.NOW = NOW;
        }
    }
}
