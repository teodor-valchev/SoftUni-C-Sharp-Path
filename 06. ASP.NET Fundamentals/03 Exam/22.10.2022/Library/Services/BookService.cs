using Library.Data;
using Library.Data.Models;
using Library.Interfaces;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }
        //adding a book to DB
        public async Task AddBook(AddBookViewModel model)
        {
            var entity = new Book()
            {
                Author = model.Author,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Description = model.Description,
                Title = model.Title
            };

            await context.Books.AddAsync(entity);
            await context.SaveChangesAsync();
        }


        // adiing the books to mine collection
        public async Task AddBookToMineCollection(int bookId, string userId)
        {
            var user = await context.Users
                 .Where(u => u.Id == userId)
                 .Include(u => u.ApplicationUsersBooks)
                 .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user");
            }

            var book = await context.Books.FirstOrDefaultAsync(u => u.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException("Invalid Bookd");
            }

            if (!user.ApplicationUsersBooks.Any(b => b.BookId == bookId))
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    BookId = bookId,
                    ApplicationUser = user,
                    Book = book,
                    ApplicationUserId = userId
                });

                await context.SaveChangesAsync();
            }
            }
        // getting all the books
        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            var entities = await context.Books
                .Include(b => b.Category)
                .ToListAsync();

            return entities
                .Select(b => new BookViewModel()
                {
                    Author = b.Author,
                    Category = b?.Category?.Name,
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Title = b.Title
                });
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<BookViewModel>> GetMineBooks(string userId)
        {
            var user = await context.Users .Where(u => u.Id == userId).Include(u => u.ApplicationUsersBooks)
               .ThenInclude(um => um.Book)
               .ThenInclude(m => m.Category)
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }
            return user.ApplicationUsersBooks
                .Select(b => new BookViewModel()
                {
                    Author = b.Book.Author,
                    Category = b.Book.Category?.Name,
                    Id = b.BookId,
                    ImageUrl = b.Book.ImageUrl,
                    Title = b.Book.Title,
                    Rating = b.Book.Rating,
                });
        }

        public async Task RemoveBook(int bookId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var book = user.ApplicationUsersBooks.FirstOrDefault(b=>b.BookId == bookId);



            if (book != null)
            {
                user.ApplicationUsersBooks.Remove(book);

                await context.SaveChangesAsync();
            }
    }
}}
