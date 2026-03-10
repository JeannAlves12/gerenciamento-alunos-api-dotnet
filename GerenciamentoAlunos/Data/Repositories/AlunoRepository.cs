using GerenciamentoAlunos.Data.Contexts;
using GerenciamentoAlunos.Domain.Entities;
using GerenciamentoAlunos.Domain.Interfaces.IRepositories;

namespace GerenciamentoAlunos.Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly DataContext _context;

        public AlunoRepository(DataContext context)
        {
            _context = context;
        }

        public List<Aluno> GetAll()
        {
            return _context.Alunos;
        }

        public Aluno GetById(Guid id)
        {
            return _context.Alunos.FirstOrDefault(a => a.Id == id);
        }

        public Aluno GetByEmail(string email)
        {
            return _context.Alunos.FirstOrDefault(a => a.Email == email);
        }

        public void Add(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
        }

        public void Delete(Guid id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
            }
        }

        public void Update(Aluno aluno)
        {
            var alunoExistente = _context.Alunos.FirstOrDefault(a => a.Id == aluno.Id);
            if (alunoExistente != null)
            {
                alunoExistente.FirstName = aluno.FirstName;
                alunoExistente.Email = aluno.Email;
                alunoExistente.CursoId = aluno.CursoId;
            }
        }
    }
}
