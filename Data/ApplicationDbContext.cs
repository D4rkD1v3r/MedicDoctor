using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rmiMedicineDoctor.Models.Entities;

namespace rmiMedicineDoctor.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<MedicalDoctor> MedicalDoctors { get; set; }
  }
}
