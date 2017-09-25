using FluentValidation.Attributes;
using rmiMedicineDoctor.ViewModels.Validators;

namespace rmiMedicineDoctor.ViewModels
{
  [Validator(typeof(RegistrationViewModelValidator))]
  public class RegistrationViewModel
  {
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string StaffPosition { get; set; }
    public string AcademicRank { get; set; }
  }
}
