using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Web.Models;

public class TarefaViewModel
{
    public int Id { get; set; }
    
    [Required]
    [DisplayName("Título")]    
    public string? Titulo { get; set; } 

    [Required]
    [DisplayName("Descrição")]    
    public string? Descricao { get; set; } 

    [Required]
    [DisplayName("Concluída")]
    public bool Concluida { get; set; }

}