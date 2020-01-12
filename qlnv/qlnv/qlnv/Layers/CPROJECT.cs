using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace qlnv.Layers
{
    class CPROJECT
    {
        #region Load,Update,Delete Project
        //public List LoadProName()
        //{
        //    QLNVEntities qlnv = new QLNVEntities();
        //    var temp = from p in qlnv.DUANs select p.TenDA;
        //    List<string> str = new List<string>();
            
        //    foreach (var p in temp)
        //    {
        //        str += p;
        //    }
        //    return str;
        //}
        public DataTable LoadProjectInfo()
        {
            QLNVEntities projectEntities = new QLNVEntities();
            var pro = from p in projectEntities.DUANs where p.MaDA!= "NEWBIE" select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("Project Id");
            dt.Columns.Add("Project Name");
            dt.Columns.Add("Department's");
            dt.Columns.Add("Price");
            dt.Columns.Add("Progressing");

            foreach(var p in pro)
            {
                dt.Rows.Add(p.MaDA, p.TenDA, p.Phong, p.KinhPhi, p.DangTienHanh);
            }
            return dt;
        }
		public bool AddProject(string MADA,string TENDA,string DEP,string CHIPHI,string NOWINWORKING)
		{
            QLNVEntities qlnv = new QLNVEntities();
			DUAN da = new DUAN();
			da.MaDA = MADA;
			da.TenDA = TENDA;
			da.Phong = DEP;
			da.KinhPhi = CHIPHI;
			da.DangTienHanh = NOWINWORKING; ;

			qlnv.DUANs.Add(da);
			qlnv.SaveChanges();

			return true;
		}
		public bool UpdateProject(Paramater_Project PROJ)
		{
            QLNVEntities qlnv = new QLNVEntities();
			var proj =
				(from duan in qlnv.DUANs where duan.MaDA == PROJ.MADA select duan).SingleOrDefault();

			if(proj!=null)
			{
				proj.MaDA = PROJ.MADA;
				proj.TenDA = PROJ.TENDA;
				proj.Phong = PROJ.DEP;
				proj.KinhPhi = PROJ.CHIPHI;
				proj.DangTienHanh = PROJ.NOWINWORKING;

				qlnv.SaveChanges();
			}
			return true;
		}
		public bool DeleteProject(string MADA)
		{
            QLNVEntities qlnv = new QLNVEntities();
			DUAN da = new DUAN();
			da.MaDA = MADA;
			qlnv.DUANs.Attach(da);
			qlnv.DUANs.Remove(da);

			qlnv.SaveChanges();
			return true;
		}
        #endregion
        #region LoadAssignProject form
        public bool isdelete=false;
        public DataTable LoadAssign(string PROJECT,string MANV)
        {
            List<string> NV = new List<string>();
            List<string> DA = new List<string>();
            QLNVEntities qlnv = new QLNVEntities();
            
            var temp = from p in qlnv.DUANs where p.TenDA == PROJECT select p;

            string MADA = "";
            foreach(var p in temp)
            {
                MADA = p.MaDA;
            }

            var temp2 = from p in qlnv.PHANCONGs select p;

            foreach(var p in temp2)
            {
                if (p.MaDA == MADA)
                    NV.Add(p.MaNV);
            }
            
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("FULL NAME");
            dt.Columns.Add("BIRTHDATE");
            dt.Columns.Add("SEX");
            dt.Columns.Add("PHONE");
            dt.Columns.Add("ADDRESS");
            dt.Columns.Add("DEPARTMENT");
            dt.Columns.Add("NOW WORKING");
            if (isdelete == true)
            {
                var temp3 = from p in qlnv.STAFFS where p.MaNV != MANV select p;
                foreach (var p in temp3)
                {
                    for (int i = 0; i < NV.Count; i++)
                    {
                        if (p.MaNV == NV[i])
                        {
                            dt.Rows.Add(p.MaNV, p.HoTen, p.NgaySinh.Value.ToString("dd/MM/yyyy"), p.Phai, p.SDT, p.DiaChi, p.PhongBan, p.NowWorking);
                        }
                    }
                }
            }
            else
            {
                if (isdelete == false)
                {
                    var temp3 = from p in qlnv.STAFFS where p.NowWorking!="No" select p;
                    foreach (var p in temp3)
                    {
                        for (int i = 0; i < NV.Count; i++)
                        {
                            if (p.MaNV == NV[i])
                            {
                                dt.Rows.Add(p.MaNV, p.HoTen, p.NgaySinh.Value.ToString("dd/MM/yyyy"), p.Phai, p.SDT, p.DiaChi, p.PhongBan, p.NowWorking);
                            }
                        }
                    }
                }
            }
            return dt;
        }
        public bool AddNewEmpToProject(string MANV,string ProjId,string NAME)
        {
            QLNVEntities qlnv = new QLNVEntities();

            PHANCONG PC = new PHANCONG();
            PC.MaDA = ProjId;
            PC.MaNV = MANV;
            PC.TenNV = NAME;

            qlnv.PHANCONGs.Add(PC);
            qlnv.SaveChanges();
            return true;
        }
        public bool DeleteEmpFromPro(string MANV)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var temp = from p in qlnv.STAFFS where p.MaNV != MANV select p;
            return true;
        }
        #endregion
    }
}
