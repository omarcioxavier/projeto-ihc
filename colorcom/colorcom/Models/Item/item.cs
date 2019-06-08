using colorcom.Models.Estoque;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colorcom.Models.Item
{
    [Table("item")]
    public class item
    {
        [Key]
        public int it_cod { get; set; }

        [MaxLength(100)]
        public string it_titulo { get; set; }

        [MaxLength(100)]
        public string it_descricao { get; set; }

        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string it_ean { get; set; }

        public float it_preco_compra { get; set; }

        public float it_preco_venda { get; set; }

        public int it_min { get; set; }

        public int it_max { get; set; }

        public int it_quantidade { get; set; }

        public bool it_status { get; set; }

        public int it_ca_cod { get; set; }

        public int it_um_cod { get; set; }

        [ForeignKey("it_ca_cod")]
        public virtual categoria categoria { get; set; }

        [ForeignKey("it_um_cod")]
        public virtual unidadeMedida unidadeMedida { get; set; }

        public virtual ICollection<logItem> logsItem { get; set; }

        public virtual ICollection<movimentoEstoque> movimentosEstoque { get; set; }
    }
}