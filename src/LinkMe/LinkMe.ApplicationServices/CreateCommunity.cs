using LinkMe.Domain;
using LinkMe.Domain.Contracts;

namespace LinkMe.ApplicationServices
{
    public class CreateCommunity
    {
        public class Command
        {
            public string Name { get; set; }
            public string Description { get; set; }
            //public string Category { get; set; }
        }

        public class Handler
        {
            private readonly IBaseRepository<Community> _repository;

            public Handler(IBaseRepository<Community> repository)
            {
                _repository = repository;
            }

            public Community Handle(Command command)
            {
                var community = new Community { Name = command.Name, Description = command.Description };
                return _repository.Add(community);
            }
        }
    }
}
