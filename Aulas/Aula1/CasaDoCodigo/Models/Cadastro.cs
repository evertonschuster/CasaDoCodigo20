using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class Cadastro : BaseModel
    {
        public Cadastro()
        {
        }


        public virtual Pedido Pedido { get; set; }
        [DataMember]
        [MinLength(5, ErrorMessage = "Nome deve ter no minimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no maximo 50 caracteres")]
        [Required(ErrorMessage = "Nome é Obrigatorio")]
        public string Nome { get; set; } = "";

        [DataMember]
        [Required(ErrorMessage = "Email é Obrigatorio")]
        public string Email { get; set; } = "";

        [DataMember]
        [Required(ErrorMessage = "Telefone é Obrigatorio")]
        public string Telefone { get; set; } = "";

        [DataMember]
        [Required(ErrorMessage = "Endereco é Obrigatorio")]
        public string Endereco { get; set; } = "";

        [DataMember]
        [Required(ErrorMessage = "Complemento é Obrigatorio")]
        public string Complemento { get; set; } = "";

        [Required(ErrorMessage = "Bairro é Obrigatorio")]
        public string Bairro { get; set; } = "";

        [DataMember]
        [Required(ErrorMessage = "Municipio é Obrigatorio")]
        public string Municipio { get; set; } = "";

        [DataMember]
        [Required(ErrorMessage = "UF é Obrigatorio")]
        public string UF { get; set; } = "";

        [DataMember]
        [Required(ErrorMessage = "CEP é Obrigatorio")]
        public string CEP { get; set; } = "";
    }
}
