namespace Domain;

public sealed record Result<T>
{
    public Notification Notifcation { get; set; } = new Notification();
    public T? Value { get; set; }
}
