using CasaDoCodigo.Models;
using CasaDoCodigo.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.DAO
{
    public class CadastroDAO : DAO<Cadastro>
    {
        public CadastroDAO(IDAO dao) : base(dao)
        {
        }

        public CadastroDAO(LojaContexto context, Session session) : base(context, session)
        {
        }
    }
}
