using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StipePaymentDotNet48
{
    public static class StripePayment
    {
        // Set your secret key. Remember to switch to your live secret key in production.
        // See your keys here: https://dashboard.stripe.com/apikeys
        public static string StripeSecreatApiKey = "sk_test_51LCf5WBRmSsrBJTcHEHl9L1crIzPWsbUim9kgXS76adIo92S7gbweyKBg6WzByLzs5OnD8mkCr4ACDCCIShecdfn00lMxX4hfh";

        public static string TestUserName = "Miyamoto Musashi";
        public static string TestUserAddress = "Miyamoto Musashi";
        public static string TestCardNumb = "4242424242424242";
        public static long TestAmount = 20000; // including 2 digit decimal

        private static CreditCardModel _creditCardModel;
        private static TokenService Tokenservice;
        private static Token stripeToken;
        private static bool _isCarcValid;
        private static bool _isTransectionSuccess;


        public static string CustomerCreateOptions()
        {
            try
            {
                StripeConfiguration.ApiKey = StripeSecreatApiKey;

                var options = new CustomerCreateOptions { 
                    Name = TestUserName,
                    Address = new AddressOptions
                    {
                        Line1 = "Line 1",
                        Line2 = "Line 2",
                        City = "City",
                        State = "State",
                        Country = "Singapore",
                        PostalCode = 099419
                    },

                };

                var service = new CustomerService();
                var customer = service.Create(options);
                return customer.Id;
            }
            catch (Exception ex)
            {
                return null;
                Console.WriteLine(ex.Message);
            }
        }

        public static void SetupIntentCreateOptions(string CustomerId)
        {
            try
            {

                StripeConfiguration.ApiKey = StripeSecreatApiKey;

                var options = new SetupIntentCreateOptions
                {
                    Customer = CustomerId,
                    
                    //PaymentMethodTypes = new List<string> { "bancontact", "card", "ideal" },
                };
                var service = new SetupIntentService();
                service.Create(options);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async void PayCommand()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                await Task.Run(async () =>
                {

                    var Token = CreateToken();
                    Console.Write("Payment Gateway" + "Token :" + Token);
                    if (Token != null)
                    {
                        _isTransectionSuccess = MakePayment(Token);
                    }
                    else
                    {
                    }
                });
            }
            catch (Exception ex)
            {
                Console.Write("Payment Gatway" + ex.Message);
            }
            finally
            {
                if (_isTransectionSuccess)
                {
                    Console.Write("Payment Gateway" + "Payment Successful ");
                }
                else
                {
                    Console.Write("Payment Gateway" + "Payment Failure ");
                }
            }

        }

        public static bool MakePayment(string token)
        {
            try
            {
                StripeConfiguration.SetApiKey(StripeSecreatApiKey);
                var options = new ChargeCreateOptions
                {
                    Amount = (long)float.Parse("20000"),
                    Currency = "sgd",
                    Description = "Charge for customer",
                    Source = stripeToken.Id,
                    StatementDescriptor = "TEST",
                    Capture = true,
                };
                //Make Payment
                var service = new ChargeService();
                Charge charge = service.Create(options);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Payment Gatway (CreateCharge)" + ex.Message);
                throw ex;
            }
        }


        private static string CreateToken()
        {
            try
            {
                StripeConfiguration.SetApiKey(StripeSecreatApiKey);
                var service = new ChargeService();
                var Tokenoptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        //Number = CreditCardModel.Number,
                        //ExpYear = CreditCardModel.ExpYear,
                        //ExpMonth = CreditCardModel.ExpMonth,
                        //Cvc = CreditCardModel.Cvc,
                        Number = TestCardNumb,
                        ExpMonth = 12,
                        ExpYear = 25,
                        Cvc = "123",
                        Name = TestUserName,
                        Currency = "sgd",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
