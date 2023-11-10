# Documentação da API

## Introdução

A API foi desenvolvida para gerenciar o sistema de aluguel de livros em uma biblioteca. Oferece funcionalidades para operações CRUD relacionadas a pessoas, livros, cópias de livros e aluguéis. Além disso, implementa autenticação JWT para garantir a segurança das operações.

## Modelos de Dados

### Pessoa
- **Nome**: Nome completo da pessoa.
- **CPF**: Cadastro de Pessoa Física.
- **Data de Nascimento**: Data de nascimento da pessoa.
- **Endereço**: Endereço completo da pessoa.

### Livro
- **Título**: Título do livro.
- **Autor**: Autor do livro.
- **ISBN**: Número Padrão Internacional do Livro.

### Cópia do Livro
- **Código da Cópia**: Código único para a cópia do livro.
- **ID do Livro**: ID do livro associado.

### Aluguel
- **ID da Cópia do Livro**: ID da cópia do livro sendo alugada.
- **ID da Pessoa**: ID da pessoa que está alugando o livro.
- **Data de Aluguel**: Data em que o livro foi alugado.
- **Tipo de Operação**: 'S' para alugar, 'E' para devolver.
- **Está Atrasado?**: Indica se o livro foi devolvido com atraso.

### Usuário
- **Nome**: Nome do usuário.
- **Nome de Usuário**: Nome de usuário único.
- **Senha**: Senha do usuário.

## Regras de Aluguel

1. **Disponibilidade da Cópia do Livro:**
   - Ao realizar um aluguel (operação 'S'), a cópia do livro deve estar disponível.
   - Ao realizar uma devolução (operação 'E'), a cópia do livro não deve estar disponível, indicando que foi alugada anteriormente.

2. **Restrições para Devoluções:**
   - Não é possível devolver um livro que não foi previamente alugado.

3. **Atrasos nas Devoluções:**
   - Se a pessoa tiver mais de duas devoluções em atraso, ela não poderá realizar novos aluguéis.

## Funcionalidades

- **Pessoa**: Operações CRUD para gerenciar informações sobre pessoas.
- **Livro**: Operações CRUD para gerenciar informações sobre livros.
- **Cópia do Livro**: Operações CRUD para gerenciar informações sobre cópias de livros.
- **Aluguel**: Operações CRUD para gerenciar informações sobre aluguéis.

## Requisitos

- Persistência utilizando banco de dados relacional PostgreSQL.
- API RESTful com formato JSON.
- Autenticação JWT para garantir a segurança das operações.
- Listar o titulo dos 3 livros que mais tiveram atraso na devolução por mes durante o ano (mostrar todos os meses de um ano)
- Listar o titulo dos 3 livros mais alugados por cidade durante o ano (mostrar todos os meses de um ano)

# Endpoints da API

## **HealthController**

- `GET /api/Health`: Verifica o status da API.

## **BookController**

- `GET /api/Book`: Obtém todos os livros.
- `GET /api/Book/{id}`: Obtém um livro por ID.
- `POST /api/Book`: Cria um novo livro.
- `PUT /api/Book`: Atualiza as informações de um livro.
- `DELETE /api/Book/{id}`: Exclui um livro por ID.

## **CopyBookController**

- `GET /api/CopyBook`: Obtém todas as cópias de livros.
- `GET /api/CopyBook/{id}`: Obtém uma cópia de livro por ID.
- `POST /api/CopyBook`: Cria uma nova cópia de livro.
- `PUT /api/CopyBook`: Atualiza as informações de uma cópia de livro.
- `DELETE /api/CopyBook/{id}`: Exclui uma cópia de livro por ID.

## **PersonController**

- `GET /api/Person`: Obtém todas as pessoas.
- `GET /api/Person/{id}`: Obtém uma pessoa por ID.
- `POST /api/Person`: Cria uma nova pessoa.
- `PUT /api/Person`: Atualiza as informações de uma pessoa.
- `DELETE /api/Person/{id}`: Exclui uma pessoa por ID.

## **RentController**

- `GET /api/Rent`: Obtém todos os aluguéis.
- `GET /api/Rent/{id}`: Obtém um aluguel por ID.
- `POST /api/Rent`: Cria um novo aluguel.
- `PUT /api/Rent`: Atualiza as informações de um aluguel.
- `DELETE /api/Rent/{id}`: Exclui um aluguel por ID.

## **UserController**

- `POST /api/User/Register`: Registra um novo usuário.
- `POST /api/User/Login`: Realiza o login de um usuário.
- `PUT /api/User`: Atualiza as informações de um usuário.
- `GET /api/User`: Obtém as informações de um usuário.

## Exceções

- Todas as respostas de erro incluem mensagens explicativas para facilitar o entendimento do problema.