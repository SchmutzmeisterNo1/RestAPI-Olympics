using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Models.Entity
{
	public class Page
	{
		public int Id { get; set; }

		public string Value { get; set; }

		public int BookId { get; set; }

		[ForeignKey("BookId")]
		public virtual Book Book { get; set; }
	}
}
