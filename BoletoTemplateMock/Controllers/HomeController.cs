using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BoletoTemplateMock.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var content = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "/View/index.html");

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/plain",
            };
        }

        [HttpGet]
        [Route("dataVencimento={dataVencimento}&nossoNumero={nossoNumero}&valor={valor}")]
        public IActionResult Get(string dataVencimento, string nossoNumero, string valor)
        {
            var content = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "/View/boleto.html");
            content = content.Replace("{{DataVencimento}}", Convert.ToDateTime(dataVencimento).ToString("d"));
            content = content.Replace("{{NossoNumero}}", nossoNumero);
            content = content.Replace("{{Valor}}", valor);
            content = content.Replace("{{DateTime.Now}}", DateTime.Now.ToString("d"));

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }
    }
}
