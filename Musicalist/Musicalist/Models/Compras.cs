using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musicalist.Models
{
    public class Compras
    {
        public Compras()
        {
            
        }


        [Key]
        public int ComprasID { get; set; }

        [Required]
        public string Conteudo { set; get; }





        // **************************
        // criar a chave forasteira
        // relaciona o objeto Compras com um objeto User
        public User User { get; set; }

        // cria um atributo para funcionar como FK, na BD
        // e relaciona-o com o atributo anterior
        [ForeignKey("User")]
        public int UserFK { get; set; }
    }
}