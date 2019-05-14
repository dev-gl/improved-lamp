using System.Collections.Generic;
using System.Threading.Tasks;

namespace Graph.Core
{
    public interface IGraphFeed<T>
    {
        Task EnqueueAsync(IPayload<T> payload);
        Task<IEnumerable<IPayload<T>>> GetComputedPayloads();
    }
}