using Microsoft.EntityFrameworkCore;
using COLLEGE.Models.DbEntities; 

namespace COLLEGE.Data
{
    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; } 
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentFee> StudentFees { get; set; }

    }
}
