//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class DUAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DUAN()
        {
            this.PHANCONGs = new HashSet<PHANCONG>();
        }
    
        public string MaDA { get; set; }
        public string TenDA { get; set; }
        public string Phong { get; set; }
        public string KinhPhi { get; set; }
        public string DangTienHanh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONG> PHANCONGs { get; set; }
    }
}
