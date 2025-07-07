using System.Security.Cryptography;
using System.Text;

namespace api.Controllers
{
    public class HashSenhaController
    {
        public static string GerarHash(string senha)
        {
            using (SHA256 sha256Hash = SHA256.Create())  //cria uma instância do algoritmo SHA256
            {

                //primeiro onverte a senha para bytes usando codificação UTF8
                //depois aplica o SHA256 nesses bytes com o método ComputeHash, que retorna um array de bytes com o hash gerado
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                //StringBuilder converte os bytes para uma string final do hash (em formato hexadecimal)
                StringBuilder builder = new StringBuilder();

                //para cada byte do hash, ele converte para uma string hexadecimal com 2 dígitos (x2), como 0a, f3, 7b, etc. E 
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); //vai adicionando ao builder
                }

                //retorna a string final da senha no formatro HASH :)
                return builder.ToString();
            }

        }
    }
}
