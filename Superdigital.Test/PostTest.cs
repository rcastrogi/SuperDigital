using Newtonsoft.Json;
using SuperDigital.Domain.Entity;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace Superdigital.Test
{
    public class PostTest
    {
        [Fact]
        public bool RealizarPost()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44343/api/SuperDigital");
                var obj = new TransferEntity()
                {
                    BancoOri = 1,
                    AgenciaOri = 12,
                    ContaOri = 3123,
                    DigitoOri = 32,
                    BancoDes = 2,
                    AgenciaDes = 47,
                    ContaDes = 8334,
                    DigitoDes = 6,
                    Valor = 500
                };

                string jsonLancamento = JsonConvert.SerializeObject(obj);
                StringContent paramTransfer = new StringContent(jsonLancamento);
                paramTransfer.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage retorno = client.PostAsync("", paramTransfer).Result;
                return retorno.IsSuccessStatusCode;
            }
        }
    }
}
