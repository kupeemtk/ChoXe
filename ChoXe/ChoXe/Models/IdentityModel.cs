using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoXe.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(255)]
        public string Address { get; set; }
        public bool Sex { get; set; }
        public DateTime? birthday { get; set; }
        public string Avatar { get; set; }
        public int? credit { get; set; }
    }
   
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
         : base("Data Source =choxe123.database.windows.net; Initial Catalog = choxe123; Persist Security Info=True;User ID = phungnguyen; Password=Hoaiphung1234;MultipleActiveResultSets=True")
        //: base("Data Source =DESKTOP-ER13Q4F\\SQLEXPRESS; Initial Catalog = choxe; Persist Security Info=True;User ID = sa; Password=1234;MultipleActiveResultSets=True")
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}