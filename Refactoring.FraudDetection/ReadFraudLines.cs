using System;
using System.Collections.Generic;
using System.IO;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class ReadFraudLines
    {
        public List<Order> ReadOrders(string filePath)
        {
            var orders = new List<Order>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var items = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                CreateListOfOrders(items, ref orders);                
            }
            return orders;
        }

        private List<Order> CreateListOfOrders(string[] item, ref List<Order> orders)
        {
            var order = new Order
            {
                OrderId = int.Parse(item[0]),
                DealId = int.Parse(item[1]),
                Email = item[2].ToLower(),
                Street = item[3].ToLower(),
                City = item[4].ToLower(),
                State = item[5].ToLower(),
                ZipCode = item[6],
                CreditCard = item[7]
            };
            orders.Add(order);
            return orders;
        }

    }
}
