using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNews.Models
{
    public class StoryEdit
    {
		public int Id { get; set; }

		public int CategoryId { get; set; }

		public int WriterId { get; set; }

		public string Title { get; set; }

		public string Body { get; set; }

		public string Location { get; set; }
	}
}
