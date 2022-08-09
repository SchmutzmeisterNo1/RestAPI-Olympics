using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Models.Entity
{
	public class Shelve
	{
		public int Id { get; set; }

		public string Headline { get; set; }

		public string Description { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime LastUpdatedDate { get; set; }

		public virtual IEnumerable<Book> Books { get; set; }
	}
}
