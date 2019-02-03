using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class CarrinhoViewModel
    {
        public List<ItemPedido> Itens { get; private set; } = new List<ItemPedido>();

        public CarrinhoViewModel(List<ItemPedido> itens)
        {
            Itens = itens;
        }

        public CarrinhoViewModel(Pedido p)
        {
            if (p != null && p.Itens != null )
            {

            Itens = p.Itens;
            }
        }

        public int TotalItens => Itens.Count();

        public decimal TotalCompra => Itens.Sum(p => p.Produto.Preco * p.Quantidade);
    }
}
