using CasaDoCodigo.Models;
using CasaDoCodigo.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAO
{
    public class ItemPedidoDAO : DAO<ItemPedido>
    {
        public ItemPedidoDAO(IDAO dao) : base(dao)
        {
        }

        public ItemPedidoDAO(LojaContexto context, Session session) : base(context, session)
        {
        }
    }
}
