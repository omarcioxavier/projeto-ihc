using colorcom.DAL;
using colorcom.Models.Emitente;
using colorcom.ViewModels.Item;
using System;
using System.Linq;
using System.Web.Mvc;

namespace colorcom.Controllers.Emitente
{
    public class EmitenteController : Controller
    {
        public EmitenteController()
        {
            _context = new colorcomContext();
        }

        private colorcomContext db = new colorcomContext();

        private colorcomContext _context;

        // GET: Emitentes
        public ActionResult Index()
        {
            var emitentes = _context.emitentes.ToList();
            return View(emitentes);
        }

        // GET: Emitente/id
        public ActionResult Details(int? id)
        {
            var emitentes = _context.emitentes.ToList();
            return View(_context.emitentes.ToList());
        }

        // New: Emitente
        public ActionResult New()
        {
            var viewModel = new EmitenteFormViewModel()
            {
                emitente = new emitente()
            };
            return View("EmitenteForm", viewModel);
        }

        // Edit: Emitente/id
        public ActionResult Edit(int id)
        {
            var emitente = _context.emitentes.SingleOrDefault(i => i.em_cod == id);

            if (emitente == null)
            {
                return HttpNotFound();
            }
            var viewModel = new EmitenteFormViewModel
            {
                emitente = emitente
            };

            return View("EmitenteForm", viewModel);
        }


        // Save: Emitente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(emitente emitente)
        {
            if (emitente.em_cod == 0)//Novo
            {
                _context.emitentes.Add(emitente);
            }
            else//Editando
            {
                var emitenteExistente = _context.emitentes.Single(e => e.em_cod == emitente.em_cod);

                emitenteExistente.em_nome = emitente.em_nome;
                emitenteExistente.em_nomeFantasia = emitente.em_nomeFantasia;
                emitenteExistente.em_documento = emitente.em_documento;
                emitenteExistente.em_endereco = emitente.em_endereco;
                emitenteExistente.em_telefone = emitente.em_telefone;
                emitenteExistente.em_celular = emitente.em_celular;
                emitenteExistente.em_email = emitente.em_email;
                emitenteExistente.em_status = emitente.em_status;
                emitenteExistente.em_inscricaoEstadual = emitente.em_inscricaoEstadual;

                emitenteExistente.em_ci_cod = emitente.em_ci_cod;
                emitenteExistente.em_te_cod = emitente.em_te_cod;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("New", "Emitente");
            }

            return RedirectToAction("Index", "Emitente");
        }

        // Delete: Emitente/id
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            emitente emitente = db.emitentes.Find(id);
            db.emitentes.Remove(emitente);
            db.SaveChanges();
            return RedirectToAction("Index");
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