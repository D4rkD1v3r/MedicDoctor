using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rmi.medicine.doctor.Models.Entities
{
  /// <summary>
  /// Запись о докторе.
  /// </summary>
  public class MedicalDoctor
  {
    public int Id { get; set; }
    public string IdentityId { get; set; }
    public ApplicationUser Identity { get; set; }
    public string StaffPosition { get; set; }
    public string AcademicRank { get; set; }
  }
}
