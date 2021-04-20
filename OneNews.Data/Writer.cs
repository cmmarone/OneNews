using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNews.Data
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid AuthorId { get; set; }

        public virtual ICollection<Story> Stories { get; set; } = new List<Story>();

    }
}
