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
    public class StoryController : ApiController
    {
        private StoryService CreateStoryService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var storyService = new StoryService(authorId);
            return storyService;
        }

        public IHttpActionResult Post(StoryCreate model)
        {
            var service = CreateStoryService();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!service.CreateStory(model))
                return InternalServerError();
            return Ok($"The story '{model.Title}' has been published.");
        }

        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            var service = CreateStoryService();
            var stories = service.GetAllStories();
            return Ok(stories);
        }
        
        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            var service = CreateStoryService();
            var story = service.GetStoryById(id);
            return Ok(story);
        }

        public IHttpActionResult Put(StoryEdit model)
        {
            var service = CreateStoryService();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!service.UpdateStory(model))
                return InternalServerError();
            return Ok($"The story '{model.Title}' has been updated.");
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateStoryService();
            if (!service.DeleteStory(id))
                return InternalServerError();
            return Ok("Story has been deleted.");
        }
    }
}