using api.Fornecedor.Dtos;
using api.Fornecedor.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Fornecedor.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public FornecedorRepository(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        public async Task<FornecedorModel> CreateAsync(FornecedorModel fornecedorModel)
        {
            await _dbContext.FORNECEDORES.AddAsync(fornecedorModel);
            await _dbContext.SaveChangesAsync();
            return fornecedorModel;
        }

        public async Task<FornecedorModel?> DeleteAsync(int id)
        {
            var fornecedorModel = await _dbContext.FORNECEDORES.FirstOrDefaultAsync(x => x.id_fornecedor == id);
            if (fornecedorModel == null) {
                return null;
            }
            _dbContext.FORNECEDORES.Remove(fornecedorModel);
            _dbContext.SaveChanges();
            return fornecedorModel; 
        }

        public async Task<FornecedorModel?> ObterPorIdAsync(int id)
        {
            return await _dbContext.FORNECEDORES.FindAsync(id);
        }

        public async Task<List<FornecedorModel>> ObterTodosAsync()
        {
            return await _dbContext.FORNECEDORES.ToListAsync();
        }

        public async Task<FornecedorModel?> UpdateAsync(int id, AtualizarFornecedorDto updateDto)
        {
            var fornecedorModel = await _dbContext.FORNECEDORES.FirstOrDefaultAsync(x => x.id_fornecedor == id);
            if (fornecedorModel == null)
            {
                return null;
            }

            fornecedorModel.cnpj_fornecedor = updateDto.cnpj_fornecedor;
            fornecedorModel.razao_social = updateDto.razao_social;
            fornecedorModel.telefone = updateDto.telefone;
            fornecedorModel.email = updateDto.email;
            fornecedorModel.categoria = updateDto.categoria;
            fornecedorModel.cep = updateDto.cep;
            fornecedorModel.rua = updateDto.rua;
            fornecedorModel.numero = updateDto.numero;
            fornecedorModel.complemento = updateDto.complemento;
            fornecedorModel.bairro = updateDto.bairro;
            fornecedorModel.cidade = updateDto.cidade;
            fornecedorModel.uf = updateDto.uf;
            _dbContext.SaveChanges();
            return fornecedorModel;
        }
    }
}
