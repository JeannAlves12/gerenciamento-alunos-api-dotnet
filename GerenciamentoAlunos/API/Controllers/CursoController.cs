using GerenciamentoAlunos.Domain.DTOs;
using GerenciamentoAlunos.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoAlunos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _service;

        public CursoController(ICursoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cursos = _service.GetAll();
            return Ok(cursos);
        }

        [HttpPost]
        public IActionResult Post(CursoDTO dto)
        {
            _service.Add(dto);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var curso = _service.GetById(id);

            if (curso == null)
                return NotFound("Curso não encontrado");

            return Ok(curso);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Curso removido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}