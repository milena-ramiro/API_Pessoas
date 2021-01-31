using Microsoft.EntityFrameworkCore;

namespace API_Pessoas.Model.Context
{
    public class IPersonRepository : DbContext
    {
        public IPersonRepository() { }

        public IPersonRepository(DbContextOptions<IPersonRepository> options) : base(options) { }

        public DbSet<tbPessoa> Pessoa { get; set; }
    }
}
