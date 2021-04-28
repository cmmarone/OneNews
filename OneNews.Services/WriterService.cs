using OneNews.Data;
using OneNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNews.Services
{
    public class WriterService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        private readonly Guid _authorId;
        public WriterService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateWriter(WriterCreate writer)
        {
            var entity = new Writer

            {
                Name = writer.Name
            };



            _context.Writers.Add(entity);
            return _context.SaveChanges() == 1;

        }
        public IEnumerable<WriterListItem> GetWriters()
        {
            var query =
            _context.Writers.Select(e =>

                        new WriterListItem
                        {
                            Id = e.Id,
                            Name = e.Name,

                        }
                );

            return query.ToArray();

        }

        public WriterDetail GetWriterById(int id)

        {
            var entity =
            _context.Writers
            .Single(e => e.Id == id);

            return
             new WriterDetail
             {
                 Id = entity.Id,
                 Name = entity.Name,
                 Stories = ConvertStoryToListItemForWriter(entity.Stories)
             };
        }
        public ICollection<StoryListItemForWriter> ConvertStoryToListItemForWriter(ICollection<Story> stories)
        {
            var listOfItems = new List<StoryListItemForWriter>();
            foreach (Story story in stories)
            {
               var listItem = new StoryListItemForWriter();
               listItem.Id = story.Id;
               listItem.Title = story.Title;
               listItem.Location = story.Location;
               listItem.DateTimeDisplay = StoryService.DisplayDateTime(story.TimeOfPublication);
               listItem.CategoryName = (_context.Categories.Single(c => c.Id == story.CategoryId)).Name;
                    
               listOfItems.Add(listItem);
               
            }
            return listOfItems;
        }


        public bool UpdateWriter(WriterEdit model)
        {

            var entity =
                _context.Writers
                .Single(e => e.Id == model.Id && e.AuthorId == _authorId);
            entity.Name = model.Name;
            entity.Id = model.Id;





            return _context.SaveChanges() == 1;
        }

        public bool DeleteWriter(int Id)
        {
            var entity =
                _context.Writers
                .Single(e => e.Id == Id && e.AuthorId == _authorId);
            _context.Writers.Remove(entity);
            return _context.SaveChanges() == 1;
        }




    }
}
