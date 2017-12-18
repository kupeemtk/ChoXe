namespace ChoXe.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Xe")]
    public partial class Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Xe()
        {
            Posts = new HashSet<Post>();
        }

        [Key]
        public int IDXe { get; set; }

        [StringLength(50)]
        public string TenXe { get; set; }

        [StringLength(10)]
        public string LoaiXe { get; set; }

        [StringLength(5)]
        public string HangXe { get; set; }

        public byte? SoGhe { get; set; }

        [StringLength(10)]
        public string MauXe { get; set; }

        public double? Gia { get; set; }

        public byte? PhanKhoi { get; set; }

        public int? SoThangSuDung { get; set; }

        [StringLength(255)]
        public string AnhXe { get; set; }

        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
