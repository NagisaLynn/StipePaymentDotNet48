using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StipePaymentDotNet48
{
    public class PaymentCard
    {
        public long VIPMasterId { get; set; }
        public long ExpMonth { get; set; }
        public long ExpYear { get; set; }
        public string CVV { get; set; }
        public string CardHolderName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressState { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public string AddressZip { get; set; }
    }

    public class PaymentModel
    {
        /// <summary>
        /// Gets or sets the payment token from client.
        /// </summary>
        public string VipMasterId { get; set; }
        public string Token { get; set; }
        public long Amount { get; set; }
        public string Description { get; set; }
    }
}
