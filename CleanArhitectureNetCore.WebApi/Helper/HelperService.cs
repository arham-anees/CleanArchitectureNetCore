using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CleanArhitectureNetCore.WebApi.Helper
{
    public static class HelperService
    {
        public static RSAParameters ReadRsa(IConfiguration configuration, string name, string path)
        {
     
      // read RSA key
      var key = File.ReadAllBytes($"{path}/{name}");
            //var rsa = RSA.Create();
            //rsa.ImportFromPem(privateKey.ToCharArray());
            //Values to store encrypted symmetric keys.
            byte[] EncryptedSymmetricKey;
            byte[] EncryptedSymmetricIV;

            //Create a new instance of RSACryptoServiceProvider.
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            //Get an instance of RSAParameters from ExportParameters function.
            RSAParameters RSAKeyInfo = RSA.ExportParameters(false);

            //Set RSAKeyInfo to the public key values.
            RSAKeyInfo.Modulus = key;
            //Import key parameters into RSA.
            RSA.ImportParameters(RSAKeyInfo);

            //Create a new instance of the RijndaelManaged class.
            RijndaelManaged RM = new RijndaelManaged();

            //Encrypt the symmetric key and IV.
            EncryptedSymmetricKey = RSA.Encrypt(RM.Key, false);
            EncryptedSymmetricIV = RSA.Encrypt(RM.IV, false);

            //Console.WriteLine("RijndaelManaged Key and IV have been encrypted with RSACryptoServiceProvider.");
            return RSAKeyInfo;
        }
    }
}
