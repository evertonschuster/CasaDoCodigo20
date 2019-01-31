using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAO
{
    public class ProdutoDao : DAO<Produto>
    {
        public ProdutoDao(LojaContexto context) : base(context)
        {
        }

    }
}
