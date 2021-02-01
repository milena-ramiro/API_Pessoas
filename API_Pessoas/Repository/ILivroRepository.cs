using System.Collections.Generic;
using API_Pessoas.Model;

namespace API_Pessoas.Repository
{
    public interface ILivroRepository
    {
        tbLivro Create(tbLivro book);
        tbLivro FindByID(long id);
        List<tbLivro> FindAll();
        tbLivro Update(tbLivro book);
        void Delete(long id);
    }
}