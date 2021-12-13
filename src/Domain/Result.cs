namespace Domain;

public sealed class Result<T>
{
    public Notification Notifcation { get; set; }
    public T? Value { get; set; }
}
