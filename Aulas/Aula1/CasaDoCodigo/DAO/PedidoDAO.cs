using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAO
{
    public class PedidoDAO : DAO<Pedido>
    {
        public PedidoDAO(LojaContexto context) : base(context)
        {
        }
    }
}
