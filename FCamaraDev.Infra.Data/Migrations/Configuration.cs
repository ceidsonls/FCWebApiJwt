namespace FCamaraDev.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Entity;
    internal sealed class Configuration : DbMigrationsConfiguration<Contexto.FCamaraContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto.FCamaraContext context)
        {
            context.Produtos.AddOrUpdate(
                 new Produto { ProdutoId = 1, Codigo = "123456", Nome = "Notebook", Valor = 2000.1m, Disponivel = true },
                 new Produto { ProdutoId = 2, Codigo = "234567", Nome = "Mouse", Valor = 20.1m, Disponivel = true },
                 new Produto { ProdutoId = 3, Codigo = "345678", Nome = "Teclado", Valor = 35.1m, Disponivel = false },
                 new Produto { ProdutoId = 4, Codigo = "432353", Nome = "Microfone", Valor = 60.1m, Disponivel = true },
                 new Produto { ProdutoId = 5, Codigo = "654665", Nome = "HeadSet", Valor = 70.1m, Disponivel = true },
                 new Produto { ProdutoId = 6, Codigo = "878466", Nome = "Desktop", Valor = 1895.1m, Disponivel = false }
                           );
            context.Usuarios.AddOrUpdate(
                new Usuario { UsuarioId = 1, Login = "Admin", Senha = "admin", Nome = "Administrador", Ativo = true },
                new Usuario { UsuarioId = 2, Login = "Convidado", Senha = "convidado", Nome = "Convidado", Ativo = true },
                new Usuario { UsuarioId = 3, Login = "user", Senha = "user", Nome = "user", Ativo = true }
                           );
        }
    }
}
