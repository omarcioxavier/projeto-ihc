using colorcom.DAL;
using colorcom.Models.Pedidos;
using colorcom.ViewModels.Item;
using colorcom.ViewModels.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace colorcom.Controllers.Pedido
{
    public class ItemPedidoController : Controller
    {
        public ItemPedidoController()
        {
            _context = new colorcomContext();
        }

        private colorcomContext db = new colorcomContext();

        private colorcomContext _context;

        public ActionResult New()
        {
            var itens = _context.itens.ToList();
            var viewModel = new ItemPedidoFormViewModel()
            {
                itens = itens,
                itemPedido = new itemPedido(),
            };
            return View("ItemPedidoForm", viewModel);
        }

        public ActionResult GetPrecoItemById(int itemID)
        {
            return Json(db.itens.Where(i => i.it_cod == itemID).Select(i => new
            {
                Codigo = i.it_cod,
                Nome = i.it_descricao,
                Preco = i.it_preco_venda
            }).ToList(), JsonRequestBehavior.AllowGet);
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