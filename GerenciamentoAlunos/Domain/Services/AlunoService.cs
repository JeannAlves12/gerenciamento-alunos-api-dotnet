using GerenciamentoAlunos.Domain.DTOs;
using GerenciamentoAlunos.Domain.Entities;
using GerenciamentoAlunos.Domain.Interfaces.IRepositories;
using GerenciamentoAlunos.Domain.Interfaces.IServices;

namespace GerenciamentoAlunos.Domain.Services
{
    public class AlunoServices : IAlunoService
    {
        private readonly IAlunoRepository _repository;
        private readonly ICursoRepository _cursoRepository;

        public AlunoServices(IAlunoRepository repository, ICursoRepository cursoRepository)
        {
            _repository = repository;
            _cursoRepository = cursoRepository;
        }

        public List<AlunoResponseDTO> GetAll()
        {
            var alunos = _repository.GetAll();
            var cursos = _cursoRepository.GetAll();

            var resultado = alunos.Select(aluno =>
            {
                var curso = cursos.FirstOrDefault(c => c.Id == aluno.CursoId);

                return new AlunoResponseDTO
                {
                    Id = aluno.Id,
                    FirstName = aluno.FirstName,
                    Email = aluno.Email,
                    Curso = curso?.Nome
                };
            }).ToList();

            return resultado;
        }

        public Aluno GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Add(AlunoDTO dto)
        {
            // REGRA 1 - Presença
            if (string.IsNullOrWhiteSpace(dto.FirstName))
                throw new Exception("FirstName é obrigatório");

            // REGRA 2 - Extensão
            if (dto.FirstName.Length > 50)
                throw new Exception("FirstName deve ter no máximo 50 caracteres");

            // REGRA 3 - Domínio do Email
            if (!dto.Email.EndsWith("@faculdade.edu"))
                throw new Exception("O email deve terminar com @faculdade.edu");

            // REGRA 4 - Email único
            var alunoExistente = _repository.GetByEmail(dto.Email);

            if (alunoExistente != null)
                throw new Exception("Este email já está cadastrado");

            // REGRA EXTRA - Curso deve existir
            var curso = _cursoRepository.GetById(dto.CursoId);

            if (curso == null)
                throw new Exception("Curso não encontrado");

            var aluno = new Aluno
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                Email = dto.Email,
                CursoId = dto.CursoId
            };

            _repository.Add(aluno);
        }

        public void Delete(Guid id)
        {
            var aluno = _repository.GetById(id);

            if (aluno == null)
                throw new Exception("Aluno não encontrado");

            _repository.Delete(id);
        }

        public void Update(Guid id, AlunoDTO dto)
        {
            var aluno = _repository.GetById(id);

            if (aluno == null)
                throw new Exception("Aluno não encontrado");

            aluno.FirstName = dto.FirstName;
            aluno.Email = dto.Email;
            aluno.CursoId = dto.CursoId;

            _repository.Update(aluno);
        }
    }
}