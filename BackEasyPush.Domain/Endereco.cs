using System;
using System.Collections.Generic;
using System.Text;

namespace BackEasyPush.Domain
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public int IdPessoa { get; set; }
        public int IdPais { get; set; }
        public int IdCidade { get; set; }
        public int IdEstado { get; set; }
        public string Uf { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Status { get; set; }

    }
}
