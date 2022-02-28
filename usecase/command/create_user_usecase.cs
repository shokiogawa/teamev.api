using System;
using System.Threading.Tasks;
using teamev.api.domain.entity;
using teamev.api.domain.domain_service_interface;
using teamev.api.domain.repository_interface;
namespace teamev.api.usecase.command
{
  public class CreateUserUsecase
  {

    public CreateUserUsecase(IUserDomainService _userDomainService, IUserRepository _userRepo)
    {
      this._userDomainService = _userDomainService;
      this._userRepo = _userRepo;
    }

    private readonly IUserDomainService _userDomainService;
    private readonly IUserRepository _userRepo;
    public async Task<Guid> InvokeAsync(string userUid, string name, string email)
    {
      Console.WriteLine("ユースケース");
      //1. userがすでに作られたかどうかの判定
      await _userDomainService.IsUserNotCreatedAsync(userUid);
      User user = new(userUid, name, email);
      await _userRepo.CreateUserAsync(user);
      return user.PublicUserId;
    }

  }

}