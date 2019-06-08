using colorcom.Models.Emitente;
using colorcom.Models.Localizacao;
using colorcom.Models.Usuario;
using System.Collections.Generic;

namespace colorcom.ViewModels.Item
{
    public class EmitenteFormViewModel
    {
        public IEnumerable<cidade> cidades { get; set; }
        public IEnumerable<tipoEmitente> tiposEmitentes { get; set; }
        public emitente emitente { get; set; }

        public string title
        {
            get
            {
                if (emitente != null && emitente.em_cod != 0)
                {
                    return "Editar Cliente";
                }
                return "Novo Cliente";
            }
        }
    }
}