namespace api.Fornecedor.Helper
{
    public class FornecedorQueryObject
    {
        // tipo? -> é opcional, não é de preenchimento obrigatorio

        public string? cnpj_fornecedor { get; set; } = null;
        public string? razao_social { get; set; } = null;
        public string? email { get; set; } = null;
        public string? telefone { get; set; } = null;
        public string? categoria { get; set; } = null;
        public string? cep { get; set; } = null;
        public string? logradouro { get; set; } = null;
        public string? bairro { get; set; } = null;
        public string? cidade { get; set; } = null;
        public string? uf { get; set; } = null;
        public string? ordenar { get; set; } = null;
        public bool DESC { get; set; } = false;
        //public int num_pag { get; set; } = 1; //pag atual -> começa em 1
        //public int tam_pag { get; set; } = 5; // qnt de elemntos por pag
    }
}
