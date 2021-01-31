using API_Pessoas.Model;
using API_Pessoas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_Pessoas.Business.Implementations
{
    public class PessoaBusinessImplementation : IPessoaBusiness
    {
        private readonly IPessoaRepository _repository;

        public PessoaBusinessImplementation(IPessoaRepository repository)
        {
            _repository = repository;
        }


        public tbPessoa Create(tbPessoa person)
        {
            return _repository.Create(person);

        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<tbPessoa> FindAll()
        {
            return _repository.FindAll();
        }

        public tbPessoa FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public tbPessoa Update(tbPessoa person)
        {
            return _repository.Update(person);
        }

    }
}
