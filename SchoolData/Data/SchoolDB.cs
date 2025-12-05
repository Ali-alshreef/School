using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SchoolCore.Models;

namespace SchoolData.DataDB
{
    public class SchoolDB : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> TableOfTechers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }

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


                    foreach (var prop in item.CurrentValues.Properties)
                    {

                        //if( item.Entity is City)
                        //{

                        //}
                        int id = (item.Entity as BaseModel).Id;
                        string s = prop.Name;
                        string tName = GetTableName(item);
                        var c1 = item.OriginalValues[prop]; /// FROM DataBase 
                        var c2 = item.CurrentValues[prop]; // After Update 
                        if(c1 != c2 && s !="Id" && s!= "CreatedOn" && s != "CreatedBy"
                            && s != "ModifyedOn" && s != "ModifyedOnBy")
                        {
                           LogEntry logEntry = new LogEntry();
                            logEntry.TableId = id;
                            logEntry.TableName = tName;
                            logEntry.ColmunName = s;
                            logEntry.OldValue = c1.ToString();
                            logEntry.NewValue = c2.ToString();
                            logEntry.Date = DateTime.Now;
                            logEntry.AppUser = "User1";
                            LogEntries.Add(logEntry);
                        }
                    }
                }
                else if( item.State == EntityState.Deleted)
                {

                }
            }

            return base.SaveChanges();
        }


        public string GetTableName(EntityEntry entityEntry)
        {
            if(entityEntry.Entity is City)
            {
                return "City";
            }
            else if (entityEntry.Entity is Student)
            {
                return "Student";
            }
            return "not";
        }
    }
}
