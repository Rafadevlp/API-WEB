using AulaApp;
using AulaApp.FakeDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : ControllerBase
    {
        public SubCategoriaController() : base() 
        { }

        /// <summary>
        /// Lista todos os registros do recurso.
        /// </summary>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public List<SubCategoria> GetAll() 
        {
            return Estoque.SubCategorias;
        }

        /// <summary>
        /// Pesquisa o registro usando uma chave.
        /// </summary>
        /// <param name="id"> Chave de pesquisa. </param>
        /// <returns>Registro localizado.</returns>
        [HttpGet("porid/{id:int}")] 
        public SubCategoria GetByID(int id)
        {
            return Estoque.SubCategorias.SingleOrDefault(sub => sub.SubCategoriaId == id);
        }

        /// <summary>
        /// Pesquisa o registro usando o nome.
        /// </summary>
        /// <param name="nomeParcial"> Descrição parcial. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("pornome/{nomeParcial}")] 
        public List<SubCategoria> GetByName(string nomeParcial)
        {
            return Estoque.SubCategorias.Where(sub => sub.Descricao.StartsWith(nomeParcial)).ToList();
        }

        /// <summary>
        /// Pesquisa o registro por Categoria.
        /// </summary>
        /// <param name="categoria"> Categoria a Localizar. </param>
        /// <returns> Registro por Categoria. </returns>
        [HttpGet("porcategoria/{categoria:int}")] 
        public List<SubCategoria> GetByCategoria(int categoria)
        {
            return Estoque.SubCategorias.Where(sub => sub.CategoriaId == categoria).ToList();
        }

        /// <summary>
        /// Inclui um novo dado no registro.
        /// </summary>
        /// <param name="dados"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public SubCategoria Post([FromBody] SubCategoria dados) 
        {
            int chave = Estoque.SubCategorias.Max(sub => sub.SubCategoriaId) + 1;
            dados.SubCategoriaId = chave;
            Estoque.SubCategorias.Add(dados);
            return dados;
        }

        /// <summary>
        /// Altera um dado existente no recurso.
        /// </summary>
        /// <param name="dados"> Altera o dado selecionado. </param>
        /// <returns> Dados alterado. </returns>
        [HttpPut]
        public SubCategoria Put([FromBody] SubCategoria dados) 
        {
            int id = dados.SubCategoriaId;
            SubCategoria alt = Estoque.SubCategorias.SingleOrDefault(sub => sub.SubCategoriaId == id);
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
        public SubCategoria Delete([FromBody] SubCategoria dados)
        {
            int id = dados.SubCategoriaId;
            SubCategoria del = Estoque.SubCategorias.SingleOrDefault(sub => sub.SubCategoriaId == id);
            if (del != null)
            {
                Estoque.SubCategorias.Remove(del);
            }
            return del;
        }

        /// <summary>
        /// Exclui um registro existente no recurso, utilizando um id.
        /// </summary>
        /// <param name="id">Chave para localização. </param>
        /// <returns> Dado excluido por Id.</returns>
        [HttpDelete("{id:int}")]
        public SubCategoria DeleteById(int id)
        {
            SubCategoria del = Estoque.SubCategorias.SingleOrDefault(sub => sub.SubCategoriaId == id);
            if (del != null)
            {
                Estoque.SubCategorias.Remove(del);
            }
            return del;
        }
    }
}