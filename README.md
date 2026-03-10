# Gerenciamento de Alunos API

API desenvolvida em **.NET** para gerenciamento de **Alunos e Cursos**, utilizando o padrão de arquitetura **Ports and Adapters (Arquitetura Hexagonal)**.

O objetivo do projeto é separar a lógica de negócio das tecnologias externas, garantindo um sistema desacoplado e organizado.

## Estrutura do Projeto

O projeto foi dividido em camadas:

- **API**  
  Contém os Controllers responsáveis por receber as requisições HTTP.

- **Domain**  
  Contém as entidades, interfaces e regras de negócio.

- **Data**  
  Contém as implementações dos repositórios e o contexto de dados.

## Regras de Negócio

As validações são feitas manualmente no `AlunoService`.

- O campo **FirstName** não pode ser vazio
- O **FirstName** deve ter no máximo **50 caracteres**
- O **Email** deve terminar com `@faculdade.edu`
- Não é permitido cadastrar dois alunos com o **mesmo email**

## Tecnologias Utilizadas

- .NET
- ASP.NET Core Web API
- Swagger
- C#

## Como Executar

1. Clonar o repositório
git clone https://github.com/seu-usuario/gerenciamento-alunos.git

2. Abrir o projeto no **Visual Studio**

3. Executar a aplicação

4. Acessar o Swagger:
https://localhost:xxxx/swagger


## Endpoints

### Alunos
- `GET /Aluno`
- `POST /Aluno`
- `PUT /Aluno/{id}`
- `DELETE /Aluno/{id}`

### Cursos
- `GET /Curso`
- `GET /Curso/{id}`
- `POST /Curso`
- `PUT /Curso/{id}`
- `DELETE /Curso/{id}`

---

Projeto desenvolvido para prática de **Arquitetura Hexagonal e APIs em .NET**.
