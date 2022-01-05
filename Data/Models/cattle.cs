using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("tb_cattle")]
    public class cattle
    {
		[Key]
		public string id { get; set; }
		public int numero { get; set; }
		[Required]
		public string nome { get; set; }
		public string descricao { get; set; }
		public string responsavel { get; set; }
		public int peso_kg { get; set; }
		public string cor { get; set; }
		public decimal valor { get; set; }
		public int ativo { get; set; }
		[ForeignKey("user")]
		public string user_id { get; set; }
		public virtual user user { get; set; }

	}
}
