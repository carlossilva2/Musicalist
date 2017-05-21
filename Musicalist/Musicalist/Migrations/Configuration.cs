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
            var user = new List<User> {
               new User  {UserID = 1, Nome = "Miguel Dantas", Username = "MDantas", Password = "12345678", DataInsc = new DateTime(2017,03,31), DataNasc= new DateTime(1996,04,10), Tipo="Registado" },
               new User  {UserID = 2, Nome = "Rúben Pimentel", Username = "RPimentel", Password = "12345678", DataInsc =  new DateTime(2016,01,05), DataNasc = new DateTime(1987,05,09), Tipo="Registado" },
               new User  {UserID = 3, Nome = "Carlos Silva", Username = "CMSilva", Password = "12345678", DataInsc =  new DateTime(2016,01,01), DataNasc = new DateTime(1996,04,10), Tipo="Administrador" },
               new User  {UserID = 4, Nome = "Lourenço Bandeira", Username = "LBandeira", Password = "12345678", DataInsc =  new DateTime(2016,01,01), DataNasc = new DateTime(1968,09,08), Tipo="Administrador" },
               new User  {UserID = 5, Nome = "António Abreu", Username = "AAbreu", Password = "12345678", DataInsc =  new DateTime(2016,11,22), DataNasc = new DateTime(1991,07,15), Tipo="Registado" },
               new User  {UserID = 6, Nome = "César Lima", Username = "CLima", Password = "12345678", DataInsc =  new DateTime(2016,07,19), DataNasc = new DateTime(1980,01,10), Tipo="Registado" },
               new User  {UserID = 7, Nome = "Ânia Freitas", Username = "AFreitas", Password = "12345678", DataInsc =  new DateTime(2017,02,15), DataNasc = new DateTime(1988,10,01), Tipo="Registado" },
               new User  {UserID = 8, Nome = "Vicente Venâncio", Username = "VVen", Password = "12345678", DataInsc =  new DateTime(2017,01,20), DataNasc = new DateTime(1977,04,21), Tipo="Registado" }
            };

            user.ForEach(dd => context.User.AddOrUpdate(d => d.Nome, dd));
            context.SaveChanges();

            // ############################################################################################
            // adiciona Compras
            var compra = new List<Compras> {
               new Compras  {ComprasID = 1, DataCompra  =  new DateTime(2017,05,06),RuaEntreg = "Rua 123", RuaFatur="Rua 123", CidadeEntreg="Imagina", CidadeFatur="Imagina", PostalEntreg="0000-001", PostalFatur="0000-001", PaisEntreg="CDF", PaisFatur="CDF", UserFK=3},
               new Compras  {ComprasID = 2, DataCompra  =  new DateTime(2017,05,06),RuaEntreg = "Rua 123", RuaFatur="Rua 123", CidadeEntreg="Imagina", CidadeFatur="Imagina", PostalEntreg="0000-001", PostalFatur="0000-001", PaisEntreg="CDF", PaisFatur="CDF", UserFK=1 },
               new Compras  {ComprasID = 3, DataCompra  =  new DateTime(2017,05,01),RuaEntreg = "Rua 123", RuaFatur="Rua 123", CidadeEntreg="Imagina", CidadeFatur="Imagina", PostalEntreg="0000-001", PostalFatur="0000-001", PaisEntreg="CDF", PaisFatur="CDF", UserFK=1},
               new Compras  {ComprasID = 4, DataCompra  =  new DateTime(2017,04,25), RuaEntreg = "Rua 123", RuaFatur="Rua 123", CidadeEntreg="Imagina", CidadeFatur="Imagina", PostalEntreg="0000-001", PostalFatur="0000-001", PaisEntreg="CDF", PaisFatur="CDF", UserFK=6}
            };

            compra.ForEach(dd => context.Compras.AddOrUpdate(d => d.ComprasID, dd));
            context.SaveChanges();

            // ############################################################################################
            // adiciona Contactos
            var contacto = new List<Contacto> {
                new Contacto {Numero = 912345678, Decricao = "Movel", UserFK=2 },
                new Contacto {Numero = 237837578, Decricao = "", UserFK=1 },
                new Contacto {Numero = 919232376, Decricao = "Movel", UserFK=3 },
                new Contacto {Numero = 249721504, Decricao = "Casa", UserFK=3 },
                new Contacto {Numero = 924376894, Decricao = "", UserFK=4 },
                new Contacto {Numero = 927537865, Decricao = "Movel", UserFK=5 },
                new Contacto {Numero = 245768237, Decricao = "", UserFK=6 },
                new Contacto {Numero = 937654281, Decricao = "Movel", UserFK=7 },
                new Contacto {Numero = 222845643, Decricao = "Movel :)", UserFK=8 }
            };

            contacto.ForEach(dd => context.Contacto.AddOrUpdate(d => d.Numero, dd));
            context.SaveChanges();

            // ############################################################################################
            // adiciona Produtos
            var produtos = new List<Produtos> {
               new Produtos  {ProdutosID = 1, Fabricante = "Fender", Nome = "Standard Strat MN AWT", Tipo = "Guitarra ST", eUnico = false , Stock=37, Preco = 555},
               new Produtos  {ProdutosID = 2, Fabricante = "ESP", Nome = "LTD Iron Cross SW", Tipo = "Guitarra Single Cut", eUnico = false , Stock=12, Preco = 1499},
               new Produtos  {ProdutosID = 3, Fabricante = "Ibanez", Nome = "Paul Stanley PS1CM", Tipo = "Guitarra Heavy", eUnico = true , Stock=1, Preco = 7099},
               new Produtos  {ProdutosID = 4, Fabricante = "Harley Benton", Nome = "Victory Flames Classic Series", Tipo = "Guitarra Heavy", eUnico = false , Stock=138, Preco = 139},
               new Produtos  {ProdutosID = 5, Fabricante = "Epiphone", Nome = "SG G-400 Pro EB", Tipo = "Guitarra Double Cut", eUnico = false , Stock=322, Preco = 295},
               new Produtos  {ProdutosID = 6, Fabricante = "Gibson", Nome = "SG Standard Reissue VOS Trem", Tipo = "Guitarra Double Cut", eUnico = false , Stock=5, Preco = 3999},
               new Produtos  {ProdutosID = 7, Fabricante = "Gibson", Nome = "Les Paul Custom EB GH", Tipo = "Guitarra Single Cut", eUnico = true , Stock=1, Preco = 3299},
               new Produtos  {ProdutosID = 8, Fabricante = "PRS", Nome = "SE Santana SY 2017", Tipo = "Guitarra Double Cut", eUnico = true , Stock=1, Preco = 888}
            };

            produtos.ForEach(dd => context.Produtos.AddOrUpdate(d => d.Nome, dd));
            context.SaveChanges();

            // ############################################################################################
            // adiciona ComprasProdutos
            var compProdutos = new List<ComprasProdutos> {
               new ComprasProdutos  {ComprasFK=1,ProdutosFK=1,Preco=7654,NProdutos=2},
               new ComprasProdutos  {ComprasFK=1,ProdutosFK=3,Preco=7654,NProdutos=2},
               new ComprasProdutos  {ComprasFK=2,ProdutosFK=5,Preco=295,NProdutos=1},
               new ComprasProdutos  {ComprasFK=3,ProdutosFK=4,Preco=139,NProdutos=1},
               new ComprasProdutos  {ComprasFK=4,ProdutosFK=7,Preco=3299,NProdutos=1}
            };

            compProdutos.ForEach(dd => context.ComprasProdutos.AddOrUpdate(d => d.ComprasFK, dd));
            context.SaveChanges();

            // ############################################################################################
            // adiciona Imagens
            var imagens = new List<Imagem> {
               new Imagem  {Image="Imagem1", ProdutosFK=1},
               new Imagem  {Image="Imagem2", ProdutosFK=2},
               new Imagem  {Image="Imagem3", ProdutosFK=3},
               new Imagem  {Image="Imagem4", ProdutosFK=4},
               new Imagem  {Image="Imagem5", ProdutosFK=5},
               new Imagem  {Image="Imagem6", ProdutosFK=6},
               new Imagem  {Image="Imagem7", ProdutosFK=7},
               new Imagem  {Image="Imagem8", ProdutosFK=8},
            };

            imagens.ForEach(dd => context.Imagem.AddOrUpdate(d => d.Image, dd));
            context.SaveChanges();
        }
    }
}
