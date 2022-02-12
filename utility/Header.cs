using Microsoft.AspNetCore.Mvc;
namespace teamev.api.utility
{
  public class Header
  {
    [FromHeader]
    public string Authorization { get; set; }

    public string getToken()
    {
      string idToken = Authorization.Remove(0, 7);
      return idToken;
    }

  }
}