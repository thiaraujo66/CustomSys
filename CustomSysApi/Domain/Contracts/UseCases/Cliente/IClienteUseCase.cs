using Domain.Entities;

namespace Domain.Contracts.UseCases.Cliente
{
    public interface IClienteUseCase
    {
        void AddCliente(Clientes customer);
        void Alterar(Clientes customer);
        void Excluir(Clientes customer);
        Task<Clientes> GetById(string id);
        Task<IEnumerable<Clientes>> SelecionarTodos();
        Task<bool> SaveAllAsync();
    }
}
