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
        //[Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "{0} must be 30 characters or less"), MinLength(8, ErrorMessage = "{0} must be 8 characters or more")]
        public string Password { get; set; }
        
        [Required]
        [Column(TypeName = "date")]
        [Display(Name = "Data de Inscrição")]
        public DateTime? DataInsc { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNasc { get; set; }
                
        public string Tipo { get; set; }

        // especificar que um User faz muitas Compras
        public ICollection<Compras> Compras { get; set; }

        public virtual ICollection<Contacto> Contacto { get; set; }
    }
}