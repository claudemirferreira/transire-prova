using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using DataAccess.Repository;
using Domain.Model;
using Marvin.JsonPatch;
using Marvin.JsonPatch.Exceptions;
using TransireAPI.Attributes;
using TransireAPI.Common;
using TransireAPI.Models;

namespace TransireAPI.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Books api for getting/finding/adding/deleting library books.
    /// </summary>
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        private readonly IRepository<Produto> _repository;

        /// <inheritdoc />
        /// <summary>
        /// Default constructor. Requires books repository.
        /// </summary>
        /// <param name="repository"></param>
        public ProdutoController(IRepository<Produto> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns>Ok with all books.</returns>
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var lista = await _repository.GetAll();

            return Ok(lista.Select(x => x.ToModel()).ToList());
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns>Ok with all books.</returns>
        /// 
        /**/
        [Route("pesquisar"), ValidateModelState]
        public async Task<IHttpActionResult> PostPesquisar(ProdutoModel produto)
        {
            var lista = await _repository.ListarPorNome(produto.Nome);
            return Ok(lista.Select(x => x.ToModel()).ToList());
        }
        

        /// <summary>
        /// Get book for given book id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok with matching book OR NotFound.</returns>
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var produto = await _repository.GetById(id);

            if (produto == null)
                return NotFound();

            return Ok(produto.ToModel());
        }

        /// <summary>
        /// Add a book.
        /// </summary>
        /// <param name="produto"></param>
        /// <returns>Created status for successful post.</returns>
        [Route(""), ValidateModelState]
        public async Task<IHttpActionResult> Post(ProdutoModel produto)
        {
            if (produto.ProdutoID != null)
                return BadRequest("Cannot add book as it already has an id.");

            await _repository.InsertOrUpdate(ModelExtensions.ToEntity(produto));

            //return StatusCode(HttpStatusCode.Created);
            return Ok(produto);
        }

        /// <summary>
        /// Add a book.
        /// </summary>
        /// <param name="produto"></param>
        /// <returns>Created status for successful post.</returns>
        [Route("{id:int}"), ValidateModelState]
        public async Task<IHttpActionResult> Put(int id, ProdutoModel produto)
        {
            if (produto.ProdutoID == null)
                return BadRequest("Cannot update book as it no exists has an id.");

            await _repository.InsertOrUpdate(ModelExtensions.ToEntity(produto));

            //return StatusCode(HttpStatusCode.Created);
            return Ok(produto);
        }

        /// <summary>
        /// Update existing book.
        /// </summary>
        /// <param name="id">Id of book.</param>
        /// <param name="patch">JSON patch operations in body.</param>
        /// <returns>Ok with updated book.</returns>
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Patch(int id, JsonPatchDocument<ProdutoModel> patch)
        {
            var produto = await _repository.GetById(id);
            if (produto == null)
                return NotFound();

            try
            {
                var produtoModel = produto.ToModel();
                patch.ApplyTo(produtoModel);
                await _repository.InsertOrUpdate(produtoModel.ToEntity());

                return Ok(produtoModel);
            }
            catch (JsonPatchException exception)
            {
                return BadRequest($"An error occured whilst updating book. Status {exception.SuggestedStatusCode}. {exception.Message}.");
            }
        }

        /// <summary>
        /// Deletes book for given id.
        /// </summary>
        /// <param name="id">Book id.</param>
        /// <returns>No content status for successful deletion.</returns>
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var produto = await _repository.GetById(id);
            if (produto == null)
                return NotFound();

            await _repository.Delete(id);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}