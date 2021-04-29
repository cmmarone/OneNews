using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNews.Models
{
    public class StoryDetail
    {
		public int Id { get; set; }
		public string CategoryName { get; set; }
		public string WriterName { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public string Location { get; set; }
        public string DateTimeDisplay { get; set; }
	}
}
