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
                 


             };
        }
        public ICollection<StoryListItem> ConvertStoryBaseModelToListItem(ICollection<Story> stories)
        {
            var listOfItems = new List<StoryListItem>();
            var serviceStory = new StoryService();
            foreach (Story story in stories)
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


        public bool UpdateWriter(WriterEdit model)
        {

            var entity =
                _context.Writers
                .Single(e => e.Id == model.Id);
            entity.Name = model.Name;
            entity.Id = model.Id;





            return _context.SaveChanges() == 1;
        }

        public bool DeleteWriter(int Id)
        {
            var entity =
                _context.Writers
                .Single(e => e.Id == Id);
            _context.Writers.Remove(entity);
            return _context.SaveChanges() == 1;
        }




    }
}
