# Aplicação de Cadastro de Clientes - Projeto desenvolvido para a disciplina de PROGRAMAÇÃO WEB I	

## Descrição
Este projeto é uma aplicação web que permite o cadastro, listagem, atualização e exclusão de clientes para um supermercado. Os dados dos clientes são armazenados em um arquivo JSON. Além disso, a aplicação possui autenticação para garantir que apenas usuários autorizados possam acessá-la.

## Requisitos Obrigatórios
1. **Cadastro de Usuário:**
   - Crie uma página para cadastrar usuários.
   - A senha deve ser criptografada antes de ser armazenada.
   - Os usuários só podem editar seus próprios perfis.

2. **Persistência de Dados:**
   - Os dados dos clientes devem ser armazenados em um arquivo JSON.

3. **Linguagem de Programação:**
   - O sistema deve ser desenvolvido em uma linguagem de programação nativamente web. No seu caso, C# com ASP.NET MVC e Razor é uma ótima escolha.

4. **Operações CRUD:**
   - Implemente todas as operações CRUD (Create, Read, Update e Delete) para os clientes.

5. **Validações:**
   - Não permita cadastrar clientes com o mesmo CPF/CNPJ (Campo `CodigoFiscal`) ou Inscrição Estadual (Campo `InscricaoEstatudal`).
   - O usuário deve escolher uma cidade existente; não é permitido cadastrar novas cidades.

6. **Tela de Cadastro/Edição:**
   - A tela de inserção e atualização dos dados do cliente deve ser a mesma.
   - Inclua um botão para exportar o cadastro do cliente em formato JSON.

## Como Executar o Projeto
1. Clone o repositório para sua máquina local.
2. Abra o projeto no Visual Studio ou na sua IDE preferida.
3. Execute a aplicação.
4. Acesse a página de cadastro de usuários e crie um usuário.
5. Acesse a aplicação com o usuário criado e comece a cadastrar clientes!
