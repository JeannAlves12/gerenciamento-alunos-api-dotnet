namespace GerenciamentoAlunos.Domain.DTOs
{
    public class AlunoResponseDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string Curso { get; set; }
    }
}