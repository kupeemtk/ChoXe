using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChoXe.Models;
using ChoXe.Framework;
using PagedList;

namespace ChoXe.Controllers
{
    public class ProductController : Controller
    {
       
        ChoXeDBContext db2 = new ChoXeDBContext();
        // Trang product
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult showXeMay( int? page)
        {
            List<ShowXeMay> listxm = new List<ShowXeMay>();
            var result = (from p in db2.Posts
                          join x in db2.Xes

                          on p.Xe equals x.IDXe
                          join u in db2.AspNetUsers
                          on p.UserDangTin equals u.Id
                          where x.LoaiXe.Equals("OTO")
                          select new
                          {
                              tenXe = x.TenXe,
                              userDangTin = u.UserName,
                              gia = x.Gia,
                              id = x.IDXe
                          }).ToList();
            foreach (var i in result)
            {
                listxm.Add(new ShowXeMay()
                {
                    tenXe = i.tenXe,gia = i.gia,tenNguoiDang = i.userDangTin, IDXe = i.id
                });
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return PartialView("showXeMay",listxm.ToPagedList(pageNumber,pageSize));
        }
        //trang chi tiết sản phẩm
        [HttpGet]
        public ActionResult ProductDetail(int id)
            //using (ChoXeDBContext db = new ChoXeDBContext())
        {
            
                var xe = (from x in db2.Xes
                     where x.IDXe.Equals(id)
                     select new ChiTietXe()
                     {
                         IDXe = x.IDXe,
                         TenXe = x.TenXe,
                         LoaiXe = x.LoaiXe,
                         HangXe=x.HangXe,
                         SoGhe =x.SoGhe,
                         MauXe =x.MauXe,
                         Gia =x.Gia,
                         PhanKhoi =x.PhanKhoi,
                         SoThangSuDung =x.SoThangSuDung,
                         AnhXe = x.AnhXe
                     }).ToList();
            return View(xe);
        }
        //trang giỏ hàng
        [HttpGet]
        public ActionResult Cart()
        {
            return View();
        }
        //trang đăng tin
        [HttpGet]
        public ActionResult News()
        {
            return View();
        }

    }
}