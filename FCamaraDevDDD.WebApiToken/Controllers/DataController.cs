using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using FCamaraDev.Entity;
using FCamaraDev.Repository.Repositories;
using FCamaraDev.Repository.Repositories.Interfaces;

namespace FCamaraDevDDD.WebApiToken.Controllers
{
    public class DataController : ApiController
    {
        private readonly IUnitOfWork<Produto> produtoUoWork;
        private readonly IRepository<Produto> produtoRepository;

        public DataController()
        {
            produtoUoWork = new UnitOfWork<Produto>();
            produtoRepository = produtoUoWork.TEntityRepository;
        }

        [Authorize]
        [HttpGet]
        [Route("api/data/getProdutos")]
        public IHttpActionResult GetProdutos()
        {
            var produtos = produtoRepository.ObterTodos().ToList();
            return Ok(produtos);
        }
    }
}
