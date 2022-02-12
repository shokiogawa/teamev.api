using System.Threading.Tasks;
namespace teamev.api.domain.domain_service_interface
{
  public interface IUserDomainService
  {
    Task IsUserCreatedAsync(string userUid);
  }
}