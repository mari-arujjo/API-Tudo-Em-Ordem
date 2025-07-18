using api.Fornecedor.Dtos;
using api.Fornecedor.Model;
using api.Fornecedor.Repository;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace api.Fornecedor.Controller
{
    [ApiController]
    [Route("api/fornecedor")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var fornecedores = await _fornecedorRepository.ObterTodosAsync();
            var fornecedoresDto = fornecedores.Select(f => f.ConverterParaFornecedorDto());
            return Ok(fornecedoresDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var fornecedores = await _fornecedorRepository.ObterPorIdAsync(id);
            if (fornecedores == null)
            {
                return NotFound();
            }

            return Ok(fornecedores.ConverterParaFornecedorDto());
        }

        [HttpPost]
        public async Task<IActionResult> NovoFornecedor([FromBody] CriarFornecedorDto dto)
        {
            var fornecedorModel = dto.CriarNovoForncedorDto();
            await _fornecedorRepository.CreateAsync(fornecedorModel);
            return CreatedAtAction(
                nameof(ObterPorId), 
                new { 
                    id = fornecedorModel.id_fornecedor 
                }, 
                fornecedorModel.ConverterParaFornecedorDto()
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarFornecedor([FromRoute] int id, [FromBody] AtualizarFornecedorDto updateDto)
        {
            var fornecedorModel = await _fornecedorRepository.UpdateAsync(id, updateDto);
            if (fornecedorModel == null)
            {
                return NotFound();
            }

            return Ok(fornecedorModel.ConverterParaFornecedorDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarFornecedor([FromRoute] int id)
        {
            var fornecedorModel = await _fornecedorRepository.DeleteAsync(id);
            if (fornecedorModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
