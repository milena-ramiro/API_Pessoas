using System.Collections.Generic;
using System.Linq;
using API_Pessoas.Data.Converter.Contract;
using API_Pessoas.Data.VO;
using API_Pessoas.Model;

namespace API_Pessoas.Data.Converter.Implementations
{
    public class PessoaConverter : IParser<PessoaVO, tbPessoa>, IParser<tbPessoa, PessoaVO>
    {
        public tbPessoa Parse(PessoaVO origin)
        {
            if (origin == null) return null;
            return new tbPessoa
            {
                id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Addres = origin.Addres,
                Gender = origin.Gender
            };
        }

        public PessoaVO Parse(tbPessoa origin)
        {
            if (origin == null) return null;
            return new PessoaVO()
            {
                Id = origin.id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Addres = origin.Addres,
                Gender = origin.Gender
            };
        }

        public List<PessoaVO> Parse(List<tbPessoa> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        
        public List<tbPessoa> Parse(List<PessoaVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}