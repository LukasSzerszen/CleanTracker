namespace Domain;

public sealed class Result<T>
{
    public Notifcation Notifcation { get; set; }
    public T? Value { get; set; }
}
