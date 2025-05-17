namespace Models.Entitys
{
    public interface EntityInterface
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
