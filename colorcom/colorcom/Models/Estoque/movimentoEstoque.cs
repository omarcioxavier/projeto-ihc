using colorcom.Models.Item;
using colorcom.Models.NotaFiscal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colorcom.Models.Estoque
{
    [Table("movimentoEstoque")]
    public class movimentoEstoque
    {
        [Key]
        public int me_cod { get; set; }

        public int me_it_cod { get; set; }

        public int me_sn_cod { get; set; }

        public int me_en_cod { get; set; }

        [ForeignKey("me_it_cod")]
        public virtual item item { get; set; }

        [ForeignKey("me_sn_cod")]
        public virtual saidaNF saidaNF { get; set; }

        [ForeignKey("me_en_cod")]
        public virtual entradaNF entradaNF { get; set; }
    }
}