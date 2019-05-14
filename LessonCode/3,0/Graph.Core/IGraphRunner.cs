using System.Threading.Tasks;

namespace Graph.Core
{
    public interface IGraphRunner<T, T2>
    {
        Task<IPayload<T2>> ComputeAsync(IPayload<T> input);
    }
}
