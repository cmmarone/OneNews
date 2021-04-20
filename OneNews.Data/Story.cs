using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNews.Data
{
    public class Story
    {
		[Key]
		public int Id { get; set; }

		[ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }

		[ForeignKey(nameof(Writer))]
		public int WriterId { get; set; }
		public virtual Writer Writer { get; set; }

		public string Title { get; set; }
		public string Body { get; set; }
		public string Location { get; set; }
		public DateTimeOffset TimeOfPublication { get; set; }
		public Guid AuthorId { get; set; }
	}
}
