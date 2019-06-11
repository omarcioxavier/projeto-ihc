using colorcom.Models.Emitente;
using colorcom.Models.Localizacao;
using colorcom.Models.Pedidos;
using colorcom.Models.Usuario;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colorcom.Models.NotaFiscal
{
    [Table("saidaNF")]
    public class saidaNF
    {
        [Key]
        public int sn_cod { get; set; }

        public DateTime sn_data { get; set; }

        public string sn_endereco { get; set; }

        public int sn_us_cod { get; set; }

        public int sn_ci_cod { get; set; }

        public int sn_em_cod { get; set; }

        public int sn_ip_cod { get; set; }

        public int sn_es_cod { get; set; }

        [ForeignKey("sn_us_cod")]
        public virtual usuario usuario { get; set; }

        [ForeignKey("sn_ci_cod")]
        public virtual cidade cidade { get; set; }

        [ForeignKey("sn_es_cod")]
        public virtual estado estado { get; set; }

        [ForeignKey("sn_em_cod")]
        public virtual emitente emitente { get; set; }

        [ForeignKey("sn_ip_cod")]
        public virtual itemPedido itemPedido { get; set; }
    }
}