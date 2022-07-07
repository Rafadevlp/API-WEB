using AulaApp;
using AulaApp.FakeDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public ProdutoController() : base() 
        { }
        /// <summary>
        /// Lista todos os registros do recurso.
        /// </summary>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public List<Produto> GetAll() 
        {
            return Estoque.Produtos;
        }

        /// <summary>
        /// Pesquisa o registro usando uma chave.
        /// </summary>
        /// <param name="id"> Chave de pesquisa. </param>
        /// <returns>Registro localizado.</returns>
        [HttpGet("porid/{id:int}")] 
        public Produto GetByID(int id)
        {
            return Estoque.Produtos.SingleOrDefault(pro => pro.ProdutoId == id);
        }

        /// <summary>
        /// Pesquisa o registro usando o nome.
        /// </summary>
        /// <param name="nomeParcial"> Descrição parcial. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("pornome/{nomeParcial}")] 
        public List<Produto> GetByName(string nomeParcial)
        {
            return Estoque.Produtos.Where(pro => pro.Descricao.StartsWith(nomeParcial)).ToList();
        }

        /// <summary>
        /// Pesquisa o registro por Categoria.
        /// </summary>
        /// <param name="cat"> Categoria a Localizar. </param>
        /// <returns> Registro por Categoria. </returns>
        [HttpGet("porcategoria/{cat:int}")] 
        public List<Produto> GetByCategoria(int cat)
        {
            return Estoque.Produtos.Where(pro => pro.CategoriaId == cat).ToList();
        }

        /// <summary>
        /// Pesquisa o registro por Subcategoria.
        /// </summary>
        /// <param name="sub"> Subcategoria a Localizar. </param>
        /// <returns> Registro por Subcategoria. </returns>
        [HttpGet("porsubcategoria/{sub:int}")]
        public List<Produto> GetBySubCategoria(int sub)
        {
            return Estoque.Produtos.Where(pro => pro.SubCategoriaId == sub).ToList();
        }

        /// <summary>
        /// Pesquisa o registro por Categoria e Subcategoria.
        /// </summary>
        /// <param name="cat"> Categoria a Localizar. </param>
        /// <param name="sub"> Subcategoria a Localizar. </param>
        /// <returns></returns>
        [HttpGet("porcategoria/{cat:int}/porsubcategoria/{sub:int}")] 
        public List<Produto> GetByCategoriaSubcategoria(int cat, int sub) 
        {
            return Estoque.Produtos
                .Where(pro => pro.CategoriaId == cat)   
                .Where(pro => pro.SubCategoriaId == sub) 
                .ToList();
        }

        /// <summary>
        /// Inclui um novo dado no registro.
        /// </summary>
        /// <param name="dados"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public Produto Post([FromBody] Produto dados)
        {
            int chave = Estoque.Produtos.Max(pro => pro.ProdutoId) + 1;
            dados.ProdutoId = chave;
            Estoque.Produtos.Add(dados);
            return dados;
        }

        /// <summary>
        /// Altera um dado existente no recurso.
        /// </summary>
        /// <param name="dados"> Altera o dado selecionado. </param>
        /// <returns> Dados alterado. </returns>
        [HttpPut]
        public Produto Put([FromBody] Produto dados)
        {
            int id = dados.ProdutoId;
            Produto alt = Estoque.Produtos.SingleOrDefault(pro => pro.ProdutoId == id);
            if (alt != null)
            {
                alt.Descricao = dados.Descricao;
                alt.DataDeInsercao = dados.DataDeInsercao;
            }
            return alt;
        }

        /// <summary>
        /// Exclui um registro existente.
        /// </summary>
        /// <param name="dados"> Dado que será deletado. </param>
        /// <returns> Exclui um dado. </returns>
        [HttpDelete]
        public Produto Delete([FromBody] Produto dados)
        {
            int id = dados.ProdutoId;
            Produto del = Estoque.Produtos.SingleOrDefault(pro => pro.ProdutoId == id);
            if (del != null)
            {
                Estoque.Produtos.Remove(del);
            }
            return del;
        }

        /// <summary>
        /// Exclui um registro existente no recurso, utilizando um id.
        /// </summary>
        /// <param name="id">Chave para localização. </param>
        /// <returns> Dado excluido por Id.</returns>
        [HttpDelete("{id:int}")]
        public Produto DeleteById(int id)
        {
            Produto del = Estoque.Produtos.SingleOrDefault(pro => pro.ProdutoId == id);
            if (del != null)
            {
                Estoque.Produtos.Remove(del);
            }
            return del;
        }
    }
}
