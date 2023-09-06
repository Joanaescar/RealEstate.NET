using Microsoft.EntityFrameworkCore;
using RealEstate.Entites;

namespace RealEstate.Database
{
    public class REDbContext : DbContext
    {
        //para criar as tabelas na base de dados
        public DbSet<User> Users { get; set; }
        public DbSet<House> Houses { get; set; }

        //é o caminho para a base de dados
        public string DbPath { get; }

        //construtor onde indico a pasta e o caminho da base de dados
        public REDbContext() 
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "realestate.db");
        }

        //utilizar sql lite para a base de dados
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    }
}
