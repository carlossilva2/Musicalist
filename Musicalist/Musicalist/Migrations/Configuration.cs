namespace Musicalist.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Musicalist.Models.appDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Musicalist.Models.appDB context)
        {
            // Configuration --- SEED
            //=============================================================

            // ############################################################################################
            // adiciona Users
            var users = new List<User> {
               new User  {Nome = "Miguel Dantas", DataInsc = new DateTime(2017,03,31), DataNasc= new DateTime(1996,04,10), Tipo="Registado" },
               new User  {Nome = "Rúben Pimentel", DataInsc =  new DateTime(2016,01,05), DataNasc = new DateTime(1987,05,09), Tipo="Registado" },
               new User  {Nome = "Carlos Silva", DataInsc =  new DateTime(2016,01,01), DataNasc = new DateTime(1996,04,10), Tipo="Administrador" },
               new User  {Nome = "Lourenço Bandeira", DataInsc =  new DateTime(2016,01,01), DataNasc = new DateTime(1968,09,08), Tipo="Administrador" },
               new User  {Nome = "António Abreu", DataInsc =  new DateTime(2016,11,22), DataNasc = new DateTime(1991,07,15), Tipo="Registado" },
               new User  {Nome = "César Lima", DataInsc =  new DateTime(2016,07,19), DataNasc = new DateTime(1980,01,10), Tipo="Registado" },
               new User  {Nome = "Ânia Freitas", DataInsc =  new DateTime(2017,02,15), DataNasc = new DateTime(1988,10,01), Tipo="Registado" },
               new User  {Nome = "Vicente Venâncio", DataInsc =  new DateTime(2017,01,20), DataNasc = new DateTime(1977,04,21), Tipo="Registado" }
            };

            users.ForEach(dd => context.User.AddOrUpdate(d => d.Nome, dd));
            context.SaveChanges();

            // ############################################################################################
            // adiciona Produtos
            var produtos = new List<Produtos> {
               new Produtos  {Fabricante = "Fender", Nome = "Standard Strat MN AWT", Tipo = "Guitarra ST", eUnico = false , Stock=37, Preco = 555},
               new Produtos  {Fabricante = "ESP", Nome = "LTD Iron Cross SW", Tipo = "Guitarra Single Cut", eUnico = false , Stock=12, Preco = 1499},
               new Produtos  {Fabricante = "Ibanez", Nome = "Paul Stanley PS1CM", Tipo = "Guitarra Heavy", eUnico = true , Stock=1, Preco = 7099},
               new Produtos  {Fabricante = "Harley Benton", Nome = "Victory Flames Classic Series", Tipo = "Guitarra Heavy", eUnico = false , Stock=138, Preco = 139},
               new Produtos  {Fabricante = "Epiphone", Nome = "SG G-400 Pro EB", Tipo = "Guitarra Double Cut", eUnico = false , Stock=322, Preco = 295},
               new Produtos  {Fabricante = "Gibson", Nome = "SG Standard Reissue VOS Trem", Tipo = "Guitarra Double Cut", eUnico = false , Stock=5, Preco = 3999},
               new Produtos  {Fabricante = "Gibson", Nome = "Les Paul Custom EB GH", Tipo = "Guitarra Single Cut", eUnico = true , Stock=1, Preco = 3299},
               new Produtos  {Fabricante = "PRS", Nome = "SE Santana SY 2017", Tipo = "Guitarra Double Cut", eUnico = true , Stock=1, Preco = 888}
            };

            produtos.ForEach(dd => context.Produtos.AddOrUpdate(d => d.Nome, dd));
            context.SaveChanges();
        }
    }
}
