using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoXe.Models
{
    public class ChiTietXe
    {
        
        public int IDXe { get; set; }
        public String TenXe { get; set; }
        public String LoaiXe { get; set; }
        public String HangXe { get; set; }
        public byte? SoGhe { get; set; }
        public String MauXe { get; set; }
        public double? Gia { get; set; }
        public byte? PhanKhoi { get; set; }
        public int? SoThangSuDung { get; set; }
        public String AnhXe { get; set; }

       
    }
}