using System;
using System.Data;
using System.Linq;
using System.Text; //dung de chuyen ascii
using System.Data.Entity.Validation;
using System.Security.Cryptography;
using System.Data.SqlTypes;

namespace qlnv.Layers
{
    class CLogin
    {
        #region LoadTableTimeKeeping,IsLogin,ShowId,ChangePassword,
        public DataTable LoadTableTimeKeeping(string MANV)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.CHAMCONGs where p.MaNV==MANV select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("Check In");
            dt.Columns.Add("Check Out");
            dt.Columns.Add("Total time");
            foreach (var p in temp)
            {
                dt.Rows.Add(p.NgayThang.ToString("dd/MM/yyyy"), p.CheckIn , p.CheckOut,p.TG);
            }
            return dt;
        }
        public string HashPass(string password)
        {
            string Hashstr = "";
            byte[] temp= ASCIIEncoding.ASCII.GetBytes(password); //chuyen sang ma ASSCII
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp); //Ma hoa

            foreach(byte p in hashData)
            {
                Hashstr += p; //chen chuoi ma hoa vao Hashstr
            }
            return Hashstr;
        }
        public bool CheckPassWord(string MANV,string password)
        {
            bool check= false;
            QLNVEntities qlnv = new QLNVEntities();
            var temp = (from p in qlnv.TaiKhoans where p.MaNV==MANV && p.Pass == password select p).SingleOrDefault();
            
            if(temp!=null)
            {
                check = true;
                return check;
            }
            else
            {
                return check;
            }
        }
        public string LoadPositionForEdit(string MANV)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = (from p in qlnv.TaiKhoans where p.MaNV == MANV select p).SingleOrDefault();

            string Position = "";
            if(temp!=null)
            {
                Position = temp.ChucVu;
            }
            return Position;
        }
        public string SubNum(string ID)
        {
            string num = "";
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.TaiKhoans where p.MaNV == ID select p.Pass;
            
            foreach(var p in temp)
            {
                num = p;
            }
            return num.Substring(0, 4);
        }
       
        public bool IsLogin(string ID,string PASSWORD)
        {
            string subnum=SubNum(ID);
            string temp = HashPass(PASSWORD);
            string hashData = subnum + "." + temp;
            bool kq = false ;
            QLNVEntities qlnv = new QLNVEntities();
           
            //Edited
            var user = qlnv.TaiKhoans.FirstOrDefault(u => u.MaNV == ID);
            if(user!=null && this.CannotLogin(user.MaNV)==false)
            {
                if(user.Pass == hashData)
                {
                    kq = true;
                    return kq;
                }
                else
                {
                    kq = false ;
                }
            }
            return kq;
        }
        public string ShowId(string ID)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.TaiKhoans where p.MaNV== ID select p;

            string kq = "";
            foreach(var temp1 in temp)
            {
                kq = temp1.MaNV;
            }
            return kq;
        }
        public bool ChangePassword(string ID,string PASSWORD)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var emp = (from p in qlnv.TaiKhoans where p.MaNV == ID select p).SingleOrDefault();

            if(emp!=null)
            {
                emp.Pass = PASSWORD;
                qlnv.SaveChanges();
            }
            return true;
        }
        public bool CannotLogin(string MANV)
        {
            bool rs;
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.STAFFS where p.MaNV == MANV select p;

            string str = "";
            foreach (var p in temp)
            {
                str = p.NowWorking;
            }
            if (str == "No")
            {
                rs = true;
                return rs;
            }
            else
            {
                rs = false;
                return rs;
            }
        }
        #endregion
        #region CheckIn CheckOut LoadByMonth
        public string EmployeeOrManager(string MANV)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = (from p in qlnv.TaiKhoans where p.MaNV == MANV select p);

            string chucvu = "";
            foreach(var p in temp)
            {
                chucvu = p.ChucVu;
            }
            return chucvu.Trim();
        }
        public bool Checkin(string MANV,string NAME,string DateJob,string TimeCheckin,string MONTH)
        {
            QLNVEntities qlnv = new QLNVEntities();
            DateTime date = DateTime.ParseExact(DateJob,"dd/MM/yyyy", null);
            TimeSpan timeCheckin = TimeSpan.Parse(TimeCheckin);
            var temp = (from p in qlnv.CHAMCONGs where p.MaNV == MANV && p.NgayThang != null && p.CheckIn != null && p.CheckOut == null select p).FirstOrDefault();
            if (temp!=null)
            {
                temp.MaNV = temp.MaNV;
                temp.HoTen = temp.HoTen;
                temp.NgayThang = temp.NgayThang;
                temp.CheckIn = temp.CheckIn;
                temp.CheckOut = timeCheckin;
                temp.Thang = temp.Thang;

                qlnv.SaveChanges();
            }
            else
            {
                CHAMCONG cc = new CHAMCONG();
                cc.MaNV = MANV;
                cc.HoTen = NAME;
                cc.NgayThang = date;
                cc.CheckIn = timeCheckin;
                cc.Thang = MONTH;
                qlnv.CHAMCONGs.Add(cc);
                qlnv.SaveChanges();
            }
            return true;
        }
        
        public DataTable LoadByMonth(string MONTH,string MANV)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.CHAMCONGs where p.MaNV == MANV && p.Thang==MONTH select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("Check In");
            dt.Columns.Add("Check Out");
            dt.Columns.Add("Total time");
            foreach (var p in temp)
            {
                dt.Rows.Add(p.NgayThang.ToString("dd/MM/yyyy"), p.CheckIn, p.CheckOut, p.TG);
            }
            return dt;
        }
       
        #endregion
        #region Salary
        public string month;
        public string id;
        public int workingday=0;
        public int absentday;
        public int late=0;
        public int fine;//tien phat
        public int bonus;//thuong du an
        public  int proccess;//du an tham gia
        public string BasicSalary;//luong co ban
        public int Salary;//luong
        public int lateDay=0;//ngay tre

        public bool NoneCheckedIn(string MONTH,string MANV)
        {
            bool kq;
            QLNVEntities QLNV = new QLNVEntities();
            var temp = (from p in QLNV.CHAMCONGs where p.MaNV == MANV && p.Thang == MONTH select p);

            if(temp!=null)
            {
                kq = true;
                return kq;
            }
            else
            {
                kq = false;
                return kq;
            }
        }
        public string SalaryPerMonth(string MANV,string MONTH)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.TinhLuongs where p.MaNV == MANV && p.ThangNam == MONTH select p;
            string kq = "0";
            foreach(var p in temp)
            {
                kq = p.Luong;
            }
            return kq;
        }
        public DataTable SalaryByMonth(string MANV,string MONTH)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.TinhLuongs where p.MaNV == MANV && p.ThangNam == MONTH select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("Month");
            dt.Columns.Add("ID");
            dt.Columns.Add("Working day");
            dt.Columns.Add("Absent");
            dt.Columns.Add("Late");
            dt.Columns.Add("Fine");
            dt.Columns.Add("Proccess");
            dt.Columns.Add("Bonus");
            dt.Columns.Add("Base Wage");
            dt.Columns.Add("Salary");

            foreach(var p in temp)
            {
                dt.Rows.Add(p.ThangNam,p.MaNV,p.SoNgayDiLam,p.SoNgayNghi,p.SoNgayTre,p.TienPhat,p.DuAnThamGia,p.TienDuAn,p.LuongCoBan,p.Luong);
            }
            return dt;
        }
        public string Month(string MANV,string MONTH)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.CHAMCONGs where p.MaNV == MANV && p.Thang == MONTH select p;

            
            foreach(var p in temp)
            {
                month = p.Thang;
                return month;
            }
            return month;
        }
        public string ID(string MANV, string MONTH)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.CHAMCONGs where p.MaNV == MANV && p.Thang == MONTH select p;
            
            foreach (var p in temp)
            {
                id = p.MaNV;
            }
            return id;
        }
        public string WorkingDay(string MANV,string MONTH)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.CHAMCONGs
                       where p.MaNV == MANV
                       && p.Thang == MONTH
                       && p.CheckIn != null
                       && p.CheckOut != null
                       select p;

            foreach(var p in temp)
            {
                workingday += 1;
            }
            return workingday.ToString();
        }
        public string AdsentDay(string MONTH)
        {
            switch(MONTH)
            {
                case "1":
                case "3":
                case "5":
                case "7":
                case "8":
                case "10":
                case "12":
                    {
                        absentday = 31 - workingday;
                        break;
                    }
                case "4":
                case "6":
                case "9":
                case "11":
                    {
                        absentday = 30 - workingday;
                        break;
                    }
                case "2":
                    {
                        absentday = 28 - workingday;
                        break;
                    }
            }
            return absentday.ToString();
        }

        public string Tre(string MANV,string MONTH)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.CHAMCONGs where p.MaNV == MANV && p.Thang==MONTH select p;

            int lateday = 0;
            string str = "";
            foreach(var p in temp)
            {
                int k;
                str = p.CheckIn.ToString();
                k = Convert.ToInt32(str.Substring(0,2));
                if(k>7)
                {
                    lateday += 1;
                    late += (k - 7) * 50000;
                }
            }
            lateDay = lateday;
            return late.ToString();
        }
        public string Proccess(string MANV)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.PHANCONGs where p.MaNV == MANV select p;

            foreach(var p in temp)
            {
                proccess += 1;
            }
            return proccess.ToString();
        }
        public string Bonus()
        {
            bonus = 500000 * proccess;
            return bonus.ToString();
        }
        public string Basicsalary(string MANV)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.STAFFS where p.MaNV == MANV select p;

            foreach(var p in temp)
            {
                BasicSalary = p.Luong;
            }
            return BasicSalary;
        }
        public string Punishment()
        {
            fine = (absentday * 100000)+late;
            return fine.ToString();
        }
        public string SALARY()
        {
            int t = Convert.ToInt32(BasicSalary);
            Salary = t + bonus - fine;
            if (Salary <= 0)
                Salary = 0;
            return Salary.ToString();
        }
        public bool AddToSalaryTable()
        {
            QLNVEntities qlnvn = new QLNVEntities();
            TinhLuong luong = new TinhLuong();

            luong.ThangNam = month;
            luong.MaNV = id;
            luong.SoNgayDiLam = workingday.ToString();
            luong.SoNgayNghi = absentday.ToString();
            luong.SoNgayTre = lateDay.ToString();
            luong.TienPhat = fine.ToString();
            luong.DuAnThamGia = proccess.ToString();
            luong.TienDuAn = bonus.ToString();
            luong.LuongCoBan = BasicSalary;
            luong.Luong = Salary.ToString();
            try
            {
                qlnvn.TinhLuongs.Add(luong);
                qlnvn.SaveChanges();
            }
            catch(DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            return true;
        }
        public bool AddedToSalaryTable(string MANV,string MONTH)
        {
            bool rs;
            QLNVEntities qlnv = new QLNVEntities();
            var temp = (from p in qlnv.TinhLuongs where p.MaNV == MANV && p.ThangNam == MONTH select p).SingleOrDefault();

            if(temp!=null)
            {
                rs=true;
            }
            else
            {
                rs= false;
            }
            return rs;
        }
        public bool RefreshSalaryTable(string MANV,string MONTH) //dung de cap nhat lai bang luong khi bam check in
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = (from p in qlnv.TinhLuongs where p.MaNV == MANV && p.ThangNam == MONTH select p).FirstOrDefault();
            
            if (temp != null)
            {
                qlnv.TinhLuongs.Attach(temp);
                qlnv.TinhLuongs.Remove(temp);
            }
            else
            {
                if (temp == null)
                {
                    AddedToSalaryTable(MANV, MONTH);
                }
            }
            qlnv.SaveChanges();
            return true;
        }
        public int TotalSalary(string MAPB,string MONTH)
        {
            //int total = 0;
            //QLNVEntities qlnv = new QLNVEntities();
            //var temp = from p in qlnv.PHONGBANs where p.MaPB == MAPB select p;

            //foreach(var p in temp)
            //{
            //    var temp1 = from q in qlnv.STAFFS where q.PhongBan == p.MaPB select q;

            //    foreach(var q in temp1)
            //    {
            //        var temp2 = from i in qlnv.TinhLuongs where i.MaNV == q.MaNV && i.ThangNam == MONTH select i;
            //        foreach(var k in temp2)
            //        {
            //            total += Convert.ToInt32(k.Luong);
            //        }
            //    }
            //    break;
            //}
            //return total;
            int total = 0;
            QLNVEntities qlnv = new QLNVEntities();

            var temp1 = from q in qlnv.STAFFS where q.PhongBan == MAPB select q;

            foreach (var q in temp1)
            {
                var temp2 = from i in qlnv.TinhLuongs where i.MaNV == q.MaNV && i.ThangNam == MONTH select i;
                foreach (var k in temp2)
                {
                    total += Convert.ToInt32(k.Luong);
                }
            }
            if (total > 0)
                return total;
            else
                total = 0;
            return total;
        }
        #endregion
    }
}
