using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Graph.Core;

namespace graph
{
    public class BasicBitchMathGraphRunner : IGraphRunner<double, double>
    {
        private IEnumerable<IMathNode> _nodes;

        public BasicBitchMathGraphRunner(IEnumerable<IMathNode> nodes)
        {
            _nodes = nodes;
        }

        public Task<IPayload<double>> ComputeAsync(IPayload<double> input)
        {
            var next = input;

            foreach (var mathNode in _nodes)
            {
                next = mathNode.Math(next);
            }

            return Task.FromResult(next);
        }
    }
}