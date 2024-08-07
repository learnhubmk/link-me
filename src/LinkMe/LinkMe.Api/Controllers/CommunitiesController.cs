using LinkMe.ApplicationServices;
using LinkMe.Domain;

using Microsoft.AspNetCore.Mvc;

namespace LinkMe.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommunitiesController: ControllerBase
    {
        private readonly CreateCommunity.Handler _createCommunityHandler;

        public CommunitiesController(CreateCommunity.Handler createCommunityHandler)
        {
            _createCommunityHandler = createCommunityHandler;
        }

        [HttpPost]
        public Community RegisterCommunity(CreateCommunity.Command community)
        {
            return _createCommunityHandler.Handle(community);
        }
    }
}
