namespace ChoXe.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            PostLikes = new HashSet<PostLike>();
        }

        [Key]
        public int IDPost { get; set; }

        public int? Xe { get; set; }

        [StringLength(10)]
        public string LoaiTin { get; set; }

        public DateTime? NgayDang { get; set; }

        public DateTime? HetHan { get; set; }

        [StringLength(50)]
        public string TieuDe { get; set; }

        [StringLength(128)]
        public string UserDangTin { get; set; }

        public int? LuotXem { get; set; }

        public bool? IsSuccess { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Xe Xe1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostLike> PostLikes { get; set; }
    }
}
