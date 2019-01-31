using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAO
{
    public class CadastroDAO : DAO<Cadastro>
    {
        public CadastroDAO(LojaContexto context) : base(context)
        {
        }
    }
}
