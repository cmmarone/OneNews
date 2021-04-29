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

        private readonly Guid _authorId;
        public CategoryService(Guid authorId)
        {
            _authorId = authorId;
        }


        public bool CreateCategory(CategoryCreate model)
        {
            var category = new Category
            {
                Name = model.Name,
                AuthorId = _authorId
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
                Stories = ConvertStoryBaseModeltoListItem(entity.Stories)
           
            };

            
        }

        public ICollection<StoryListItemForCategory> ConvertStoryBaseModeltoListItem(ICollection<Story> stories)
        {
            var listOfItems = new List<StoryListItemForCategory>();
            foreach(Story story in stories)
            {
                var listItem = new StoryListItemForCategory();
                listItem.Id = story.Id;
                listItem.WriterName = (_context.Writers.Single(w => w.Id == story.WriterId)).Name;
                listItem.Title = story.Title;
                listItem.Location = story.Location;
                listItem.DateTimeDisplay = StoryService.DisplayDateTime(story.TimeOfPublication);
                listOfItems.Add(listItem);
              
            }
            return listOfItems;
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            var entity = _context
                .Categories
                .Single(e => e.Id == model.Id && e.AuthorId == _authorId);
            entity.Name = model.Name;

            return _context.SaveChanges() == 1;
        }

        public bool DeleteCategory(int id)
        {
            var entity = _context
                .Categories
                .Single(e => e.Id == id && e.AuthorId == _authorId);
            _context.Categories.Remove(entity);
            return _context.SaveChanges() == 1;
        }

    }
}
