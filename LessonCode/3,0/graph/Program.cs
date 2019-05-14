using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Graph.Core;

namespace graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            var graphSourcer = new GraphSourcer<int>();
            var graphFeed = new GraphFeed<int>();
            var graphRunner = new GraphRunner<int, int>();
            
            var graphEngine = new GraphEngine<int, int>(graphSourcer, graphFeed, graphRunner, cancellationTokenSource.Token);

            Thread.Sleep(TimeSpan.FromSeconds(30));

            var results = graphFeed.GetComputedPayloadsAsync().Result;
        }
    }

    internal class GraphFeed<T> : IGraphFeed<T>
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

    internal class GraphSourcer<T> : IGraphSourcer<T>
    {
        public Task<IEnumerable<IPayload<T>>> GetPayloadsAsync()
        {
            throw new NotImplementedException();
        }
    }

    internal class GraphRunner<T, T2> : IGraphRunner<T, T2>
    {
        public Task<IPayload<T2>> ComputeAsync(IPayload<T> input)
        {
            throw new NotImplementedException();
        }
    }
}
