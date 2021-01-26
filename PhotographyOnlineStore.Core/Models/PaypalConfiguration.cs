using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public static class PaypalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        // Static constructor for setting the readonly static members.
        static PaypalConfiguration()
        {
            var config = GetConfig();
            ClientId = ConfigurationManager.AppSettings["clientId"];
            ClientSecret = ConfigurationManager.AppSettings["clientSecret"];
   //         ClientId = "AcS1LYucC2TIM_2Pfn-6KIjcOQmTEGi8lkVO1uFnIswLT_svxD_pfTzETNnAtEbZ666xOdTOvlqxM9zR";
   //         ClientSecret = "EG90qJ-rky8KkTVJ_HF8OSR_DP3XABTAuyTrM7-pbMxfSi2xLHpt894hRDK8vJq7v5P2IYwRHsDCjwLF";
        }

        // Create the configuration map that contains mode and other optional configuration details.
        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        // Create accessToken
        private static string GetAccessToken()
        {
            // ###AccessToken
            // Retrieve the access token from
            // OAuthTokenCredential by passing in
            // ClientID and ClientSecret
            // It is not mandatory to generate Access Token on a per call basis.
            // Typically the access token can be generated once and
            // reused within the expiry window                
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }

        // Returns APIContext object
        public static APIContext GetAPIContext()
        {
            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();

            // Use this variant if you want to pass in a request id  
            // that is meaningful in your application, ideally 
            // a order id.
            // String requestId = Long.toString(System.nanoTime();
            // APIContext apiContext = new APIContext(GetAccessToken(), requestId ));

            return apiContext;
        }

    }
}