namespace LinkMe.Domain
{
    public class Category : DomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Community> Communities { get; set; }
    }
}
