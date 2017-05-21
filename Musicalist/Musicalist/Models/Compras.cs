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
            ComprasProdutos = new HashSet<ComprasProdutos>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ComprasID { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? DataCompra { get; set; }
        //*****************************************
        //Morada de Entrega
        [Required]
        public string RuaEntreg { get; set; }

        [Required]
        public string CidadeEntreg { get; set; }

        [Required]
        public string PostalEntreg { get; set; }

        [Required]
        public string PaisEntreg { get; set; }

        //*****************************************
        //Morada de Faturação
        [Required]
        public string RuaFatur { get; set; }

        [Required]
        public string CidadeFatur { get; set; }

        [Required]
        public string PostalFatur { get; set; }

        [Required]
        public string PaisFatur { get; set; }
        

        //*****************************************
        // criar a chave forasteira
        // relaciona o objeto Compras com um objeto User
        public User User { get; set; }

        // cria um atributo para funcionar como FK, na BD
        // e relaciona-o com o atributo anterior
        [ForeignKey("User")]
        public int UserFK { get; set; }

        public virtual ICollection<ComprasProdutos> ComprasProdutos { get; set; }
    }
}