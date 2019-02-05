using System;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Models
{
    public class TarefaItem
    {
        [Key]
        public int id { get; set; }        
        [Display(Name="Tarefa Completa")]
        public bool EstaCompleta { get; set; }
        [Required(ErrorMessage="Nome da tarefa obrigatorio")]
        [StringLength(200)]
        [Display(Name="Nome da Tarefa")]
        public string Nome { get; set; }
        [Display(Name="Data de Conclusão")]
        public DateTimeOffset? DataConclusaoTarefa { get; set; }
    }
}