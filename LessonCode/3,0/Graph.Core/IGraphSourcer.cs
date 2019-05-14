using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Graph.Core
{
    public interface IGraphSourcer<T>
    {
        Task<IEnumerable<IPayload<T>>> GetPayloadsAsync();
    }
}