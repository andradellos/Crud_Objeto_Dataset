using System;
using System.Collections.Generic;
using System.Text;

namespace BackEasyPush.Domain
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public DateTime Nascimento { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Contato> Contatos { get; set; }
    }
}
