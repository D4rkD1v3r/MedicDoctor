using AutoMapper;
using rmiMedicineDoctor.Models.Entities;

namespace rmiMedicineDoctor.ViewModels.Mapping
{
  public class ViewModelToEntityMappingProfile : Profile
  {
    public ViewModelToEntityMappingProfile()
    {
      CreateMap<RegistrationViewModel, ApplicationUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
    }
  }
}
