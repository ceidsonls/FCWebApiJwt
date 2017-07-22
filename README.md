# FCWebApiJwt
# Projeto 
Utilizando WebApi com o JWT para gerar Token que expira em 1 minuto, obter uma lista de produtos caso esteja autenticado e o token não tenha expirado.

#Sinopse 
O projeto consiste em um serviço REST com WebApi implementado com as seguintes considerações:
	 - Padrão jwt para geração e validação de token de acesso.
	 – O token expira em 1 minuto.
	 - Listagem de produtos, que só deve retorna se receber um token válido.
	 - Seed de criação do banco de dados e carga de dados, utilizando Entity Framework com Migrations.

#Exemplo de código

Através do package manager console do visual studio e definir o projeto FCamaraDev.Infra.Data pra e executar o comando  'Update-Database'.

No construtor do contexto informar a ConnectionString:
 public FCamaraContext()
            : base("FCamaraContext")
        {

        }

Configuração criada na classe 'Startup', configuração para o uso do token, complemento de URL  a ser utilizada, tempo que o mesmo irá expirar.
Método provedor a ser executado quando a URL do token é executada.

 var myProvider = new MyAuthorizationServerProvider();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(1),
                Provider = myProvider
            };

Na classe MyAuthorizationServerProvider o método GrantResourceOwnerCredentials
verifica o usuário e senha informado para assim gerar o token.

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
       
no Controller a action a ser executada, ' [Authorize]' quer dizer que precisa ter um token válido para executar,  [Route("api/data/getProdutos")] a rota para executa-lo(ex: http://localhost:56085/api/data/getProdutos).
    [Authorize]
        [HttpGet]
        [Route("api/data/getProdutos")]
        public IHttpActionResult GetProdutos()
        {
            var produtos = produtoRepository.ObterTodos().ToList();
            return Ok(produtos);
        }

#Instalação

Após baixar o projeto deve executar o comando 'Update-Database' no console para criaçao da base de dados.
executar a aplicação e verificar qual a URL foi gerada para ser utilizada na aplicaçao que irá consumir.
ex: http://localhost:56085/
com essa url pode ser gerado o token:
http://localhost:56085/token 
No Postman
POST
Hearders
Content-Type :application/x-www-form-urlencoded
Body
username : Admin
password : admin
grant_type : password

Executar outras ações com:
Ex: http://localhost:56085/api/data/getProdutos
GET
Headers
Authorization : bearer 'o valor do token gerado' 
#Referência 

http://www.developerhandbook.com/c-sharp/create-restful-api-authentication-using-web-api-jwt/
https://stackoverflow.com/questions/14301524/in-angular-how-to-redirect-with-location-path-as-http-post-success-callback

#Testes
Foi utilizado o plugin 'Postman' do GoogleChrome
