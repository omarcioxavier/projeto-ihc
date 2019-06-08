using colorcom.DAL;
using colorcom.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace colorcom.Controllers.Pedido
{
    public class PedidoController : Controller
    {
        public PedidoController()
        {
            _context = new colorcomContext();
        }

        private colorcomContext db = new colorcomContext();

        private colorcomContext _context;

        // Get: Pedido
        public ActionResult Index()
        {
            var pedidos = _context.pedidos.ToList();
            return View(pedidos);
        }

        // Get: Item/id
        public ActionResult Details(int? id)
        {
            var pedido = _context.pedidos
                .SingleOrDefault(e => e.pe_cod == id);

            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // New: Item
        public ActionResult New()
        {
            var viewModel = new PedidoFormViewModel()
            {
                pedido = new pedido()
            };
            return View("PedidoForm", viewModel);
        }

        // Edit: Item/id
        public ActionResult Edit(int id)
        {
            var pedido = _context.pedidos.SingleOrDefault(p => p.pe_cod == id);

            if (pedido == null)
            {
                return HttpNotFound();
            }
            var viewModel = new PedidoFormViewModel
            {
                pedido = pedido
            };

            return View("PedidoForm", viewModel);
        }

        // Save: item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(pedido pedido)
        {
            if (pedido.pe_cod == 0)//Nova
            {
                _context.pedidos.Add(pedido);
            }
            else//Editando
            {
                var pedidoExistente = _context.pedidos.Single(p => p.pe_cod == pedido.pe_cod);

                pedidoExistente.pe_valor = pedido.pe_valor;
                pedidoExistente.pe_dataHora = pedido.pe_dataHora;
                pedidoExistente.pe_us_cod = pedido.pe_us_cod;
                pedidoExistente.pe_em_cod = pedido.pe_em_cod;
                pedidoExistente.pe_ip_cod = pedido.pe_ip_cod;
                pedidoExistente.pe_valor = pedido.pe_valor;

                pedidoExistente.usuario = pedido.usuario;
                pedidoExistente.emitente = pedido.emitente;
                pedidoExistente.itensPedido = pedido.itensPedido;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("New", "Pedido");
            }

            return RedirectToAction("Index", "Pedido");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            pedido pedido = db.pedidos.Find(id);
            db.pedidos.Remove(pedido);
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