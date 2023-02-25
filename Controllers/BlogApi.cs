using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Context;
using server.Models;
namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogApi : ControllerBase
    {
        public readonly MyDbContext _db;
        public BlogApi(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var blogs = _db.Blogs.ToList();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var blogCurrent = _db.Blogs.SingleOrDefault(blog => blog.BlogId == Guid.Parse(id));
            if (blogCurrent != null)
            {
                return Ok(blogCurrent);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            try
            {
                var blogNew = new Blog
                {
                    BlogId = Guid.NewGuid(),
                    Title = blog.Title,
                    Content = blog.Content,
                    Author = blog.Author,
                    ImageUrl = blog.ImageUrl
                };
                _db.Add(blogNew);
                _db.SaveChanges();
                return Ok(blogNew);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, BlogModel blogUd)
        {
            var blogCurrent = _db.Blogs.SingleOrDefault(blog => blog.BlogId == Guid.Parse(id));
            if (blogCurrent != null)
            {
                blogCurrent.Title = blogUd.Title;
                blogCurrent.Content = blogUd.Content;
                blogCurrent.ImageUrl = blogUd.ImageUrl;
                _db.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var blogCurrent = _db.Blogs.SingleOrDefault(blog => blog.BlogId == Guid.Parse(id));
            if (blogCurrent != null)
            {
                _db.Remove(blogCurrent);
                _db.SaveChanges();

            }
            return NoContent();
        }
    }
}