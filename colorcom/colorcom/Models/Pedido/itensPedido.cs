using colorcom.Models.Item;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colorcom.Models.Pedidos
{
    [Table("itensPedido")]
    public class itensPedido
    {
        [Key]
        public int ip_cod { get; set; }

        public float ip_valor { get; set; }

        [Required]
        public string ip_descricao { get; set; }

        [Required]
        public int ip_quantidade { get; set; }

        public int ip_it_cod { get; set; }

        [ForeignKey("ip_it_cod")]
        public virtual item item { get; set; }
    }
}