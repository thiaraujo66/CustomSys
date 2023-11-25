using Domain.Contracts.Repositories.Cliente;
using Domain.Contracts.UseCases.Cliente;
using Domain.Entities;

namespace Application.UseCases.Cliente
{
    public class ClienteUseCase : IClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteUseCase(IClienteRepository clienteRepository) 
        {
            _clienteRepository = clienteRepository;
        }

        public void AddCliente(Clientes customer)
        {
            _clienteRepository.AddCliente(customer);
        }

        public void Alterar(Clientes customer)
        {
            _clienteRepository.Alterar(customer);
        }

        public void Excluir(Clientes customer)
        {
            _clienteRepository.Excluir(customer);
        }

        public async Task<Clientes> GetById(string id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _clienteRepository.SaveAllAsync();
        }

        public async Task<IEnumerable<Clientes>> SelecionarTodos()
        {
            return await _clienteRepository.SelecionarTodos();
        }
    }
}
