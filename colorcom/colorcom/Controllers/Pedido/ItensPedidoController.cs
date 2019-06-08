using colorcom.DAL;
using colorcom.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace colorcom.Controllers.Pedido
{
    public class ItensPedidoController : Controller
    {
        public ItensPedidoController()
        {
            _context = new colorcomContext();
        }

        private colorcomContext db = new colorcomContext();

        private colorcomContext _context;

        // Get: Pedido
        public ActionResult Index()
        {
            var itensPedido = _context.itensPedido.ToList();
            return View(itensPedido);
        }

        // Get: Item/id
        public ActionResult Details(int? id)
        {
            var itensPedido = _context.itensPedido
                .SingleOrDefault(ip => ip.ip_cod == id);

            if (itensPedido == null)
            {
                return HttpNotFound();
            }
            return View(itensPedido);
        }

        // New: Item
        public ActionResult New()
        {
            var viewModel = new ItemPedidoFormViewModel()
            {
                pedido = new pedido()
            };
            return View("ItemPedidoForm", viewModel);
        }

        // Edit: Item/id
        public ActionResult Edit(int id)
        {
            var itensPedido = _context.itensPedido
                     .SingleOrDefault(ip => ip.ip_cod == id);

            if (itensPedido == null)
            {
                return HttpNotFound();
            }
            var viewModel = new itensPedidoFormViewModel
            {
                pedido = itensPedido
            };

            return View("ItensPedidoForm", viewModel);
        }

        // Save: item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(itensPedido itensPedido)
        {
            if (itensPedido.ip_cod == 0)//Nova
            {
                _context.itensPedido.Add(itensPedido);
            }
            else//Editando
            {
                var itensPedidoExistente = _context.itensPedido.Single(ip => ip.ip_cod == itensPedido.ip_cod);

                itensPedidoExistente.ip_valor = itensPedidoExistente.ip_valor;
                itensPedidoExistente.ip_descricao = itensPedidoExistente.ip_descricao;
                itensPedidoExistente.ip_quantidade = itensPedidoExistente.ip_quantidade;
                itensPedidoExistente.ip_it_cod = itensPedidoExistente.ip_it_cod;

                itensPedidoExistente.item = itensPedidoExistente.item;

            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("New", "ItensPedido");
            }

            return RedirectToAction("Index", "ItensPedido");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            itensPedido itensPedido = db.itensPedido.Find(id);
            db.itensPedido.Remove(itensPedido);
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