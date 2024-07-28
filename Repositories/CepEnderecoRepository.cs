using Endereco.Data;
using Endereco.Repositories.Interface;
using Endereco.Services;

namespace Endereco.Repositories
{
  public class CepEnderecoRepository : ICepEnderecoRepository
  {
    public string Cep { get; set; }
    private readonly EnderecoContext _context;

    public CepEnderecoRepository(string cep)
    {
      Cep = cep;
      _context = new EnderecoContext();
    }

    public CEPEndereco Post()
    {
      string urlCepApi = $"https://viacep.com.br/ws/{Cep}/json/";

      ConsultaCepService cepService = new ConsultaCepService();
      var resultado = cepService.ConsultaCep(urlCepApi);


      _context.CEPEnderecos.Add(new CEPEndereco
      {
        Cep = resultado.Cep,
        Logradouro = resultado.Logradouro,
        Complemento = resultado.Complemento,
        Unidade = resultado.Unidade,
        Bairro = resultado.Bairro,
        Localidade = resultado.Localidade,
        Uf = resultado.Uf,
        Ibge = resultado.Ibge,
        Gia = resultado.Gia,
        Ddd = resultado.Ddd,
        Siafi = resultado.Siafi,
      });
      _context.SaveChanges();
      
      return resultado;
    }
  }
}
