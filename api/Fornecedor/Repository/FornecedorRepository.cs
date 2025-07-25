using api.Fornecedor.Dtos;
using api.Fornecedor.Helper;
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

        public async Task<List<FornecedorModel>> ObterTodosAsync(FornecedorQueryObject query)
        {
            var fornecedor =  _dbContext.FORNECEDORES.AsQueryable();
            if (!string.IsNullOrEmpty(query.cnpj_fornecedor))
            {
                fornecedor = fornecedor.Where( f => f.cnpj_fornecedor.Contains(query.cnpj_fornecedor));
            }
            if (!string.IsNullOrEmpty(query.razao_social))
            {
                fornecedor = fornecedor.Where(f => f.razao_social.Contains(query.razao_social));
            }
            if (!string.IsNullOrEmpty(query.email))
            {
                fornecedor = fornecedor.Where(f => f.email.Contains(query.email));
            }
            if (!string.IsNullOrEmpty(query.telefone))
            {
                fornecedor = fornecedor.Where(f => f.telefone.Contains(query.telefone));
            }
            if (!string.IsNullOrEmpty(query.categoria))
            {
                fornecedor = fornecedor.Where(f => f.categoria.Contains(query.categoria));
            }
            if (!string.IsNullOrEmpty(query.cep))
            {
                fornecedor = fornecedor.Where(f => f.cep.Contains(query.cep));
            }
            if (!string.IsNullOrEmpty(query.logradouro))
            {
                fornecedor = fornecedor.Where(f => f.logradouro.Contains(query.logradouro));
            }
            if (!string.IsNullOrEmpty(query.bairro))
            {
                fornecedor = fornecedor.Where(f => f.bairro.Contains(query.bairro));
            }
            if (!string.IsNullOrEmpty(query.cidade))
            {
                fornecedor = fornecedor.Where(f => f.cidade.Contains(query.cidade));
            }
            if (!string.IsNullOrEmpty(query.uf))
            {
                fornecedor = fornecedor.Where(f => f.uf.Contains(query.uf));
            }

            if (!string.IsNullOrWhiteSpace(query.ordenar))
            {
                if (query.ordenar.Equals("cnpj_fornecedor"))
                {
                    if (query.DESC)
                    {
                        fornecedor = fornecedor.OrderByDescending(u => u.cnpj_fornecedor);
                    }
                    else
                    {
                        fornecedor = fornecedor.OrderBy(u => u.cnpj_fornecedor);
                    }
                }
                if (query.ordenar.Equals("razao_social"))
                {
                    if (query.DESC)
                    {
                        fornecedor = fornecedor.OrderByDescending(u => u.razao_social);
                    }
                    else
                    {
                        fornecedor = fornecedor.OrderBy(u => u.razao_social);
                    }
                }
                if (query.ordenar.Equals("email"))
                {
                    if (query.DESC)
                    {
                        fornecedor = fornecedor.OrderByDescending(u => u.email);
                    }
                    else
                    {
                        fornecedor = fornecedor.OrderBy(u => u.email);
                    }
                }
                if (query.ordenar.Equals("categoria"))
                {
                    if (query.DESC)
                    {
                        fornecedor = fornecedor.OrderByDescending(u => u.categoria);
                    }
                    else
                    {
                        fornecedor = fornecedor.OrderBy(u => u.categoria);
                    }
                }
                if (query.ordenar.Equals("cep"))
                {
                    if (query.DESC)
                    {
                        fornecedor = fornecedor.OrderByDescending(u => u.cep);
                    }
                    else
                    {
                        fornecedor = fornecedor.OrderBy(u => u.cep);
                    }
                }
                if (query.ordenar.Equals("logradouro"))
                {
                    if (query.DESC)
                    {
                        fornecedor = fornecedor.OrderByDescending(u => u.logradouro);
                    }
                    else
                    {
                        fornecedor = fornecedor.OrderBy(u => u.logradouro);
                    }
                }
                if (query.ordenar.Equals("bairro"))
                {
                    if (query.DESC)
                    {
                        fornecedor = fornecedor.OrderByDescending(u => u.bairro);
                    }
                    else
                    {
                        fornecedor = fornecedor.OrderBy(u => u.bairro);
                    }
                }
                if (query.ordenar.Equals("cidade"))
                {
                    if (query.DESC)
                    {
                        fornecedor = fornecedor.OrderByDescending(u => u.cidade);
                    }
                    else
                    {
                        fornecedor = fornecedor.OrderBy(u => u.cidade);
                    }
                }
                if (query.ordenar.Equals("uf"))
                {
                    if (query.DESC)
                    {
                        fornecedor = fornecedor.OrderByDescending(u => u.uf);
                    }
                    else
                    {
                        fornecedor = fornecedor.OrderBy(u => u.uf);
                    }
                }
            }

            return await fornecedor.ToListAsync();
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
            fornecedorModel.logradouro = updateDto.logradouro;
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
