using colorcom.Models.Item;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colorcom.Models.Pedidos
{
    [Table("itemPedido")]
    public class itemPedido
    {
        [Key]
        public int ip_cod { get; set; }

        public float ip_valor { get; set; }

        public string ip_descricao { get; set; }

        public int ip_quantidade { get; set; }

        public int ip_it_cod { get; set; }

        [ForeignKey("ip_it_cod")]
        public virtual item item { get; set; }
    }
}