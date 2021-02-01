using API_Pessoas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pessoas.Business
{
    public interface ILivroBusiness
    {
        tbLivro Create(tbLivro book);
        tbLivro FindByID(long id);
        List<tbLivro> FindAll();
        tbLivro Update(tbLivro book);
        void Delete(long id);
    }
}