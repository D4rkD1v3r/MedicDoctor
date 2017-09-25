using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace rmi.medicine.doctor.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Models.Entities.MedicalDoctor> MedicalDoctors { get; set; }
  }
}
