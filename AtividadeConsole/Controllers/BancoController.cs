using System;
using System.Collections.Generic;
using System.Linq;
using AtividadePOO.Models;
using AtividadePOO2.Repositories;

namespace AtividadeConsole.Controllers
{
    public class BancoController
    {   private readonly BaseRepository<Banco> _repository;
        public BancoController()
        {
            _repository = new BaseRepository<Banco>();
            
        }

        
        public void RealizarOp()
        {
            Console.WriteLine("Digite 0 para buscar por Id");
            Console.WriteLine("Digite 1 para listar");
            Console.WriteLine("Digite 2 para cadastrar");
            Console.WriteLine("Digite 3 para para atualizar");
            Console.WriteLine("Digite 4 para deletar");
            var x = Convert.ToInt32(Console.ReadLine());
            if(x==0){
                Console.WriteLine("Digite o id");
                var id =   Convert.ToInt32(Console.ReadLine());
                var entiy = _repository.GetById(id);
                PrintObjeto(entiy);
            }
            if(x==1){
                var entities = _repository.GetAll();
                PrintLista(entities);
            }
            if(x==2){
                Console.WriteLine("Digite o nome do banco");
                string nome = Console.ReadLine();
                var banco = new Banco(){
                    Nome = nome,
                    
                };
                _repository.Create(banco);
            }
            if(x==3){
                Console.WriteLine("Digite um id");
                var id  = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite um novo nome");
                string nome = Console.ReadLine();
                var banco = new Banco(){
                    Id = id,
                    Nome = nome,
                    
                };
                _repository.Update(id, banco);
            }
            if(x==4){
                Console.WriteLine("Digite o Id da entidade");
                var id = Convert.ToInt32(Console.ReadLine());
                var entity = _repository.GetById(id);
                if(entity == null){
                    Console.WriteLine("Id não existente");
                }else{
                    _repository.Delete(entity);
                }
                
            }

        }

        public void PrintObjeto(Banco e){
            Console.WriteLine("Id: "+ e.Id +" Nome: "+ e.Nome);
        }
        public void PrintLista(IQueryable<Banco> entities){
            foreach( var e in entities){
                Console.WriteLine("Id: "+ e.Id +" Nome: "+ e.Nome);
            }
            
        }
    }
}