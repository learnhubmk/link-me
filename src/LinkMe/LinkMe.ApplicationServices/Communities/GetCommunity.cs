using LinkMe.Domain;
using LinkMe.Domain.Contracts;

using MediatR;

namespace LinkMe.ApplicationServices.Communities
{
    public class GetCommunity
    {
        public record Request(int Id)
        : IRequest<Community>
        {
           
        }

        public class Handler(IBaseRepository<Community> _repository)
            : IRequestHandler<Request, Community>
        {
            public async Task<Community> Handle(Request request, CancellationToken cancellationToken)
            {
              
                var result = await _repository.GetAsync(request.Id);

                return  result;
            }
        }
    }
}
