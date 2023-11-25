using CustomSysApi.Models.Cliente;
using CustomSysApi.Models.Error;
using CustomSysApi.Models.Request;
using CustomSysApi.Models.Response.Cliente;
using CustomSysApi.Models.Response.Padrao;
using Domain.Contracts.UseCases.Cliente;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CustomSysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteUseCase _clienteUseCase;
        private readonly IValidator<ClienteInput> _clienteValidator;

        private ClienteInput _clienteInput = new ClienteInput();

        public ClienteController(IClienteUseCase clienteUseCase, IValidator<ClienteInput> clienteValidator)
        {
            _clienteUseCase = clienteUseCase;
            _clienteValidator = clienteValidator;
        }

        [HttpPost("AddCliente")]
        [ProducesResponseType(typeof(BaseReturn<string>), 200)]
        public async Task<ActionResult> AddCliente(ClienteInput input)
        {
            try
            {
                ValidationResult validationResult = _clienteValidator.Validate(input);

                if (!validationResult.IsValid)
                {
                    return BadRequest(new BaseReturn<ClienteValidationFailure>() { IsSucces = false, Status = "Erro nas informações fornecidas", Data = (List<ClienteValidationFailure>)validationResult.Errors.ToClienteValidationFailure() });
                }

                Clientes cliente = _clienteInput.ConvertInputToClientes(input);
                _clienteUseCase.AddCliente(cliente);

                if (await _clienteUseCase.SaveAllAsync())
                    return Created("", new BaseReturn<Clientes>() { IsSucces = true, Status = "Cliente inserido com sucesso", Data = null });

                return BadRequest(new BaseReturn<Clientes>() { IsSucces = false, Status = "Falha ao incluir o cliente", Data = null });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseReturn<string>() { IsSucces = false, Status = "Falha ao efetuar a requisição", Data = new List<string>() { ex.Message } });
            }
        }

        [HttpGet("ListCliente")]
        [ProducesResponseType(typeof(BaseReturn<ClienteGetByIdResponse>), 200)]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            try
            {
                IEnumerable<Clientes> clientes = await _clienteUseCase.SelecionarTodos();

                ClienteGetByIdResponse clienteResponse = new ClienteGetByIdResponse();

                List<ClienteGetByIdResponse> clientesResponse = new List<ClienteGetByIdResponse>();

                clientesResponse = clienteResponse.ClienteToClienteGetByIdResponse(clientes.ToList());

                return Ok(new BaseReturn<ClienteGetByIdResponse>() { IsSucces = true, Status = "Consulta de Clientes realizada com sucesso", Data = clientesResponse });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseReturn<string>() { IsSucces = false, Status = "Falha ao efetuar a requisição", Data = new List<string>() { ex.Message } });
            }
        }

        [HttpPost("GetClienteById")]
        [ProducesResponseType(typeof(BaseReturn<ClienteGetByIdResponse>), 200)]
        public async Task<ActionResult> GetById(ByIdRequest<string> input)
        {
            try
            {
                ClienteGetByIdResponse clienteResponse = new ClienteGetByIdResponse();

                List<Clientes> cliente = new List<Clientes>
                {
                    await _clienteUseCase.GetById(input.Id)
                };

                if (cliente.Count < 0)
                    return BadRequest(new BaseReturn<Clientes>() { IsSucces = false, Status = "Não foi possível consultar o cliente.", Data = null });

                List<ClienteGetByIdResponse> clientesResponse = new List<ClienteGetByIdResponse>();

                clientesResponse = clienteResponse.ClienteToClienteGetByIdResponse(cliente);

                return Ok(new BaseReturn<ClienteGetByIdResponse>() { IsSucces = true, Status = "Consulta de cliente realizada com sucesso", Data = clientesResponse });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseReturn<string>() { IsSucces = false, Status = "Falha ao efetuar a requisição", Data = new List<string>() { ex.Message } });
            }
        }

        [HttpPut("AltCliente")]
        [ProducesResponseType(typeof(BaseReturn<string>), 200)]
        public async Task<ActionResult> AlterarCliente(ClienteInput input) 
        {
            try
            {
                Clientes cliente = _clienteInput.ConvertInputToClientes(input);

                _clienteUseCase.Alterar(cliente);

                if (await _clienteUseCase.SaveAllAsync())
                    return Ok(new BaseReturn<Clientes>() { IsSucces = true, Status = "Cliente alterado com sucesso", Data = null });

                return BadRequest(new BaseReturn<Clientes>() { IsSucces = false, Status = "Falha ao alterar o cliente", Data = null });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseReturn<string>() { IsSucces = false, Status = "Falha ao efetuar a requisição", Data = new List<string>() { ex.Message } });
            }
        }

        [HttpDelete("DelCliente")]
        [ProducesResponseType(typeof(BaseReturn<string>), 200)]
        public async Task<ActionResult> ExcluirCliente(ByIdRequest<string> input)
        {
            try
            {
                List<Clientes> clientes = new List<Clientes>
                {
                    await _clienteUseCase.GetById(input.Id)
                };

                if (clientes.Count < 0)
                    return BadRequest(new BaseReturn<Clientes>() { IsSucces = false, Status = "Não foi possível localizar o cliente com id: " + input.Id, Data = null });

                if (string.IsNullOrEmpty(clientes.FirstOrDefault().Clid))
                    return BadRequest(new BaseReturn<Clientes>() { IsSucces = false, Status = "Não foi possível localizar o cliente com id: " + input.Id, Data = null });

                _clienteUseCase.Excluir(clientes.FirstOrDefault());

                if (await _clienteUseCase.SaveAllAsync())
                    return Ok(new BaseReturn<Clientes>() { IsSucces = true, Status = "Cliente excluído com sucesso", Data = null });

                return BadRequest(new BaseReturn<Clientes>() { IsSucces = false, Status = "Não foi possível excluír o cliente com id: " + input.Id, Data = null });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseReturn<string>() { IsSucces = false, Status = "Falha ao efetuar a requisição", Data = new List<string>() { ex.Message } });
            }
        }
    }
}
