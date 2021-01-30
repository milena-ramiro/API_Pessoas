using API_Pessoas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pessoas.Services.Implementations
{
    public class PessoaServiceImplementation : IPessoaService
    {
        public tbPessoa Create(tbPessoa person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<tbPessoa> FindAll()
        {
            throw new NotImplementedException();
        }

        public tbPessoa FindByID(long id)
        {
            throw new NotImplementedException();
        }

        public tbPessoa Update(tbPessoa person)
        {
            throw new NotImplementedException();
        }
    }
}
