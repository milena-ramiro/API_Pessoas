using API_Pessoas.Model;
using API_Pessoas.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_Pessoas.Repository.Implementations
{
    public class PessoaRepositoryImplementation : IPessoaRepository
    {
        
        
        private MySqlContext _context;

        public PessoaRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }
        
        public List<tbPessoa> FindAll()
        {
            return _context.Pessoa.ToList();
        }

        public tbPessoa FindByID(long id)
        {
            return _context.Pessoa.Where(p => p.id == id).FirstOrDefault();
        }


        public tbPessoa Create(tbPessoa person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return person;

        }

        public void Delete(long id)
        {
            var result = FindByID(id);

            if (result != null)
            {
                try
                {
                    _context.Pessoa.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        

        public tbPessoa Update(tbPessoa person)
        {
            var result = FindByID(person.id);

            if(result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return person;
            }
            else
            {
                return null;
            }
            
        }

    }
}
