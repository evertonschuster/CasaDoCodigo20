using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class Produto : BaseModel
    {
        public Produto()
        {

        }

        [Required]
        [DataMember]
        public string Codigo { get; private set; }
        [Required]
        [DataMember]
        public string Nome { get; private set; }
        [Required]
        [DataMember]
        public decimal Preco { get; private set; }

        public Produto(string codigo, string nome, decimal preco)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco = preco;
        }
    }
}
