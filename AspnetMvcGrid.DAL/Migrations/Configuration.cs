namespace AspnetMvcGrid.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;

    internal sealed class Configuration : DbMigrationsConfiguration<AspnetMvcGrid.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AspnetMvcGrid.DAL.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            var sqlFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory , "*.sql" );
            foreach(var sql in sqlFiles )
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(sql));
            }
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
