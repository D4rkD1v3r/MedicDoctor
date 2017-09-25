using FluentValidation.Attributes;
using rmiMedicineDoctor.ViewModels.Validators;

namespace rmiMedicineDoctor.ViewModels
{
  [Validator(typeof(CredentialsViewModelValidator))]
  public class CredentialsViewModel
  {
    public string UserName { get; set; }
    public string Password { get; set; }
  }
}
