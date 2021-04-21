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

        public IEnumerable<StoryListItem> GetAllStories()
        {
            var storyEntities = _context.Stories.ToList();
            var storyList = storyEntities.Select(e => new StoryListItem
            {
                Id = e.Id,
                CategoryName = (_context.Categories.Single(c => c.Id == e.CategoryId)).Name,
                WriterName = (_context.Writers.Single(w => w.Id == e.WriterId)).Name,
                Title = e.Title,
                Location = e.Location,
                TimeOfPublication = e.TimeOfPublication
            }).ToList().OrderBy(s => s.TimeOfPublication);
            return storyList;
        }

        public StoryDetail GetStoryById(int id)
        {
            var entity = _context.Stories.Single(e => e.Id == id);
            return new StoryDetail
            {
                Id = entity.Id,
                CategoryName = (_context.Categories.Single(c => c.Id == entity.CategoryId)).Name,
                WriterName = (_context.Writers.Single(w => w.Id == entity.WriterId)).Name,
                Title = entity.Title,
                Body = entity.Body,
                Location = entity.Location,
                TimeOfPublication = entity.TimeOfPublication
            };
        }

        //public string GetCategoryNameById(int categoryId)
        //{
        //    var categoryEntity = _context.Categories.Single(e => e.Id == categoryId);
        //    return categoryEntity.Name;
        //}
    }
}
