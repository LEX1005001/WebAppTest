using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebAppTest;

namespace WebApplication3.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Human> Humans => Set<Human>();
    }
}