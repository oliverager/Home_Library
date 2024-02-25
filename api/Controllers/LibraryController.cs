using System.ComponentModel.DataAnnotations;
using api.Filters;
using api.TransferModels;
using infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using sarah_library.TransferModels;
using service;

namespace sarah_library.Controllers;

[ApiController]

public class LibraryController : ControllerBase
{

    private readonly ILogger<LibraryController> _logger;
    private readonly BookService _bookService;

    public LibraryController(ILogger<LibraryController> logger, BookService bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    [HttpGet]
    [Route("/api/books")]
    public ResponseDto Get()
    {
        return new ResponseDto()
        {
            MessageToClient = "Successfully fetched",
            ResponseData = _bookService.GetBookForFeed()
        };
    }

    [HttpPost]
    [ValidateModel]
    [Route("/api/book")]
    public ResponseDto Post([FromBody]CreateBookRequestDto dto)
    {
        return new ResponseDto()
        {
            MessageToClient = "Successfully created a book",
            ResponseData = _bookService.CreateBook(dto.Title, dto.Author, dto.Publisher, dto.Rating, dto.SpiceLevel, dto.Description, dto.AddedAt)
        };

    }

    [HttpPut]
    [ValidateModel]
    [Route("/api/book/{bookId}")]
    public ResponseDto Put([FromRoute] int bookId,
        [FromBody] UpdateBookRequestDto dto)
    {
        HttpContext.Response.StatusCode = 201;
        return new ResponseDto()
        {
            MessageToClient = "Successfully Update Book",
            ResponseData =
                _bookService.UpdateBook(dto.BookId, dto.Title, dto.Author, dto.Publisher, dto.Rating, dto.SpiceLevel, dto.Description)
        };
    }

    [HttpDelete]
    [Route("/api/book/{bookId}")]
    public ResponseDto Delete([FromRoute] int bookId)
    {
        _bookService.DeleteBook(bookId);
        return new ResponseDto()
        {
            MessageToClient = "Successfully Delete Book"
        };
    }
    
}