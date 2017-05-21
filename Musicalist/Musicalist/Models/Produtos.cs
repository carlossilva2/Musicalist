using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musicalist.Models
{
    public class Produtos
    {
        public Produtos()
        {
            ComprasProdutos = new HashSet<ComprasProdutos>();
            Imagem = new HashSet<Imagem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProdutosID { get; set; }

        [Required]
        public bool eUnico { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int Preco { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Fabricante { get; set; }

        [Required]
        public string Tipo { get; set; }

        public virtual ICollection<ComprasProdutos> ComprasProdutos { get; set; }

        public virtual ICollection<Imagem> Imagem { get; set; }
    }
}