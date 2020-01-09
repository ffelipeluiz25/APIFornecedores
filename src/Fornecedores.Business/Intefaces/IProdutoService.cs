using System;
using System.Threading.Tasks;
using Fornecedores.Business.Models;

namespace Fornecedores.Business.Intefaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}