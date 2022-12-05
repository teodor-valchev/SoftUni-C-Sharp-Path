namespace BookShop
{
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            var context = new BookShopContext();

            //var input = int.Parse(Console.ReadLine());
            var result = GetMostRecentBooks(context);
            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => new { b.Title })
                .OrderBy(b => b.Title)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {

                sb.AppendLine($"{book.Title}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                  .Where(b => b.EditionType == Models.Enums.EditionType.Gold && b.Copies < 5000)
                  .Select(b => new
                  {
                      b.Title,
                      b.BookId
                  })
                  .OrderBy(b => b.BookId)
                  .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in goldenBooks)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                  .Where(b => b.Price > 40)
                  .OrderByDescending(b => b.Price)
                  .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                 .Where(y => y.ReleaseDate.Value.Year != year)
                 .OrderBy(b => b.BookId)
                 .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            var books = context.Books
                            .Select(b => new
                            {
                                b.Title,
                                BookCategories = b.BookCategories.Select(bc => bc.Category.Name).ToList()
                            })
                            .OrderBy(b => b.Title)
                            .ToList()
                            .Where(b =>
                            {
                                var inputToLower = categories.Select(c => c.ToLower()).ToList();
                                var categoriesToLower = b.BookCategories.Select(bc => bc.ToLower()).ToList();

                                var intersectedCollection = inputToLower.Intersect(categoriesToLower).ToList();
                                return intersectedCollection.Count > 0;
                            });

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime newdate = Convert.ToDateTime(date);

            var books = context.Books
                 .Where(x => x.ReleaseDate < newdate)
                 .Select(x => new
                 {
                     x.Title,
                     x.EditionType,
                     x.Price,
                     ReleaseDate = x.ReleaseDate

                 }).OrderByDescending(x => x.ReleaseDate)
                 .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(f => f.FirstName.EndsWith(input))
                .ToArray()
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(f => f.FullName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
              .Where(b => b.Title.ToLower().Contains(input.ToLower()))
              .OrderBy(b => b.Title)
              .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var author in books)
            {
                sb.AppendLine($"{author.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
             .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
             .Select(b => new
             {
                 FullName = $"{b.Author.FirstName} {b.Author.LastName}",
                 b.BookId,
                 b.Title
             })
             .OrderBy(b => b.BookId)
             .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.FullName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var bookCount = context.Books
                .Where(t => t.Title.Length > lengthCheck)
                .Count();

            return bookCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                                     .Include(a => a.Books)
                                     .Select(a => new
                                     {
                                         FullName = $"{a.FirstName} {a.LastName}",
                                         CountOfBookCopies = a.Books.Select(b => b.Copies).Sum()
                                     })
                                     .OrderByDescending(a => a.CountOfBookCopies)
                                     .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var book in authors)
            {
                sb.AppendLine($"{book.FullName} - {book.CountOfBookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                 .Include(b => b.CategoryBooks)
                 .ThenInclude(b => b.Book)
                 .ToArray()
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                    .Select(x => x.Book.Copies * x.Book.Price)
                    .Sum()

                }).OrderByDescending(c => c.TotalProfit)
                .ToList();


            StringBuilder sb = new StringBuilder();
            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Include(b => b.CategoryBooks)
                .ThenInclude(b => b.Book)
                .ToArray()
               .Select(c => new
               {
                  CategoryName= c.Name,
                   BookName = c.CategoryBooks
                   .Select(b => new
                   {
                       b.Book.Title,
                       b.Book.ReleaseDate
                   }).OrderByDescending(b=>b.ReleaseDate)
                      .Take(3)
                     .ToArray()
               })
               .OrderBy(c=>c.CategoryName)
               .ToList();


            StringBuilder sb = new StringBuilder();
            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.BookName)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }


            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                          .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();


        }

        public static int RemoveBooks(BookShopContext context)
        {
           var books = context.Books
                .Where(b => b.Copies < 4200);

            var booksDeleted = books.Count();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return booksDeleted;
        }
    }
}
