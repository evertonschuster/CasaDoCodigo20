﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class Pedido : BaseModel
    {
        public Pedido()
        {
            Cadastro = new Cadastro();
        }

        public Pedido(Cadastro cadastro)
        {
            Cadastro = cadastro;
        }

        public Pedido(int id, Cadastro cadastro)
        {
            this.Id = id;
            if (cadastro == null)
            {
                Cadastro = new Cadastro();
            }
            else
            {
                Cadastro = cadastro;
            }
        }

        public List<ItemPedido> Itens { get; private set; } = new List<ItemPedido>();
        [Required]
        public virtual Cadastro Cadastro { get; private set; }

        internal void AtualizaCadastro(Cadastro cadastro)
        {
            this.Cadastro = cadastro;
        }
    }
}
