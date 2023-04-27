using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace Estoque.Models
{
    [Table("Categoria")]
    public class categoria
    {
        [DisplayName("ID")]
        [Key]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public int idCategoria { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string nomeCategoria { get; set; }
        
        public List<produtos> produtos { get; set; }
    }
}