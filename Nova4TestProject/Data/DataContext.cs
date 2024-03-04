using Microsoft.EntityFrameworkCore;
using Nova4TestProject.Models;

namespace Nova4TestProject.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<BitcoinHistory> BitcoinInfo { get; set; }
    }
}
