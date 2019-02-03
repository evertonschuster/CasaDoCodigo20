using System;
using System.Collections.Generic;
using CasaDoCodigo.Models;
using CasaDoCodigo.Uteis;

namespace CasaDoCodigo.DAO
{
    public interface IDAO : IDisposable
    {
        LojaContexto GetContext();
        //protected readonly Microsoft.EntityFrameworkCore.DbSet<T> dbSet;
        Session GetSssion();
    }
}