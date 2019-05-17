using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Graph.Core;

namespace graph
{
    public class AbstractSourcer<T,T2> : IGraphSourcer<T>
    {
        private IGraphSourcer<T2> _internalSourcer;
        private readonly Func<T2, T> _mapFunc;

        public AbstractSourcer(IGraphSourcer<T2> internalSourcer, Func<T2, T> mapFunc)
        {
            _internalSourcer = internalSourcer;
            _mapFunc = mapFunc;
        }

        public async Task<IEnumerable<IPayload<T>>> GetPayloadsAsync()
        {
            var abstractTerms = await _internalSourcer.GetPayloadsAsync();

            var castedTerms = abstractTerms
                .Select(x => 
                    new DefaultPayload<T>
                    {
                        Data = _mapFunc(x.Data)
                    });

            return castedTerms;
        }
    }

    public class AddableGraphSourcer<T> : IGraphSourcer<T>
    {
        Queue<T> _internalBuffer = new Queue<T>();

        private readonly int MaxReturnSize;

        public AddableGraphSourcer(int maxReturnSize)
        {
            MaxReturnSize = maxReturnSize;
        }

        public void AddData(T item)
        {
            _internalBuffer.Enqueue(item);
        }

        public async Task<IEnumerable<IPayload<T>>> GetPayloadsAsync()
        {
            var batch = new List<IPayload<T>>();
            var count = 0;

            while (count < MaxReturnSize && _internalBuffer.TryDequeue(out var item))
            {
                batch.Add(new DefaultPayload<T>{Data = item});
                count++;
            }

            return await Task.FromResult(batch);
        }
    }
}