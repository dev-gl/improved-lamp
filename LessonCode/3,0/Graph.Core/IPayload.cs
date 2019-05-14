namespace Graph.Core
{
    public interface IPayload<T>
    {
        T Data { get; set; }
    }
}
