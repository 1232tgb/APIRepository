using Microsoft.AspNetCore.Mvc;
using MyAPI.Helpers;
using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Repositories.Interface
{
    //testar depois se realmente precisa herdar de IRepository
    public interface IPalavraRepository : IRepository<Palavra>
    {
        //verificar se o [FromQuery] funciona a partir daí ou se tem que jogar
        IEnumerable<Palavra> ObterTodasCondicao([FromQuery]UrlQuery query);
        
        Palavra GetById(int id);

        void FakeDelete(Palavra palavra);
    }
}
