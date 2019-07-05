using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NewsEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsDataRepositoryNewsDataRepository.Concrete.EntityFramework
{
    public class NContext : DbContext
    {
        public IConfigurationRoot Configuration { get; }
     //   private IMongoDatabase _database = null;
        public NContext()
        {

        }

      ////  public NContext(IOptions<DatabaseSettings> settings)
      //  {
      //      Configuration = settings.Value.iConfigurationRoot;
      //      settings.Value.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
      //      settings.Value.Database = Configuration.GetSection("MongoConnection:Database").Value;

      //      var client = new MongoClient(settings.Value.ConnectionString);
      //      if (client!=null)
      //      {
      //          _database = client.GetDatabase(settings.Value.Database);
          //  }

     //   }

        //public IMongoCollection<News> newss
        //{
        //    get
        //    {
        //        return _database.GetCollection<News>("News");
        //    }

        //}
        public NContext(DbContextOptions<NContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SERKANYILMAZ\\SQLEXPRESS; Database=News7; Trusted_Connection=True;");
        }

        public DbSet<News> news { get; set; }
        public DbSet<Category> categories { get; set; }

        public static implicit operator DbSet<object>(NContext v)
        {
            throw new NotImplementedException();
        }
    }
    public class NewsContextFactory : IDesignTimeDbContextFactory<NContext>
    {
        public NContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NContext>();
            //optionsBuilder.UseSqlite("Data Source=blog.db");

            return new NContext(optionsBuilder.Options);
        }
        protected  void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().ToTable("news");
            modelBuilder.Entity<Category>().ToTable("categories");
        }
    }
}
