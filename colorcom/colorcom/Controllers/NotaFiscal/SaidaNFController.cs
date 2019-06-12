using colorcom.DAL;
using colorcom.Models.NotaFiscal;
using colorcom.ViewModels.Item;
using colorcom.ViewModels.NotaFiscal;
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
            var usuarios = _context.usuarios.ToList();
            var estados = _context.estados.ToList();
            var cidades = _context.cidades.ToList();
            var emitentes = _context.emitentes.ToList();
            var itensPedido = _context.itensPedido.ToList();
            var viewModel = new SaidaNFFormViewModel()
            {
                estados = estados,
                cidades = cidades,
                emitentes = emitentes,
                saidaNf = new saidaNF(),
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
                saidaNf = saidaNF
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
    }
}