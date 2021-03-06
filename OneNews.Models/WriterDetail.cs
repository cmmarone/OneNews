using OneNews.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNews.Models
{
    public class WriterDetail
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        public virtual ICollection<StoryListItemForWriter> Stories { get; set; }

    }
}
