using colorcom.Models.NotaFiscal;
using colorcom.Models.Pedidos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colorcom.Models.Usuario
{
    [Table("usuario")]
    public class usuario
    {
        [Key]
        public int us_cod { get; set; }

        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string us_login { get; set; }

        [MaxLength(100)]
        public string us_senha { get; set; }

        public bool us_status { get; set; }

        public int us_tu_cod { get; set; }

        [ForeignKey("us_tu_cod")]
        public tipoUsuario tipoUsuario { get; set; }

        public virtual ICollection<pedido> pedidos { get; set; }

        public virtual ICollection<entradaNF> entradasNF { get; set; }
    }
}