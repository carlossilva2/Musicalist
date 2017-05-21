using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musicalist.Models
{
    public class Imagem
    {
        public Imagem()
        {

        }

        [Key]
        public int ImagemID { get; set; }

        [Required]
        public string Image { get; set; }

        public Produtos Produtos { get; set; }

        [ForeignKey("Produtos")]
        public int ProdutosFK { get; set; }
    }
}