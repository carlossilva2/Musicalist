using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Musicalist.Models
{   
    public class appDB : DbContext
    {
        //representar as tabelas a criar na Base de Dados
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<ComprasProdutos> ComprasProdutos { get; set; }
        public virtual DbSet<Imagem> Imagem { get; set; }


        //especificar onde sera criada a base de dados
        public appDB() :base("appDB")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}