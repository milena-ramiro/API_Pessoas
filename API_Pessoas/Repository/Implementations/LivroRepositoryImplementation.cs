using System;
using System.Collections.Generic;
using System.Linq;
using API_Pessoas.Model;
using API_Pessoas.Model.Context;

namespace API_Pessoas.Repository.Implementations
{
    public class LivroRepositoryImplementation : ILivroRepository
    {
        
        private MySqlContext _context;

        public LivroRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }

        
        public List<tbLivro> FindAll()
        {
            return _context.Livro.ToList();
        }
        
        public tbLivro FindByID(long id)
        {
            return _context.Livro.Where(l => l.id == id).FirstOrDefault();
        }

        public tbLivro Create(tbLivro book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return book;
        }

       

        public tbLivro Update(tbLivro book)
        {
            try
            {
                var result = FindByID(book.id);
                if (result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return book;
        }

        public void Delete(long id)
        {
            try
            {
                var result = FindByID(id);
                if (result != null)
                {
                    _context.Livro.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        

    }
}