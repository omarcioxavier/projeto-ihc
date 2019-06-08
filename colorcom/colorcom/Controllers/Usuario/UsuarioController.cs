using colorcom.DAL;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using colorcom.Models.Usuario;
using colorcom.ViewModels.Usuario;

namespace colorcom.Controllers.Usuario
{
    public class UsuarioController : Controller
    {
        public UsuarioController()
        {
            _context = new colorcomContext();
        }

        private colorcomContext db = new colorcomContext();

        private colorcomContext _context;

        // GET: Usuario
        public ActionResult Index()
        {
            var usuarios = _context.usuarios
                .Include(u => u.tipoUsuario)
                .ToList();
            return View(_context.usuarios.ToList());
        }

        // GET: Usuario/New
        public ActionResult New()
        {
            var tipoUsuario = _context.tiposUsuarios.ToList();

            var viewModel = new UsuarioFormViewModel
            {
                tiposUsuarios = tipoUsuario
            };

            return View("UsuarioForm", viewModel);
        }

        // GET: Usuario/Edit
        public ActionResult Edit(int id)
        {
            var usuario = _context.usuarios.SingleOrDefault(u => u.us_cod == id);

            if (usuario == null)
            {
                return HttpNotFound();
            }
            var viewModel = new UsuarioFormViewModel
            {
                usuario = usuario,
                tiposUsuarios = _context.tiposUsuarios.ToList(),
            };

            return View("UsuarioForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(usuario usuario)
        {
            if (usuario.us_cod == 0)//Nova
            {
                _context.usuarios.Add(usuario);
            }
            else//Editando
            {
                var usuarioExistente = _context.usuarios.Single(c => c.us_cod == usuario.us_cod);

                usuarioExistente.us_login = usuario.us_login;
                usuarioExistente.us_senha = usuario.us_senha;
                usuarioExistente.us_status = usuario.us_status;

                usuarioExistente.us_tu_cod = usuario.us_tu_cod;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("New", "Usuario");
            }

            return RedirectToAction("Index", "Usuario");
        }

        [HttpPost, ActionName("AtivarInativar")]
        public ActionResult AtivarInativarUsuario(int id)
        {
            var usuario = _context.usuarios.Single(u => u.us_cod == id);

            if (usuario.us_status)
            {
                usuario.us_status = false;
            }
            else
            {
                usuario.us_status = true;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Usuario");
            }

            return RedirectToAction("Index", "Usuario");
        }

        // POST: Usuario/Delete/id
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            usuario usuario = db.usuarios.Find(id);
            db.usuarios.Remove(usuario);
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