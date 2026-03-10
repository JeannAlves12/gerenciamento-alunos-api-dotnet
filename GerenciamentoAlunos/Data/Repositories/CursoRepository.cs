using GerenciamentoAlunos.Data.Contexts;
using GerenciamentoAlunos.Domain.Entities;
using GerenciamentoAlunos.Domain.Interfaces.IRepositories;

namespace GerenciamentoAlunos.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly DataContext _context;

        public CursoRepository(DataContext context)
        {
            _context = context;
        }

        public List<Curso> GetAll()
        {
            return _context.Cursos;
        }

        public Curso GetById(Guid id)
        {
            return _context.Cursos.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Curso curso)
        {
            _context.Cursos.Add(curso);
        }

        public void Delete(Guid id)
        {
            var curso = _context.Cursos.FirstOrDefault(c => c.Id == id);

            if (curso != null)
                _context.Cursos.Remove(curso);
        }


    }
}