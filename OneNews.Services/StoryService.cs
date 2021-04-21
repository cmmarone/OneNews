using OneNews.Data;
using OneNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNews.Services
{
    public class StoryService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public bool CreateStory(StoryCreate model)
        {
            var storyEntity = new Story
            {
                CategoryId = model.CategoryId,
                WriterId = model.WriterId,
                Title = model.Title,
                Body = model.Body,
                Location = model.Location,
                TimeOfPublication = DateTimeOffset.Now
            };

            _context.Stories.Add(storyEntity);
            return _context.SaveChanges() == 1;
        }
    }
}
