using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Repositories.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> ObterTodos();
        T Obter(int id);
        void Cadastrar(T item);
        void Atualizar(T item);
        void Deletar(int id);
    }
}
