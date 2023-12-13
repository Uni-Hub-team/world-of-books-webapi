using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Domain.Configurations;
using WorldOfBooks.Service.Interfaces.Books;
using WorldOfBooks.Service.Service.Books;

namespace WorldOfBooks.WebApi.Controllers.Commons.Books;

public class CommonCommentController : BaseController
{
    private readonly ICommentService _commentService;
    public CommonCommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(long Id)
        => Ok(await _commentService.GetByIdAsync(Id));


    [HttpGet("by-bookId")]
    public async Task<IActionResult> GetAllAsync(long bookId)
        => Ok(await _commentService.GetByBookIdsync(bookId));
}