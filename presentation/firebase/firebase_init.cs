using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Threading.Tasks;
using teamev.api.utility;
using System.Text.Json;
namespace teamev.api.presentation.firebase
{
  public class FirebaseInitApp
  {
    public readonly FirebaseJson firebaseJson;
    public FirebaseInitApp(FirebaseJson firebaseJson)
    {
      this.firebaseJson = firebaseJson;
      string json = JsonSerializer.Serialize(this.firebaseJson);
      try
      {
        FirebaseApp.Create(new AppOptions()
        {
          Credential = GoogleCredential.FromJson(json)
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