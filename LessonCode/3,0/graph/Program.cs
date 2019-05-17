using System;
using System.Collections.Generic;
using System.Threading;
using Graph.Core;

namespace graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            var graphSourcer = new AddableGraphSourcer<double>(1);
            var graphFeed = new GraphFeed<double>();
            var graphRunner = new BasicBitchMathGraphRunner(new List<IMathNode>());

            var graphEngine = new GraphEngine<double, double>(graphSourcer, graphFeed, graphRunner, cancellationTokenSource.Token);

            var results = graphFeed.GetComputedPayloadsAsync().Result;
        }
    }

    public class DefaultPayload<T> : IPayload<T>
    {
        public T Data { get; set; }
    }

    public class ErroredPayload<T> : IPayload<T>
    {
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
