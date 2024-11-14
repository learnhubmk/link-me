using LinkMe.ApplicationServices.Communities;
using LinkMe.Domain;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace LinkMe.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    
    public class CommunitiesController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<Community> RegisterCommunity(RegisterCommunity.Request request) => 
            await sender.Send(request);
    }
}
