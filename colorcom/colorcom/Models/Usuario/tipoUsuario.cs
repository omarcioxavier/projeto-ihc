using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colorcom.Models.Usuario
{
    [Table("tipoUsuario")]
    public class tipoUsuario
    {
        [Key]
        public int tu_cod { get; set; }

        [MaxLength(100)]
        public string tu_descricao { get; set; }

        public virtual ICollection<usuario> usuarios { get; set; }
    }
}