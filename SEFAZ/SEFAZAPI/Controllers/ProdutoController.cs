using Microsoft.AspNetCore.Mvc;
using SEFAZAPI.Util;
using SEFAZDOMINIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SEFAZAPI.Controllers
{

    [ApiController]

    public class ProdutoController : Controller
    {
        [HttpGet]
        [Route("v1/[controller]")]
        public IActionResult ConsultarProdutoPorCodigoGTIN(long codigoGtin)
        {
            try
            {
                if (codigoGtin == 0)
                {
                    return BadRequest("Erro 400 - Bad Request");
                }
                SqliteDataAcess dataAcess = new SqliteDataAcess();
                var produto = dataAcess.ConsultarProdutoPorCodigoGTIN(codigoGtin);

                Auxiliar Auxiliar = new Auxiliar();

                for(int i = 0; i < produto.Count; i++)
                {
                    var latitude = produto[i].Num_Latitude;
                    var longitude = produto[i].Num_Longitude;
                    produto[i].Url_Maps = Auxiliar.GerarUrlMaps(latitude, longitude);
                }

                if (produto.Count > 0)
                {
                    return Ok(produto);
                }
                else
                {
                    return NotFound("Erro 404 - Not Found");
                }
            }
            catch (Exception erro)
            {
                return Problem(erro.Message.ToString());
            }

        }

        [HttpGet]
        [Route("v1/importar")]
        public IActionResult ImportarProdutos()
        {
            try
            {

                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = @"Importar.bat",
                        Arguments = @"",
                        UseShellExecute = false,
                        RedirectStandardOutput = false,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                proc.WaitForExit();
                return Ok("Importação realizada com sucesso!");
            }
            catch (Exception erro)
            {
                return Problem(erro.Message.ToString());
            }

        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return Ok("A API \"Menor Preço\" - SEFAZ possui as seguintes rotas:\n" +
                         "\nProduto - [v1/produto]: A função dessa rota é pesquisar o produto pelos parâmetros: código GTIN (COD_GTIN)," +
                         " latitude (NUM_LATITUDE) e longitude (NUM_LONGITUDE), retornando a lista de produtos e a URL do Google Maps de cada estabelecimento.\n" +
                         "\nImportar - [v1/importar]: A função dessa rota é importar a planilha .csv para o banco SQLite.\n" +
                         "\nEssa API foi desenvolvida por: Isabella Kuster Bregensk.");


        }

    }
}
