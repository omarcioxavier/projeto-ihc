using colorcom.Models.Emitente;
using colorcom.Models.Localizacao;
using colorcom.Models.Pedidos;
using colorcom.Models.Usuario;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colorcom.Models.NotaFiscal
{
    [Table("entradaNF")]
    public class entradaNF
    {
        [Key]
        public int en_cod { get; set; }

        public DateTime en_data { get; set; }

        [MaxLength(100)]
        public string en_endereco { get; set; }

        public int en_us_cod { get; set; }

        public int en_ci_cod { get; set; }

        public int en_em_cod { get; set; }

        public int en_ip_cod { get; set; }

        public int em_es_cod { get; set; }

        [ForeignKey("en_us_cod")]
        public virtual usuario usuario { get; set; }

        [ForeignKey("en_ci_cod")]
        public virtual cidade cidade { get; set; }

        [ForeignKey("em_es_cod")]
        public virtual estado estado { get; set; }

        [ForeignKey("en_em_cod")]
        public virtual emitente emitente { get; set; }

        [ForeignKey("en_ip_cod")]
        public virtual itemPedido itemPedido { get; set; }
    }
}