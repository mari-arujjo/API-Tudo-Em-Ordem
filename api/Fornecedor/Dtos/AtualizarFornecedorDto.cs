using System.ComponentModel.DataAnnotations;

namespace api.Fornecedor.Dtos
{
    public class AtualizarFornecedorDto
    {
        [Required]
        [MinLength(18, ErrorMessage = "O CNPJ deve ter 18 caracteres. Digite no formato: XX.XXX.XXX/XXXX-XX")]
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
        [MinLength(13, ErrorMessage = "O n° de telefone deve ter 13 caracteres. Digite no formato: XX 9XXXX-XXXX")]
        [MaxLength(13, ErrorMessage = "Limite de caracteres: 13")]
        public String telefone { get; set; } = string.Empty;
        public String categoria { get; set; } = string.Empty;

        [Required]
        [MinLength(9, ErrorMessage = "0 CEP deve ter 9 caracteres. Digite no formato: XXXXX-XXX")]
        [MaxLength(9, ErrorMessage = "Limite de caracteres: 9")]
        public String cep { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "A rua deve ter no mínimo 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "Limite de caracteres: 50")]
        public String rua { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "O número deve ter no mínimo 1 caractere.")]
        [MaxLength(5, ErrorMessage = "Limite de caracteres: 5")]
        public int numero { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O complemento deve ter no mínimo 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "Limite de caracteres: 50")]
        public String? complemento { get; set; } = string.Empty;

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
