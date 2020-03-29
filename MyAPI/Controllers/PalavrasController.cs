using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyAPI.DataBase;
using MyAPI.Helpers;
using MyAPI.Models;
using MyAPI.Repositories.Classes;
using MyAPI.Repositories.Interface;

namespace MyAPI.Controllers
{

    public class PalavrasController : Controller
    {

        IPalavraRepository repository;
      
        public PalavrasController(IPalavraRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult ObterTodas([FromQuery]UrlQuery query)
        {
           
            var palavras = repository.ObterTodasCondicao(query);
            return Ok(palavras);
        }
   
        [HttpGet]
        public IActionResult Obter(int Id)
        {
            var palavra = repository.GetById(Id);
            return Ok(palavra);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody]Palavra palavra)
        {
            if (palavra == null)
                return StatusCode(500);

            repository.Cadastrar(palavra);

            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody]Palavra palavra)
        {
            if (palavra == null)
                return StatusCode(500);

            repository.Atualizar(palavra);

            return Ok();
        }

       
        [HttpDelete]
        public IActionResult Deletar(int Id)
        {
            var palavra = repository.GetById(Id);

            if (palavra == null)
                return NotFound();

            repository.Deletar(Id);
          
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