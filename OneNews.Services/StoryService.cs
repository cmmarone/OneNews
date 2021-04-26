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
                CategoryId = (_context.Categories.Single(c => c.Name.ToLower() == model.CategoryName.ToLower())).Id,
                WriterId = (_context.Writers.Single(w => w.Name.ToLower() == model.WriterName.ToLower())).Id,
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
                DateTimeDisplay = DisplayDateTime(e.TimeOfPublication)
            }).ToList().OrderByDescending(s => s.Id);
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
                DateTimeDisplay = DisplayDateTime(entity.TimeOfPublication)
            };
        }

        public bool UpdateStory(StoryEdit model)
        {
            var entity = _context.Stories.Single(e => e.Id == model.Id);
            if (model.CategoryName != null)
                entity.CategoryId = (_context.Categories.Single(c => c.Name.ToLower() == model.CategoryName.ToLower())).Id;
            if (model.WriterName != null)
                entity.WriterId = (_context.Writers.Single(w => w.Name.ToLower() == model.WriterName.ToLower())).Id;
            if (model.Title != null)
                entity.Title = model.Title;
            if (model.Body != null)
                entity.Body = model.Body;
            if (model.Location != null)
                entity.Location = model.Location;
            return _context.SaveChanges() > 0;
        }

        public bool DeleteStory(int id)
        {
            var entity = _context.Stories.Single(e => e.Id == id);
            _context.Stories.Remove(entity);
            return _context.SaveChanges() == 1;
        }

        public string DisplayDateTime(DateTimeOffset timeOfPublicaton)
        {
            var localDateTime = timeOfPublicaton.ToLocalTime();
            int standardHour = localDateTime.Hour;
            string amPm = "am";
            if ((localDateTime.Hour % 12) > 0)
            {
                standardHour = localDateTime.Hour % 12;
                amPm = "pm";
            }
            return $"{localDateTime.DayOfWeek}, " +
                $"{localDateTime.Month}/{localDateTime.Day}/{localDateTime.Year} " +
                $"at {standardHour}:{localDateTime.Minute:D2}{amPm}";
        }
    }
}