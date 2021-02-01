using System.Collections.Generic;
using API_Pessoas.Model;
using API_Pessoas.Repository;
using API_Pessoas.Repository.Implementations;

namespace API_Pessoas.Business.Implementations
{
    public class LivroBusinessImplementation : ILivroBusiness
    {
        private readonly ILivroRepository _repository;
            
        public LivroBusinessImplementation(ILivroRepository repository)
        {
            _repository = repository;
        }
        
        public tbLivro Create(tbLivro book)
        {
            return _repository.Create(book);
        }

        public tbLivro FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public List<tbLivro> FindAll()
        {
            return _repository.FindAll();
        }

        public tbLivro Update(tbLivro book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}