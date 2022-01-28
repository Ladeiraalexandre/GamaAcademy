using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGamaAcademy.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Descricao { get; set; }
    }
}
