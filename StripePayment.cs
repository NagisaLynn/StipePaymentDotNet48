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
        public static string StripePublishableApiKey = "pk_test_51LCf5WBRmSsrBJTc1c6yUy8MuA6pT5tOWRE5TL2kGCNlnUgGTZPl5XWD0EpP26DHj5skOIKPEHnwaIZj5UFbxYsQ009i8xSWFF";
        public static string StripeSecretApiKey = "sk_test_51LCf5WBRmSsrBJTcHEHl9L1crIzPWsbUim9kgXS76adIo92S7gbweyKBg6WzByLzs5OnD8mkCr4ACDCCIShecdfn00lMxX4hfh";

        public static string TestUserName = "Miyamoto Musashi";
        public static string TestCardNumb = "4242424242424242";
        public static string TestUserInfo = "cus_LxTGIsP7ioXDE5";
        public static string CardRequestId = "card_1LFYKRBRmSsrBJTcYj9jcMsI";
        public static long TestAmount = 20000; // including 2 digit decimal

        private static CreditCardModel _creditCardModel;
        private static TokenService Tokenservice;
        private static Token stripeToken;
        private static bool _isCarcValid;
        private static bool _isTransectionSuccess;
        public static bool PayAsCustomerorGuest; // true for customer and false for guest


        public static string CustomerCreateOptions()
        {
            try
            {
                StripeConfiguration.ApiKey = StripeSecretApiKey;

                var options = new CustomerCreateOptions { 
                    Name = TestUserName,
                    Address = new AddressOptions
                    {
                        Line1 = "Line 1",
                        Line2 = "Line 2",
                        City = "City",
                        State = "State",
                        Country = "Singapore",
                        PostalCode = "099419"
                    },
                    Description = "Test Customer",
                    Email = "test@gmail.com",
                    Phone = "45678932",
                    
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

                StripeConfiguration.ApiKey = StripeSecretApiKey;
               
                var options = new SetupIntentCreateOptions
                {
                    Customer = CustomerId,
                    //PaymentMethod = CreateCardToken(),
                    PaymentMethodTypes = new List<string>
                      {
                        "card"
                      },
                    //PaymentMethodTypes = new List<string> { "type = card and  },
                };
                CreatCard(CustomerId);
                var service = new SetupIntentService();
                service.Create(options);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static StripeList<PaymentMethod> RetrieveCardByCustomerId(string CustomerId)
        {
            StripeList<PaymentMethod> paymentmethods = new StripeList<PaymentMethod>();
            try
            {
                StripeConfiguration.ApiKey = StripeSecretApiKey;
                var options = new PaymentMethodListOptions
                {
                    Customer = CustomerId,
                    Type = "card",
                };
                var service = new PaymentMethodService();
                paymentmethods = service.List(options);
            }
            catch (Exception ex)
            {

            }
            return paymentmethods;
        }

        public static void PayNow()
        {
            try
            {
                StripeConfiguration.ApiKey = StripeSecretApiKey;

                var options = new PaymentIntentCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "paynow" },
                    PaymentMethodData = new PaymentIntentPaymentMethodDataOptions
                    {
                        Type = "paynow",
                    },
                    Amount = 1099,
                    Currency = "sgd",
                };
                var service = new PaymentIntentService();
                service.Create(options);
            }
            catch(Exception ex)
            {

            }
        }

        public static void CreatPayNowQRCode()
        {
            try
            {
                StripeConfiguration.ApiKey = StripeSecretApiKey;

               
            }
            catch (Exception ex)
            {

            }
        }

        public static void CreatCard(string CustomerId)
        {
            try
            {
                var options = new CardCreateOptions
                {
                    Source = CreateCardToken(),
                };
                var service = new CardService();
                service.Create(CustomerId, options);
            }
            catch (Exception ex)
            {

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
                    if (PayAsCustomerorGuest)
                    {
                        try
                        {

                            StripeConfiguration.ApiKey = StripeSecretApiKey;
                            var service = new PaymentIntentService();
                            var options = new PaymentIntentCreateOptions
                            {
                                Amount = 1099,
                                Currency = "sgd",
                                Customer = TestUserInfo,
                                PaymentMethod = CardRequestId,
                                Confirm = true,
                                OffSession = true,
                            };
                            service.Create(options);
                        }
                        catch (StripeException e)
                        {
                            //switch (e.StripeError.ErrorType)
                            //{
                            //    case "card_error":
                            //        // Error code will be authentication_required if authentication is needed
                            //        Console.WriteLine("Error code: " + e.StripeError.Code);
                            //        var paymentIntentId = e.StripeError.PaymentIntent.Id;
                            //        var service = new PaymentIntentService();
                            //        var paymentIntent = service.Get(paymentIntentId);

                            //        Console.WriteLine(paymentIntent.Id);
                            //        break;
                            //    default:
                            //        break;
                            //}
                        }
                    }
                    else
                    {
                        var Token = CreateCardToken();
                        Console.Write("Payment Gateway" + "Token :" + Token);
                        if (Token != null)
                        {
                            _isTransectionSuccess = MakePayment(Token);
                        }
                        else
                        {
                        }
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
                StripeConfiguration.SetApiKey(StripeSecretApiKey);
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


        private static string CreateCardToken()
        {
            try
            {
                StripeConfiguration.SetApiKey(StripeSecretApiKey);
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
