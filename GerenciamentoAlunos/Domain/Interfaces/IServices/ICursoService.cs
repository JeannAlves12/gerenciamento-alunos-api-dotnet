using GerenciamentoAlunos.Domain.DTOs;
using GerenciamentoAlunos.Domain.Entities;

namespace GerenciamentoAlunos.Domain.Interfaces.IServices
{
    public interface ICursoService
    {
        List<Curso> GetAll();

        Curso GetById(Guid id);

        void Add(CursoDTO cursoDto);

        void Delete(Guid id);
    }
}