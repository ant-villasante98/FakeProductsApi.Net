using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FakestoreApi.DTO.V2;

namespace FakestoreApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly HttpClient _httpclient;
        private readonly IConfiguration _configuration;

        private readonly string ApiTestUrl;


        public ProductosController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpclient = httpClient;
            _configuration = configuration;
            ApiTestUrl = _configuration["ApiTestUrl"]?.ToString() ?? "";
            if (ApiTestUrl == "")
            {
                Console.WriteLine("-----Url de api no encontroda-----");
            }
        }

        [MapToApiVersion("2.0")]
        [HttpGet(Name = "GetProductsData")]
        public async Task<IActionResult> GetProductsDataAsync()
        {

            _httpclient.DefaultRequestHeaders.Clear();

            var response = await _httpclient.GetStreamAsync(ApiTestUrl + "products?limit=10");
            var products = await JsonSerializer.DeserializeAsync<Producto[]>(response);

            return Ok(products);
        }
    }
}
