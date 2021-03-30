using System.Collections.Generic;
using API_Pessoas.Data.VO;
using API_Pessoas.HyperMedia.Utils;

namespace API_Pessoas.Business
{
    public interface IPessoaBusiness
    {
        PessoaVO Create(PessoaVO person);
        PessoaVO FindByID(long id);
        List<PessoaVO> FindByName(string first_name, string last_name);
        List<PessoaVO> FindAll();

        PagedSearchVO<PessoaVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int currentPage);
        PessoaVO Update(PessoaVO person);
        PessoaVO Disable(long id);
        void Delete(long id);
    }
}
