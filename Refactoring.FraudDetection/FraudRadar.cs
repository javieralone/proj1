// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    using System.Collections.Generic;
    
    public class FraudRadar
    {
        public IEnumerable<FraudResult> Check(string filePath)
        {
            var fraudResults = new List<FraudResult>();
            CheckFraud checkFraud = new CheckFraud();
            Normalize normalize = new Normalize();
            ReadFraudLines readFraudLines = new ReadFraudLines();

            // READ FRAUD LINES
            List<Order> orders = readFraudLines.ReadOrders(filePath);
            
            // NORMALIZE
            orders = normalize.NormalizeOrder(orders);

            // CHECK FRAUD
            return fraudResults = checkFraud.CheckFraudulentOrder(orders);
        }
    }
}