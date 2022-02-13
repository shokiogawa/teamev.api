using teamev.api.domain.repository_interface;
using System.Threading.Tasks;
using teamev.api.domain.entity;
using System;
namespace teamev.api.usecase.command
{
  public class CreateTeamUsecase
  {

    public CreateTeamUsecase(ITeamRepository _teamrepository)
    {
      this._teamrepository = _teamrepository;

    }
    private readonly ITeamRepository _teamrepository;

    public async Task<Guid> InvokeAsync(string userUid, string teamName)
    {
      Team team = new(teamName);
      await _teamrepository.CreateTeamAsync(userUid, team);
      return team.PublicTeamId;
    }

  }
}