using colorcom.Models.Emitente;
using colorcom.Models.Usuario;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colorcom.Models.Pedidos
{
    [Table("pedido")]
    public class pedido
    {
        [Key]
        public int pe_cod { get; set; }

        public float pe_valor { get; set; }

        public DateTime pe_dataHora { get; set; }

        public int pe_us_cod { get; set; }

        public int pe_em_cod { get; set; }

        public int pe_ip_cod { get; set; }

        [ForeignKey("pe_us_cod")]
        public virtual usuario usuario { get; set; }

        [ForeignKey("pe_em_cod")]
        public virtual emitente emitente { get; set; }

        [ForeignKey("pe_ip_cod")]
        public virtual itensPedido itensPedido { get; set; }
    }
}