using System;
using AtividadeConsole.Controllers;
using AtividadePOO.Models;
using AtividadePOO2.Repositories;

namespace AtividadeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var bc = new BancoController();
            while(true){
                Console.WriteLine("Digite 1 para realizar operações sobre 'Banco'");
                Console.WriteLine("Digite 0 para sair");
                
                var i = Convert.ToInt32(Console.ReadLine());
                if(i==0){
                    break;
                }
                else if(i==1){
                    bc.RealizarOp();
                }
            }
        }
    }
}
