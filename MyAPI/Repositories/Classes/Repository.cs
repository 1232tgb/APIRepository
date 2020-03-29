using MyAPI.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAPI.DataBase;
using Microsoft.EntityFrameworkCore;

namespace MyAPI.Repositories.Classes
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected MimicContext context;
        
        public Repository(MimicContext context)
        {
            this.context = context;
        }
        
        public IEnumerable<T> ObterTodos()
        {
            return context.Set<T>().AsQueryable();
        }

        public T Obter(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Cadastrar(T item)
        {
            context.Add(item);
            context.SaveChanges();
        }

        public void Atualizar(T item)
        {
            context.Update(item);
            context.SaveChanges();
        }
        
        public void Deletar(int id)
        {
            var item = context.Set<T>().Find(id);
            
            if (item != null)
                context.Remove(item);

            context.SaveChanges();
        }




    }
}
