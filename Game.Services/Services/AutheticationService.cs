using Nethereum.Signer;


namespace Game.Services.Services
{
    public class AutheticationService
    {       
        public static bool ValidaAssinatura(string nounce, string signature, string publicAddress)
        {

            //signing
            var message = "I am signing on fazendinha.io with nonce: " + nounce;
            var signer = new EthereumMessageSigner();
            //verification           
            var recoveredAddress = signer.EncodeUTF8AndEcRecover(message, signature);
            return string.Equals(recoveredAddress, publicAddress, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
