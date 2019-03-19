using AppliFraisMobile.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

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

        public async Task<ConnexionResult> Connexion()
        {
            string data;
            XmlSerializer xml;
            Connexion req = new Connexion();
            xml = new XmlSerializer(typeof(Connexion));
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8, // no BOM in a .NET string
                Indent = true,
                OmitXmlDeclaration = true
            };
            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    xml.Serialize(xmlWriter, req);
                }
                data = textWriter.ToString();
            }
            string reponse = await ExecuteRequete(Method.POST, "Connexion", data);
            if (reponse.StartsWith("Erreur - "))
            {
                ConnexionResult result = new ConnexionResult
                {
                    Error = reponse
                };
                return result;
            }
            else
            {
                ConnexionResponse response = new ConnexionResponse();
                xml = new XmlSerializer(typeof(ConnexionResponse));
                using (TextReader reader = new StringReader(reponse))
                {
                    response = (ConnexionResponse)xml.Deserialize(reader);
                }
                return response.GetVehiculeResult;
            }
        }
    }
}
