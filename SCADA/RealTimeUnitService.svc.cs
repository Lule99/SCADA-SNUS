using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace SCADA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RealTimeUnitService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RealTimeUnitService.svc or RealTimeUnitService.svc.cs at the Solution Explorer and start debugging.
    public class RealTimeUnitService : IRealTimeUnitService
    {

        static CspParameters csp = new CspParameters();
        static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp);
        static string keypath = "";


        public void Init(string kp)
        {
            keypath = kp;
        }

        public void Write(string message, byte[] signature)
        {
            byte[] hash = null;

            using (SHA256 sha = SHA256Managed.Create())
            {
                hash = sha.ComputeHash(Encoding.UTF8.GetBytes(message));
            }

            lock (keypath)
            {
                using (StreamReader sr = new StreamReader(keypath))
                {
                    rsa.FromXmlString(sr.ReadToEnd());
                }
            }

            RSAPKCS1SignatureDeformatter deformater = new RSAPKCS1SignatureDeformatter(rsa);
            deformater.SetHashAlgorithm("SHA256");

            if (deformater.VerifySignature(hash, signature))
            {
                string[] tokens = message.Split(':');
                RealTimeDriver.WriteToAdresses(tokens[0], int.Parse(tokens[2]), Double.Parse(tokens[1]));

            }
            
        }
    }
}
