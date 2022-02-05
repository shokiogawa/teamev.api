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
          Credential = GoogleCredential.FromFile("teamev_firebase_auth.json")
        });
      }
      catch (Exception e)
      {
        throw new InvalidOperationException("Firebase can not initialized", e);
      }
    }

    public string GetValifyUserUid(string idToken)
    {
      try
      {
        Task<FirebaseToken> task = FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
        task.Wait();
        string uid = task.Result.Uid;
        return uid;
      }
      catch (Exception error)
      {
        throw new InvalidCastException("Can not get userId", error);
      }
    }
  }
}