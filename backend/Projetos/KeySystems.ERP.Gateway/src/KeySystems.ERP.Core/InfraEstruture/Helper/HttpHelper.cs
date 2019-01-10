
//Responsável por fazer as requisição
using System.Net.Http;

using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace KeySystems.ERP.Core.InfraEstruture.Helper
{
    public class HttpHelper
    {
        public T Get<T>(string url, params object[] parametros)
             where T : new()
        {
            using (var client = new HttpClient())
            {
                StringBuilder builder = new StringBuilder();

                foreach (var item in parametros)
                    builder.Append($"{item.ToString()}/");

                url = string.Format("{0}{1}", url, builder.ToString());

                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                string json =  response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<T>(json);
            }
        }
        
        public T Post<T>(string url, string json)
            where T : new()
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(json);

                var buffer = Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = client.PostAsync(url, byteContent).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return default(T);

                response.EnsureSuccessStatusCode();

                var responseContent = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
        }
    }
}