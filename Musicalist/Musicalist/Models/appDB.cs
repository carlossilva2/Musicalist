using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Musicalist.Models
{   
    public class appDB : DbContext
    {
        //representar as tabelas a criar na Base de Dados
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }


        //especificar onde sera criada a base de dados
        public appDB() :base("appDB")
        {

        }
    }
}