using Library.Data.Models;
using Library.Models;

namespace Library.Interfaces
{
    public interface IBookService
    {
        //Gets all the created books
        Task<IEnumerable<BookViewModel>> GetAll();

        // Getting the books categories
        Task<IEnumerable<Category>> GetCategories();

        // adding book to collectio
        Task AddBook(AddBookViewModel model);

        // Adding book to mine coolecton
        Task AddBookToMineCollection(int bookId, string userId);

        Task<IEnumerable<BookViewModel>> GetMineBooks(string userId);
        // removing from my collection
        Task RemoveBook(int bookId, string userId);
    }
}
