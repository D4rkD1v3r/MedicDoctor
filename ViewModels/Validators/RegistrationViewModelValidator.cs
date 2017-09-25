using FluentValidation;

namespace rmiMedicineDoctor.ViewModels.Validators
{
  public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
  {
    public RegistrationViewModelValidator()
    {
      RuleFor(vm => vm.Email).NotEmpty().WithMessage("Email должен быть указан");
      RuleFor(vm => vm.Password).NotEmpty().WithMessage("Пароль не может быть пустым");
      RuleFor(vm => vm.FirstName).NotEmpty().WithMessage("Имя должно быть указано");
      RuleFor(vm => vm.LastName).NotEmpty().WithMessage("Фамилия должна быть указана");
    }
  }
}
