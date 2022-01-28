using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGamaAcademy.Models
{
    public class Servicos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Imagem { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Descricao { get; set; }
                      
    }
}
