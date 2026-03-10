using GerenciamentoAlunos.Domain.DTOs;
using GerenciamentoAlunos.Domain.Entities;
using GerenciamentoAlunos.Domain.Interfaces.IRepositories;
using GerenciamentoAlunos.Domain.Interfaces.IServices;

namespace GerenciamentoAlunos.Domain.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;

        public CursoService(ICursoRepository repository)
        {
            _repository = repository;
        }

        public List<Curso> GetAll()
        {
            return _repository.GetAll();
        }

        public Curso GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Add(CursoDTO cursoDto)
        {
            var curso = new Curso
            {
                Id = Guid.NewGuid(),
                Nome = cursoDto.NomeCurso
            };

            _repository.Add(curso);
        }

        public void Delete(Guid id)
        {
            var curso = _repository.GetById(id);

            if (curso == null)
                throw new Exception("Curso não encontrado");

            _repository.Delete(id);
        }
    }
}