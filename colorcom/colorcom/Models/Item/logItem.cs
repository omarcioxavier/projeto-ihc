using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colorcom.Models.Item
{
    [Table("logItem")]
    public class logItem
    {
        [Key]
        public int li_cod { get; set; }

        public float li_preco_novo { get; set; }

        public DateTime li_dataHora { get; set; }

        public string li_tipo { get; set; }

        public string li_descricao { get; set; }

        public int li_it_cod { get; set; }

        [ForeignKey("li_it_cod")]
        public virtual item item { get; set; }
    }
}