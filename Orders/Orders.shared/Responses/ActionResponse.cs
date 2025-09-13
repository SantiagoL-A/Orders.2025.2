namespace Orders.shared.Responses;

public class ActionResponse<T>
{
    public bool WasSucces { get; set; }
    public string? Message { get; set; }
    public T? Result { get; set; }
}