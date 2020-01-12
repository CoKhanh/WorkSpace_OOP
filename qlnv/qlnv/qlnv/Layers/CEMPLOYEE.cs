using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace qlnv.Layers
{
    class CEMPLOYEE
    {
        #region Load,Add,Update,Delete,ChangeNowWorkingToNo
        public DataTable LoadEmployeeInfo(string NAME) 
        {
            if (NAME == "" || NAME=="Enter Employee's ID") //giá trị tìm kiếm là rỗng thì show tất cả
            {
                QLNVEntities qlnv = new QLNVEntities();
                var staffs = from p in qlnv.STAFFS where p.NowWorking != "No" select p;

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("FULL NAME");
                dt.Columns.Add("BIRTHDATE");
                dt.Columns.Add("SEX");
                dt.Columns.Add("PHONE");
                dt.Columns.Add("ADDRESS");
                dt.Columns.Add("BASE WAGE");
                dt.Columns.Add("DEPARTMENT");
                dt.Columns.Add("NOW WORKING");

                foreach (var p in staffs)
                {
                    dt.Rows.Add(p.MaNV, p.HoTen, p.NgaySinh.Value.ToString("dd/MM/yyyy"), p.Phai, p.SDT, p.DiaChi, p.Luong, p.PhongBan, p.NowWorking);
                }
                return dt;
            }
            else
            {
                QLNVEntities qlnv = new QLNVEntities();
                var staffs = from p in qlnv.STAFFS where p.NowWorking != "No" && p.HoTen.Contains(NAME) select p;

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("FULL NAME");
                dt.Columns.Add("BIRTHDATE");
                dt.Columns.Add("SEX");
                dt.Columns.Add("PHONE");
                dt.Columns.Add("ADDRESS");
                dt.Columns.Add("BASE WAGE");
                dt.Columns.Add("DEPARTMENT");
                dt.Columns.Add("NOW WORKING");

                foreach (var p in staffs)
                {
                    dt.Rows.Add(p.MaNV, p.HoTen, p.NgaySinh.Value.ToString("dd/MM/yyyy"), p.Phai, p.SDT, p.DiaChi, p.Luong, p.PhongBan, p.NowWorking);
                }
                return dt;
            }
        }
        public bool AddNewEmployee(string MANV,string HOTEN,DateTime BIRTHDAY,string SEX,string PHONE,string ADDRESS,string SALARY,string DEPARTMENT,string NOW,ref string err)
        {
            QLNVEntities qlnv = new QLNVEntities();

            STAFF st = new STAFF();
            st.MaNV = MANV;
            st.HoTen = HOTEN;
            st.NgaySinh = BIRTHDAY;
            st.Phai = SEX;
            st.SDT = PHONE;
            st.DiaChi = ADDRESS;
            st.Luong = SALARY;
            st.PhongBan = DEPARTMENT;
            st.NowWorking = NOW;
            qlnv.STAFFS.Add(st);
            qlnv.SaveChanges();

            return true;
        }
        public bool UpdateEmp(Paramater_Emps EMPS)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var emps = (from staffs in qlnv.STAFFS where staffs.MaNV == EMPS.MANV  select staffs).SingleOrDefault();

            if (emps != null)
            {
                emps.HoTen = EMPS.HOTEN;
                emps.NgaySinh = EMPS.NGAYSINH;
                emps.Phai = EMPS.SEX;
                emps.SDT = EMPS.PHONE;
                emps.DiaChi = EMPS.ADDRESS;
                emps.Luong = EMPS.SALARY;
                emps.PhongBan = EMPS.DEP;
                emps.NowWorking = EMPS.NOW;
                qlnv.SaveChanges();
            }
            return true;
        }
		public bool ChangeNowWorkingToNo(string MANV,string NOWWORKING)
		{
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.STAFFS where p.MaNV == MANV select p;
            
            foreach(var p in temp)
            {
                p.NowWorking = NOWWORKING;
            }
            
            qlnv.SaveChanges();
            return true;
        }
        #endregion
        #region FindStaff,LoadListEmpOfPerDept,AutoAddNewId,CreateAcc,UpdatePosition
        public bool UpdatePosition(string MANV,string newPosition)
        {
            QLNVEntities QLNV = new QLNVEntities();
            var temp = (from p in QLNV.TaiKhoans where p.MaNV == MANV select p).SingleOrDefault();

            if(temp!=null)
            {
                temp.ChucVu = newPosition;

                QLNV.SaveChanges();
            }
            return true;
        }
        public string FindStaff(string empID) //tìm nhân viên theo mã 
        {
            QLNVEntities qlnv = new QLNVEntities();
            var femps = (from emps in qlnv.STAFFS where emps.MaNV==empID select emps);

            string str="";
            foreach(var emps in femps)
            {
                str = emps.HoTen;
            }
            return str;
        }
        public DataTable LoadListEmpOfPerDept(string DeptId)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var lstEmpDept = from lst in qlnv.STAFFS where lst.PhongBan == DeptId select lst;

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("FULL NAME");
            dt.Columns.Add("BIRTHDATE");
            dt.Columns.Add("SEX");
            dt.Columns.Add("PHONE");
            dt.Columns.Add("ADDRESS");
            dt.Columns.Add("SALARY");
            dt.Columns.Add("DEPARTMENT");
            dt.Columns.Add("NOW WORKING");

            foreach (var p in lstEmpDept)
            {
                dt.Rows.Add(p.MaNV, p.HoTen, p.NgaySinh.Value.ToString("dd/MM/yyyy"), p.Phai, p.SDT, p.DiaChi, p.Luong, p.PhongBan, p.NowWorking);
            }
            return dt;
        }
        public int AutoAddNewId()
        {
            int newId= 1;
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.STAFFS select p;

            foreach(var p in temp)
            {
                newId += 1;
            }
            return newId;   //trả về mã số nhân viên tiếp theo
        }
        public bool CreateAccount(string MANV,string Pass,string Position)
        {
            QLNVEntities qlnv = new QLNVEntities();
            TaiKhoan tk = new TaiKhoan();

            tk.MaNV = MANV;
            tk.Pass = Pass;
            tk.ChucVu = Position;
            qlnv.TaiKhoans.Add(tk);
            qlnv.SaveChanges();

            return true;
        }
        #endregion
        #region For frmChamCong
        public string Password(string Pass)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var pass = from p in qlnv.TaiKhoans where p.Pass == Pass select p;

            string Passw = "";
            foreach (var p in pass)
            {
                Passw = p.Pass;
            }
            return Passw;
        }
        public string ID(string EMPID)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var id = from p in qlnv.STAFFS where p.MaNV == EMPID select p;

            string Id = "";
            foreach (var p in id)
            {
                Id = p.MaNV;
            }
            return Id;
        }
        public string FULLNAME(string EMPID)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var fname = from p in qlnv.STAFFS where p.MaNV == EMPID select p;

            string fullname = "";
            foreach (var p in fname)
            {
                fullname = p.HoTen;
            }
            return fullname;
        }
        public DateTime BIRTHDAY(string EMPID)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var bday = from p in qlnv.STAFFS where p.MaNV == EMPID select p;

            DateTime birthday=new DateTime();
            foreach (var p in bday)
            {
                birthday = p.NgaySinh.Value;
                
            }
            return birthday;
        }

        public string ADDRESS(string EMPID)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var add = from p in qlnv.STAFFS where p.MaNV == EMPID select p;

            string address = "";
            foreach (var p in add)
            {
                address = p.DiaChi;
            }
            return address;
        }
        public string PHONE(string EMPID)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var phone = from p in qlnv.STAFFS where p.MaNV == EMPID select p;

            string Phone = "";
            foreach (var p in phone)
            {
                Phone = p.SDT;
            }
            return Phone;
        }
        public bool EditInFormChamCong(string ID,string NAME,DateTime BIRTHDAY,string ADDRESS,string PHONE)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = (from p in qlnv.STAFFS where p.MaNV == ID select p).SingleOrDefault();

            if(temp!=null)
            {
                temp.HoTen = NAME;
                temp.NgaySinh = BIRTHDAY;
                temp.DiaChi = ADDRESS;
                temp.SDT = PHONE;

                qlnv.SaveChanges();
            }
            return true;
        }
        #endregion
    }
}
