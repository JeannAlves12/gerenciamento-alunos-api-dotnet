using GerenciamentoAlunos.Domain.Entities;

namespace GerenciamentoAlunos.Data.Contexts
{
    public class DataContext
    {
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public List<Curso> Cursos { get; set; } = new List<Curso>();
    }
}
