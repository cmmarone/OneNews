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
    [Authorize]
    public class StoryController : ApiController
    {
        private readonly StoryService _service = new StoryService();

        public IHttpActionResult Post(StoryCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_service.CreateStory(model))
                return InternalServerError();
            return Ok($"The story '{model.Title}' has been published.");
        }

        public IHttpActionResult Get()
        {
            var stories = _service.GetAllStories();
            return Ok(stories);
        }

        public IHttpActionResult Get(int id)
        {
            var story = _service.GetStoryById(id);
            return Ok(story);
        }

        public IHttpActionResult Put(StoryEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_service.UpdateStory(model))
                return InternalServerError();
            return Ok($"The story '{model.Title}' has been updated.");
        }

        public IHttpActionResult Delete(int id)
        {
            if (!_service.DeleteStory(id))
                return InternalServerError();
            return Ok("Story has been deleted.");
        }
    }
}