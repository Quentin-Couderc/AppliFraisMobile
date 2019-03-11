using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppliFraisMobile.Services
{
    public class WebService
    {
        HttpClient client;
        public enum Method
        {
            GET,
            POST
        }
        public WebService()
        {
            client = new HttpClient();
        }
        private async Task<string> ExecuteRequete(Method method, string param, string data)
        {
            string retourReponse;
            HttpResponseMessage response;
            switch (method)
            {
                case Method.GET:
                    response = await client.GetAsync("http://localhost:31002/ServiceParc.svc/rest/" + param);
                    break;
                case Method.POST:
                    HttpContent httpContent = new StringContent(data);
                    httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/xml");
                    response = await client.PostAsync("http://localhost:31002/ServiceParc.svc/rest/" + param, httpContent);
                    break;
                default:
                    response = null;
                    break;
            }

            if (response.IsSuccessStatusCode)
            {
                retourReponse = await response.Content.ReadAsStringAsync();
            }
            else
            {
                retourReponse = "Erreur - " + response.StatusCode + " - reponse : " + response.Content + " - requete : " + response.RequestMessage;
            }
            return retourReponse;
        }
    }
}
