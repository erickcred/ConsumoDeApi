using Endereco.Repositories;

Console.WriteLine("Digite o Cep");
string cepS = Console.ReadLine()!;

CepEnderecoRepository cep = new CepEnderecoRepository(cepS);
var resultado = cep.Post();

Console.WriteLine(resultado.Bairro);


