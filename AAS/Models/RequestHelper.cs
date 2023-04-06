using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AAS.Models
{
    public static class RequestHelper
    {
        public static async Task<object> SendRequestAsync(string uri, string method, string data)
        {
            WebRequest request = WebRequest.Create(uri);
            request.Method = method.ToUpper();

            byte[] arr = Encoding.UTF8.GetBytes(data);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = arr.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(arr, 0, arr.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static object SendRequest(string uri, string method, string data)
        {
            WebRequest request = WebRequest.Create(uri);

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3;
            request.Method = method.ToUpper();
            ServicePointManager
                    .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;

            byte[] arr = Encoding.UTF8.GetBytes(data);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = arr.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(arr, 0, arr.Length);
            }

            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
