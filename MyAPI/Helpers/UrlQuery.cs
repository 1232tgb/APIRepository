using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Helpers
{
    public class UrlQuery
    {
        public DateTime? data { get; set; }
        public bool? ativo { get; set; }
        public int? pagina { get; set; }
        public int? quantidade { get; set; }
    }
}
