using GerenciamentoAlunos.Domain.DTOs;
using GerenciamentoAlunos.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoAlunos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;

        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()  
        {
            var alunos = _service.GetAll();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var aluno = _service.GetById(id);

            if (aluno == null)
                return NotFound("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(AlunoDTO dto)
        {
            try
            {
                _service.Add(dto);
                return Ok("Aluno criado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Aluno removido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, AlunoDTO dto)
        {
            try
            {
                _service.Update(id, dto);
                return Ok("Aluno atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}