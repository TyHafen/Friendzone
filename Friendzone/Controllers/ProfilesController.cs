using System.Collections.Generic;
using Friendzone.Models;
using Friendzone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendzone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProfilesController : ControllerBase
    {
        private readonly FollowsService _fService;

        public ProfilesController(FollowsService fService)
        {
            _fService = fService;
        }
        [HttpGet("{id}/follows")]
        public ActionResult<List<FollowViewModel>> GetProfileFollows(string id)
        {
            try
            {
                List<FollowViewModel> follows = _fService.GetProfileFollows(id);
                return Ok(follows);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}