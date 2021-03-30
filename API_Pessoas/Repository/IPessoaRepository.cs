using System.Collections.Generic;
using API_Pessoas.Data.VO;
using API_Pessoas.Model;
using API_Pessoas.Repository.Generics;

namespace API_Pessoas.Repository
{
    public interface IPessoaRepository : IRepository<tbPessoa>
    {
        tbPessoa Disable(long id);
        List<tbPessoa> FindByName(string first_name, string last_name);
    }
}