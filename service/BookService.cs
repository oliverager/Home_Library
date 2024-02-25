using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using infrastructure.DataModels;
using infrastructure.QueryModels;
using infrastructure.Repositories;

namespace service;

public class BookService(BookRepository bookRepository)
{
    private readonly BookRepository _bookRepository = bookRepository;

    public IEnumerable<BookFeedQuery> GetBookForFeed()
    {
        return _bookRepository.GetBookForFeed();
    }

    public Book CreateBook(string title, string author, string publisher, int rating, int spiceLevel, string description, DateTime addedAt)
    {
        
        return _bookRepository.CreateBook(title, author, publisher, rating, spiceLevel, description, addedAt );
    }

    public Book UpdateBook(int bookId, string title, string author, string publisher, int rating, int spiceLevel, string description)
    {
        return _bookRepository.UpdateBook(bookId, title, author, publisher, rating, spiceLevel, description);
    }

    public void DeleteBook(int bookId)
    {
        
        var result = _bookRepository.DeleteBook(bookId);
        if (!result)
        {
            throw new Exception("Could not insert book");
        }
    }
}
