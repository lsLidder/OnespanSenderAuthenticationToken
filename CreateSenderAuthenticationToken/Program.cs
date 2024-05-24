using OneSpanSign.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSenderAuthenticationToken
{
    internal class Program
    {

        // ***Replace the values for ClientAppId and ClientAppSecret with actual values
        static string baseurl = "https://sandbox.esignlive.com";
        static string ClientAppId = "***************************";
        static string ClientAppSecret = "**************************************************************************";
        static string SenderEmail = "c09324-esg@coxautoinc.com";
        static string packageId = "gKT97_eZrPU18dubwh_zBCfKzqI=";
        static void Main(string[] args)
        {
            try
            {
                OneSpanSign.Sdk.ApiTokenConfig apiTokenConfig = new OneSpanSign.Sdk.ApiTokenConfig()
                {
                    BaseUrl = baseurl,
                    ClientAppId = ClientAppId,
                    ClientAppSecret = ClientAppSecret,
                    SenderEmail = SenderEmail,
                    TokenType = (OneSpanSign.Sdk.ApiTokenType)1 //owner
                };
                OssClient _ossClient = new OssClient(apiTokenConfig, baseurl, false, null, new Dictionary<string, string>());

                // _ossClient = CreateOssClient(signatureClientConfig);

                #region Successcall
                PackageId package = new PackageId(packageId);
                var signers = _ossClient.GetPackage(package).Signers; //This call to get pakcage works fine 
                #endregion

                #region FailureCall
                var token = _ossClient.AuthenticationTokenService.CreateSenderAuthenticationToken(new PackageId(packageId)); //This call fails.
                #endregion 

                Console.WriteLine($"Success. the token is : {token}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
