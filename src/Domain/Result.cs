namespace Domain;

public sealed record Result<T>
{
    public Notification Notifcation { get; set; }
    public T? Value { get; set; }
}
