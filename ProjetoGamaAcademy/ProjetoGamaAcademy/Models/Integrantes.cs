using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGamaAcademy.Models
{
    public class Integrantes
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        
    }
}
