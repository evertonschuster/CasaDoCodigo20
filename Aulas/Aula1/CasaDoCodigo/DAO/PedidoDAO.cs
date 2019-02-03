using CasaDoCodigo.Models;
using CasaDoCodigo.Uteis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAO
{
    public class PedidoDAO : DAO<Pedido>
    {
        public PedidoDAO(IDAO dao) : base(dao)
        {
        }

        public PedidoDAO(LojaContexto context, Session session) : base(context, session)
        {
        }

        public override Pedido getById(Pedido p)
        {
            return dbSet
                .Where(i => i.Id == p.Id)
                .Include(i => i.Itens)
                .ThenInclude(pp => pp.Produto)
                .Include(i => i.Cadastro)
                .FirstOrDefault();
        }

        public void AddProdutoPedido(Pedido p, Produto produto)
        {

            var itemPedido = p.Itens.Where(pp => pp.Produto.Id == produto.Id).FirstOrDefault();
            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(p, produto, 1, produto.Preco);
                p.Itens.Add(itemPedido);
            }

        }

        internal void UpdateQuantidadeItemPedido(Pedido pedido, ItemPedido itemPedidoNovo)
        {
            var itemPedidoDB = pedido.Itens.Where(ip => ip.Produto.Codigo == itemPedidoNovo.Produto.Codigo).FirstOrDefault();
            if (itemPedidoDB == null)
            {
                throw new ArgumentException("Item do Pedido nao localizado.");
            }

            if (itemPedidoNovo.Quantidade >= 1)
            {
                itemPedidoDB.Quantidade = itemPedidoNovo.Quantidade;
            }
            else
            {
                pedido.Itens.Remove(itemPedidoDB);
            }


        }

        internal void AtualizaCadastro(Pedido pedido, Cadastro cadastro)
        {
            var cadastroDAO = new CadastroDAO(this);
            cadastroDAO.Remove(pedido.Cadastro );
            cadastroDAO.Add(cadastro);

            pedido.AtualizaCadastro(cadastro);

        }
    }
}
