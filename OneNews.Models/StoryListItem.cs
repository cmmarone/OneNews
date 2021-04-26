using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNews.Models
{
    public class StoryListItem
    {
		public int Id { get; set; }
		public string CategoryName { get; set; }
		public string WriterName { get; set; }
		public string Title { get; set; }
		public string Location { get; set; }
        public string DateTimeDisplay { get; set; }
    }

	public class StoryListItemForWriter
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string DateTimeDisplay { get; set; }
    }

    public class StoryListItemForCategory
    {
        public int Id { get; set; }
        public string WriterName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string DateTimeDisplay { get; set; }
    }
}
