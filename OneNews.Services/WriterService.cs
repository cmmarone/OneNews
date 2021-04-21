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

        private readonly Guid _userId;

        public WriterService(Guid userId)
        {
            _userId = userId;


        }
        public bool CreateWriter(WriterCreate model)
        {

            new Writer()
            {

            };


        }
    }
}
