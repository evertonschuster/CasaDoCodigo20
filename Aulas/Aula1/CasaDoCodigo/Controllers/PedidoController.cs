using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.DAO;
using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : ControllerPai
    {
        public PedidoController(LojaContexto lojaContexto, IHttpContextAccessor contextAcessor) : base(lojaContexto, contextAcessor)
        {
            this.DAO = new PedidoDAO(contexto, session);
        }

        public IActionResult Carrossel()
        {
            var produtoDAO = new ProdutoDAO(this.DAO);

            return View(produtoDAO.List());
        }

        public IActionResult Carrinho(string codigo)
        {
            var pedidoDAO = new PedidoDAO(this.DAO);
            var produtoDAO = new ProdutoDAO(pedidoDAO);

            var pedidoId = Convert.ToInt32(this.session["pedidoID"]);
            var pedido = pedidoDAO.getById(new Pedido(pedidoId, null));


            //adiciona no carrinho se tiver codigo
            if (codigo != null)
            {
                var produto = produtoDAO.getByCodigo(new Produto(codigo, "", 0));

                if (pedido == null)
                {
                    pedido = new Pedido();
                    pedidoDAO.Add(pedido);
                }

                pedidoDAO.AddProdutoPedido(pedido, produto);

                pedidoDAO.SaveChanges();
                this.session["pedidoID"] = pedido.Id;
            }
            

            return View(new CarrinhoViewModel(pedido));
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(Cadastro cadastro )
        {
            if(ModelState.IsValid)
            {
                var pedidoDAO = new PedidoDAO(this.DAO);
                var pedidoId = Convert.ToInt32(this.session["pedidoID"]);

                var pedido = pedidoDAO.getById(new Pedido(pedidoId,null));
                pedidoDAO.AtualizaCadastro (pedido,cadastro);

                pedidoDAO.SaveChanges();

                return View("Resumo",pedido );
            }

            return View("Cadastro", cadastro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public CarrinhoViewModel UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            var pedidoDAO = new PedidoDAO(this.DAO);

            var pedidoID = Convert.ToInt32(this.session["pedidoID"]);
            var pedido = pedidoDAO.getById(new Pedido(pedidoID,null));

            pedidoDAO.UpdateQuantidadeItemPedido(pedido, itemPedido);
            pedidoDAO.SaveChanges();

            return new CarrinhoViewModel(pedido);
        }


    }
}