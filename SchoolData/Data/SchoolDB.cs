using Microsoft.EntityFrameworkCore;
using SchoolCore.Models;

namespace SchoolData.DataDB
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
                    (item.Entity as BaseModel).CreatedBy = "Admin";
                    (item.Entity as BaseModel).CreatedOn = DateTime.Now;
                }
                else if(item.State == EntityState.Modified)
                {
                    (item.Entity as BaseModel).ModifyedOnBy = "Admin 22";
                    (item.Entity as BaseModel).ModifyedOn = DateTime.Now;
                    foreach (var prop in item.OriginalValues.Properties)
                    {
                        var c1 = item.OriginalValues[prop];
                        var c2 = item.CurrentValues[prop];
                        if(c1 != c2)
                        {
                            // something changed
                        }
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
