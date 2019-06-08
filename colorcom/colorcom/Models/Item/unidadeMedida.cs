using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colorcom.Models.Item
{
    [Table("unidadeMedida")]
    public class unidadeMedida
    {
        [Key]
        public int um_cod { get; set; }

        [MaxLength(10)]
        public string um_sigla { get; set; }

        [MaxLength(100)]
        public string um_descricao { get; set; }

        public virtual ICollection<item> itens { get; set; }
    }
}