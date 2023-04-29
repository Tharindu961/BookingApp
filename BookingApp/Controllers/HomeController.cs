using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingApp.Controllers
{
    public class HomeController : Controller
    {
        BookingAppContext _context = new BookingAppContext();
        public ActionResult Index()
        {
            var listodData = _context.Goods.ToList();
            return View(listodData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Good model)
        {
            _context.Goods.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Goods.Where(x => x.GoodsId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Good Model)
        {
            var data = _context.Goods.Where(x => x.GoodsId == Model.GoodsId).FirstOrDefault();
            if(data != null)
            {
                data.FromAdderess = Model.FromAdderess;
                data.ToAddress = Model.ToAddress;
                data.GoodsType = Model.GoodsType;
                data.Date = Model.Date;
                data.Weight = Model.Weight;
                data.Price = Model.Price;
            }
            return RedirectToAction("index");
        }

        public ActionResult Detail(int id)
        {
            var data = _context.Goods.Where(x => x.GoodsId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Goods.Where(x => x.GoodsId == id).FirstOrDefault();
            _context.Goods.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Delete Sucessfully";
            return RedirectToAction("index");
        }
    }
}