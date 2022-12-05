using Library.Interfaces;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class Books : Controller
    {
        private readonly IBookService bookService;

        public Books(IBookService _bookService)
        {
            bookService = _bookService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAll();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddBookViewModel()
            {
                Categories = await bookService.GetCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await bookService.AddBook(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Went wrong!");

                return View(model);
            }
        }

        public async Task<IActionResult> AddToCollection(int bookId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => 
                c.Type == ClaimTypes.NameIdentifier)?.Value;
                await bookService.AddBookToMineCollection(bookId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.Claims.FirstOrDefault(c =>
            c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await bookService.GetMineBooks(userId);

            return View("Mine", model);
        }

        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var userId = User.Claims.FirstOrDefault(c =>
            c.Type == ClaimTypes.NameIdentifier)
                ?.Value;
            await bookService.RemoveBook(bookId, userId);

            return RedirectToAction(nameof(Mine));
        }
    }
}
