using FluentValidation.Attributes;
using Ng2AspNetCore.ViewModels.Validations;

namespace Ng2AspNetCore.ViewModels
{
  [Validator(typeof(RegistrationViewModelValidator))]
  public class RegistrationViewModel
  {
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Location { get; set; }
  }
}
