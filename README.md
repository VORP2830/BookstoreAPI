Criar um sistema de controle de aluguel livros em uma biblioteca.

Dados:
- um livro pode ter varias copias
- uma copia não pode estar com mais de uma pessoa ao mesmo tempo

Todos os campos são obrigatórios.
### Cadastro de Pessoa
- Nome
- CPF
- Data Nascimento
- Endereço completo

### Cadastro de Livro
- Titulo
- Autor
- ISBN
- Código da cópia

### Funcionalidades
- Pessoa: CRUD
- Livro: CRUD
- Copia: CRUD
- Controle de aluguel

### Requisitos
- Persistencia utlizando banco de dados relacional PostgreSQL.
- RESTful JSON
- Autenticacao JWT
- Listar o titulo dos 3 livros que mais tiveram atraso na devolução por mes durante o ano (mostrar todos os meses de um ano)
- Listar o titulo dos 3 livros mais alugados por cidade durante o ano (mostrar todos os meses de um ano)
- Se pessoa atrasou devolução mais de 2x ela não pode alugar mais