using allspice.Services;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TagsController : ControllerBase
  {
    private readonly TagsService _tagsService;

    public TagsController(TagsService tagsService)
    {
      _tagsService = tagsService;
    }
  }
}