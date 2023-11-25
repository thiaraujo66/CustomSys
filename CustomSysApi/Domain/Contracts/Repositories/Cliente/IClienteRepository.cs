using Domain.Entities;

namespace Domain.Contracts.Repositories.Cliente
{
    public interface IClienteRepository
    {
        void AddCliente(Clientes customer);
        void Alterar(Clientes customer);
        void Excluir(Clientes customer);
        Task<Clientes> GetById(string id);
        Task<IEnumerable<Clientes>> SelecionarTodos();

        Task<bool> SaveAllAsync();
    }
}
