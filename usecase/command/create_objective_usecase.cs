using System;
using teamev.api.domain.entity;
using teamev.api.domain.value_object;
using teamev.api.domain.repository_interface;
using teamev.api.infrastructure.repository_imp;
using System.Threading.Tasks;
using teamev.api.domain.domain_service_interface;
namespace teamev.api.usecase.command
{
  public class CreateObjectiveUsecase
  {
    public CreateObjectiveUsecase(IObjectiveRepository _objectiveRepo, IObjectiveDomainService _objectiveDomainService)
    {
      this._objectiveRepo = _objectiveRepo;
      this._objectiveDomainService = _objectiveDomainService;
    }
    private readonly IObjectiveRepository _objectiveRepo;
    private readonly IObjectiveDomainService _objectiveDomainService;
    public async Task<Guid> InvokeAsync(Guid publicTeamId, string title, string content, string author, string userUid)
    {

      //1. ユーザーがチームに所属しているかの確認。(uidとteamIdを使って、userが所属しているかの確認で、成功したらuseridを返す。)
      await _objectiveDomainService.IsUserJoined(userUid, publicTeamId);

      //2. ユーザーがリーダーかどうかの確認。 (中間テーブルにステータスをもたす。)
      var teamId = await _objectiveDomainService.IsUserLeader(userUid, publicTeamId);

      //3. 今日作られたチーム目標がないかの確認。
      await _objectiveDomainService.HasTObjectiveCreated(publicTeamId);

      ObjectiveInfo objectiveInfo = new(title, content, author);
      TeamObjective objective = new(teamId, objectiveInfo);

      await _objectiveRepo.CreateAsync(objective);
      return objective.PublicObjectiveId;
    }
  }
}