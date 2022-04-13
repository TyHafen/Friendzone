using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Friendzone.Models;
using Friendzone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendzone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FollowsController : ControllerBase
    {
        private readonly FollowsService _fService;
        private readonly AccountService _aService;

        public FollowsController(FollowsService fService, AccountService aService)
        {
            _fService = fService;
            _aService = aService;
        }



        [HttpPost]
        public async Task<ActionResult<Follow>> Create([FromBody] Follow followData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                followData.followerId = userInfo.Id;
                Follow created = _fService.Create(followData);
                return Ok(created);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}