namespace Hospital.SharedKernel
{
    public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateAt { get; set; }
    public bool IsDeleted { get; set; }

}
}