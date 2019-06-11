using colorcom.Models.Emitente;
using colorcom.Models.Localizacao;
using colorcom.Models.NotaFiscal;
using colorcom.Models.Pedidos;
using colorcom.Models.Usuario;
using System.Collections.Generic;

namespace colorcom.ViewModels.Item
{
    public class SaidaNFFormViewModel
    {
        public saidaNF saidaNf { get; set; }
        public IEnumerable<estado> estados { get; set; }
        public IEnumerable<cidade> cidades { get; set; }
        public IEnumerable<itemPedido> itensPedido { get; set; }
        public IEnumerable<emitente> emitente { get; set; }
        public IEnumerable<usuario> usuarios { get; set; }

        public string title
        {
            get
            {
                if (saidaNf == null && saidaNf.sn_cod == 0)
                {
                    return "Nova Entrada NF";
                }
                return null;
            }
        }
    }
}