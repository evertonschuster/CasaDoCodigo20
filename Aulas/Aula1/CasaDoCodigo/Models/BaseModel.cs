using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    [DataContract]
    public class BaseModel : IDisposable 
    {
        [DataMember]
        public int Id { get; protected set; }

        public void Dispose()
        {
            
        }
    }

}
