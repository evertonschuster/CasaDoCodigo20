using CasaDoCodigo.DAO;
using CasaDoCodigo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Uteis
{
    public class DataService
    {
        private readonly ProdutoDAO produtoRepository;

        public DataService(ProdutoDAO produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {

            List<Livros> livros = GetLivos();
            SalvarLivros(livros);



        }

        private void SalvarLivros(List<Livros> livros)
        {
            foreach (var item in livros)
            {
                var produto = new Produto(
                        item.Codigo,
                        item.Nome,
                        item.Preco
                        );

                produtoRepository.Add(produto);
            }
        }

        private static List<Livros> GetLivos()
        {
            var json = File.ReadAllText("livros.json");

            var livros = JsonConvert.DeserializeObject<List<Livros>>(json);
            return livros;
        }


    }
    public class Livros
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
