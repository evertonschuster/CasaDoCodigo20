using CasaDoCodigo.Models;
using CasaDoCodigo.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAO
{
    public class ProdutoDAO : DAO<Produto>
    {
        public ProdutoDAO(IDAO dao) : base(dao)
        {
        }

        public ProdutoDAO(LojaContexto context, Session session) : base(context, session)
        {
        }

        internal Produto getByCodigo(Produto produto)
        {
            return dbSet.Where(p => p.Codigo == produto.Codigo).FirstOrDefault();
        }
    }
}
