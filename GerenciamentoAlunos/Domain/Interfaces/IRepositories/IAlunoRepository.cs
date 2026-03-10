using GerenciamentoAlunos.Domain.Entities;

namespace GerenciamentoAlunos.Domain.Interfaces.IRepositories
{
    public interface IAlunoRepository
    {
        List<Aluno> GetAll();

        Aluno GetById(Guid id);

        Aluno GetByEmail(string email);

        void Add(Aluno aluno);
        void Delete(Guid id);
        void Update(Aluno aluno);
    }
}
