using Dapper;
using Npgsql;
using System.Collections.Generic;
using infrastructure.DataModels;
using infrastructure.QueryModels;

namespace infrastructure.Repositories
{
    public class BookRepository
    {
        private NpgsqlDataSource _dataSource;

        public BookRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<BookFeedQuery> GetBookForFeed()
        {
            string sql = $@"
                SELECT book_id as {nameof(BookFeedQuery.BookId)},
                    title as {nameof(BookFeedQuery.Title)},
                    author as {nameof(BookFeedQuery.Author)},
                    publisher as {nameof(BookFeedQuery.Publisher)},
                    rating as {nameof(BookFeedQuery.Rating)},
                    spice_level as {nameof(BookFeedQuery.SpiceLevel)},
                    description as {nameof(BookFeedQuery.Description)},
                    added_at as {nameof(BookFeedQuery.AddedAt)},
                    cover_url as {nameof(BookFeedQuery.CoverUrl)}
                FROM library.book;
            ";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<BookFeedQuery>(sql);
            }
        }

        public Book CreateBook(string title, string author, string publisher, int rating, int spiceLevel, string description, DateTime addedAt, string coverUrl)
        {
            var sql = $@"
INSERT INTO library.book (title, author, publisher, rating, spice_level, description, added_at, cover_url) 
VALUES (@title, @author, @publisher, @rating, @spiceLevel, @description, @addedAt, @coverUrl)
RETURNING book_id as {nameof(Book.BookId)},
            title as {nameof(Book.Title)},
            author as {nameof(Book.Author)},
            publisher as {nameof(Book.Publisher)},
            rating as {nameof(Book.Rating)},
            spice_level as {nameof(Book.SpiceLevel)},
            description as {nameof(Book.Description)},
            added_at as {nameof(Book.AddedAt)},
            cover_url as {nameof(Book.CoverUrl)}
";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<Book>(sql, new { title, author, publisher, rating, spiceLevel, description, addedAt, coverUrl });
            }
        }
        
        public Book UpdateBook(int bookId, string title, string author, string publisher, int rating, int spiceLevel, string description, string coverUrl)
        {
            var sql = $@"
UPDATE library.book SET title = @title, author = @author, publisher = @publisher, rating = @rating, spice_level = @spiceLevel, description = @description, cover_url = @coverUrl
WHERE book_id = @bookId
RETURNING book_id as {nameof(Book.BookId)},
            title as {nameof(Book.Title)},
            author as {nameof(Book.Author)},
            publisher as {nameof(Book.Publisher)},
            rating as {nameof(Book.Rating)},
            spice_level as {nameof(Book.SpiceLevel)},
            description as {nameof(Book.Description)},
            cover_url as {nameof(Book.CoverUrl)}
";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<Book>(sql, new {bookId, title, author, publisher, rating, spiceLevel, description, coverUrl });
            }
        }

        public bool DeleteBook(int bookId)
        {
            var sql = @"DELETE FROM library.book WHERE book_id = @bookId;";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Execute(sql, new { bookId }) == 1;
            }
        }

        public bool DoesBookWithTitleExist(string title)
        {
            var sql = @"SELECT COUNT(*) FROM library.book WHERE title = @title;";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.ExecuteScalar<int>(sql, new { title }) == 1;
            }
        }
    }
}