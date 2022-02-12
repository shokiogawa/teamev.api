using System;
using System.Threading.Tasks;
using teamev.api.infrastructure.db;
namespace teamev.api.domain.domain_service_interface
{
  public interface IObjectiveDomainService
  {
    Task<int> IsUserJoined(string userUid, Guid publicTeamId);
    Task<int> IsUserLeader(string userUid, Guid publicTeamId);
    Task HasTObjectiveCreated(Guid publicTeamId);

  }

}