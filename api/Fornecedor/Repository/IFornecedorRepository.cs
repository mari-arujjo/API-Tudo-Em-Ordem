using api.Fornecedor.Dtos;
using api.Fornecedor.Model;

namespace api.Fornecedor.Repository
{
    public interface IFornecedorRepository
    {
        Task<List<FornecedorModel>> ObterTodosAsync();
        Task<FornecedorModel?> ObterPorIdAsync(int id);
        Task<FornecedorModel> CreateAsync(FornecedorModel fornecedorModel);
        Task<FornecedorModel?> DeleteAsync(int id); 
        Task<FornecedorModel?> UpdateAsync(int id, AtualizarFornecedorDto updateDto);

    }
}
