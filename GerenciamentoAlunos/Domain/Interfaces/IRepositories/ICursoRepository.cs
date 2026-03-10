using GerenciamentoAlunos.Domain.Entities;

namespace GerenciamentoAlunos.Domain.Interfaces.IRepositories
{
    public interface ICursoRepository
    {
        List<Curso> GetAll();

        Curso GetById(Guid id);

        void Add(Curso curso);
        void Delete(Guid id);
    }
}