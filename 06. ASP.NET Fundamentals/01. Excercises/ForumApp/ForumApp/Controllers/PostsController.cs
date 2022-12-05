using ForumApp.Data;
using ForumApp.Data.Entities;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly ForumAppDbContext context;

        public PostsController(ForumAppDbContext _context)
        {
            context = _context;
        }
        public IActionResult All()
        {
           var posts = context
                .Posts
                .Select(p=>new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                }).ToList();

            return View(posts);
        }
        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]

        public async Task<IActionResult> Add(PostFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };

            context.Posts.Add(post);
            context.SaveChanges();

            return  Redirect("All");
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var post = await context
                .Posts
                .FindAsync(id);

            if (post == null)
            {
                return BadRequest(404);
            }          
            return View(new PostFormModel()
            {
                Title = post.Title,
                Content=post.Content
            });
                
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, PostFormModel model)
        {
            var post = await context
               .Posts
               .FindAsync(id);

            if (post == null)
            {
                return BadRequest(404);
            }

            post.Title = model.Title;
            post.Content = model.Content;
            context.SaveChanges();

            return RedirectToAction("All");

        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var post = await context
               .Posts
               .FindAsync(id);

            context.Posts.Remove(post);
            context.SaveChanges();

            return RedirectToAction("All");

        }


    }
}
