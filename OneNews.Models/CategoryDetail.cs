using OneNews.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNews.Models
{
    public class CategoryDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<StoryListItemForCategory> Stories { get; set; }
    }
}
