using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Graph.Core
{
    public sealed class GraphEngine<T, T2>
    {
        private readonly CancellationToken _cancellationToken;
        private IGraphSourcer<T> Source { get; set; }
        private IGraphFeed<T2> Output { get; set; }
        private IGraphRunner<T, T2> GraphRunner { get; set; }
        private Queue<IPayload<T>> _buffer = new Queue<IPayload<T>>();
        private Task _internalTask;

        public GraphEngine(IGraphSourcer<T> source, IGraphFeed<T2> output, IGraphRunner<T, T2> graphRunner, CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            Source = source;
            Output = output;
            GraphRunner = graphRunner;

            _internalTask = Run();
        }
        
        private async Task Run()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                await RunInternalAsync();
                await Task.Delay(TimeSpan.FromMilliseconds(25), _cancellationToken);
            }
        }

        private async Task RunInternalAsync()
        {
            try
            {
                if (_buffer.Peek() == null)
                {
                    foreach (var item in await Source
                        .GetPayloadsAsync()
                        .ConfigureAwait(false))
                    {
                        _buffer.Enqueue(item);
                    }
                }

                if (_buffer.Peek() == null)
                    return;

                var dequeued = _buffer.Dequeue();

                var result = await GraphRunner
                    .ComputeAsync(dequeued)
                    .ConfigureAwait(false);

                await Output.EnqueueAsync(result).ConfigureAwait(false);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
