using CasaDoCodigo.DAO;
using CasaDoCodigo.Uteis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Controllers
{
    public class ControllerPai : Controller
    {
        protected LojaContexto contexto { get; }
        protected IHttpContextAccessor contextAcessor { get; }
        protected Session session { get; }

        protected IDAO DAO { get; set;}

        public ControllerPai(LojaContexto lojaContexto, IHttpContextAccessor contextAcessor)
        {
            this.contexto = lojaContexto;
            this.contextAcessor = contextAcessor;
            this.session = new Session(contextAcessor);

        }

    }
}
