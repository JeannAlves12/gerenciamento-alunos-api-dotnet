using GerenciamentoAlunos.Domain.DTOs;
using GerenciamentoAlunos.Domain.Entities;

namespace GerenciamentoAlunos.Domain.Interfaces.IServices
{
    public interface IAlunoService
    {
        List<AlunoResponseDTO> GetAll();

        Aluno GetById(Guid id);

        void Add(AlunoDTO alunoDto);

        void Delete(Guid id);

        void Update(Guid id, AlunoDTO alunoDto);
    }
}
