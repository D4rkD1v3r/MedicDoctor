using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using rmiMedicineDoctor.Data;
using rmiMedicineDoctor.Helpers;
using rmiMedicineDoctor.Models.Entities;
using rmiMedicineDoctor.ViewModels;

namespace rmiMedicineDoctor.Controllers
{
  [Route("api/[controller]")]
  public class AccountsController : Controller
  {
    private readonly ApplicationDbContext _appDbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public AccountsController(UserManager<ApplicationUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
    {
      _userManager = userManager;
      _mapper = mapper;
      _appDbContext = appDbContext;
    }

    // POST api/accounts
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var userIdentity = _mapper.Map<ApplicationUser>(model);

      var result = await _userManager.CreateAsync(userIdentity, model.Password);

      if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

      await _appDbContext.MedicalDoctors.AddAsync(new MedicalDoctor { IdentityId = userIdentity.Id, AcademicRank = model.AcademicRank,StaffPosition = model.StaffPosition});
      await _appDbContext.SaveChangesAsync();

      return new OkObjectResult("Пользователь успешно создан");
    }
  }
}
