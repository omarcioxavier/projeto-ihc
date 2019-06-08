using colorcom.DAL;
using colorcom.Models.NotaFiscal;
using colorcom.ViewModels.Item;
using System;
using System.Linq;
using System.Web.Mvc;

namespace colorcom.Controllers.NotaFiscal
{
    public class SaidaNFController : Controller
    {

        public SaidaNFController()
        {
            _context = new colorcomContext();
        }

        private colorcomContext db = new colorcomContext();

        private colorcomContext _context;

        // GET: SaidaNF
        public ActionResult Index()
        {
            var saidaNF = _context.saidasNF.ToList();
            return View(saidaNF);
        }

        // Get: SaidaNF/id
        public ActionResult Details(int? id)
        {
            var saidaNF = _context.saidasNF
                .SingleOrDefault(s => s.sn_cod == id);

            if (saidaNF == null)
            {
                return HttpNotFound();
            }
            return View(saidaNF);
        }

        // Saida: SaidaNF
        public ActionResult New()
        {
            var viewModel = new SaidaNFFormViewModel()
            {
                saidaNF = new saidaNF()
            };
            return View("SaidaNFForm", viewModel);
        }

        // Edit: SaidaNF/id
        public ActionResult Edit(int id)
        {
            var saidaNF = _context.saidasNF.SingleOrDefault(s => s.sn_cod == id);

            if (saidaNF == null)
            {
                return HttpNotFound();
            }
            var viewModel = new SaidaNFFormViewModel
            {
                saidaNF = saidaNF
            };

            return View("SaidaNFForm", viewModel);
        }

        // Save: SaidaNF
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(saidaNF saidaNF)
        {
            _context.saidasNF.Add(saidaNF);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("New", "EntradaNF");
            }

            return RedirectToAction("Index", "EntradaNF");
        }

        // Inativate: EntradaNF
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inativar(saidaNF saidaNF)
        {
            var saidaNFExistente = _context.saidasNF.Single(e => e.sn_cod == saidaNF.sn_cod);

            saidaNFExistente.sn_status = saidaNF.sn_status;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("New", "Item");
            }

            return RedirectToAction("Index", "Item");
        }
    }
}