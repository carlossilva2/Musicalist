using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musicalist.Models
{
    public class ComprasProdutos
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Preco { get; set; }
        
        [Required]
        public int NProdutos { get; set; }

        [ForeignKey("ComprasFK")]
        public Compras C { get; set; }
        public int ComprasFK { get; set; }

        [ForeignKey("ProdutosFK")]
        public Produtos P { get; set; }
        public int ProdutosFK { get; set; }
    }
}