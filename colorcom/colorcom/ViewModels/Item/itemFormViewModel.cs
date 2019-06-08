using colorcom.Models.Item;
using System.Collections.Generic;

namespace colorcom.ViewModels.Item
{
    public class ItemFormViewModel
    {
        public IEnumerable<categoria> categorias { get; set; }
        public IEnumerable<unidadeMedida> unidadesMedida { get; set; }
        public item item { get; set; }

        public string title
        {
            get
            {
                if (item != null && item.it_cod != 0)
                {
                    return "Editar Produto";
                }
                return "Novo Produto";
            }
        }
    }
}