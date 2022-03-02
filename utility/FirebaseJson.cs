using System.Text.Json;

namespace teamev.api.utility
{
  public class FirebaseJson
  {
    public string type { get; set; }
    public string project_id { get; set; }
    public string private_key_id { get; set; }

    public string private_key { get; set; }
    public string client_email { get; set; }
    public string client_id { get; set; }
    public string auth_uri { get; set; }
    public string token_uri { get; set; }
    public string auth_provider_x509_cert_url { get; set; }
    public string client_x509_cert_url { get; set; }

    public FirebaseJson(string type, string project_id, string private_key_id, string private_key, string client_email, string client_id, string auth_uri, string token_uri, string auth_provider_x509_cert_url, string client_x509_cert_url)
    {
      this.type = type;
      this.project_id = project_id;
      this.private_key_id = private_key_id;
      this.private_key = private_key;
      this.client_email = client_email;
      this.client_id = client_id;
      this.auth_uri = auth_uri;
      this.token_uri = token_uri;
      this.auth_provider_x509_cert_url = auth_provider_x509_cert_url;
      this.client_x509_cert_url = client_x509_cert_url;
    }
  }
}