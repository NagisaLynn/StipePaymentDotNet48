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
        public static string TestCardInfo = "card_1LFYKRBRmSsrBJTcYj9jcMsI";
        public static string TestDescription = "Card Testing by ";
        public static long TestAmount = 20000; // including 2 digit decimal

        private static TokenService Tokenservice;
        private static Token stripeToken;
        private static bool _isCarcValid;
        public static bool PayAsCustomerorGuest; // true for customer and false for guest

        public static async void Payment_by_Card()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = TestAmount,
                    Currency = "sgd",
                    Source = TestCardToken(),
                    Description = TestDescription + " Payment by Card"
                };
                var service = new ChargeService();
                Charge response = service.Create(chargeOptions);

                if (response.Paid)
                {
                    Console.Write("Payment Gateway" + "Payment Successful ");
                }
                else
                {
                    Console.Write("Payment Gateway" + "Payment Failure ");
                }
            }
            catch (Exception ex)
            {
                Console.Write("Payment Gatway" + ex.Message);
            }
        }

        public static string CustomerCreateOptions()
        {
            try
            {
                StripeConfiguration.ApiKey = StripeSecretApiKey;

                var options = new CustomerCreateOptions
                {
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

        public static async void Payment_by_Customer()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                var service = new PaymentIntentService();
                var options = new PaymentIntentCreateOptions
                {
                    Amount = TestAmount,
                    Currency = "sgd",
                    Customer = TestUserInfo,
                    PaymentMethod = TestCardInfo,
                    Confirm = true,
                    OffSession = true,
                    Description = TestDescription + " Payment by Customer"
                };
                PaymentIntent response = service.Create(options);

                if (response.StripeResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.Write("Payment Gateway" + "Payment Successful ");
                }
                else
                {
                    Console.Write("Payment Gateway" + "Payment Failure ");
                }
            }
            catch (Exception ex)
            {
                Console.Write("Payment Gatway" + ex.Message);
            }
        }

        public static List<string> GetAllCards()
        {
            List<string> ReturnResponse = new List<string>();
            try
            {
                var options = new PaymentMethodListOptions
                {
                    Customer = TestUserInfo,
                    Type = "card",
                };
                var service = new PaymentMethodService();
                StripeList<PaymentMethod> stripeList = service.List(options);
                foreach (PaymentMethod paymentMethod in stripeList)
                {
                    ReturnResponse.Add(paymentMethod.Id);
                }
                if (ReturnResponse.Count > 0)
                {
                    Console.Write("Card Count" + ReturnResponse.Count);
                }
                else
                {
                    Console.Write("Card Count" + ReturnResponse.Count);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Card Count Error " + ex.Message);
            }
            return ReturnResponse;
        }

        public static void AddNewCard()
        {
            try
            {
                var options = new CardCreateOptions
                {
                    Source = TestCardToken(),
                };
                var service = new Stripe.CardService();
                var response = service.Create(TestUserInfo, options);

                if (response.StripeResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.Write("Add Card " + "Successful ");
                }
                else
                {
                    Console.Write("Add Card " + "Failure ");
                }
            }
            catch (Exception ex)
            {
                Console.Write("Add Card " + ex.Message);
            }
        }

        public static void UpdateCard()
        {
            try
            {
                var options = new CardUpdateOptions
                {
                    Name = TestUserName,
                    AddressLine1 = "AddressLine1",
                    AddressLine2 = "AddressLine2",
                    AddressState = "AddressState",
                    AddressCity = "AddressCity",
                    AddressCountry = "AddressCountry",
                    AddressZip = "123456",
                    ExpMonth = 12,
                    ExpYear = 25,

                };

                var service = new Stripe.CardService();
                var response = service.Update(
                    TestUserInfo,
                    TestCardInfo,
                    options);

                if (response.StripeResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.Write("Update Card " + "Successful ");
                }
                else
                {
                    Console.Write("Update Card " + "Failure ");
                }
            }
            catch (Exception ex)
            {
                Console.Write("Update Card " + ex.Message);
            }
        }

        public static void DeleteCard()
        {
            try
            {

                var service = new Stripe.CardService();
                var response = service.Delete(
                    TestUserInfo,
                    TestCardInfo);

                if (response.StripeResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.Write("Delete Card " + "Successful ");
                }
                else
                {
                    Console.Write("Delete Card " + "Failure ");
                }
            }
            catch (Exception ex)
            {
                Console.Write("Delete Card " + ex.Message);
            }
        }

        public static void Payment_by_PayNow()
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
                    Amount = TestAmount,
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

        private static string TestCardToken()
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
