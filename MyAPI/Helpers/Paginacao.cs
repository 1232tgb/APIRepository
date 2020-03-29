using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Helpers
{
    public class Paginacao
    {
        public int NumeroPagina { get; set; }
        public int ItemPorPagina { get; set; }
        public int TotalItens { get; set; }

        public Paginacao(int NumeroPagina, int ItemPorPagina, int TotalItens)
        {
            this.NumeroPagina = NumeroPagina;
            this.ItemPorPagina = ItemPorPagina;
            this.TotalItens = TotalItens;
        }

        public double TotalPaginas()
        {
            return (double)TotalItens / ItemPorPagina;
        }

    }
}
