using colorcom.DAL;
using colorcom.Models.Estoque;
using System;
using System.Linq;
using System.Web.Mvc;

namespace colorcom.Controllers.Item
{
    public class MovimentoEstoqueController : Controller
    {
        public MovimentoEstoqueController()
        {
            _context = new colorcomContext();
        }

        private colorcomContext db = new colorcomContext();

        private colorcomContext _context;

        // Get: Estoque
        public ActionResult Index()
        {
            var estoques = _context.movimentosEstoque.ToList();
            return View(estoques);
        }

        // Save: Estoque
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(movimentoEstoque estoque)
        {
            _context.movimentosEstoque.Add(estoque);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index", "Estoque");
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