using LinkMe.ApplicationServices;
using LinkMe.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LinkMe.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    
    public class CommunitiesController: ControllerBase
    {
        private readonly CreateCommunity.Handler _createCommunityHandler;
        private readonly ISender _sender;

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
