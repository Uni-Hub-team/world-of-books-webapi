using Microsoft.AspNetCore.Mvc;
using WorldOfBooks.Persistence.Dtos.Books;
using WorldOfBooks.Persistence.Dtos.Comments;
using WorldOfBooks.Service.Interfaces.Books;
using WorldOfBooks.Service.Service.Books;

namespace WorldOfBooks.WebApi.Controllers.User.Comments;
[Route("api/user/book/comment")]
[ApiController]
public class UserCommentController : BaseUserController
{
    private readonly ICommentService _commentService;
    public UserCommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CommentCreationDto dto)
       => Ok(await _commentService.CreateAsync(dto));

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(long Id)
       => Ok(await _commentService.DeleteAsync(Id));
}