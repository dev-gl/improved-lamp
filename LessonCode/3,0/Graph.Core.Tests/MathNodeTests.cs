using graph;
using graph.MathNodes;
using NUnit.Framework;

namespace Graph.Core.Tests
{
    [TestFixture]
    public class SquareNodeTests
    {
        [Test]
        public void AssertNeverOverflows()
        {
            var testNode = new SquareNode();

            Assert.IsInstanceOf(typeof(ErroredPayload<double>), testNode.Math(new DefaultPayload<double>{ Data = double.MaxValue}));
        }

        [Test]
        public void AssertDoesNotThrow()
        {
            var testNode = new SquareNode();

            Assert.IsInstanceOf(typeof(ErroredPayload<double>), testNode.Math(null));
        }

        [Test]
        public void AssertReturnsCorrectValue()
        {
            var testNode = new SquareNode();

            Assert.AreEqual(25, testNode.Math(new DefaultPayload<double>{ Data = 5 }).Data);
        }

        [Test]
        public void AssertNegativeBigBoiIsError()
        {
            var testNode = new SquareNode();

            Assert.IsInstanceOf(typeof(ErroredPayload<double>), testNode.Math(new DefaultPayload<double>{ Data = double.MinValue }));
        }

        [Test]
        public void AssertSquareDoesNotTransformErroredPayload()
        {
            var testNode = new SquareNode();

            Assert.AreNotEqual(4.0, testNode.Math(new ErroredPayload<double>{ Data = 2 }).Data);
        }
    }
}
