using System;
using System.Linq;
using System.Threading.Tasks;
using graph;
using Graph.Core;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AdderGraphSourcerTests
    {
        [Test]
        public void Does_Not_Throw()
        {
            var sourcer = new AddableGraphSourcer<int>(1);

            Assert.DoesNotThrowAsync(sourcer.GetPayloadsAsync);
        }

        [Test]
        public async Task Returns_Data_If_Has()
        {
            var sourcer = new AddableGraphSourcer<int>(1);

            sourcer.AddData(1);

            var payloads = await sourcer.GetPayloadsAsync();

            Assert.AreEqual(1, payloads.Count());
        }

        [TestCase(1, ExpectedResult = 1)]
        [TestCase(5, ExpectedResult = 5)]
        public async Task<int> Returns_Data_UptoMax_If_Has(int max)
        {
            var sourcer = new AddableGraphSourcer<int>(max);

            foreach (var i in Enumerable.Range(0, 50))
            {
                sourcer.AddData(1);
            }

            var payloads = await sourcer.GetPayloadsAsync();

            return payloads.Count();
        }
    }

    [TestFixture]
    public class AbstractSourcerTests
    {
        [Test]
        public async Task ReturnsAllElementsOfInternalSource()
        {
            var internalSourcer = Substitute.For<IGraphSourcer<long>>();
                internalSourcer
                .GetPayloadsAsync()
                .Returns(new IPayload<long>[]
                {
                    new DefaultPayload<long>
                    {
                        Data = 1L
                    },
                    new DefaultPayload<long>
                    {
                        Data = 1L
                    },
                    new DefaultPayload<long>
                    {
                        Data = 1L
                    },
                    new DefaultPayload<long>
                    {
                        Data = 1L
                    },
                    new DefaultPayload<long>
                    {
                        Data = 1L
                    },
                });

            var AbstractSourcer = new AbstractSourcer<int, long>(internalSourcer, (x) => (int) x);

            var res = await AbstractSourcer.GetPayloadsAsync();
            Assert.AreEqual(5, res.Count());
        }
    }
}