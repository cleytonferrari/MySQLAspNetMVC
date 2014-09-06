
using System.ComponentModel.DataAnnotations;

namespace MySqlASPNetMVC.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da Pessoa é obrigatório")]
        public string Nome { get; set; }

    }
}
