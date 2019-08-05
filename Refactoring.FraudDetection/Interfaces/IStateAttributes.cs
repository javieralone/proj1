using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public interface IStateAttributes
    {
        string Street { get; set; }

        string City { get; set; }

        string State { get; set; }

        string ZipCode { get; set; }
    }
}
