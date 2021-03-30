using System;
using System.Collections.Generic;
using System.Linq;
using API_Pessoas.Model;
using API_Pessoas.Model.Context;
using API_Pessoas.Repository.Generics;

namespace API_Pessoas.Repository
{
    public class PessoaRepository : GenericRepository<tbPessoa>, IPessoaRepository
    {
        
        //Extendo o contexto mysql do generic repository
        public PessoaRepository(MySqlContext context) : base(context){}

        public tbPessoa Disable(long id)
        {
            if (!_context.Pessoa.Any(p => p.id.Equals(id))) return null;
            var user = _context.Pessoa.SingleOrDefault(p => p.id.Equals(id));
            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    //Desabilitar o usuario
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return user;
        }

        public List<tbPessoa> FindByName(string first_name, string last_name)
        {
            if(!string.IsNullOrWhiteSpace(first_name) && !string.IsNullOrWhiteSpace(last_name))
                return _context.Pessoa.Where(p => p.FirstName.Contains(first_name) && p.LastName.Contains(last_name)).ToList();
            else if(string.IsNullOrWhiteSpace(first_name) && !string.IsNullOrWhiteSpace(last_name))
                return _context.Pessoa.Where(p => p.LastName.Contains(last_name)).ToList();
            else if(!string.IsNullOrWhiteSpace(first_name) && string.IsNullOrWhiteSpace(last_name))
                return _context.Pessoa.Where(p => p.FirstName.Contains(first_name)).ToList();

            return null;

        }
    }
}