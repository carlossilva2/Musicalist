using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Musicalist.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class appDB : IdentityDbContext<ApplicationUser>
    {
        public appDB()
            : base("appDB", throwIfV1Schema: false)
        {
        }

        static appDB()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<appDB>(new ApplicationDbInitializer());
        }

        public static appDB Create()
        {
            return new appDB();
        }

        //representar as tabelas a criar na Base de Dados
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<ComprasProdutos> ComprasProdutos { get; set; }
        public virtual DbSet<Imagem> Imagem { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}