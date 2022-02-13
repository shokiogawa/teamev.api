using System;
using System.Threading.Tasks;
using teamev.api.domain.entity;
namespace teamev.api.domain.repository_interface
{
  public interface ITeamRepository
  {
    Task CreateTeamAsync(string userUid, Team team);
  }
}