using Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Context : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Senha> Senhas { get; set; }

        public DbSet<SenhaTag> SenhaTags { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Usuario> Usuarios { get; set;}
        // Heroku Config
        //"Server=us-cdbr-east-05.cleardb.net;User Id=b4a4154b57bdb4;Database=heroku_96f4f1c4546dac0;Pwd=b857f5e2"

        // Local Config
        //"Server=localhost;User Id=root;Database=encryptme"
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql("Server=localhost;User Id=root;Database=encryptme");
    }
}