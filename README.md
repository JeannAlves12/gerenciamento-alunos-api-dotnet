# Gerenciamento de Alunos API

🇬🇧 **Summary:** ASP.NET Core Web API to manage students and courses, built with Hexagonal Architecture (Ports and Adapters) to keep business rules decoupled from external technologies. Practice project.

🇧🇷 API em **.NET** para gerenciar **alunos e cursos**, usando **Arquitetura Hexagonal (Ports and Adapters)** para separar a lógica de negócio das tecnologias externas.

## Estrutura

| Camada | Responsabilidade |
|---|---|
| **API** | Controllers que recebem as requisições HTTP |
| **Domain** | Entidades, interfaces (portas) e regras de negócio |
| **Data** | Implementações dos repositórios e contexto de dados (adaptadores) |

## Regras de negócio

Validadas manualmente no `AlunoService`:

- `FirstName` não pode ser vazio
- `FirstName` com no máximo 50 caracteres
- `Email` deve terminar com `@faculdade.edu`
- Não é permitido cadastrar dois alunos com o mesmo e-mail

## Tecnologias

C#, .NET, ASP.NET Core Web API, Swagger

## Como executar

```bash
git clone https://github.com/JeannAlves12/gerenciamento-alunos-api-dotnet
```

1. Abra `GerenciamentoAlunos.slnx` no **Visual Studio**
2. Execute a aplicação
3. Acesse o Swagger: `https://localhost:<porta>/swagger`

## Endpoints

**Alunos:** `GET /Aluno` · `POST /Aluno` · `PUT /Aluno/{id}` · `DELETE /Aluno/{id}`

**Cursos:** `GET /Curso` · `GET /Curso/{id}` · `POST /Curso` · `PUT /Curso/{id}` · `DELETE /Curso/{id}`

## Objetivo

Projeto de estudo para praticar Arquitetura Hexagonal e construção de APIs em .NET.
