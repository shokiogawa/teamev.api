using teamev.api.domain.entity;
using System.Threading.Tasks;
namespace teamev.api.domain.repository_interface
{
  public interface IObjectiveRepository
  {
    Task CreateAsync(TeamObjective objective);
  }
}