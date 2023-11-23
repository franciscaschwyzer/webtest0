using System.ComponentModel.DataAnnotations;

namespace webteste0.Models
{
    public class Maquina
    {
        [Key]
        public int maquina_id { get; set; }
        public string nome_maquina { get; set; }
        public string descricao { get; set; }
    }
}
