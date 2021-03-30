using API_Pessoas.Model;
using System.Collections.Generic;
using API_Pessoas.Data.Converter.Implementations;
using API_Pessoas.Data.VO;
using API_Pessoas.HyperMedia.Utils;
using API_Pessoas.Repository.Generics;
using API_Pessoas.Repository;

namespace API_Pessoas.Business.Implementations
{
    public class PessoaBusinessImplementation : IPessoaBusiness
    {
        private readonly IPessoaRepository _repository;
        private readonly PessoaConverter _converter;

        public PessoaBusinessImplementation(IPessoaRepository repository)
        {
            _repository = repository;
            _converter = new PessoaConverter();
        }

        

        public List<PessoaVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PagedSearchVO<PessoaVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int currentPage)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = currentPage > 0 ? (currentPage - 1) * size : 0;
            
            string query = @"select * from tbpessoa p where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) query = query + $" and p.first_name LIKE '%{name}%' ";
            query += $"order by p.first_name {sort} limit {size} offset {offset}";
            
            string countQuery = @"select count(*) from tbpessoa p where 1=1";
            if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $" and p.first_name LIKE '%{name}%' ";
            
            var persons = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);
            
            return new PagedSearchVO<PessoaVO>
            {
                CurrentPage = currentPage,
                List = _converter.Parse(persons),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        public PessoaVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }
        public List<PessoaVO> FindByName(string first_name, string last_name)
        {
            return _converter.Parse(_repository.FindByName(first_name, last_name));
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

        public PessoaVO Disable(long id)
        {
            var pessoaEntity = _repository.Disable(id);
            return _converter.Parse(pessoaEntity);
        }


        public void Delete(long id)
        {
            _repository.Delete(id);
        }

       
    }
}
