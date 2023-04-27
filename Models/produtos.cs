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
    [Table("Produto")]
    public class produtos
    {
        [DisplayName("ID")]
        [Key]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public int idProdutos { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string nomeProduto { get; set; }

        [DisplayName("Valor")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public decimal valorProduto { get; set; }

        [DisplayName("Valor de compra")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public decimal valorCompra { get; set; }

        [DisplayName("Valor de venda")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public decimal valorVenda { get; set; }

        [DisplayName("Ultima modificação")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public DateTime dataProduto { get; set; } = DateTime.Today;

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public virtual ICollection<categoria> categoria { get; set; }

        public produtos()
            {
            categoria = new List<categoria>();
            }

}
 
}