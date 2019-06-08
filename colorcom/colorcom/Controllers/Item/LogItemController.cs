using colorcom.DAL;
using colorcom.Models.Item;
using System;
using System.Linq;
using System.Web.Mvc;

namespace colorcom.Controllers.Item
{
    public class LogItemController : Controller
    {
        public LogItemController()
        {
            _context = new colorcomContext();
        }

        private colorcomContext db = new colorcomContext();

        private colorcomContext _context;

        // Get: Log
        public ActionResult Index()
        {
            var logsItens = _context.logsItens.ToList();
            return View(logsItens);
        }

        // Save: Log
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Save(logItem logItem)
        {
            _context.logsItens.Add(logItem);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
            }
            //return RedirectToAction("Index", "LogItem");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}