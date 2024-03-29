﻿using colorcom.DAL;
using colorcom.Models.NotaFiscal;
using colorcom.ViewModels.Item;
using colorcom.ViewModels.NotaFiscal;
using System;
using System.Linq;
using System.Web.Mvc;

namespace colorcom.Controllers.NotaFiscal
{
    public class EntradaNFController : Controller
    {

        public EntradaNFController()
        {
            _context = new colorcomContext();
        }

        private colorcomContext db = new colorcomContext();

        private colorcomContext _context;

        // GET: EntradaNF
        public ActionResult Index()
        {
            var entradasNF = _context.entradasNF.ToList();
            return View(entradasNF);
        }

        // Get: EntradaNF/id
        public ActionResult Details(int? id)
        {
            var entradaNF = _context.entradasNF
                .SingleOrDefault(e => e.en_cod == id);

            if (entradaNF == null)
            {
                return HttpNotFound();
            }
            return View(entradaNF);
        }

        // New: EntradaNF
        public ActionResult New()
        {
            var viewModel = new EntradaNFFormViewModel()
            {
                entradaNf = new entradaNF()
            };
            return View("EntradaNFForm", viewModel);
        }

        // Edit: EntradaNF/id
        public ActionResult Edit(int id)
        {
            var entradaNF = _context.entradasNF.SingleOrDefault(e => e.en_cod == id);

            if (entradaNF == null)
            {
                return HttpNotFound();
            }
            var viewModel = new EntradaNFFormViewModel
            {
                entradaNf = entradaNF
            };

            return View("EntradaNFForm", viewModel);
        }

        // Save: EntradaNF
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(entradaNF entradaNF)
        {
            _context.entradasNF.Add(entradaNF);

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