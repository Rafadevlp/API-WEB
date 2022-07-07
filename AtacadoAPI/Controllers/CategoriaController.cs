using AulaApp;
using AulaApp.FakeDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public CategoriaController() : base() 
        { }

        /// <summary>
        /// Lista todos os registros do recurso.
        /// </summary>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public List<Categoria> GetAll() 
        {
            return Estoque.Categorias;
        }

        /// <summary>
        /// Pesquisa o registro usando uma chave.
        /// </summary>
        /// <param name="id"> Chave de pesquisa. </param>
        /// <returns>Registro localizado.</returns>
        [HttpGet("{id:int}")]
        public Categoria GetByID(int id)
        {
            return Estoque.Categorias.SingleOrDefault(cat => cat.CategoriaId == id);
        }

        /// <summary>
        /// Pesquisa o registro usando o nome.
        /// </summary>
        /// <param name="nomeParcial"> Descrição parcial. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{nomeParcial}")]
        public List<Categoria> GetByName(string nomeParcial)
        {
            return Estoque.Categorias.Where(cat => cat.Descricao.StartsWith(nomeParcial)).ToList();
        }

        /// <summary>
        /// Inclui um novo dado no registro.
        /// </summary>
        /// <param name="dados"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public Categoria Post([FromBody] Categoria dados) 
        {
            int chave = Estoque.Categorias.Max(cat => cat.CategoriaId) + 1;
            dados.CategoriaId = chave;
            Estoque.Categorias.Add(dados);
            return dados;
        }


        /// <summary>
        /// Altera um dado existente no recurso.
        /// </summary>
        /// <param name="dados"> Altera o dado selecionado. </param>
        /// <returns> Dados alterado. </returns>
        [HttpPut]
        public Categoria Put([FromBody] Categoria dados)
        {
            int id = dados.CategoriaId;
            Categoria alt = Estoque.Categorias.SingleOrDefault(cat => cat.CategoriaId == id);
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
        public Categoria Delete([FromBody] Categoria dados)
        {
            int id = dados.CategoriaId;
            Categoria del = Estoque.Categorias.SingleOrDefault(cat => cat.CategoriaId == id); 
            if (del != null)
            {
                Estoque.Categorias.Remove(del);
            }
            return del;
        }
        
        /// <summary>
        /// Exclui um registro existente no recurso, utilizando um id.
        /// </summary>
        /// <param name="id">Chave para localização. </param>
        /// <returns> Dado excluido por Id.</returns>
        [HttpDelete("{id:int}")] 
        public Categoria DeleteById(int id)
        {
            Categoria del = Estoque.Categorias.SingleOrDefault(cat => cat.CategoriaId == id);
            if (del != null)
            {
                Estoque.Categorias.Remove(del);
            }
            return del;
        }
    }
}
