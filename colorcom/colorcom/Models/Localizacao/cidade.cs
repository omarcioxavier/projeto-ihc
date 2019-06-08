using colorcom.Models.Emitente;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colorcom.Models.Localizacao
{
    [Table("cidade")]
    public class cidade
    {
        [Key]
        public int ci_cod { get; set; }

        [MaxLength(100)]
        public string ci_nome { get; set; }

        public int ci_es_cod { get; set; }

        [ForeignKey("ci_es_cod")]
        public virtual estado estado { get; set; }

        public virtual ICollection<emitente> emitentes { get; set; }
    }
}