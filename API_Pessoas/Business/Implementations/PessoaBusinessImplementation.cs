using API_Pessoas.Model;
using System.Collections.Generic;
using API_Pessoas.Data.Converter.Implementations;
using API_Pessoas.Data.VO;
using API_Pessoas.Repository.Generics;

namespace API_Pessoas.Business.Implementations
{
    public class PessoaBusinessImplementation : IPessoaBusiness
    {
        private readonly IRepository<tbPessoa> _repository;
        private readonly PessoaConverter _converter;

        public PessoaBusinessImplementation(IRepository<tbPessoa> repository)
        {
            _repository = repository;
            _converter = new PessoaConverter();
        }
        
        public List<PessoaVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PessoaVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public PessoaVO Create(PessoaVO person)
        {
            var pessoaEntity = _converter.Parse(person); //Parseando o objeto VO para entidade
            pessoaEntity = _repository.Create(pessoaEntity); //Persistindo a entidade
            return _converter.Parse(pessoaEntity); //Convertendo a entidade resultante para VO e retornando esse dado
        }
        
        public PessoaVO Update(PessoaVO person)
        {
            var pessoaEntity = _converter.Parse(person); //Parseando o objeto VO para entidade
            pessoaEntity = _repository.Update(pessoaEntity); //Persistindo a entidade
            return _converter.Parse(pessoaEntity); //Convertendo a entidade resultante para VO e retornando esse dado
        }
        
        public void Delete(long id)
        {
            _repository.Delete(id);
        }


        

    }
}
