using CustomSysWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CustomSysWeb.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientesController(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            string apiUrl = "https://localhost:44338/api/Cliente/ListCliente";

            try
            {
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    Cliente.Root root = new Cliente.Root();

                    root = JsonConvert.DeserializeObject<Cliente.Root>(content);

                    return View(root.Data);
                }
                else
                {
                    ViewBag.ErrorMessage = $"Erro na requisição: {response.ReasonPhrase}";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro na requisição: " + ex.Message;
                return View();
            }
        }

        public IActionResult Create() 
        {
            ViewData["ClienteCad"] = new Cliente();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Nome, Cgc, Sexo, Endereco, Email, Telefone, Obs, Excluido, TipoCliente, SituacaoCliente, Nacionalidade, DtNasc, DtCad, CdUsuCad")] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient httpClient = _httpClientFactory.CreateClient();

                    string apiUrl = "https://localhost:44338/api/Cliente/AddCliente";

                    string json = cliente.ToJson();

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        //Código abaixo pode ser utilizado quando implementar gravação de Log's

                        //var responseBody = await response.Content.ReadAsStringAsync();

                        TempData["SucessoMessage"] = "Cliente adicionado com sucesso!";

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = $"Erro na requisição: {response.ReasonPhrase}";
                        return View(cliente);
                    }
                }
                ViewData["ClienteCad"] = cliente;
                return View(cliente);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro na requisição: " + ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Edit(string? id) 
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            string apiUrl = "https://localhost:44338/api/Cliente/GetClienteById";

            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                string json = "{\"id\":\"" + id + "\"}";

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    Cliente.Root root = new Cliente.Root();

                    root = JsonConvert.DeserializeObject<Cliente.Root>(responseBody);

                    return View(root.Data[0]);
                }
                else
                {
                    ViewBag.ErrorMessage = $"Erro na requisição: {response.ReasonPhrase}";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro na requisição: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id, Nome, Cgc, Sexo, Endereco, Email, Telefone, Obs, Excluido, TipoCliente, SituacaoCliente, Nacionalidade, DtNasc, DtCad, CdUsuCad")] Cliente cliente) 
        {
            try
            {
                if (id != cliente.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    HttpClient httpClient = _httpClientFactory.CreateClient();

                    string apiUrl = "https://localhost:44338/api/Cliente/AltCliente";

                    string json = cliente.ToJson();

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        //Código abaixo pode ser utilizado quando implementar gravação de Log's

                        //var responseBody = await response.Content.ReadAsStringAsync();

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = $"Erro na requisição: {response.ReasonPhrase}";
                        return View(cliente);
                    }
                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro na requisição: " + ex.Message;
                return View(cliente);
            }
        }

        public async Task<IActionResult> Details(string? id) 
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            string apiUrl = "https://localhost:44338/api/Cliente/GetClienteById";

            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                string json = "{\"id\":\"" + id + "\"}";

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    Cliente.Root root = new Cliente.Root();

                    root = JsonConvert.DeserializeObject<Cliente.Root>(responseBody);

                    return View(root.Data[0]);
                }
                else
                {
                    ViewBag.ErrorMessage = $"Erro na requisição: {response.ReasonPhrase}";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro na requisição: " + ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Delete(string? id) 
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            string apiUrl = "https://localhost:44338/api/Cliente/GetClienteById";

            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                string json = "{\"id\":\"" + id + "\"}";

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    Cliente.Root root = new Cliente.Root();

                    root = JsonConvert.DeserializeObject<Cliente.Root>(responseBody);

                    return View(root.Data[0]);
                }
                else
                {
                    ViewBag.ErrorMessage = $"Erro na requisição: {response.ReasonPhrase}";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro na requisição: " + ex.Message;
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                string apiUrl = "https://localhost:44338/api/Cliente/DelCliente/" + id;

                var response = await httpClient.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    //Código abaixo pode ser utilizado quando implementar gravação de Log's
                    
                    //var responseBody = await response.Content.ReadAsStringAsync();
                    

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = $"Erro na requisição: {response.ReasonPhrase}";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro na requisição: " + ex.Message;
                return View();
            }
        }    
    }
}
