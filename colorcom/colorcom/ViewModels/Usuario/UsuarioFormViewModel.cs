using colorcom.Models.Usuario;
using System.Collections.Generic;

namespace colorcom.ViewModels.Usuario
{
    public class UsuarioFormViewModel
    {
        public IEnumerable<tipoUsuario> tiposUsuarios { get; set; }
        public usuario usuario { get; set; }

        public string title
        {
            get
            {
                if (usuario != null && usuario.us_cod != 0)
                {
                    return "Editar Usuário";
                }
                return "Novo Usuário";
            }
        }
    }
}