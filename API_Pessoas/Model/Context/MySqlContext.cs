using Microsoft.EntityFrameworkCore;

namespace API_Pessoas.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext() { }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<tbPessoa> Pessoa { get; set; }
        public DbSet<tbLivro> Livro { get; set; }
    }
}
