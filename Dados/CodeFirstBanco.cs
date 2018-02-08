using System.Linq;
using autenticacaoefcookie.Models;

namespace autenticacaoefcookie.Dados
{
    public class CodeFirstBanco
    {
        public static void Inicializar(AutenticacaoContext contexto){
            contexto.Database.EnsureCreated();

           //acrescentei essa linha que não tinha no notepad
            if(contexto.Usuarios.Any()) return;

            //popular os dados
            var usuario = new Usuario(){
              Nome= "Sandro"  ,
              Email= "sandrounib@hotmail.com",
              Senha="123456"
            };

            contexto.Usuarios.Add(usuario);

            var permissao = new Permissao(){
                Nome = "Financeiro"
            };

            contexto.Permissoes.Add(permissao);
            
            var usuariopermissao = new UsuarioPermissao(){
                IdUsuario = usuario.IdUsuario,
                IdPermissao = permissao.IdPermissao
            };

            contexto.UsuariosPermissoes.Add(usuariopermissao);
            contexto.SaveChanges();


        }
    }
}