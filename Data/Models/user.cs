﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
	[Table("tb_user")]
	public class user
	{
		[Key]
		public string id { get; set; }
		public string email { get; set; }
		public string nome { get; set; }
		public string login { get; set; }
		public string password { get; set; }

	}
}
