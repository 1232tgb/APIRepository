using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAPI.DataBase;
using MyAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Helpers;

namespace MyAPI.Repositories.Classes
{
    public class PalavraRepository : Repository<Palavra>, IPalavraRepository
    {
        public PalavraRepository(MimicContext context) : base(context) { }

        public Palavra GetById(int id)
        {
            return context.Palavras.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Palavra> ObterTodasCondicao([FromQuery] UrlQuery query)
        {
            var palavras = context.Palavras.AsQueryable();

            if (query.ativo.HasValue)
            {
                palavras = palavras.Where(p => p.Ativo == query.ativo);
            }
            if (query.data.HasValue)
            {
                palavras = palavras.Where(p => p.Criado == query.data || p.Atualizado == query.data);
            }

            if (query.pagina.HasValue && query.quantidade.HasValue)
            {
                Paginacao paginacao = new Paginacao(query.pagina.Value, query.quantidade.Value, palavras.Count());
                if (query.pagina.Value >= 0)
                {
                    palavras = palavras.Skip((query.pagina.Value - 1) * query.quantidade.Value).Take(query.quantidade.Value);
                }
            }

            return palavras;
        }

        public void FakeDelete(Palavra palavra)
        {
            palavra.Ativo = false;
            Atualizar(palavra);
        }

    }
}
