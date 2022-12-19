using RazorPagesCase.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCase.Data;

public class AppDbContext : DbContext
{
        public DbSet<SR>? SRs {get; set;}   
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("DataSource = SRdb.db; Cache=Shared");
}