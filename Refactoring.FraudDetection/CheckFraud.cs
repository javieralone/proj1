using System.Collections.Generic;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class CheckFraud
    {
        public List<FraudResult> CheckFraudulentOrder(List<Order> orders)
        {
            List<FraudResult> fraudResults = new List<FraudResult>();
            Order current = new Order();

            for (int i = 0; i < orders.Count; i++)
            {
                current = orders[i];

                for (int j = i + 1; j < orders.Count; j++)
                {
                    var otherOrder = orders[j];

                    if (current.isFraudulent(otherOrder))
                        fraudResults.Add(new FraudResult { IsFraudulent = true, OrderId = otherOrder.OrderId });

                }
            }
            return fraudResults;
        }
        
    }
}
