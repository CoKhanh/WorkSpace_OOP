using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace qlnv.Layers
{
    class CDEPARTMENT
    {
        public DataTable LoadDepartmentInfo()
        {
            QLNVEntities qlnv = new QLNVEntities();
            var dep = from p in qlnv.PHONGBANs select p;
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Department's Id");
            dt.Columns.Add("Department's name");
            dt.Columns.Add("Manager's Id");
            dt.Columns.Add("Manager's Name");
            
            //dt.Columns[0].
            foreach (var p in dep)
            {
                dt.Rows.Add(p.MaPB, p.TenPB, p.TruongPhong,p.TenTrPhong);
            }
            return dt;
        }
        public bool AddDept(string MAPB,string TENPB,string MANAGERID,string MANAGERNAME)
        {
            QLNVEntities qlnv = new QLNVEntities();
            PHONGBAN pb = new PHONGBAN();

            pb.MaPB = MAPB;
            pb.TenPB = TENPB;
            pb.TruongPhong = MANAGERID;
            pb.TenTrPhong = MANAGERNAME;

            qlnv.PHONGBANs.Add(pb);
            qlnv.SaveChanges();

            return true;
        }
        public bool UpdateDept(Paramater_Dept DEPT)
        {
            QLNVEntities qlnv = new QLNVEntities();
            var dept = (from depts in qlnv.PHONGBANs where depts.MaPB == DEPT.MAPB select depts).SingleOrDefault();

            if(dept!=null)
            {
                dept.TenPB = DEPT.TENPB;
                dept.TruongPhong = DEPT.MATRPHONG;
                dept.TenTrPhong = DEPT.TENTRPHONG;

                qlnv.SaveChanges();
            }
            return true;
        }
        
    }
}
