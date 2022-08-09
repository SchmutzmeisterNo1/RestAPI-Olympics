using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Models.Entity
{
	public class Book
	{
		public int Id { get; set; }

		public string Headline { get; set; }

		public int ShelveId { get; set; }

		[ForeignKey("ShelveId")]
		public virtual Shelve Shelve { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime LastUpdatedDate { get; set; }

		public virtual IEnumerable
	}
}
