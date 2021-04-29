using OneNews.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNews.Models
{
    public class StoryCreate
    {
		[Required]
		public string CategoryName { get; set; }
		[Required]
		public string WriterName { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public string Body { get; set; }
		[Required]
		public string Location { get; set; }
	}
}