﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace qlnv
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QLNVEntities : DbContext
    {
        public QLNVEntities()
            : base("name=QLNVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CHAMCONG> CHAMCONGs { get; set; }
        public virtual DbSet<DangNhap> DangNhaps { get; set; }
        public virtual DbSet<DUAN> DUANs { get; set; }
        public virtual DbSet<PHANCONG> PHANCONGs { get; set; }
        public virtual DbSet<PHONGBAN> PHONGBANs { get; set; }
        public virtual DbSet<STAFF> STAFFS { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TinhLuong> TinhLuongs { get; set; }
    
        public virtual int AssignEmp(string maDA, string maNV, string tenNV)
        {
            var maDAParameter = maDA != null ?
                new ObjectParameter("MaDA", maDA) :
                new ObjectParameter("MaDA", typeof(string));
    
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var tenNVParameter = tenNV != null ?
                new ObjectParameter("TenNV", tenNV) :
                new ObjectParameter("TenNV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AssignEmp", maDAParameter, maNVParameter, tenNVParameter);
        }
    
        public virtual int CC_Check(string maNV, Nullable<System.DateTime> ngayThang, ObjectParameter @return)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var ngayThangParameter = ngayThang.HasValue ?
                new ObjectParameter("NgayThang", ngayThang) :
                new ObjectParameter("NgayThang", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CC_Check", maNVParameter, ngayThangParameter, @return);
        }
    
        public virtual int CC_edit_info(string maNV, string hoTen, Nullable<System.DateTime> ngaySinh, string diaChi, string sDT)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("HoTen", hoTen) :
                new ObjectParameter("HoTen", typeof(string));
    
            var ngaySinhParameter = ngaySinh.HasValue ?
                new ObjectParameter("NgaySinh", ngaySinh) :
                new ObjectParameter("NgaySinh", typeof(System.DateTime));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var sDTParameter = sDT != null ?
                new ObjectParameter("SDT", sDT) :
                new ObjectParameter("SDT", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CC_edit_info", maNVParameter, hoTenParameter, ngaySinhParameter, diaChiParameter, sDTParameter);
        }
    
        public virtual int CC_InsertCC(string maNV, string hoTen, Nullable<System.DateTime> ngayThang, Nullable<System.TimeSpan> checkIn, string thang)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("HoTen", hoTen) :
                new ObjectParameter("HoTen", typeof(string));
    
            var ngayThangParameter = ngayThang.HasValue ?
                new ObjectParameter("NgayThang", ngayThang) :
                new ObjectParameter("NgayThang", typeof(System.DateTime));
    
            var checkInParameter = checkIn.HasValue ?
                new ObjectParameter("CheckIn", checkIn) :
                new ObjectParameter("CheckIn", typeof(System.TimeSpan));
    
            var thangParameter = thang != null ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CC_InsertCC", maNVParameter, hoTenParameter, ngayThangParameter, checkInParameter, thangParameter);
        }
    
        public virtual int CC_InsertRaVe(string maNV, Nullable<System.DateTime> ngayThang, string checkOut)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var ngayThangParameter = ngayThang.HasValue ?
                new ObjectParameter("NgayThang", ngayThang) :
                new ObjectParameter("NgayThang", typeof(System.DateTime));
    
            var checkOutParameter = checkOut != null ?
                new ObjectParameter("CheckOut", checkOut) :
                new ObjectParameter("CheckOut", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CC_InsertRaVe", maNVParameter, ngayThangParameter, checkOutParameter);
        }
    
        public virtual ObjectResult<CC_load_bangCC_Result> CC_load_bangCC(string maNV, string thang)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var thangParameter = thang != null ?
                new ObjectParameter("Thang", thang) :
                new ObjectParameter("Thang", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CC_load_bangCC_Result>("CC_load_bangCC", maNVParameter, thangParameter);
        }
    
        public virtual ObjectResult<CC_Load_Emp_Result> CC_Load_Emp(string maNV)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CC_Load_Emp_Result>("CC_Load_Emp", maNVParameter);
        }
    
        public virtual ObjectResult<CC_load_ID_Result> CC_load_ID(string maNV)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CC_load_ID_Result>("CC_load_ID", maNVParameter);
        }
    
        public virtual ObjectResult<CC_Salary_Result> CC_Salary(string maNV, string ngayThang)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var ngayThangParameter = ngayThang != null ?
                new ObjectParameter("NgayThang", ngayThang) :
                new ObjectParameter("NgayThang", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CC_Salary_Result>("CC_Salary", maNVParameter, ngayThangParameter);
        }
    
        public virtual int CC_Sua_MK(string maNV, string pass)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("Pass", pass) :
                new ObjectParameter("Pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CC_Sua_MK", maNVParameter, passParameter);
        }
    
        public virtual int CheckID(string maNV, ObjectParameter @return)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CheckID", maNVParameter, @return);
        }
    
        public virtual int CheckMaNV(string maNV)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CheckMaNV", maNVParameter);
        }
    
        public virtual int Delete_Staff(string maNV)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Delete_Staff", maNVParameter);
        }
    
        public virtual int DeleteEmpInPro(string maDA, string maNV)
        {
            var maDAParameter = maDA != null ?
                new ObjectParameter("MaDA", maDA) :
                new ObjectParameter("MaDA", typeof(string));
    
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteEmpInPro", maDAParameter, maNVParameter);
        }
    
        public virtual int Edit_Project(string maDA, string tenDA, string phong, string kinhPhi, string dangTienHanh)
        {
            var maDAParameter = maDA != null ?
                new ObjectParameter("MaDA", maDA) :
                new ObjectParameter("MaDA", typeof(string));
    
            var tenDAParameter = tenDA != null ?
                new ObjectParameter("TenDA", tenDA) :
                new ObjectParameter("TenDA", typeof(string));
    
            var phongParameter = phong != null ?
                new ObjectParameter("Phong", phong) :
                new ObjectParameter("Phong", typeof(string));
    
            var kinhPhiParameter = kinhPhi != null ?
                new ObjectParameter("KinhPhi", kinhPhi) :
                new ObjectParameter("KinhPhi", typeof(string));
    
            var dangTienHanhParameter = dangTienHanh != null ?
                new ObjectParameter("DangTienHanh", dangTienHanh) :
                new ObjectParameter("DangTienHanh", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Edit_Project", maDAParameter, tenDAParameter, phongParameter, kinhPhiParameter, dangTienHanhParameter);
        }
    
        public virtual int EditDept(string maPB, string tenPB, string truongPhong, string tenTrPhong)
        {
            var maPBParameter = maPB != null ?
                new ObjectParameter("MaPB", maPB) :
                new ObjectParameter("MaPB", typeof(string));
    
            var tenPBParameter = tenPB != null ?
                new ObjectParameter("TenPB", tenPB) :
                new ObjectParameter("TenPB", typeof(string));
    
            var truongPhongParameter = truongPhong != null ?
                new ObjectParameter("TruongPhong", truongPhong) :
                new ObjectParameter("TruongPhong", typeof(string));
    
            var tenTrPhongParameter = tenTrPhong != null ?
                new ObjectParameter("TenTrPhong", tenTrPhong) :
                new ObjectParameter("TenTrPhong", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditDept", maPBParameter, tenPBParameter, truongPhongParameter, tenTrPhongParameter);
        }
    
        public virtual int editStaff(string maNV, string hoTen, Nullable<System.DateTime> ngaySinh, string phai, string sDT, string diaChi, string luong, string phongBan, string nowWorking)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("HoTen", hoTen) :
                new ObjectParameter("HoTen", typeof(string));
    
            var ngaySinhParameter = ngaySinh.HasValue ?
                new ObjectParameter("NgaySinh", ngaySinh) :
                new ObjectParameter("NgaySinh", typeof(System.DateTime));
    
            var phaiParameter = phai != null ?
                new ObjectParameter("Phai", phai) :
                new ObjectParameter("Phai", typeof(string));
    
            var sDTParameter = sDT != null ?
                new ObjectParameter("SDT", sDT) :
                new ObjectParameter("SDT", typeof(string));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var luongParameter = luong != null ?
                new ObjectParameter("Luong", luong) :
                new ObjectParameter("Luong", typeof(string));
    
            var phongBanParameter = phongBan != null ?
                new ObjectParameter("PhongBan", phongBan) :
                new ObjectParameter("PhongBan", typeof(string));
    
            var nowWorkingParameter = nowWorking != null ?
                new ObjectParameter("NowWorking", nowWorking) :
                new ObjectParameter("NowWorking", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("editStaff", maNVParameter, hoTenParameter, ngaySinhParameter, phaiParameter, sDTParameter, diaChiParameter, luongParameter, phongBanParameter, nowWorkingParameter);
        }
    
        public virtual ObjectResult<string> FindDept(string maPB)
        {
            var maPBParameter = maPB != null ?
                new ObjectParameter("MaPB", maPB) :
                new ObjectParameter("MaPB", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("FindDept", maPBParameter);
        }
    
        public virtual ObjectResult<FindProject_Result> FindProject(string tenDA)
        {
            var tenDAParameter = tenDA != null ?
                new ObjectParameter("TenDA", tenDA) :
                new ObjectParameter("TenDA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FindProject_Result>("FindProject", tenDAParameter);
        }
    
        public virtual ObjectResult<string> FindStaff(string maNV)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("FindStaff", maNVParameter);
        }
    
        public virtual int Hide_staff(string nowWorking, string maNV)
        {
            var nowWorkingParameter = nowWorking != null ?
                new ObjectParameter("NowWorking", nowWorking) :
                new ObjectParameter("NowWorking", typeof(string));
    
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Hide_staff", nowWorkingParameter, maNVParameter);
        }
    
        public virtual int Insert_Proj(string maDA, string tenDA, string phong, string kinhPhi, string dangTienHanh)
        {
            var maDAParameter = maDA != null ?
                new ObjectParameter("MaDA", maDA) :
                new ObjectParameter("MaDA", typeof(string));
    
            var tenDAParameter = tenDA != null ?
                new ObjectParameter("TenDA", tenDA) :
                new ObjectParameter("TenDA", typeof(string));
    
            var phongParameter = phong != null ?
                new ObjectParameter("Phong", phong) :
                new ObjectParameter("Phong", typeof(string));
    
            var kinhPhiParameter = kinhPhi != null ?
                new ObjectParameter("KinhPhi", kinhPhi) :
                new ObjectParameter("KinhPhi", typeof(string));
    
            var dangTienHanhParameter = dangTienHanh != null ?
                new ObjectParameter("DangTienHanh", dangTienHanh) :
                new ObjectParameter("DangTienHanh", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Proj", maDAParameter, tenDAParameter, phongParameter, kinhPhiParameter, dangTienHanhParameter);
        }
    
        public virtual int InsertDept(string maPB, string tenPB, string truongPhong, string tenTrPhong)
        {
            var maPBParameter = maPB != null ?
                new ObjectParameter("MaPB", maPB) :
                new ObjectParameter("MaPB", typeof(string));
    
            var tenPBParameter = tenPB != null ?
                new ObjectParameter("TenPB", tenPB) :
                new ObjectParameter("TenPB", typeof(string));
    
            var truongPhongParameter = truongPhong != null ?
                new ObjectParameter("TruongPhong", truongPhong) :
                new ObjectParameter("TruongPhong", typeof(string));
    
            var tenTrPhongParameter = tenTrPhong != null ?
                new ObjectParameter("TenTrPhong", tenTrPhong) :
                new ObjectParameter("TenTrPhong", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertDept", maPBParameter, tenPBParameter, truongPhongParameter, tenTrPhongParameter);
        }
    
        public virtual int insertStaff(string maNV, string hoTen, Nullable<System.DateTime> ngaySinh, string phai, string sDT, string diaChi, string luong, string phongBan, string nowWorking)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("HoTen", hoTen) :
                new ObjectParameter("HoTen", typeof(string));
    
            var ngaySinhParameter = ngaySinh.HasValue ?
                new ObjectParameter("NgaySinh", ngaySinh) :
                new ObjectParameter("NgaySinh", typeof(System.DateTime));
    
            var phaiParameter = phai != null ?
                new ObjectParameter("Phai", phai) :
                new ObjectParameter("Phai", typeof(string));
    
            var sDTParameter = sDT != null ?
                new ObjectParameter("SDT", sDT) :
                new ObjectParameter("SDT", typeof(string));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var luongParameter = luong != null ?
                new ObjectParameter("Luong", luong) :
                new ObjectParameter("Luong", typeof(string));
    
            var phongBanParameter = phongBan != null ?
                new ObjectParameter("PhongBan", phongBan) :
                new ObjectParameter("PhongBan", typeof(string));
    
            var nowWorkingParameter = nowWorking != null ?
                new ObjectParameter("NowWorking", nowWorking) :
                new ObjectParameter("NowWorking", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertStaff", maNVParameter, hoTenParameter, ngaySinhParameter, phaiParameter, sDTParameter, diaChiParameter, luongParameter, phongBanParameter, nowWorkingParameter);
        }
    
        public virtual ObjectResult<Load_Dept_Result> Load_Dept()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Load_Dept_Result>("Load_Dept");
        }
    
        public virtual ObjectResult<Load_Emp_Grby_Dept_Result> Load_Emp_Grby_Dept(string maPB)
        {
            var maPBParameter = maPB != null ?
                new ObjectParameter("MaPB", maPB) :
                new ObjectParameter("MaPB", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Load_Emp_Grby_Dept_Result>("Load_Emp_Grby_Dept", maPBParameter);
        }
    
        public virtual ObjectResult<Load_Employee_Result> Load_Employee()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Load_Employee_Result>("Load_Employee");
        }
    
        public virtual ObjectResult<Load_Project_Result> Load_Project()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Load_Project_Result>("Load_Project");
        }
    
        public virtual ObjectResult<LoadEmpProject_Result> LoadEmpProject(string maDA)
        {
            var maDAParameter = maDA != null ?
                new ObjectParameter("MaDA", maDA) :
                new ObjectParameter("MaDA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LoadEmpProject_Result>("LoadEmpProject", maDAParameter);
        }
    
        public virtual int Login(string maNV, string password, ObjectParameter chucVu)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Login", maNVParameter, passwordParameter, chucVu);
        }
    
        public virtual ObjectResult<string> ProFindEmpName(string maNV, string maDA)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var maDAParameter = maDA != null ?
                new ObjectParameter("MaDA", maDA) :
                new ObjectParameter("MaDA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("ProFindEmpName", maNVParameter, maDAParameter);
        }
    
        public virtual int Salary_Insert(string thangNam, string maNV, string soNgayDiLam, string soNgayNghi, string soNgayDiTre, string tienPhat, string duAnThamGia, string tienThuong, string luongCoBan, string tongLuong)
        {
            var thangNamParameter = thangNam != null ?
                new ObjectParameter("ThangNam", thangNam) :
                new ObjectParameter("ThangNam", typeof(string));
    
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var soNgayDiLamParameter = soNgayDiLam != null ?
                new ObjectParameter("SoNgayDiLam", soNgayDiLam) :
                new ObjectParameter("SoNgayDiLam", typeof(string));
    
            var soNgayNghiParameter = soNgayNghi != null ?
                new ObjectParameter("SoNgayNghi", soNgayNghi) :
                new ObjectParameter("SoNgayNghi", typeof(string));
    
            var soNgayDiTreParameter = soNgayDiTre != null ?
                new ObjectParameter("SoNgayDiTre", soNgayDiTre) :
                new ObjectParameter("SoNgayDiTre", typeof(string));
    
            var tienPhatParameter = tienPhat != null ?
                new ObjectParameter("TienPhat", tienPhat) :
                new ObjectParameter("TienPhat", typeof(string));
    
            var duAnThamGiaParameter = duAnThamGia != null ?
                new ObjectParameter("DuAnThamGia", duAnThamGia) :
                new ObjectParameter("DuAnThamGia", typeof(string));
    
            var tienThuongParameter = tienThuong != null ?
                new ObjectParameter("TienThuong", tienThuong) :
                new ObjectParameter("TienThuong", typeof(string));
    
            var luongCoBanParameter = luongCoBan != null ?
                new ObjectParameter("LuongCoBan", luongCoBan) :
                new ObjectParameter("LuongCoBan", typeof(string));
    
            var tongLuongParameter = tongLuong != null ?
                new ObjectParameter("TongLuong", tongLuong) :
                new ObjectParameter("TongLuong", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Salary_Insert", thangNamParameter, maNVParameter, soNgayDiLamParameter, soNgayNghiParameter, soNgayDiTreParameter, tienPhatParameter, duAnThamGiaParameter, tienThuongParameter, luongCoBanParameter, tongLuongParameter);
        }
    
        public virtual ObjectResult<Search_employee_Result> Search_employee(string hoten)
        {
            var hotenParameter = hoten != null ?
                new ObjectParameter("Hoten", hoten) :
                new ObjectParameter("Hoten", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Search_employee_Result>("Search_employee", hotenParameter);
        }
    
        public virtual int SignUp(string maNV, string pass, string chucVu)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("Pass", pass) :
                new ObjectParameter("Pass", typeof(string));
    
            var chucVuParameter = chucVu != null ?
                new ObjectParameter("ChucVu", chucVu) :
                new ObjectParameter("ChucVu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SignUp", maNVParameter, passParameter, chucVuParameter);
        }
    }
}
