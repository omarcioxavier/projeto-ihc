using colorcom.Models.Emitente;
using colorcom.Models.NotaFiscal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colorcom.Models.Localizacao
{
    [Table("estado")]
    public class estado
    {
        [Key]
        public int es_cod { get; set; }

        [MaxLength(100)]
        public string es_nome { get; set; }

        [MaxLength(2)]
        public string es_uf { get; set; }

        public virtual ICollection<cidade> cidades { get; set; }

        public virtual ICollection<emitente> emitentes { get; set; }

        public virtual ICollection<saidaNF> saidasNF { get; set; }

        public virtual ICollection<entradaNF> entradasNF { get; set; }
    }
}