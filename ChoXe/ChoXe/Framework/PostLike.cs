namespace ChoXe.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostLike")]
    public partial class PostLike
    {
        [Key]
        public int IdLike { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public int PostID { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Post Post { get; set; }
    }
}
