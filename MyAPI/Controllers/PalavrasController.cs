using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyAPI.DataBase;
using MyAPI.Helpers;
using MyAPI.Models;
using MyAPI.Repositories.Classes;
using MyAPI.Repositories.Interface;

namespace MyAPI.Controllers
{
    //[Route("api/palavras")]
    public class PalavrasController : Controller
    {

        IPalavraRepository repository;

        //private MimicContext context;
        public PalavrasController(IPalavraRepository repository)
        {
            this.repository = repository;
        }

        //[Route("")]
        [HttpGet]
        public IActionResult ObterTodas([FromQuery]UrlQuery query)
        {
            // var palavras = context.Palavras.AsQueryable();

            //if (query.data.HasValue)
            //{
            //    palavras = palavras.Where(p => p.Criado == query.data || p.Atualizado == query.data);
            //}

            //if (query.ativo.HasValue)
            //{
            //    palavras = palavras.Where(p => p.Ativo == query.ativo);
            //}

            //if (query.pagina.HasValue && query.quantidade.HasValue)
            //{
            //    Paginacao paginacao = new Paginacao(query.pagina.Value, query.quantidade.Value, palavras.Count());
            //    if (query.pagina.Value >= 0)
            //    {
            //        palavras = palavras.Skip((query.pagina.Value - 1) * query.quantidade.Value).Take(query.quantidade.Value);
            //    }
            //}
            var palavras = repository.ObterTodasCondicao(query);
            return Ok(palavras);
        }

        //[Route("{Id}")]
        [HttpGet]
        public IActionResult Obter(int Id)
        {

            //var palavra = context.Palavras.Where(p => p.Id == Id).FirstOrDefault();

            var palavra = repository.GetById(Id);
            return Ok(palavra);
        }

        ////[Route("{Ativo}")]
        ////[HttpGet]
        ////public IActionResult ObterAtivoInativo([FromRoute]bool ativo)
        ////{
        ////    var itens = repository.Palavra.Where(p => p.Ativo == ativo).ToList();
        ////    return Ok(itens);
        ////}

        //[Route("")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody]Palavra palavra)
        {
            if (palavra == null)
                return StatusCode(500);

            repository.Cadastrar(palavra);


            //context.Palavras.Add(palavra);
            //context.SaveChanges();
            return Ok();
        }

        //[Route("")]
        [HttpPut]
        public IActionResult Atualizar([FromBody]Palavra palavra)
        {
            if (palavra == null)
                return StatusCode(500);

            repository.Atualizar(palavra);

            ////palavra.Id = Id;

            //context.Palavras.Update(palavra);
            //context.SaveChanges();

            return Ok();
        }

        //[Route("{Id}")]
        [HttpDelete]
        public IActionResult Deletar(int Id)
        {
            var palavra = repository.GetById(Id);

            if (palavra == null)
                return NotFound();

            repository.Deletar(Id);
            //palavra.Ativo = false;
            //context.Palavras.Update(palavra);
            ////context.Palavra.Remove(palavra);
            //context.SaveChanges();

            return Ok();
        }

        public IActionResult Desativar(int Id)
        {
            var palavra = repository.GetById(Id);

            if (palavra == null)
                return NotFound();

            repository.FakeDelete(palavra);

            return Ok();
        }

    }
}