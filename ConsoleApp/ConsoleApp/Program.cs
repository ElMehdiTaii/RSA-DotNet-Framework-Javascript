using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var encryptedBase64 = @"ZwZSGOaNVdVONHAZthV3vJkklV9N4wIizR9lfvyhvdG5Zef4RdTGSAEDkxlYXTtVpu0N4OoqJ55XxrZNRLsybt0/pLitcUGUr/7m9wsp97dFp8q7UexhdgAes/qDTEdvYw1ycTsFJTbjHpOeFl5pkIZNvwpWDL4V2l9VZGMdlno=";

            using (var privateKey = RSA.Create())
            {
                privateKey.FromXmlString("<RSAKeyValue><Modulus>xsvG7a250jT8+71in0FysSl84NvGQ/IwgHe4BmH1CBaiqlHKIB1reYMhr04BIcAcAT9ZGK1ZwZYQdp7lhy2KSQyOm7gaKiqx7a3HYF7Crpkj9DiqZ9J22MZJzrzWFY1FEeqZTG6FAWll9aCqEeqTc0xB0mpeGyFO1zMKaZEdyjU=</Modulus><Exponent>AQAB</Exponent><P>444WZf3zqqm/Z71t670jcLHc0mKBqX8dtrs6yaZTdsKRTulwqKwBjDupRyN1GvANDkjTtcm5IRtomTpD6BBlhw==</P><Q>36VhsUFNQr4RO7gLoWpB+D2QtciZjnHm+QGRlfDl1mq527LHnHURrBQVRcHR3OgQbJ1wsSi4IjcKJ3l6EtcBYw==</Q><DP>pFO0ixzUPRduWN0sJwQkNrrK68clOaDJdW9J6dtKBMZHJwRfTf9A8uMWwH+zjqtx0jH3aRzuqyDe7WBtL4W/uw==</DP><DQ>uUB2sasT4msqPztuduBbkNL+YXWurK1w02YXQApxd7CkD3YBnnnij5V7IXMw8TlREYdAZ58BF2ZcBOK82Yo7XQ==</DQ><InverseQ>2gXbe/4gNIAuowBdgs1nXtuLKTP/HJzPIfil6zcF82Jc5dy7lR7nJCl088w0t1a0ebx5LrC2qjX4SMEUbMTkNg==</InverseQ><D>okAVN02wOQm4ZPp4cMSpCEF1Q8z8L96OiXusvcDbjWN0FhC1KKr6We2V44+FyvcRpE8At+xcMmz5OOeNLFwV3QLZGOYjZXP5dmRC3mG7HOv0Iu4QqAQCMEzLf998+6RwA24U74ysm+6CVCeVWZLtJSi/UdQm3jho086iQF9UOo0=</D></RSAKeyValue>");
                var dectryptedBytes = privateKey.Decrypt(Convert.FromBase64String(encryptedBase64), RSAEncryptionPadding.OaepSHA1);
                var dectryptedText = Encoding.UTF8.GetString(dectryptedBytes);
            }
        }

    }
}
