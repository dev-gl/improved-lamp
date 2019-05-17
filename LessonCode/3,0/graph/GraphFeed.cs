using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Graph.Core;

namespace graph
{
    public class GraphFeed<T> : IGraphFeed<T>
    {
        public Task EnqueueAsync(IPayload<T> payload)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IPayload<T>>> GetComputedPayloadsAsync()
        {
            throw new NotImplementedException();
        }
    }
}