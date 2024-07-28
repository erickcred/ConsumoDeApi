using System.Text.Json;

namespace Endereco.Services
{
  public class ConsultaCepService
  {
    public CEPEndereco ConsultaCep(string urlCepApi)
    {
      HttpClient client = new HttpClient();
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, urlCepApi);

      HttpResponseMessage response = client.SendAsync(request).Result;

      CEPEndereco endereco = JsonSerializer.Deserialize<CEPEndereco>(response.Content.ReadAsStringAsync().Result)!;

      return endereco;
    }
  }
}
