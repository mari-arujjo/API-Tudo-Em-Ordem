using api.Fornecedor.Dtos;

namespace api.Fornecedor.Model
{
    public static class FornecedorMapper
    {
        public static FornecedorDto ConverterParaFornecedorDto(this FornecedorModel fornecedorModel)
        {
            return new FornecedorDto
            {
                id_fornecedor = fornecedorModel.id_fornecedor,
                cnpj_fornecedor = fornecedorModel.cnpj_fornecedor,
                razao_social = fornecedorModel.razao_social,
                email = fornecedorModel.email,
                telefone = fornecedorModel.telefone,
                categoria = fornecedorModel.categoria,
                cep = fornecedorModel.cep,
                rua = fornecedorModel.rua,
                numero = fornecedorModel.numero,    
                complemento = fornecedorModel.complemento,
                bairro = fornecedorModel.bairro,
                cidade = fornecedorModel.cidade,
                uf = fornecedorModel.uf
            };
        }

        public static FornecedorModel CriarNovoForncedorDto(this CriarFornecedorDto fornecedorDto)
        {
            return new FornecedorModel
            {
                cnpj_fornecedor = fornecedorDto.cnpj_fornecedor,
                razao_social = fornecedorDto.razao_social,
                email = fornecedorDto.email,
                telefone = fornecedorDto.telefone,
                categoria = fornecedorDto.categoria,
                cep = fornecedorDto.cep,
                rua = fornecedorDto.rua,
                numero = fornecedorDto.numero,
                complemento = fornecedorDto.complemento,
                bairro = fornecedorDto.bairro,
                cidade = fornecedorDto.cidade,
                uf = fornecedorDto.uf
            };
        }
    }
}
