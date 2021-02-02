using API_Pessoas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Pessoas.Data.VO;

namespace API_Pessoas.Business
{
    public interface ILivroBusiness
    {
        LivroVO Create(LivroVO book);
        LivroVO FindByID(long id);
        List<LivroVO> FindAll();
        LivroVO Update(LivroVO book);
        void Delete(long id);
    }
}