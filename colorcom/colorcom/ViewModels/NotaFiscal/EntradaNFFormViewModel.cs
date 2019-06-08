using colorcom.Models.Emitente;
using colorcom.Models.NotaFiscal;
using colorcom.Models.Usuario;
using System.Collections.Generic;

namespace colorcom.ViewModels.Item
{
    public class EntradaNFFormViewModel
    {
        public IEnumerable<usuario> usuarios { get; set; }
        public IEnumerable<emitente> emitentes { get; set; }
        public entradaNF entradaNF { get; set; }

        public string title
        {
            get
            {
                if (entradaNF == null && entradaNF.en_cod == 0)
                {
                    return "Nova Entrada NF";
                }
                return null;
            }
        }
    }
}