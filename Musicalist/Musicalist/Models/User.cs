using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musicalist.Models
{
    public class User
    {
        public User()
        {
           Compras = new HashSet<Compras>();
           Contacto = new HashSet<Contacto>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Required]
        public string Nome { set; get; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? DataInsc { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? DataNasc { get; set; }
                
        public string Tipo { get; set; }

        // especificar que um User faz muitas Compras
        public ICollection<Compras> Compras { get; set; }

        public ICollection<Contacto> Contacto { get; set; }
    }
}