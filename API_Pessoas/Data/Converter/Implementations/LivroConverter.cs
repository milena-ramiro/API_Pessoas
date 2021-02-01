using System.Collections.Generic;
using System.Linq;
using API_Pessoas.Data.Converter.Contract;
using API_Pessoas.Data.VO;
using API_Pessoas.Model;

namespace API_Pessoas.Data.Converter.Implementations
{
    public class LivroConverter : IParser<LivroVO, tbLivro>, IParser<tbLivro, LivroVO>
    {
        public tbLivro Parse(LivroVO origin)
        {
            if (origin == null) return null;
            return new tbLivro
            {
                id = origin.Id,
                Author = origin.Author,
                Price = origin.Price,
                Title = origin.Title,
                Launch_Date = origin.Launch_Date
            };
        }

        public LivroVO Parse(tbLivro origin)
        {
            if (origin == null) return null;
            return new LivroVO
            {
                Id = origin.id,
                Author = origin.Author,
                Price = origin.Price,
                Title = origin.Title,
                Launch_Date = origin.Launch_Date
            };
        }

        public List<LivroVO> Parse(List<tbLivro> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        
        public List<tbLivro> Parse(List<LivroVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}