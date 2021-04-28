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
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var categotyService = new CategoryService(authorId);
            return categotyService;
        }

        public IHttpActionResult Post(CategoryCreate model)
        {
            if (model is null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = CreateCategoryService();
            bool isSuccessful = category.CreateCategory(model);
            if (isSuccessful)
            {
                return Ok($"Category Created:{model.Name}");
            }
            return InternalServerError();
        }

        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            CategoryService categoryService = CreateCategoryService();
            var categories = categoryService.GetCategories();
            return Ok(categories);
        }

        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetCategorybyId(id);
            return Ok(category);
        }

        public IHttpActionResult Put(CategoryEdit category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryService = CreateCategoryService();
            if (!categoryService.UpdateCategory(category))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var categoryService = CreateCategoryService();

            if (!categoryService.DeleteCategory(id))
                return InternalServerError();

            return Ok();
        }
    }
}
