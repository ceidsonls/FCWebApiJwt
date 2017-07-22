using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using FCamaraDev.Entity;
using FCamaraDev.Repository.Repositories;
using FCamaraDev.Repository.Repositories.Interfaces;
namespace FCamaraDevDDD.WebApiToken
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUnitOfWork<Usuario> usuarioUoWork;
        private readonly IRepository<Usuario> usuarioRepository;

        public MyAuthorizationServerProvider()
        {
            usuarioUoWork = new UnitOfWork<Usuario>();
            usuarioRepository = usuarioUoWork.TEntityRepository;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();//
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var usuario = usuarioRepository.ObterTodos().Where(p => p.Login == (context.UserName) && p.Senha.Equals(context.UserName)).FirstOrDefault();

            if (usuario != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, usuario.Login));
                identity.AddClaim(new Claim("username", usuario.Login));
                identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nome));
                context.Validated(identity);
            }
            else
            {
                context.SetError("ivalid_grant", "Usuário e/ou Senha incorreta.");
                return;
            }
        }
    }
}