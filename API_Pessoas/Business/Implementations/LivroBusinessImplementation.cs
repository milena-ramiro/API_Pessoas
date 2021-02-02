using System.Collections.Generic;
using API_Pessoas.Data.Converter.Implementations;
using API_Pessoas.Data.VO;
using API_Pessoas.Model;
using API_Pessoas.Repository;
using API_Pessoas.Repository.Generics;

namespace API_Pessoas.Business.Implementations
{
    public class LivroBusinessImplementation : ILivroBusiness
    {
        private readonly IRepository<tbLivro> _repository;
        private readonly LivroConverter _converter;
            
        public LivroBusinessImplementation(IRepository<tbLivro> repository)
        {
            _repository = repository;
            _converter = new LivroConverter();
        }

        public LivroVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public List<LivroVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }
        
        public LivroVO Create(LivroVO book)
        {
            var livroEntity = _converter.Parse(book); //Converti para entidade
            livroEntity = _repository.Create(livroEntity); //Persisti a entidade
            return _converter.Parse(livroEntity); //Converti para VO novamente.
        }
        
        public LivroVO Update(LivroVO book)
        {
            var livroEntity = _converter.Parse(book);
            livroEntity = _repository.Update(livroEntity);
            return _converter.Parse(livroEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}