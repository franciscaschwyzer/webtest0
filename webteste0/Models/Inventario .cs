using System.ComponentModel.DataAnnotations;

namespace webteste0.Models
{
    public class Inventario
    {

        [Key]
        public int inventario_id {  get; set; }
        public int cliente_id {  get; set; }
        public string nome {  get; set; }
        public int maquina_id {  get; set; }
        public string nome_maquina {  get; set; }
	    public int quantidade {  get; set; }
	    public string valores {  get; set; }

    }
}
