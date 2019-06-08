using colorcom.DAL;
using colorcom.Models.Item;
using colorcom.ViewModels.Item;
using System;
using System.Linq;
using System.Web.Mvc;

namespace colorcom.Controllers.Item
{
    public class ItemController : Controller
    {
        public ItemController()
        {
            _context = new colorcomContext();
        }

        private colorcomContext db = new colorcomContext();

        private colorcomContext _context;

        private LogItemController logController = new LogItemController();

        // Get: Item
        public ActionResult Index()
        {
            var itens = _context.itens.ToList();
            return View(itens);
        }

        // New: Item
        public ActionResult New()
        {
            var categorias = _context.categorias.ToList();
            var unidadesMedida = _context.unidadesMedida.ToList();
            var viewModel = new ItemFormViewModel()
            {
                categorias = categorias,
                unidadesMedida = unidadesMedida,
                item = new item()
            };
            return View("ItemForm", viewModel);
        }

        // Edit: Item/id
        public ActionResult Edit(int id)
        {
            var item = _context.itens.SingleOrDefault(i => i.it_cod == id);

            if (item == null)
            {
                return HttpNotFound();
            }
            var viewModel = new ItemFormViewModel
            {
                categorias = _context.categorias.ToList(),
                unidadesMedida = _context.unidadesMedida.ToList(),
                item = item
            };

            return View("ItemForm", viewModel);
        }

        // Save: item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(item item)
        {
            if (item.it_cod == 0)//Nova
            {
                _context.itens.Add(item);
            }
            else//Editando
            {
                var itemExistente = _context.itens.Single(i => i.it_cod == item.it_cod);

                itemExistente.it_titulo = item.it_titulo;
                itemExistente.it_descricao = item.it_descricao;
                itemExistente.it_preco_compra = item.it_preco_compra;
                itemExistente.it_ean = item.it_ean;
                itemExistente.it_preco_venda = item.it_preco_venda;
                itemExistente.it_min = item.it_min;
                itemExistente.it_max = item.it_max;
                itemExistente.it_quantidade = item.it_quantidade;
                itemExistente.it_status = item.it_status;
                itemExistente.it_ca_cod = item.it_ca_cod;
                itemExistente.it_um_cod = item.it_um_cod;

                itemExistente.it_ca_cod = item.it_ca_cod;
                itemExistente.it_um_cod = item.it_um_cod;

                SaveLog(item);

            }

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

        // Ativar/Inativar: item
        [HttpPost, ActionName("AtivarInativar")]
        public ActionResult AtivarInativarItem(int id)
        {
            var item = _context.itens.Single(i => i.it_cod == id);

            if (item.it_status)
            {
                item.it_status = false;
            }
            else
            {
                item.it_status = true;
            }

            try
            {
                SaveLog(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Item");
            }

            return RedirectToAction("Index", "Item");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            item item = db.itens.Find(id);
            db.itens.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void SaveLog(item item)
        {
            var log = new logItem()
            {
                li_dataHora = DateTime.Now,
                li_preco_novo = item.it_preco_venda,
                li_tipo = "Edição",
                li_descricao = $"Alteração do produto { item.it_titulo }. EAN { item.it_ean }",
                li_it_cod = item.it_cod
            };
            logController.Save(log);
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