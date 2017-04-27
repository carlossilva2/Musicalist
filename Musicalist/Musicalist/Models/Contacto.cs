using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musicalist.Models
{
    public class Contacto
    {
        public Contacto()
        {
            
        }
        [Key]
        public int contactoID { get; set; }

        [Required]
        public int numero { get; set; }

        public string decricao { get; set; }

        // **************************
        // criar a chave forasteira
        // relaciona o objeto Contacto com um objeto User
        public User User { get; set; }

        // cria um atributo para funcionar como FK, na BD
        // e relaciona-o com o atributo anterior
        [ForeignKey("User")]
        public int UserFK { get; set; }
    }
}
    