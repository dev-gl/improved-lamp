using System;
using Graph.Core;

namespace graph.MathNodes
{
    public class SquareNode : IMathNode
    {
        private double maxVal = System.Math.Sqrt(double.MaxValue);

        public IPayload<double> Math(IPayload<double> payload)
        {
            if(payload == null)
                return new ErroredPayload<double>
                {
                    ErrorMessage = "null payload"
                };

            if (payload is ErroredPayload<double>)
                return payload;

            var inVal = payload.Data;

            if (inVal > maxVal || inVal*-1 > maxVal)
                return new ErroredPayload<double>
                {
                    Data = inVal,
                    ErrorMessage = "Too big to Square"
                };

            return new DefaultPayload<double>
            {
                Data = inVal * inVal
            };
        }
    }
}
