using LinkMe.Domain;
using LinkMe.Domain.Contracts;

using MediatR;

namespace LinkMe.ApplicationServices.Communities
{
    public class RegisterCommunity
    {
        public record Request(string Name, string Description)
        : IRequest<Community>
        {
            //public string Category { get; set; }
            public Community ToCommunity() =>
                new() { Name = Name, Description = Description };
        }

        public class Handler(IBaseRepository<Community> _repository)
            : IRequestHandler<Request, Community>
        {
            public async Task<Community> Handle(Request request, CancellationToken cancellationToken)
            {
                var entity = request.ToCommunity();
                var result = await _repository.AddAsync(entity);
                return result;
            }
        }
    }
}
