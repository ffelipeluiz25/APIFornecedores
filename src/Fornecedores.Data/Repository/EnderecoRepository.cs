using System;
using System.Threading.Tasks;
using Fornecedores.Business.Intefaces;
using Fornecedores.Business.Models;
using Fornecedores.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Fornecedores.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}