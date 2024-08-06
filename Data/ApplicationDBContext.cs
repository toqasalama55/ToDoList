using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
namespace ToDoList.Data
{
    public class ApplicationDBContext :DbContext
    {
       public DbSet<ListItems> ListItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, reloadOnChange: true)
                .Build();

            var connection = builder.GetConnectionString("DefaultConnetion");

            optionsBuilder.UseSqlServer(connection);
        }
    }
}
