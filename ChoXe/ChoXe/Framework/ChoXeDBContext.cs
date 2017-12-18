namespace ChoXe.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ChoXeDBContext : DbContext
    {
        public ChoXeDBContext()
           // : base("Data Source =DESKTOP-ER13Q4F\\SQLEXPRESS; Initial Catalog = choxe; Persist Security Info=True;User ID = sa; Password=1234;MultipleActiveResultSets=True")
           : base("Data Source =choxe123.database.windows.net; Initial Catalog = choxe123; Persist Security Info=True;User ID = phungnguyen; Password=Hoaiphung1234;MultipleActiveResultSets=True")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<HangXe> HangXes { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostLike> PostLikes { get; set; }
        public virtual DbSet<Xe> Xes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Posts)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserDangTin);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.PostLikes)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangXe>()
                .Property(e => e.IDHangXe)
                .IsUnicode(false);


            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostLikes)
                .WithRequired(e => e.Post)
                .HasForeignKey(e => e.PostID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Xe>()
                .Property(e => e.LoaiXe)
                .IsUnicode(false);

            modelBuilder.Entity<Xe>()
                .Property(e => e.HangXe)
                .IsUnicode(false);

            modelBuilder.Entity<Xe>()
                .Property(e => e.AnhXe)
                .IsUnicode(false);

            modelBuilder.Entity<Xe>()
                .HasMany(e => e.Posts)
                .WithOptional(e => e.Xe1)
                .HasForeignKey(e => e.Xe);
        }
    }
}
