using colorcom.DAL;
using colorcom.Models.Item;
using colorcom.ViewModels.Item;
using System;
using System.Linq;
using System.Web.Mvc;

namespace colorcom.Controllers.Item
{
    public class CategoriaController : Controller
    {
        public CategoriaController()
        {
            _context = new colorcomContext();
        }

        private colorcomContext db = new colorcomContext();

        private colorcomContext _context;

        // Get: Categoria
        public ActionResult Index()
        {
            var categorias = _context.categorias.ToList();
            return View(categorias);
        }

        // New: Categoria
        public ActionResult New()
        {
            var viewModel = new CategoriaFormViewModel()
            {
                categoria = new categoria()
            };
            return View("CategoriaForm", viewModel);
        }

        // Edit: Categoria/id
        public ActionResult Edit(int id)
        {
            var categoria = _context.categorias.SingleOrDefault(i => i.ca_cod == id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CategoriaFormViewModel
            {
                categoria = categoria
            };

            return View("CategoriaForm", viewModel);
        }

        // Save: Categoria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(categoria categoria)
        {
            if (categoria.ca_cod == 0)//Nova
            {
                _context.categorias.Add(categoria);
            }
            else//Editando
            {
                var categoriaExistente = _context.categorias.Single(i => i.ca_cod == categoria.ca_cod);

                categoriaExistente.ca_descricao = categoria.ca_descricao;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("New", "Categoria");
            }

            return RedirectToAction("Index", "Categoria");
        }

        // Delete: Categoria
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            categoria categoria = db.categorias.Find(id);
            db.categorias.Remove(categoria);
            db.SaveChanges();
            return RedirectToAction("Index", "Categoria");
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