using Microsoft.AspNet.Identity;
using OneNews.Models;
using OneNews.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OneNews.WebAPI.Controllers
{
    [Authorize(Roles = "Admin, Publisher")]
    public class WriterController : ApiController
    {
        private WriterService CreateWriterService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var Service = new WriterService(authorId);
            return Service;
        }

        [HttpPost]
        public IHttpActionResult Post(WriterCreate writer)
        {
            if (writer is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Service = CreateWriterService();
            var isSuccessful = Service.CreateWriter(writer);
            if (!isSuccessful)
            {
                return InternalServerError();
            }
            return Ok("New Writer Created");
        }

        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            WriterService writerService = CreateWriterService();
            var writers = writerService.GetWriters();
            return Ok(writers);
        }

        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            WriterService writerService = CreateWriterService();
            var writer = writerService.GetWriterById(id);
            return Ok(writer);
        }

        public IHttpActionResult Put(WriterEdit writer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateWriterService();

            if (!service.UpdateWriter(writer))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateWriterService();

            if (!service.DeleteWriter(id))
                return InternalServerError();

            return Ok();
        }
    }
}
