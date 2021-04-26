using OneNews.Data;
using OneNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNews.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

     

        public bool CreateCategory(CategoryCreate model)
        {
            var category = new Category
            {
                Name = model.Name
            };

            _context.Categories.Add(category);
            return _context.SaveChanges() > 0;

        }
        public IEnumerable<CategoryListItem> GetCategories()
        {
            var entity = _context.Categories.Select(e => new CategoryListItem
            {
                Id = e.Id,
                Name = e.Name

            });
            return entity.ToArray();
            
        }

        public CategoryDetail GetCategorybyId(int id)
        {
            var entity = _context.Categories
                .Single(e => e.Id == id);

            return new CategoryDetail
            {
                Id = entity.Id,
                Name = entity.Name,
           
            };

            
        }

        public ICollection<StoryListItem> ConvertStoryBaseModeltoListItem(ICollection<Story> stories)
        {
            var listOfItems = new List<StoryListItem>();
            var serviceStory = new StoryService();
            foreach(Story story in stories)
            {
                var listItem = new StoryListItem();
                listItem.Id = story.Id;
                listItem.Title = story.Title;
                listItem.Location = story.Location;
                listItem.DateTimeDisplay = serviceStory.DisplayDateTime(story.TimeOfPublication);
                listOfItems.Add(listItem);
              
            }
            return listOfItems;
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            var entity = _context
                .Categories
                .Single(e => e.Id == model.Id);
            entity.Name = model.Name;

            return _context.SaveChanges() == 1;
        }

        public bool DeleteCategory(int id)
        {
            var entity = _context
                .Categories
                .Single(e => e.Id == id);
            _context.Categories.Remove(entity);
            return _context.SaveChanges() == 1;
        }

    }
}
