using HerbDiaryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace HerbDiaryWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
