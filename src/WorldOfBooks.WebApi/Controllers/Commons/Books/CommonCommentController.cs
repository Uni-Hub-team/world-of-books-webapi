using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Service.Interfaces.Books;

namespace WorldOfBooks.WebApi.Controllers.Commons.Books;
[Route("api/common/book/comment")]
[ApiController]
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


    [HttpGet("all/{bookId}")]
    public async Task<IActionResult> GetAllAsync(long bookId)
        => Ok(await _commentService.GetByBookIdsync(bookId));
}