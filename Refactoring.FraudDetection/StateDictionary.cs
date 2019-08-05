using System.Collections.Generic;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class StateDictionary
    {
        public Dictionary<string, string> FillStates()
        {
            Dictionary<string, string> states = new Dictionary<string, string>();
            states.Add("il", "illinois");
            states.Add("ca", "california");
            states.Add("ny", "new york");
            return states;
        }

        public Dictionary<string, string> FillStreet()
        {
            Dictionary<string, string> streets = new Dictionary<string, string>();
            streets.Add("st", "street");
            streets.Add("rd", "road");
            return streets;
        }

    }
}
