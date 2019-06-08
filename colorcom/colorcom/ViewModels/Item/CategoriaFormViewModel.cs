using colorcom.Models.Item;
using System.Collections.Generic;

namespace colorcom.ViewModels.Item
{
    public class CategoriaFormViewModel
    {
        public categoria categoria { get; set; }

        public string title
        {
            get
            {
                if (categoria != null && categoria.ca_cod != 0)
                {
                    return "Editar categoria";
                }
                return "Nova categoria";
            }
        }
    }
}