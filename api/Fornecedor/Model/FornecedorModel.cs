using System.ComponentModel.DataAnnotations;

namespace api.Fornecedor.Model
{
    public class FornecedorModel
    {
        [Key]
        public int id_fornecedor { get; set; }
        public String cnpj_fornecedor { get; set; } = string.Empty;
        public String razao_social { get; set; } = string.Empty;
        public String email { get; set; } = string.Empty;
        public String telefone { get; set; } = string.Empty;
        public String categoria { get; set; } = string.Empty;
        public String cep { get; set; } = string.Empty;
        public String logradouro { get; set; } = string.Empty;
        public int numero { get; set; }
        public String? complemento { get; set; }
        public String bairro { get; set; } = string.Empty;
        public String cidade { get; set; } = string.Empty;
        public String uf { get; set; } = string.Empty;
    }
}
