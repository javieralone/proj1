using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Interfaces;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class Order: IStateAttributes, IEmailAttributes
    {
        public int OrderId { get; set; }

        public int DealId { get; set; }

        public string Email { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string CreditCard { get; set; }

        public bool isFraudulent(Order otherOrder)
        {
            return CheckOnDealidEmailCreditCard(otherOrder) || CheckOnDealidStateZipcodeStreetCityCreditCard(otherOrder);
        }

        private bool CheckOnDealidEmailCreditCard(Order otherOrder)
        {
            return this.DealId == otherOrder.DealId && this.Email == otherOrder.Email && this.CreditCard != otherOrder.CreditCard;
        }

        private bool CheckOnDealidStateZipcodeStreetCityCreditCard(Order otherOrder)
        {
            return this.DealId == otherOrder.DealId
                                   && this.State == otherOrder.State
                                   && this.ZipCode == otherOrder.ZipCode
                                   && this.Street == otherOrder.Street
                                   && this.City == otherOrder.City
                                   && this.CreditCard != otherOrder.CreditCard;
        }
    }
}
