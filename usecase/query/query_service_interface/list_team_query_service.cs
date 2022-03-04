using System.Threading.Tasks;
using teamev.api.domain.entity;
using System.Collections.Generic;
namespace teamev.api.usecase.query.query_service_interface
{
  public interface IListTeamQueryService
  {
    Task<IEnumerable<Team>> InvokeAsync(string userUid);
  }
}