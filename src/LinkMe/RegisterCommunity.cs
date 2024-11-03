using System;

public class RegisterCommunity
{
	public record RegisterCommunityCommand(string Name, int level ):IRequest<int>

	{
        public string Name { get; set; }=string.Empty;
		public int Level { get; set; }


    }

	public class RegisterCommunityHandler:IRequestHandler<RegisterCommunityCommand, int>

	{



	}

    public RegisterCommunity()
    {
        
    }

}
