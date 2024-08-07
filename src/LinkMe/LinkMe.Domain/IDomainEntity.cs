namespace LinkMe.Domain
{
    public abstract class DomainEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public User CreatedBy { get; set; }
    }
}
