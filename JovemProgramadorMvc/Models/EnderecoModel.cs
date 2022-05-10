using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMvc.Models
{
    public class EnderecoModel
    {
        public int IdAluno { get; set; }
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string DDD { get; set; }

        public EnderecoModel()
        {
           
        }


    }
}


