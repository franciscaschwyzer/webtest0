using System.ComponentModel.DataAnnotations;

namespace webteste0.Models
{
    public class Cliente
    {
        [Key]
        public int cliente_id { get; set; }
        public string nome { get; set; }
        public string Email { get; set; }
        public string telefone { get; set; }
    }
}
