using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNews.Models
{
    public class WriterCreate
    {
        [Required]
        public string Name { get; set; }

    }
}
