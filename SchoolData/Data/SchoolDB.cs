using Microsoft.EntityFrameworkCore;
using SchoolCore.Models;

namespace LibContext.DataDB
{
    public class SchoolDB : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> TableOfTechers { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "server=localhost;database=MySchoolDB;user id=sa;password=123;Encrypt=false;");
        }

        public override int SaveChanges()
        {

            var enries = ChangeTracker.Entries().ToList();

            foreach (var item in enries)
            {

                if(item.State == EntityState.Added)
                {
                    (item.Entity as PersonInfo).CreatedBy = "Admin";
                    (item.Entity as PersonInfo).CreatedOn = DateTime.Now;
                }
                else if(item.State == EntityState.Modified)
                {
                    (item.Entity as PersonInfo).ModifyedOnBy = "Admin 22";
                    (item.Entity as PersonInfo).ModifyedOn = DateTime.Now;
                    foreach (var prop in item.OriginalValues.Properties)
                    {
                        var c = item.OriginalValues[prop];
                    }
                }
                else if( item.State == EntityState.Deleted)
                {

                }
            }

            return base.SaveChanges();
        }
    }
}
