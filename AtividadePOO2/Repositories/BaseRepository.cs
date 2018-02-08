using System;
using System.Collections.Generic;
using System.Linq;
using AtividadePOO;
using Microsoft.EntityFrameworkCore;

namespace AtividadePOO2.Repositories
{
    public class BaseRepository<T> where T : class
    {   private readonly DataContext _context;
        public BaseRepository(){
            this._context = new DataContext();
        }
        public virtual IQueryable<T> GetAll(){
            return _context.Set<T>();
            
        }

        public virtual T GetById(int id){
            return _context.Set<T>().Find(id);

        }

        public virtual void Create(T entity){
            try{
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }catch(DbUpdateException e){
                Console.WriteLine("Algo deu errado :( Erro: " + e.InnerException.Message);
            }
        }


        public virtual T Update(int id, T entity){
            var exist = _context.Set<T>().Find(id);
    
           
            if (exist != null){
                _context.Entry(exist).CurrentValues.SetValues(entity);

                try {
                    _context.SaveChanges();
                }
                catch (DbUpdateException e){
                    Console.WriteLine("Algo deu errado :( Erro: " + e.InnerException.Message);
                }
            
            }else{
                Console.WriteLine("Objeto não encontrado");
            }
         
                
            
            return entity;
        }


        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            try{
                _context.SaveChanges();
            }catch(DbUpdateException e){
                Console.WriteLine("Algo deu errado :( Erro: " + e.InnerException.Message);
            }
        }
    }
}