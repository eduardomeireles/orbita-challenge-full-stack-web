# Decisão da arquitetura Backend
O backend do projeto foi organizado em cinco camadas:

 - Models
 - Repositories
 - Controllers
 - Transfer Objects - TO
 - Migrations

## Camada de Models
  Na camada de Models, foram criadas as classes de entidade de alunos. Além disso, contém as interfaces para ter acesso ao banco de dados, via injeção de dependência, através do padrão **Repository**. 

## Camada de Repositories
  A camada de Repositories contém a classe de mapeamento do Entity Framework (classe DbContext), a classe abstrata de alunos e a classe concreta de alunos. Esta última, é onde são implementadas as regras de negócios da aplicação, herdando os seguintes métodos da classe abstrata: 
  
  - Get -> Retorna todos alunos cadastrados no sistema
  - Get(ra) -> Retorna somente o aluno correspondente ao RA que foi enviado na chamada do método.
  - Create -> Retorna TOResponse com campo 'true' ou 'false' dependendo se foi possível ou não adicionar o aluno na base de dados.
  - Update -> Retorna TOResponse com campo 'true' ou 'false' dependendo se foi possível ou não atualizar o aluno na base de dados.
  - Delete -> Retorna TOResponse com campo 'true' ou 'false' dependendo se foi possível ou não deletar o aluno na base de dados.
  
## Camada de Controllers
  A camada de Controllers contém o controlador do aluno, classe responsável por responder às solicitações feitas no frontend, retornando os dados da chamada junto com o status http.
  
## Camada de Transfer Objects
  A camada de Transfer Objects, ou DTO - Data Transfer Objects, encontra-se os objetos que serão enviados ao frontend com os dados de retorno da respectiva solicitação.

## Camada de Migrations
  A camada de Migrations possui a primeira versão do schema do banco de dados.
  

# Decisão da arquitetura Frontend
O backend do projeto foi organizado em cinco camadas:

 - Router
 - Services
 - Views

## Camada de Router
  A camada Router possui o caminho para diferentes telas da aplicação.

## Camada de Services
  A camada Router possui a classe StudentService, onde são feitas as requisições dos métodos para o backend.

## Camada de Views 
  A camada Views possui as pages da aplicação.

# Bibliotecas utilizadas
  - Entity Framework Core
  - Pomelo.EntityFrameworkCore.MySql

# Possíveis melhorias
- Backend
    - Classe para tratamento de exceções 
    - Classe de mensagem para retorno da validação das regras de negócio
    - Tornar a chave primária RA auto incremental no banco de dados e não solicitar a mesma ao criar novo aluno
    - Testes unitários
    - Testes de integração
    
- Frontend
    - Desenvolver um Design System para a aplicação, com padrão de classes CSS
    - Adiconar máscara no campo de CPF

# Requisitos obrigatórios não entregues
- Todos requisitos obrigatórios foram implementados.

