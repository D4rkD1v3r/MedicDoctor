using Microsoft.AspNetCore.Identity;

namespace rmiMedicineDoctor.Models.Entities
{
  public class ApplicationUser : IdentityUser
  {
    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// Фамилия.
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// Отчество.
    /// </summary>
    public string MiddleName { get; set; }
  }
}
