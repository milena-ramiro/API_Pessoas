using System.Collections.Generic;
using API_Pessoas.Data.VO;

namespace API_Pessoas.Business
{
    public interface IPessoaBusiness
    {
        PessoaVO Create(PessoaVO person);
        PessoaVO FindByID(long id);
        List<PessoaVO> FindAll();
        PessoaVO Update(PessoaVO person);
        void Delete(long id);
    }
}
