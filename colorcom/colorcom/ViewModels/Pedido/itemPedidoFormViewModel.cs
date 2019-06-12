using colorcom.Models.Item;
using colorcom.Models.Pedidos;
using System.Collections.Generic;

namespace colorcom.ViewModels.Pedido
{
    public class ItemPedidoFormViewModel
    {
        public IEnumerable<item> itens { get; set; }
        public itemPedido itemPedido { get; set; }
    }
}