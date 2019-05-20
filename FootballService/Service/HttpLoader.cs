using System;
using System.Net;

namespace FootballService.Service
{
    public class HttpLoader
    {
        private WebClient webClient;

        public HttpLoader()
        {
            webClient = new WebClient();
        }

        public string LoadContent(string site)
        {
            if (string.IsNullOrEmpty(site))
            {
                return string.Empty;
            }

            try
            {
                var result = webClient.DownloadString(new Uri(site));
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}