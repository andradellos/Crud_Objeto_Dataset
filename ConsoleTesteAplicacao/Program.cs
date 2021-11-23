using BackEasyPush.Apliacation.Pessoa;
using System;

namespace ConsoleTesteAplicacao
{
    //https://www.devmedia.com.br/retornando-mais-de-uma-tabela-dentro-de-um-dataset-usando-o-sqldataadapter/9347
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            OnInit _TesteAcessoDados = new OnInit();




            _TesteAcessoDados.InsertContato();
            _TesteAcessoDados.UpDateContato();

            _TesteAcessoDados.SelectContatosGeral();
           // _TesteAcessoDados.Insert();
           // _TesteAcessoDados.UpDate();
           // _TesteAcessoDados.Select();
           // _TesteAcessoDados.SelectGeral();
           // _TesteAcessoDados.Delete();

            _TesteAcessoDados.Teste();

          

        }
    }
}
