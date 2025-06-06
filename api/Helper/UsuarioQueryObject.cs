namespace api.Helper
{
    public class UsuarioQueryObject
    {
        // tipo? -> é opcional, não é de preenchimento obrigatorio

        public string? usuario { get; set; } = null;
        public string? nome { get; set; } = null;
        public int? nivel_acesso { get; set; } = null;
        public string? ordenar { get; set; } = null;
        public bool DESC { get; set; } = false;
        public int num_pag { get; set; } = 1; //pag atual -> começa em 1
        public int tam_pag { get; set; } = 2; // qnt de elemntos por pag
    } 
}
