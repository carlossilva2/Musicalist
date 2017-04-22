﻿using System;
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
        }


        [Key]
        public int UserID { get; set; }

        [Required]
        public string Nome { set; get; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? DataInsc { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? DataNasc { get; set; }
        
        [Column(TypeName = "date")]
        private string Tipo { get; set; }

        // especificar que um User faz muitas Compras
        public ICollection<Compras> Compras { get; set; }
    }
}