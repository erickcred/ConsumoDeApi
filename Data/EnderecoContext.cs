using Microsoft.EntityFrameworkCore;

namespace Endereco.Data
{
  public class EnderecoContext : DbContext
  {
    static readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Database=Endereco;User=sa;Pwd=123;TrustServerCertificate=True";

    public DbSet<CEPEndereco> CEPEnderecos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(connectionString);
    }
  }
}
