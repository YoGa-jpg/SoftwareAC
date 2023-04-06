using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Borderless.Annotations;

namespace Borderless.Model
{
    public static class RequestHelper
    {
        [CanBeNull]
        public static async Task<object> SendRequest(string uri, string method, string data)
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
    }
}