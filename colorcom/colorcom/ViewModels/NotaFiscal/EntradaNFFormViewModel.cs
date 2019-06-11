using colorcom.Models.Emitente;
using colorcom.Models.Localizacao;
using colorcom.Models.NotaFiscal;
using colorcom.Models.Pedidos;
using colorcom.Models.Usuario;
using System.Collections.Generic;

namespace colorcom.ViewModels.Item
{
    public class EntradaNFFormViewModel
    {
        public entradaNF entradaNf { get; set; }
        public IEnumerable<estado> estados { get; set; }
        public IEnumerable<cidade> cidades { get; set; }
        public IEnumerable<itemPedido> itensPedido { get; set; }
        public IEnumerable<emitente> emitente { get; set; }
        public IEnumerable<usuario> usuarios { get; set; }

        public string title
        {
            get
            {
                if (entradaNf == null && entradaNf.en_cod == 0)
                {
                    return "Nova Entrada NF";
                }
                return null;
            }
        }
    }
}