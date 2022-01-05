using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("tb_description")]
	public class description
    {
		public string id { get; set; }
		public string descricao { get; set; }
		
		[ForeignKey("cattle")]
		public string cattle_id { get; set; }

	}
}
