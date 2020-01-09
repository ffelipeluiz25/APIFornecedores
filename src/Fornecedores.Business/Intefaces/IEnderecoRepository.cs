using System;
using System.Threading.Tasks;
using Fornecedores.Business.Models;

namespace Fornecedores.Business.Intefaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}