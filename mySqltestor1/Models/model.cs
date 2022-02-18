
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


using Microsoft.EntityFrameworkCore;

namespace mySqltestor1
{
    public class admin_login 
    {
        [Key]
         public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

   
    

    public class AppContext : DbContext
    {
        public DbSet<admin_login> Admin_login { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=10.0.1.53;Port=3306;Database=get.miniproject;Uid=bmsusr;Pwd=C@res0ft@BM5;");
        }
    }
}