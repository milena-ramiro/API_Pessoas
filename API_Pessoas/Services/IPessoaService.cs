using API_Pessoas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pessoas.Services
{
    public interface IPessoaService
    {
        tbPessoa Create(tbPessoa person);
        tbPessoa FindByID(long id);
        List<tbPessoa> FindAll();
        tbPessoa Update(tbPessoa person);
        void Delete(long id);
    }
}
