using api.AppUser.Model;
using api.Fornecedor.Model;
using api.Usuario.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace api

{
    //classe gigante que permite a pesquisa sua tabelas individuais
    //especifica qual tabela vai virar objeto com EntinyFramework
    public class ApplicationDBContext : IdentityDbContext<AppUser.Model.AppUser>
    {

        // CONSTRUTOR
        // DbContextOptions é um pacote de configurações — ele guarda coisas como qual banco usar string de conexão, log, cache, etc.
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions) //repassando dbContextOptions para a mãe
        {
            
        }


        //DbSet<T> representa uma tabela do banco de dados
        public DbSet<UsuarioModel> Usuarios { get; set; } //“Pesquisa no banco a tabela USERS que guarde objetos da entidade Usuario.”
        public DbSet<FornecedorModel> Fornecedores { get; set; }

    }
}
