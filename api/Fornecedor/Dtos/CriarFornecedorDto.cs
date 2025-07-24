using System.ComponentModel.DataAnnotations;

namespace api.Fornecedor.Dtos
{
    public class CriarFornecedorDto
    {
        [Required]
        [MinLength(18, ErrorMessage = "O CNPJ deve ter 18 caracteres.")]
        [MaxLength(18, ErrorMessage = "Limite de caracteres: 18")]
        public String cnpj_fornecedor { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "A razão social deve ter no mínimo 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "Limite de caracteres: 50")]
        public String razao_social { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "O email deve ter no mínimo 10 caracteres.")]
        [MaxLength(100, ErrorMessage = "Limite de caracteres: 100")]
        public String email { get; set; } = string.Empty;

        [Required]
        [MinLength(15, ErrorMessage = "O n° de telefone deve ter 15 caracteres.")]
        [MaxLength(15, ErrorMessage = "Limite de caracteres: 15")]
        public String telefone { get; set; } = string.Empty;
        public String categoria { get; set; } = string.Empty;

        [Required]
        [MinLength(9, ErrorMessage = "O CEP deve ter 9 caracteres.")]
        [MaxLength(9, ErrorMessage = "Limite de caracteres: 9")]
        public String cep { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "O logradouro deve ter no mínimo 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "Limite de caracteres: 50")]
        public String logradouro { get; set; } = string.Empty;

        [Required]
        public int numero { get; set; }

        [ComplementoValidador]
        public String? complemento { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O bairro deve ter no mínimo 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "Limite de caracteres: 50")]
        public String bairro { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "A cidade deve ter no mínimo 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "Limite de caracteres: 50")]
        public String cidade { get; set; } = string.Empty;

        public String uf { get; set; } = string.Empty;
    }
}
