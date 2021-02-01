using System;
using System.Collections.Generic;
using API_Pessoas.Model.Base;
using API_Pessoas.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API_Pessoas.Repository.Generics
{
        public class GenericRepository<T> : IRepository<T> where T : BaseEntity
        { 
                private MySqlContext _context;
                private DbSet<T> _dataSet;

                public GenericRepository(MySqlContext context)
                {
                        _context = context;
                        //Setando dinamicamente tipo generico no DbContext
                        _dataSet = _context.Set<T>(); 
                }
                
                public T FindByID(long id)
                {
                        return _dataSet.Where(i => i.id == id).FirstOrDefault();
                }

                public List<T> FindAll()
                {
                        return _dataSet.ToList();
                }
                
                public T Create(T item)
                {
                        try
                        {
                                _dataSet.Add(item);
                                _context.SaveChanges();
                                return item;
                        }
                        catch(Exception ex)
                        {
                                throw;
                                return null;
                        }
                        
                }

                

                public T Update(T item)
                {
                        var result = FindByID(item.id);

                        if (result != null)
                        {
                                try
                                {
                                        _context.Entry(result).CurrentValues.SetValues(item);
                                        _context.SaveChanges();
                                        return item;
                                }
                                catch (Exception ex)
                                {
                                        throw;
                                        return null;
                                }
                        }
                        else
                        {
                                return null;
                        }
                }

                public void Delete(long id)
                {
                        var result = FindByID(id);

                        if (result != null)
                        {
                                try
                                {
                                        _dataSet.Remove(result);
                                        _context.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                        throw;
                                }
                        }
                }
        }
}