using System;
using System.Collections.Generic;
using System.Text;

namespace BackEasyPush.Domain
{
    public class Contato
    {
        public int IdContato { get; set; }
        public int IdPessoa { get; set; }
        /// <summary>
        /// Celular, Vizinha, Fixo, Trabalho
        /// </summary>
        public string Tipo { get; set; }
        /// <summary>
        /// O contantatode fato , número do telefone
        /// </summary>
        public string Numero  { get; set; }
        public string Status { get; set; }

    }
}
