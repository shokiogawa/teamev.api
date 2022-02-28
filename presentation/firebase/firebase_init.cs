using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Threading.Tasks;
namespace teamev.api.presentation.firebase
{
  public class FirebaseInitApp
  {
    public FirebaseInitApp()
    {
      try
      {
        FirebaseApp.Create(new AppOptions()
        {
          Credential = GoogleCredential.FromFile("firebase_auth.json")
        });
      }
      catch (Exception e)
      {
        throw new InvalidOperationException("Firebase can not initialized", e);
      }
    }

    public async Task<string> GetValifyUserUid(string idToken)
    {
      try
      {
        var task = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
        string uid = task.Uid;
        return uid;
      }
      catch (Exception error)
      {
        Console.WriteLine("ここでエラー");
        throw new InvalidCastException("Can not get userId", error);
      }
    }
  }
}