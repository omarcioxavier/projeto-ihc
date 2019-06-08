using colorcom.Models.Emitente;
using colorcom.Models.NotaFiscal;
using colorcom.Models.Pedidos;
using System.Collections.Generic;

namespace colorcom.ViewModels.Item
{
    public class SaidaNFFormViewModel
    {
        public IEnumerable<pedido> pedido { get; set; }
        public saidaNF saidaNF { get; set; }

        public string title
        {
            get
            {
                if (saidaNF == null && saidaNF.sn_cod == 0)
                {
                    return "Nova Entrada NF";
                }
                return null;
            }
        }
    }
}