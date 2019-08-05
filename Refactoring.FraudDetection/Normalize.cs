using System;
using System.Collections.Generic;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Interfaces;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class Normalize
    {
        StateDictionary dictionary = new StateDictionary();

        private IStateAttributes NormalizeStreet(IStateAttributes AnyObject)
        {
            var dicStreet = dictionary.FillStreet();

            foreach (KeyValuePair<string, string> keyValuePair in dicStreet)
            {
                AnyObject.Street = AnyObject.Street.Replace(keyValuePair.Key, keyValuePair.Value);
            }
            return AnyObject;
        }

        private IStateAttributes NormalizeState(IStateAttributes AnyObject)
        {
            var dicStates = dictionary.FillStates();
            foreach (KeyValuePair<string, string> keyValuePair in dicStates)
            {
                AnyObject.State = AnyObject.State.Replace(keyValuePair.Key, keyValuePair.Value);
            }
            return AnyObject;
        }

        private IEmailAttributes NormalizeEmail(IEmailAttributes AnyObject)
        {
            var aux = AnyObject.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            AnyObject.Email = string.Join("@", new string[] { aux[0], aux[1] });

            return AnyObject;
        }

        public List<Order> NormalizeOrder(List<Order> orders)
        {
            foreach (var order in orders)
            {
                ////Normalize email
                NormalizeEmail(order);

                //Normalize street
                NormalizeStreet(order);

                //Normalize state
                NormalizeState(order);
            }

            return orders;
        }
    }
}
