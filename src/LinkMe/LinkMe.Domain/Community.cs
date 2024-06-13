namespace LinkMe.Domain
{
    public class Community : DomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
