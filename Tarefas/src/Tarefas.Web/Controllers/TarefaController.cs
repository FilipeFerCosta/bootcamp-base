using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        private TarefaDAO tarefaDAO;

        
        public List<TarefaViewModel> listaDeTarefas { get; set; }

        public TarefaController()
        {

            tarefaDAO = new TarefaDAO();

            listaDeTarefas = new List<TarefaViewModel>()
            {
                new TarefaViewModel() { Id = 1, Titulo = "Escovar os dentes" },
                new TarefaViewModel() { Id = 2, Titulo = "Arrumar a cama" },
                new TarefaViewModel() { Id = 3, Titulo = "Por o lixo para fora", Descricao = "somente às terças, quintas e sábados" }
            };
        }
        
        public IActionResult Details(int id)
        {
            
            var tarefaDTO = tarefaDAO.Consultar(id);

            var tarefa = new TarefaViewModel()
            {
                Id          = tarefaDTO.Id,
                Titulo      = tarefaDTO.Titulo,
                Descricao   = tarefaDTO.Descricao,
                Concluida   = tarefaDTO.Concluida
            };

            return View(tarefa);
        }

        public IActionResult Index()
        {            
        
            var listaDeTarefasDTO = tarefaDAO.Consultar();

            var listaDeTarefas = new List<TarefaViewModel>();

            foreach (var tarefaDTO in listaDeTarefasDTO)
            {
                listaDeTarefas.Add(new TarefaViewModel()
                {
                    Id          =   tarefaDTO.Id,
                    Titulo      =   tarefaDTO.Titulo,
                    Descricao   =   tarefaDTO.Descricao,
                    Concluida   =   tarefaDTO.Concluida
                });
            }

            return View(listaDeTarefas);
        }


        
        public IActionResult Create()
        {            
            
            if(!ModelState.IsValid)
            {
                return View();
            }
        return View();
        
            
        }

        [HttpPost]
        public IActionResult Create(TarefaViewModel tarefa)
        {
            if(!ModelState.IsValid){

            var tarefaDTO = new TarefaDTO 
            {
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Concluida = tarefa.Concluida
            };

            tarefaDAO.Criar(tarefaDTO);
                return View();
            }
            return View();

        }
    
        [HttpPost]
        public IActionResult Update(TarefaViewModel tarefa)
        {
            if(!ModelState.IsValid)
            {
            var tarefaDTO = new TarefaDTO
            {
                Id          = tarefa.Id,
                Titulo      = tarefa.Titulo,
                Descricao   = tarefa.Descricao,
                Concluida   = tarefa.Concluida
            };

            tarefaDAO.Atualizar(tarefaDTO);
        
                return View();

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {


            var tarefaDTO = tarefaDAO.Consultar(id);

            var tarefa = new TarefaViewModel()
            {
                Id          = tarefaDTO.Id,
                Titulo      = tarefaDTO.Titulo,
                Descricao   = tarefaDTO.Descricao,
                Concluida   = tarefaDTO.Concluida
            };


            if(!ModelState.IsValid)
            {
                return View();

            }

            return View(tarefa);
        }

        public IActionResult Delete(int id)
        {
            tarefaDAO.Excluir(id);

            return RedirectToAction("Index");
        }    
    
    
    }
}