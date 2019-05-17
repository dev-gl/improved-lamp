using Graph.Core;

namespace graph
{
    public interface IMathNode
    {
        IPayload<double> Math(IPayload<double> payload);
    }
}