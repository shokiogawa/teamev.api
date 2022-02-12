using System.Threading.Tasks;
using teamev.api.domain.entity;
namespace teamev.api.domain.repository_interface
{
  public interface IUserRepository
  {
    Task CreateUserAsync(User user);
  }
}