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

		[Required]
		[ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }

		[Required]
		[ForeignKey(nameof(Writer))]
		public int WriterId { get; set; }
		public virtual Writer Writer { get; set; }

		[Required]
		public string Title { get; set; }
		[Required]
		public string Body { get; set; }
		[Required]
		public string Location { get; set; }
		[Required]
		public DateTimeOffset TimeOfPublication { get; set; }
		public Guid AuthorId { get; set; }
	}
}
