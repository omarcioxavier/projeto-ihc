using System.ComponentModel.DataAnnotations;

namespace colorcom.Models.Emitente
{
    public enum EnumTipoEmitente
    {
        [Display(Name = "Pessoa Física")]
        PessoaFisica = 1,
        [Display(Name = "Pessoa Jurídica")]
        PessoaJuridica = 2
    }
}