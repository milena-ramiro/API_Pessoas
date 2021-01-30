using API_Pessoas.Model;
using API_Pessoas.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pessoas.Services.Implementations
{
    public class PessoaServiceImplementation : IPessoaService
    {
        private MySqlContext _context;

        public PessoaServiceImplementation(MySqlContext context)
        {
            _context = context;
        }


        public tbPessoa Create(tbPessoa person)
        {
            _context.Add(person);
            return person;
        }

        public void Delete(long id)
        {
            _context.Remove(id);
        }

        public List<tbPessoa> FindAll()
        {
            return _context.Pessoa.ToList();
        }

        public tbPessoa FindByID(long id)
        {
            return _context.Pessoa.Find(id);
        }

        public tbPessoa Update(tbPessoa person)
        {
            _context.Update(person);
            return person;
        }
    }
}
