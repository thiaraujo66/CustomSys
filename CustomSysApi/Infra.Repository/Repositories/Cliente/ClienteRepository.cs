using Domain.Contracts.Repositories.Cliente;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Repositories.Cliente
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IList<Clientes> _clientes = new List<Clientes>();
        private readonly CUSTOMSYSContext _context;

        public ClienteRepository(CUSTOMSYSContext context) 
        {
            _context = context;
        }

        public void AddCliente(Clientes customer)
        {
            _context.Clientes.Add(customer);
        }

        public void Alterar(Clientes customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }

        public void Excluir(Clientes customer)
        {
            _context.Clientes.Remove(customer);
        }

        public async Task<Clientes> GetById(string id)
        {
            Clientes cliente = new Clientes();
            cliente = await _context.Clientes.AsNoTracking().Where(e => e.Clid == id).FirstOrDefaultAsync();
            return await _context.Clientes.Include(c => c.ClcdenderecoNavigation).Include(c => c.ClcdsituacaoNavigation).Include(c => c.ClcdtipoclienteNavigation).Include(c => c.ClnacionalidadeNavigation).Include(c => c.ClcdusucadNavigation).Include(c => c.ClcdusualtNavigation).FirstOrDefaultAsync(m => m.Clid == cliente.Clid);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }  

        public async Task<IEnumerable<Clientes>> SelecionarTodos()
        {
            return await _context.Clientes.Include(c => c.ClcdenderecoNavigation).Include(c => c.ClcdsituacaoNavigation).Include(c => c.ClcdtipoclienteNavigation).Include(c => c.ClnacionalidadeNavigation).Include(c => c.ClcdusucadNavigation).Include(c => c.ClcdusualtNavigation).ToListAsync();
        }
    }
}
