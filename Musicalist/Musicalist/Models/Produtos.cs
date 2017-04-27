using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musicalist.Models
{
    public class Produtos
    {
        public Produtos()
        {
            ComprasProdutos = new HashSet<ComprasProdutos>();
        }

        [Key]
        public int ProdutosID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public bool e_unico { get; set; }

        [Required]
        public int stock { get; set; }

        public ICollection<ComprasProdutos> ComprasProdutos { get; set; }
    }
}